using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MLiB
{
    public class MLBGameFuture : MLBGame
    {
        private string park;
        private string id;
        private string data_dir;
        private MLBTeam away_team;
        private MLBTeam home_team;
        private MLBPitcher away_prob;
        private MLBPitcher home_prob;

        public MLBTeam AwayTeam
        {
            get { return away_team; }
        }

        public MLBTeam HomeTeam
        {
            get { return home_team; }
        }

        public MLBPitcher AwayProbableStarter
        {
            get { return away_prob; }
        }

        public MLBPitcher HomeProbableStarter
        {
            get { return home_prob; }
        }

        public MLBGameFuture(XElement game)
            : base(game)
        {
            float era;

            away_team = new MLBTeam(
               game.Attribute("away_team_city").Value,
               game.Attribute("away_team_name").Value,
               game.Attribute("away_division").Value,
               game.Attribute("away_league_id").Value,
               game.Attribute("away_games_back").Value,
               game.Attribute("away_games_back_wildcard").Value,
               Convert.ToInt32(game.Attribute("away_win").Value),
               Convert.ToInt32(game.Attribute("away_loss").Value)
               );

            home_team = new MLBTeam(
                game.Attribute("home_team_city").Value,
                game.Attribute("home_team_name").Value,
                game.Attribute("home_division").Value,
                game.Attribute("home_league_id").Value,
                game.Attribute("home_games_back").Value,
                game.Attribute("home_games_back_wildcard").Value,
                Convert.ToInt32(game.Attribute("home_win").Value),
                Convert.ToInt32(game.Attribute("home_loss").Value)
                );

            id = game.Attribute("id").Value;
            park = game.Attribute("venue").Value;

            data_dir = game.Attribute("game_data_directory").Value;

            if (game.Element("home_probable_pitcher").Attribute("id").Value == "")
            {
                home_prob = new MLBPitcher(
                    0,
                    "N/A",
                    "N/A",
                    0,
                    0,
                    0,
                    0);
            }
            else
            {
                if (game.Element("home_probable_pitcher").Attribute("era").Value == "-.--")
                    era = 0;
                else
                {
                    era = Convert.ToSingle(game.Element("home_probable_pitcher").Attribute("era").Value);

                    home_prob = new MLBPitcher(
                        Convert.ToInt32(game.Element("home_probable_pitcher").Attribute("id").Value),
                        game.Element("home_probable_pitcher").Attribute("last").Value,
                        game.Element("home_probable_pitcher").Attribute("first").Value,
                        Convert.ToInt32(game.Element("home_probable_pitcher").Attribute("number").Value),
                        era,
                        Convert.ToInt32(game.Element("home_probable_pitcher").Attribute("wins").Value),
                        Convert.ToInt32(game.Element("home_probable_pitcher").Attribute("losses").Value)
                        );
                }
            }

            if (game.Element("away_probable_pitcher").Attribute("id").Value == "")
            {
                away_prob = new MLBPitcher(
                    0,
                    "N/A",
                    "N/A",
                    0,
                    0,
                    0,
                    0);
            }
            else
            {
                if (game.Element("away_probable_pitcher").Attribute("era").Value == "-.--")
                    era = 0;
                else
                    era = Convert.ToSingle(game.Element("away_probable_pitcher").Attribute("era").Value);
                away_prob = new MLBPitcher(
                    Convert.ToInt32(game.Element("away_probable_pitcher").Attribute("id").Value),
                    game.Element("away_probable_pitcher").Attribute("last").Value,
                    game.Element("away_probable_pitcher").Attribute("first").Value,
                    Convert.ToInt32(game.Element("away_probable_pitcher").Attribute("number").Value),
                    era,
                    Convert.ToInt32(game.Element("away_probable_pitcher").Attribute("wins").Value),
                    Convert.ToInt32(game.Element("away_probable_pitcher").Attribute("losses").Value)
                    );
            }
        }
    }
}
