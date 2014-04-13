using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MLiB
{
    public class MLBGameCompleted : MLBGame
    {
        private MLBTeamCompleted away_team;
        private MLBTeamCompleted home_team;
        private List<MLBInning> innings = new List<MLBInning>();
        private MLBPitcher winner;
        private MLBPitcher loser;
        private MLBPitcherClosing closer;

        public bool Saved
        {
            get { return (closer != null); }
        }

        public MLBPitcher WinningPitcher
        {
            get { return winner; }
        }

        public MLBPitcher LosingPitcher
        {
            get { return loser; }
        }

        public MLBPitcherClosing SavePitcher
        {
            get { return closer; }
        }

        public MLBTeamCompleted AwayTeam
        {
            get { return away_team; }
        }

        public MLBTeamCompleted HomeTeam
        {
            get { return home_team; }
        }

        public List<MLBInning> Innings
        {
            get { return innings; }
        }

        public MLBGameCompleted(XElement game)
            : base(game)
        {
            int aruns, ahits, aerrors, asb, ahr;
            int hruns, hhits, herrors, hsb, hhr;
            bool away_won;

            IEnumerable<XElement> i_innings = game.Element("linescore").Elements("inning");

            winner = new MLBPitcher(
                Convert.ToInt32(game.Element("winning_pitcher").Attribute("id").Value),
                game.Element("winning_pitcher").Attribute("last").Value,
                game.Element("winning_pitcher").Attribute("first").Value,
                Convert.ToInt32(game.Element("winning_pitcher").Attribute("number").Value),
                Convert.ToSingle(game.Element("winning_pitcher").Attribute("era").Value),
                Convert.ToInt32(game.Element("winning_pitcher").Attribute("wins").Value),
                Convert.ToInt32(game.Element("winning_pitcher").Attribute("losses").Value));
            
            loser = new MLBPitcher(
                Convert.ToInt32(game.Element("losing_pitcher").Attribute("id").Value),
                game.Element("losing_pitcher").Attribute("last").Value,
                game.Element("losing_pitcher").Attribute("first").Value,
                Convert.ToInt32(game.Element("losing_pitcher").Attribute("number").Value),
                Convert.ToSingle(game.Element("losing_pitcher").Attribute("era").Value),
                Convert.ToInt32(game.Element("losing_pitcher").Attribute("wins").Value),
                Convert.ToInt32(game.Element("losing_pitcher").Attribute("losses").Value));

            if (game.Element("save_pitcher").Attribute("id").Value != "")
                closer = new MLBPitcherClosing(
                    Convert.ToInt32(game.Element("save_pitcher").Attribute("id").Value),
                    game.Element("save_pitcher").Attribute("last").Value,
                    game.Element("save_pitcher").Attribute("first").Value,
                    Convert.ToInt32(game.Element("save_pitcher").Attribute("number").Value),
                    Convert.ToSingle(game.Element("save_pitcher").Attribute("era").Value),
                    Convert.ToInt32(game.Element("save_pitcher").Attribute("saves").Value),
                    Convert.ToInt32(game.Element("save_pitcher").Attribute("svo").Value),
                    Convert.ToInt32(game.Element("losing_pitcher").Attribute("wins").Value),
                    Convert.ToInt32(game.Element("losing_pitcher").Attribute("losses").Value));

            foreach (XElement inning in i_innings)
            {
                if(inning.Attribute("home") != null)
                    innings.Add(new MLBInning(inning.Attribute("away").Value, inning.Attribute("home").Value));
                else
                    innings.Add(new MLBInning(inning.Attribute("away").Value, ""));
            }

            aruns = Convert.ToInt32(game.Element("linescore").Element("r").Attribute("away").Value);
            ahits = Convert.ToInt32(game.Element("linescore").Element("h").Attribute("away").Value);
            aerrors = Convert.ToInt32(game.Element("linescore").Element("e").Attribute("away").Value);
            asb = Convert.ToInt32(game.Element("linescore").Element("sb").Attribute("away").Value);
            ahr = Convert.ToInt32(game.Element("linescore").Element("hr").Attribute("away").Value);

            hruns = Convert.ToInt32(game.Element("linescore").Element("r").Attribute("home").Value);
            hhits = Convert.ToInt32(game.Element("linescore").Element("h").Attribute("home").Value);
            herrors = Convert.ToInt32(game.Element("linescore").Element("e").Attribute("home").Value);
            hsb = Convert.ToInt32(game.Element("linescore").Element("sb").Attribute("home").Value);
            hhr = Convert.ToInt32(game.Element("linescore").Element("hr").Attribute("home").Value);

            away_won = (aruns > hruns);

                away_team = new MLBTeamCompleted(
                game.Attribute("away_team_city").Value,
                game.Attribute("away_team_name").Value,
                game.Attribute("away_division").Value,
                game.Attribute("away_league_id").Value,
                game.Attribute("away_games_back").Value,
                game.Attribute("away_games_back_wildcard").Value,
                Convert.ToInt32(game.Attribute("away_win").Value),
                Convert.ToInt32(game.Attribute("away_loss").Value),
                aruns,
                ahits,
                aerrors,
                ahr,
                asb,
                away_won
                );

                home_team = new MLBTeamCompleted(
                    game.Attribute("home_team_city").Value,
                    game.Attribute("home_team_name").Value,
                    game.Attribute("home_division").Value,
                    game.Attribute("home_league_id").Value,
                    game.Attribute("home_games_back").Value,
                    game.Attribute("home_games_back_wildcard").Value,
                    Convert.ToInt32(game.Attribute("home_win").Value),
                    Convert.ToInt32(game.Attribute("home_loss").Value),
                    hruns,
                    hhits,
                    herrors,
                    hhr,
                    hsb,
                    !away_won
                    );
        }
    }
}
