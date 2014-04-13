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
        private List<MLBGame> all_games = new List<MLBGame>();
        private List<MLBGameInProgress> ongoing_games = new List<MLBGameInProgress>();
        private List<MLBGameFuture> future_games = new List<MLBGameFuture>();
        private List<MLBGameCompleted> completed_games = new List<MLBGameCompleted>();

        public List<MLBGame> AllGames
        {
            get { return all_games; }
        }

        public List<MLBGameCompleted> CompletedGames
        {
            get { return completed_games; }
        }

        public List<MLBGameInProgress> InProgressGames
        {
            get { return ongoing_games; }
        }

        public List<MLBGameFuture> FutureGames
        {
            get { return future_games; }
        }

        public MLBScoreboardOnDay(DateTime date)
        {
            try
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
                            all_games.Add(new MLBGameCompleted(game));
                            completed_games.Add(new MLBGameCompleted(game));
                            break;
                        case "Warmup":
                            all_games.Add(new MLBGameInProgress(game));
                            ongoing_games.Add(new MLBGameInProgress(game));
                            break;
                        case "Pre-game":
                            all_games.Add(new MLBGameInProgress(game));
                            ongoing_games.Add(new MLBGameInProgress(game));
                            break;
                        case "In Progress":
                            all_games.Add(new MLBGameInProgress(game));
                            ongoing_games.Add(new MLBGameInProgress(game));
                            break;
                        case "Preview":
                            all_games.Add(new MLBGameFuture(game));
                            future_games.Add(new MLBGameFuture(game));
                            break;
                    }
                }
            }
            catch (System.Net.WebException)
            {
            }
        }
    }
}