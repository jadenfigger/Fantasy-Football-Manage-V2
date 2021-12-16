using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjectController
{
    public class ProjectControllerData
    {
        public static LeagueModel cLeague = null;
        public static int cTeam = 0;
        public static int cWeek = 1;
        public static int cPos;

        public bool ProgressSaved = false;


        public static string scheduleFilePath = "schedule.dat";
        public static BinaryFormatter formatter;

        public static void SavePlayerPointTotals()
        {
            // Gain code access to the file that we are going
            // to write to
            scheduleFilePath = $"{cLeague.LeagueName}-ppt.dat";
            formatter = new BinaryFormatter();
            var totals = new List<Dictionary<int, List<double>>>();
            foreach (var team in cLeague.Teams)
            {
                totals.Add(team.PlayerTotals);
            }
            try
            {
                // Create a FileStream that will write data to file.
                FileStream writerFileStream =
                    new FileStream(scheduleFilePath, FileMode.Create, FileAccess.Write);
                // Save our dictionary of friends to file
                formatter.Serialize(writerFileStream, totals);

                // Close the writerFileStream when we are done.
                writerFileStream.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to save our friends' information");
            } // end try-catch
        }

        public static void ReadPlayerPointTotals()
        {
            scheduleFilePath = $"{cLeague.LeagueName}-ppt.dat";
            formatter = new BinaryFormatter();

            
            List<Dictionary<int, List<double>>> totals;
            // Check if we had previously Save information of our friends
            // previously
            if (File.Exists(scheduleFilePath))
            {

                try
                {
                    // Create a FileStream will gain read access to the 
                    // data file.
                    FileStream readerFileStream = new FileStream(scheduleFilePath,
                        FileMode.Open, FileAccess.Read);
                    // Reconstruct information of our friends from file.
                    totals = (List<Dictionary<int, List<double>>>)formatter.Deserialize(readerFileStream);
                    // Close the readerFileStream when we are done
                    readerFileStream.Close();

                    for (var i = 0; i < cLeague.Teams.Count; i++)
                    {
                        cLeague.Teams[i].PlayerTotals = totals[i];
                    }

                }
                catch (Exception)
                {
                    Console.WriteLine("There seems to be a file that contains " +
                        "friends information but somehow there is a problem " +
                        "with reading it.");
                } // end try-catch

            } // end if

        }
        public static double CalculatePointTotal(List<int> stats)
        {
            double tot = 0;
            bool notAllN1 = false;

            //"pass_yds", "pass_td", "rush_att", "rush_yds", "rush_td", "rec", "rec_yds", "rec_td", "pass_cmp"
            if (stats[0] != -1 && stats[0] != 0)
            {
                notAllN1 = true;
                tot += stats[0] / cLeague.PointCalculationVariables[3];
                if (Convert.ToDouble(stats[0]) >= cLeague.PointCalculationVariables[0])
                {
                    tot += 5;
                }
            }
            if (stats[1] != -1 && stats[1] != 0)
            {
                notAllN1 = true;
                tot += stats[1] * cLeague.PointCalculationVariables[4];
            }
            if (stats[2] != -1 && stats[2] != 0)
            {
                notAllN1 = true;
                tot += stats[2] * cLeague.PointCalculationVariables[7];
            }
            if (stats[3] != -1 && stats[3] != 0)
            {
                notAllN1 = true;
                tot += stats[3] / cLeague.PointCalculationVariables[6];
                if (Convert.ToDouble(stats[3]) >= cLeague.PointCalculationVariables[1])
                {
                    tot += 5;
                }
            }
            if (stats[4] != -1 && stats[4] != 0)
            {
                notAllN1 = true;
                tot += stats[4] * cLeague.PointCalculationVariables[8];
            }
            if (stats[5] != -1 && stats[5] != 0)
            {
                notAllN1 = true;
                tot += stats[5] * cLeague.PointCalculationVariables[9];
            }
            if (stats[6] != -1 && stats[6] != 0)
            {
                notAllN1 = true;
                tot += stats[6] / cLeague.PointCalculationVariables[10];
                if (Convert.ToDouble(stats[6]) >= cLeague.PointCalculationVariables[2])
                {
                    tot += 5;
                }
            }
            if (stats[7] != -1 && stats[7] != 0)
            {
                notAllN1 = true;
                tot += stats[7] * cLeague.PointCalculationVariables[11];
            }
            if (stats[8] != -1 && stats[8] != 0)
            {
                notAllN1 = true;
                tot += stats[8] * cLeague.PointCalculationVariables[5];
            }
            if (notAllN1 == false)
            {
                return -1;
            }
            return Math.Round(tot, 2);
        }

        public static string[] FindAllLeagues()
        {
            return Directory.GetFiles("./", "*.sqlite");
        }

        public static void SaveSchedule()
        {
            // Gain code access to the file that we are going
            // to write to
            scheduleFilePath = $"{cLeague.LeagueName}-schedule.dat";
            formatter = new BinaryFormatter();
            try
            {
                // Create a FileStream that will write data to file.
                FileStream writerFileStream =
                    new FileStream(scheduleFilePath, FileMode.Create, FileAccess.Write);
                // Save our dictionary of friends to file
                formatter.Serialize(writerFileStream, cLeague.Schedule);

                // Close the writerFileStream when we are done.
                writerFileStream.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to save our friends' information");
            } // end try-catch
        } // end public bool Load()

        public static void LoadSchedule()
        {
            scheduleFilePath = $"{cLeague.LeagueName}-schedule.dat";
            formatter = new BinaryFormatter();
            // Check if we had previously Save information of our friends
            // previously
            if (File.Exists(scheduleFilePath))
            {
                try
                {
                    // Create a FileStream will gain read access to the 
                    // data file.
                    FileStream readerFileStream = new FileStream(scheduleFilePath,
                        FileMode.Open, FileAccess.Read);
                    // Reconstruct information of our friends from file.
                    cLeague.Schedule = (Dictionary<int, List<List<string>>>)formatter.Deserialize(readerFileStream);
                    // Close the readerFileStream when we are done
                    readerFileStream.Close();
                }
                catch (Exception)
                {
                    Console.WriteLine("There seems to be a file that contains " +
                        "friends information but somehow there is a problem " +
                        "with reading it.");
                } // end try-catch

            } // end if

        } // end public bool Load()

    }

}
