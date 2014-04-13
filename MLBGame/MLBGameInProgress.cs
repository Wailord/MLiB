using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace MLiB
{
    public class MLBGameInProgress : MLBGame
    {
        private string park;
        private string id;
        private string last_play;
        private MLBPitcher cur_pitcher;
        private MLBBatter cur_batter;
        private MLBTeamActive away_team;
        private MLBTeamActive home_team;
        private List<MLBInning> innings = new List<MLBInning>();
        private BaseSituations base_situation;
        private string inning_half;

        public string HalfInning
        {
            get { return inning_half; }
        }

        public enum BaseSituations
        {
            BasesEmpty = 0, RunnerOnFirst, RunnersOnFirstAndSecond, RunnersOnFirstAndThird,
            BasesLoaded, RunnerOnSecond, RunnersOnSecondAndThird, RunnerOnThird
        }

        public BaseSituations BaseSituation
        {
            get { return base_situation; }
        }

        public string LastPlay
        {
            get { return last_play; }
        }

        public MLBPitcher NowPitching
        {
            get { return cur_pitcher; }
        }

        public MLBBatter NowBatting
        {
            get { return cur_batter; }
        }

        public MLBTeamActive AwayTeam
        {
            get { return away_team; }
        }

        public MLBTeamActive HomeTeam
        {
            get { return home_team; }
        }

        public List<MLBInning> Innings
        {
            get { return innings; }
        }

        public MLBGameInProgress(XElement game) : 
            base(game)
        {
            int runs, hits, errors, sb, hr;

            IEnumerable<XElement> i_innings = game.Element("linescore").Elements("inning");

            foreach (XElement inning in i_innings)
            {
                if (inning.Attribute("home") != null)
                    innings.Add(new MLBInning(inning.Attribute("away").Value, inning.Attribute("home").Value));
                else
                    innings.Add(new MLBInning(inning.Attribute("away").Value, ""));
            }

            inning_half = game.Element("status").Attribute("inning_state").Value;

            runs = Convert.ToInt32(game.Element("linescore").Element("r").Attribute("away").Value);
            hits = Convert.ToInt32(game.Element("linescore").Element("h").Attribute("away").Value);
            errors = Convert.ToInt32(game.Element("linescore").Element("e").Attribute("away").Value);
            sb = Convert.ToInt32(game.Element("linescore").Element("sb").Attribute("away").Value);
            hr = Convert.ToInt32(game.Element("linescore").Element("hr").Attribute("away").Value);

            away_team = new MLBTeamActive(
                game.Attribute("away_team_city").Value,
                game.Attribute("away_team_name").Value,
                game.Attribute("away_division").Value,
                game.Attribute("away_league_id").Value,
                game.Attribute("away_games_back").Value,
                game.Attribute("away_games_back_wildcard").Value,
                Convert.ToInt32(game.Attribute("away_win").Value),
                Convert.ToInt32(game.Attribute("away_loss").Value),
                runs,
                hits,
                errors
                );

            runs = Convert.ToInt32(game.Element("linescore").Element("r").Attribute("home").Value);
            hits = Convert.ToInt32(game.Element("linescore").Element("h").Attribute("home").Value);
            errors = Convert.ToInt32(game.Element("linescore").Element("e").Attribute("home").Value);
            sb = Convert.ToInt32(game.Element("linescore").Element("sb").Attribute("home").Value);
            hr = Convert.ToInt32(game.Element("linescore").Element("hr").Attribute("home").Value);

            home_team = new MLBTeamActive(
                game.Attribute("home_team_city").Value,
                game.Attribute("home_team_name").Value,
                game.Attribute("home_division").Value,
                game.Attribute("home_league_id").Value,
                game.Attribute("home_games_back").Value,
                game.Attribute("home_games_back_wildcard").Value,
                Convert.ToInt32(game.Attribute("home_win").Value),
                Convert.ToInt32(game.Attribute("home_loss").Value),
                runs,
                hits,
                errors
                );

            id = game.Attribute("id").Value;
            park = game.Attribute("venue").Value;

            last_play = Regex.Replace(game.Element("pbp").Attribute("last").Value, @"\s+", " ");

            cur_batter = new MLBBatter(
                Convert.ToInt32(game.Element("batter").Attribute("id").Value),
                game.Element("batter").Attribute("last").Value,
                game.Element("batter").Attribute("first").Value,
                Convert.ToInt32(game.Element("batter").Attribute("number").Value),
                game.Element("batter").Attribute("pos").Value,
                Convert.ToInt32(game.Element("batter").Attribute("ab").Value),
                Convert.ToInt32(game.Element("batter").Attribute("h").Value),
                Convert.ToSingle(game.Element("batter").Attribute("avg").Value),
                Convert.ToInt32(game.Element("batter").Attribute("hr").Value),
                Convert.ToInt32(game.Element("batter").Attribute("rbi").Value),
                Convert.ToSingle(game.Element("batter").Attribute("slg").Value),
                Convert.ToSingle(game.Element("batter").Attribute("ops").Value),
                Convert.ToSingle(game.Element("batter").Attribute("obp").Value)
                );

            cur_pitcher = new MLBPitcher(
                Convert.ToInt32(game.Element("opposing_pitcher").Attribute("id").Value),
                game.Element("opposing_pitcher").Attribute("last").Value,
                game.Element("opposing_pitcher").Attribute("first").Value,
                Convert.ToInt32(game.Element("opposing_pitcher").Attribute("number").Value),
                Convert.ToSingle(game.Element("opposing_pitcher").Attribute("era").Value),
                Convert.ToInt32(game.Element("opposing_pitcher").Attribute("wins").Value),
                Convert.ToInt32(game.Element("opposing_pitcher").Attribute("losses").Value));

            switch (game.Element("runners_on_base").Attribute("status").Value)
            {
                case "0":
                    base_situation = BaseSituations.BasesEmpty;
                    break;
                case "1":
                    base_situation = BaseSituations.RunnerOnFirst;
                    break;
                case "2":
                    base_situation = BaseSituations.RunnerOnSecond;
                    break;
                case "3":
                    base_situation = BaseSituations.RunnerOnThird;
                    break;
                case "4":
                    base_situation = BaseSituations.RunnersOnFirstAndSecond;
                    break;
                case "5":
                    base_situation = BaseSituations.RunnersOnFirstAndThird;
                    break;
                case "6":
                    base_situation = BaseSituations.RunnersOnSecondAndThird;
                    break;
                case "7":
                    base_situation = BaseSituations.BasesLoaded;
                    break;
            }
        }
    }
}
