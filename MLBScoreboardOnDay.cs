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
                 XDocument mlb_xml = XDocument.Load("http://gd2.mlb.com/components/game/mlb/year_"
                    + date.Year + "/month_" + (date.Month <= 9 ? "0" : "")
                    + date.Month + "/day_" + (date.Day <= 9 ? "0" : "")
                    + date.Day + "/master_scoreboard.xml");

                XElement game_element = mlb_xml.Element("games");

                IEnumerable<XElement> todays_games = game_element.Elements("game");

                foreach (XElement game in todays_games)
                {
                    switch (game.Element("status").Attribute("status").Value)
                    {
                        case "Final":
                            completed_games.Add(new MLBGameCompleted(game));
                            break;
                        case "Game Over":
                            completed_games.Add(new MLBGameCompleted(game));
                            break;
                        case "Warmup":
                            ongoing_games.Add(new MLBGameInProgress(game));
                            break;
                        case "Pre-Game":
                            ongoing_games.Add(new MLBGameInProgress(game));
                            break;
                        case "In Progress":
                            ongoing_games.Add(new MLBGameInProgress(game));
                            break;
                        case "Preview":
                            future_games.Add(new MLBGameFuture(game));
                            break;
                        case "Delayed":
                            ongoing_games.Add(new MLBGameInProgress(game));
                            break;
                        case "Manager Challenge":
                            ongoing_games.Add(new MLBGameInProgress(game));
                            break;
                        default:
                            // uncomment to see console output of any games that aren't added
                            // to the games list; usually postponed/delayed games
                        //Console.Write(game.Element("status").Attribute("status").Value);
                            break;
                    }
                }

                foreach (MLBGameInProgress game in ongoing_games)
                {
                    all_games.Add(game);
                }
                foreach (MLBGameFuture game in future_games)
                {
                    all_games.Add(game);
                }
                foreach (MLBGameCompleted game in completed_games)
                {
                    all_games.Add(game);
                }
            }
            catch (System.Net.WebException)
            {
            }
        }
    }
}