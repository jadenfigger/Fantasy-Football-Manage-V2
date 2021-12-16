using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectController
{
    public class SqlDataAccess
    {
        public static void CreateLeague()
        {
            var path = $"{ProjectControllerData.cLeague.LeagueName}.sqlite";
            if (!File.Exists(path))
            {
                SQLiteConnection.CreateFile(path);
            }
            else
            {
                MessageBox.Show("A League with the entered name already exists", "Invalid Entry", MessageBoxButtons.OK);
                return;
            }

            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString(path)))
            {
                cnn.Open();
                var command = new SQLiteCommand(@"CREATE TABLE LeagueInfomation (
                                                LeagueName    TEXT NOT NULL UNIQUE,
                                                NumOfTeams    INTEGER NOT NULL,
                                                EndWeek   INTEGER NOT NULL,
                                                CurrWeek INTEGER NOT NULL
                                                ); ", cnn);
                command.ExecuteNonQuery();

                var currWeek = ProjectControllerData.cLeague.CurrWeek;

                cnn.Execute("insert into LeagueInfomation (LeagueName, NumOfTeams, EndWeek, CurrWeek) values (@leagueName, @numOfTeams, @endWeek, @currWeek)",
                    new { ProjectControllerData.cLeague.LeagueName, ProjectControllerData.cLeague.NumOfTeams, ProjectControllerData.cLeague.EndWeek, currWeek });
                cnn.Close();
            }
        }

      

        public static void SaveCLeague()
        {
            ProjectControllerData.SavePlayerPointTotals();

            var path = $"{ProjectControllerData.cLeague.LeagueName}.sqlite";
            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString(path)))
            {
                cnn.Open();

                // Create tables for each team
                var temp = ProjectControllerData.cLeague.Teams;

                foreach (var team in ProjectControllerData.cLeague.Teams)
                {

                    var command = new SQLiteCommand($@"CREATE TABLE Team{ProjectControllerData.cLeague.Teams.IndexOf(team)} (
                                                TeamName TEXT NOT NULL,
                                                TotalPoints INTEGER NOT NULL,
                                                StartQB TEXT NOT NULL,
                                                BackupQB TEXT NOT NULL,
                                                StartRB TEXT NOT NULL,
                                                BackupRB TEXT NOT NULL,
                                                StartWR TEXT NOT NULL,
                                                BackupWR TEXT NOT NULL
                                                ); ", cnn);
                    command.ExecuteNonQuery();
                }
                cnn.Close();
            }

            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString(path)))
            {
                var temp = ProjectControllerData.cLeague;
                cnn.Open();
                foreach (var team in ProjectControllerData.cLeague.Teams)
                {
                    //int totPoints = 0;
                    //var SQB = team.PlayerHistory[ProjectControllerData.cWeek][0].ID.ToString();
                    //var BQB = team.PlayerHistory[ProjectControllerData.cWeek][1].ID.ToString();
                    //var SRB = team.PlayerHistory[ProjectControllerData.cWeek][2].ID.ToString();
                    //var BRB = team.PlayerHistory[ProjectControllerData.cWeek][3].ID.ToString();
                    //var SWR = team.PlayerHistory[ProjectControllerData.cWeek][4].ID.ToString();
                    //var BWR = team.PlayerHistory[ProjectControllerData.cWeek][5].ID.ToString();

                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("TeamName", team.TeamName, DbType.String, ParameterDirection.Input);
                    parameters.Add("TotalPoints", 0, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("StartQB", team.PlayerHistory[ProjectControllerData.cWeek][0].ID.ToString(), DbType.String, ParameterDirection.Input);
                    parameters.Add("BackupQB", team.PlayerHistory[ProjectControllerData.cWeek][1].ID.ToString(), DbType.String, ParameterDirection.Input);
                    parameters.Add("StartRB", team.PlayerHistory[ProjectControllerData.cWeek][2].ID.ToString(), DbType.String, ParameterDirection.Input);
                    parameters.Add("BackupRB", team.PlayerHistory[ProjectControllerData.cWeek][3].ID.ToString(), DbType.String, ParameterDirection.Input);
                    parameters.Add("StartWR", team.PlayerHistory[ProjectControllerData.cWeek][4].ID.ToString(), DbType.String, ParameterDirection.Input);
                    parameters.Add("BackupWR", team.PlayerHistory[ProjectControllerData.cWeek][5].ID.ToString(), DbType.String, ParameterDirection.Input);

                    cnn.Execute($"insert into Team{ProjectControllerData.cLeague.Teams.IndexOf(team)} values (@TeamName, @TotalPoints, @StartQB, @BackupQB, @StartRB, @BackupRB, @StartWR, @BackupWR)",
                        parameters);
                }
                cnn.Close();
            }
            ProjectControllerData.SaveSchedule();
        }

        public static void LoadLeague(string name) 
        {
            var path = $"{name}.sqlite";

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString(path)))
            {
                var leagueInfomation = cnn.Query($"select * from LeagueInfomation", new DynamicParameters()).ToList();

                ProjectControllerData.cLeague = new LeagueModel(leagueInfomation[0].LeagueName.ToString(), 
                              Convert.ToInt32(leagueInfomation[0].NumOfTeams), 
                              Convert.ToInt32(leagueInfomation[0].EndWeek), 
                              Convert.ToInt32(leagueInfomation[0].CurrWeek));
                
                for (var i = 0; i < ProjectControllerData.cLeague.NumOfTeams; i++)
                {
                    var teamInfo = cnn.Query($"select * from Team{i}", new DynamicParameters()).ToList();

                    var t = new TeamModel(teamInfo[0].TeamName);


                    t.PlayerHistory.Add(ProjectControllerData.cLeague.CurrWeek, new Dictionary<int, PlayerModel>());
                        
                    t.PlayerHistory[ProjectControllerData.cLeague.CurrWeek].Add(0, WebScraper.GetPlayerByID(teamInfo[0].StartQB));
                    t.PlayerHistory[ProjectControllerData.cLeague.CurrWeek].Add(1, WebScraper.GetPlayerByID(teamInfo[0].BackupQB));
                    t.PlayerHistory[ProjectControllerData.cLeague.CurrWeek].Add(2, WebScraper.GetPlayerByID(teamInfo[0].StartRB));
                    t.PlayerHistory[ProjectControllerData.cLeague.CurrWeek].Add(3, WebScraper.GetPlayerByID(teamInfo[0].BackupRB));
                    t.PlayerHistory[ProjectControllerData.cLeague.CurrWeek].Add(4, WebScraper.GetPlayerByID(teamInfo[0].StartWR));
                    t.PlayerHistory[ProjectControllerData.cLeague.CurrWeek].Add(5, WebScraper.GetPlayerByID(teamInfo[0].BackupWR));

                    ProjectControllerData.cLeague.Teams.Add(t);
                }
                ProjectControllerData.LoadSchedule();
                ProjectControllerData.ReadPlayerPointTotals();
            }
        }

        public static void AddUser(string firstName, string lastName, string username, string password)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString("Users")))
            {
                cnn.Execute("insert into Users (FirstName, LastName, Username, Password) values (@firstName, @lastName, @username, @password)", new { firstName, lastName, username, password });
            }
        }

        public static bool VendorExists(int vendorCode)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString("Vendors")))
            {
                var output = cnn.Query($"select * from Vendors where VendorCode=={vendorCode}", new DynamicParameters()).ToList();
                return output.Count >= 1 ? true : false;
            }
        }
        public static string LoadConnectionString(string p)
        {
            return $"Data Source={p};Version=3;";
        }
    }
}
