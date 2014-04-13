using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MLiB
{
    public class MLBGameFuture
    {
        private string park;
        private string id;
        private string data_dir;
        private MLBTeam away_team;
        private MLBTeam home_team;
        private MLBPitcher away_prob;
        private MLBPitcher home_prob;

        public MLBGameFuture(XElement game)
        {
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
        }
    }
}
