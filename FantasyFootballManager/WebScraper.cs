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

        public static List<int> GetPlayerStats(string id)
        {
            var playerStats = new List<int>();
            var page = $"https://www.pro-football-reference.com/players/{id[0].ToString().ToUpper()}/{id}/gamelog/2021/";

            var web = new HtmlWeb();
            var doc = web.Load(page);

            var colNames = new List<string>() { "pass_yds", "pass_td", "rush_att", "rush_yds", "rush_td", "rec", "rec_yds", "rec_td" };
            var playerStatsTableDiv = doc.DocumentNode.SelectSingleNode("//div[contains(@id, 'div_stats')]");

            foreach (var name in colNames)
            {
                var statColList = playerStatsTableDiv.SelectNodes($".//td[contains(@data-stat, '{name}')]");
                if (statColList != null)
                {
                    playerStats.Add(Convert.ToInt32(statColList[ProjectControllerData.cWeek-1].InnerText));
                }
                else
                {
                    playerStats.Add(-1);
                }
            }
            var passCmpList = playerStatsTableDiv.SelectNodes($".//td[contains(@data-stat, 'pass_cmp')]");
            if (passCmpList != null)
            {
                playerStats.Add(Convert.ToInt32(passCmpList[ProjectControllerData.cWeek*2 - 2].InnerText));
            }
            else
            {
                playerStats.Add(-1);
            }

            return playerStats;
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
