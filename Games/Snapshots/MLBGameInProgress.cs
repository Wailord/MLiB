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
        private string last_play;
        private int cur_balls;
        private int cur_strikes;
        private int cur_outs;
        private MLBPitcher cur_pitcher;
        private MLBBatter cur_batter;
        private MLBTeamActive away_team;
        private MLBTeamActive home_team;
        private List<MLBInning> innings = new List<MLBInning>();
        private BaseSituations base_situation;
        private string inning_half;

        public int Outs
        {
            get { return cur_outs; }
        }

        public int Strikes
        {
            get { return cur_strikes; }
        }

        public int Balls
        {
            get { return cur_balls; }
        }

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
            float era;

            IEnumerable<XElement> i_innings = game.Element("linescore").Elements("inning");

            foreach (XElement inning in i_innings)
            {
                if (inning.Attribute("home") != null)
                    innings.Add(new MLBInning(inning.Attribute("away").Value, inning.Attribute("home").Value));
                else
                    innings.Add(new MLBInning(inning.Attribute("away").Value, ""));
            }

            inning_half = game.Element("status").Attribute("inning_state").Value;

            if (inning_half == "")
                inning_half = "Top";

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
                game.Attribute("away_name_abbrev").Value,
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
                game.Attribute("home_name_abbrev").Value,
                runs,
                hits,
                errors
                );
            
            last_play = Regex.Replace(game.Element("pbp").Attribute("last").Value, @"\s+", " ");

            int num;

            try
            {
                num = Convert.ToInt32(game.Element("batter").Attribute("number").Value);
            }
            catch (Exception)
            {
                num = 0;
            }

            cur_batter = new MLBBatter(
                Convert.ToInt32(game.Element("batter").Attribute("id").Value),
                game.Element("batter").Attribute("last").Value,
                game.Element("batter").Attribute("first").Value,
                num,
                game.Element("batter").Attribute("pos").Value,
                Convert.ToInt32(game.Element("batter").Attribute("ab").Value),
                Convert.ToInt32(game.Element("batter").Attribute("h").Value),
                Convert.ToSingle(game.Element("batter").Attribute("avg").Value),
                Convert.ToInt32(game.Element("batter").Attribute("hr").Value),
                Convert.ToInt32(game.Element("batter").Attribute("rbi").Value),
                Convert.ToSingle(game.Element("batter").Attribute("slg").Value),
                Convert.ToSingle(game.Element("batter").Attribute("ops").Value),
                Convert.ToSingle(game.Element("batter").Attribute("obp").Value),
                start
                );


            try
            {
                num = Convert.ToInt32(game.Element("pitcher").Attribute("number").Value);
            }
            catch (Exception)
            {
                num = 0;
            }

            if (game.Element("pitcher").Attribute("era").Value == "-.--"
                || game.Element("pitcher").Attribute("era").Value == "-")
                era = 0;
            else
            {
                era = Convert.ToSingle(game.Element("pitcher").Attribute("era").Value);

                cur_pitcher = new MLBPitcher(
                    Convert.ToInt32(game.Element("pitcher").Attribute("id").Value),
                    game.Element("pitcher").Attribute("last").Value,
                    game.Element("pitcher").Attribute("first").Value,
                    num,
                    Convert.ToSingle(game.Element("pitcher").Attribute("era").Value),
                    Convert.ToInt32(game.Element("pitcher").Attribute("wins").Value),
                    Convert.ToInt32(game.Element("pitcher").Attribute("losses").Value),
                    start);
            }

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

            cur_balls = Convert.ToInt32(game.Element("status").Attribute("b").Value);
            cur_strikes = Convert.ToInt32(game.Element("status").Attribute("s").Value);
            cur_outs = Convert.ToInt32(game.Element("status").Attribute("o").Value);

            // get HR hitters

            status = GameStatus.InProgress;
        }

        public override string ToString()
        {
            return String.Format(away_team.Abbreviation + " "
                 + away_team.Runs + ", " + home_team.Abbreviation
                 + " " + home_team.Runs + " - " + inning_half + " " + Innings.Count());
        }
    }
}
