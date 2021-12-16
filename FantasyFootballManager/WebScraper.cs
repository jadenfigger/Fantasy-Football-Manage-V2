using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ProjectController
{
    public class WebScraper
    {

        public static int GetCurrentWeek()
        {
            return 2;

            var page = "nfl.com/schedules/";

            var web = new HtmlWeb();
            var doc = web.Load(page);

            var title = doc.DocumentNode.SelectSingleNode("//h2[contains(@class, 'nfl-c-content-header__roofline')]").InnerText;
            return Convert.ToInt32(title.Split(' ')[3]);
        }

        public static List<int> GetPlayerStats(string id, int w)
        {
            var playerStats = new List<int>();
            var page = $"https://www.pro-football-reference.com/players/{id[0].ToString().ToUpper()}/{id}/gamelog/2021/";

            var web = new HtmlWeb();
            var doc = web.Load(page);

            var colNames = new List<string>() { "pass_td", "rush_att", "rush_yds", "rush_td", "rec", "rec_yds", "rec_td" };
            var playerStatsTableDiv = doc.DocumentNode.SelectSingleNode("//div[contains(@id, 'div_stats')]");

            var weeks = playerStatsTableDiv.SelectNodes(".//td[contains(@data-stat, 'week_num')]");
            var t = false;
            foreach (var week in weeks)
            {
                try
                {
                    if (Convert.ToInt32(week.InnerText) == w)
                    {
                        t = true;
                    }
                }
                catch { }
            }
            if (!t)
            {
                for (var i = 0; i < 9; i++) playerStats.Add(-1);
                return playerStats;
            }

            var passYdsList = playerStatsTableDiv.SelectNodes($".//td[contains(@data-stat, 'pass_yds')]");
            if (passYdsList != null)
            {
                var temp = passYdsList[w * 2 - 2].InnerText;
                playerStats.Add(Convert.ToInt32(passYdsList[w * 2 - 2].InnerText));
            }
            else
            {
                playerStats.Add(-1);
            }
            foreach (var name in colNames)
            {
                var statColList = playerStatsTableDiv.SelectNodes($".//td[contains(@data-stat, '{name}')]");
                if (statColList != null)
                {
                    try
                    {
                        playerStats.Add(Convert.ToInt32(statColList[w - 1].InnerText));
                    }
                    catch
                    {
                        playerStats.Add(-1);
                    }
                }
                else
                {
                    playerStats.Add(-1);
                }
            }
            var passCmpList = playerStatsTableDiv.SelectNodes($".//td[contains(@data-stat, 'pass_cmp')]");
            if (passCmpList != null)
            {
                playerStats.Add(Convert.ToInt32(passCmpList[w * 2 - 2].InnerText));
            }
            else
            {
                playerStats.Add(-1);
            }

            return playerStats;
        }

        public static PlayerModel GetPlayerByID(string id)
        {
            var page = $"https://www.pro-football-reference.com/players/{id[0].ToString().ToUpper()}/{id}.htm";

            // Creating a connection with the web page
            var web = new HtmlWeb();
            var doc = web.Load(page);

            var infoDiv = doc.DocumentNode.SelectSingleNode("//div[contains(@itemtype, 'https://schema.org/Person')]");

            var playerName = infoDiv.SelectSingleNode(".//h1[contains(@itemprop, 'name')]").InnerText.Replace("\n", String.Empty).Replace("\t", String.Empty);
            
            return new PlayerModel(playerName, null, null, id);
        }

        public static List<List<string>> FindPlayersByName(string name)
        {
            var players = new List<List<string>>();
            var nameSplit = name.Split(' ');
            if (nameSplit.Length > 1)
            {
                name = string.Join("+", nameSplit);
            }
            var page = $"https://www.pro-football-reference.com/search/search.fcgi?hint={name}&search={name}";

            // Creating a connection with the web page
            var web = new HtmlWeb();
            var doc = web.Load(page);

            var allPlayers = doc.DocumentNode.SelectNodes("//div[contains(@class, 'search-item')]");
            if (allPlayers == null)
            {
                return null;
            }

            foreach (var player in allPlayers)
            {
                var playerNameNode = player.SelectSingleNode(".//a");
                if (playerNameNode == null)
                {
                    continue;
                }
                var playerName = HttpUtility.HtmlDecode(playerNameNode.InnerText);
                var playerTeamNode = player.SelectSingleNode(".//em");
                if (playerTeamNode == null)
                {
                    continue;
                }
                var playerTeam = HttpUtility.HtmlDecode(playerTeamNode.InnerText).Split(',').Last().Replace(" ", String.Empty);
                var yearsPlayed = player.SelectSingleNode(".//div[contains(@class, 'search-item-name')]").InnerText.Replace("\n                ", String.Empty).Replace("\n", String.Empty).Split('(')[1].Replace(")", String.Empty).Replace("Pro Bowl", String.Empty);

                if (!yearsPlayed.Contains("2021"))
                {
                    continue;
                }
                var playerID = player.SelectSingleNode(".//a").Attributes["href"].Value.Split('/')[3].Split('.')[0];

                players.Add(new List<string> { playerName, playerTeam, playerID, yearsPlayed });
            }

            return players;
        }
    }
}
