using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MLiB
{
    public class MLBScoreboardOnDay
    {
        private List<MLBInProgressGame> ongoing_games = new List<MLBInProgressGame>();
        private List<MLBFutureGame> future_games = new List<MLBFutureGame>();
        private List<MLBCompletedGame> completed_games = new List<MLBCompletedGame>();

        public List<MLBCompletedGame> CompletedGames
        {
            get { return completed_games; }
        }

        public List<MLBInProgressGame> InProgressGames
        {
            get { return ongoing_games; }
        }

        public List<MLBFutureGame> FutureGames
        {
            get { return future_games; }
        }

        public MLBScoreboardOnDay(DateTime date)
        {
            IEnumerable<XElement> todays_games = XDocument.Load("http://gd2.mlb.com/components/game/mlb/year_"
                + date.Year + "/month_" + (date.Month <= 9 ? "0" : "")
                + date.Month + "/day_" + (date.Day <= 9 ? "0" : "")
                + date.Day + "/master_scoreboard.xml").Element("games").Elements("game");

            foreach (XElement game in todays_games)
            {
                switch (game.Element("status").Attribute("status").Value)
                {
                    case "Final":
                        completed_games.Add(new MLBCompletedGame(game));
                        break;
                    case "Warmup":
                        ongoing_games.Add(new MLBInProgressGame(game));
                        break;
                    case "Pre-game":
                        ongoing_games.Add(new MLBInProgressGame(game));
                        break;
                    case "In Progress":
                        ongoing_games.Add(new MLBInProgressGame(game));
                        break;
                    case "Preview":
                        future_games.Add(new MLBFutureGame(game));
                        break;
                }
            }
        }
    }
}
