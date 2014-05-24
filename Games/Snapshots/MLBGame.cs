using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace MLiB
{
    public abstract class MLBGame
    {
        protected string park;
        protected string id;
        protected string data_dir;
        protected DateTime start;
        protected GameStatus status;
        protected List<MLBBatter> hr_hitters = new List<MLBBatter>();

        public enum GameStatus
        {
            Completed, Future, InProgress
        };

        public GameStatus Status
        {
            get { return status; }
        }

        public List<MLBBatter> HomeRunHitters
        {
            get { return hr_hitters; }
        }

        public DateTime StartTime
        {
            get { return start; }
        }

        public string Ballpark
        {
            get { return park; }
        }

        public string ID
        {
            get { return id; }
        }

        public string DataDirectory
        {
            get { return data_dir; }
        }

        public MLBGame(XElement game)
        {
            data_dir = game.Attribute("game_data_directory").Value;
            id = game.Attribute("id").Value;
            park = game.Attribute("venue").Value;
            string startTime = game.Attribute("original_date").Value + " " + game.Attribute("time").Value;
            start = DateTime.ParseExact(startTime, "yyyy/MM/dd h:mm", CultureInfo.InvariantCulture);

            if (game.Attribute("ampm").Value == "PM")
                start = start.AddHours(12);

                  // get HR hitters
            XElement homer_section = game.Element("home_runs");
            if (homer_section != null)
            {
                IEnumerable<XElement> homers = homer_section.Elements("player");

                foreach (XElement player in homers)
                {
                    int num, pid;
                    try
                    {
                        num = Convert.ToInt32(player.Attribute("number").Value);
                    }
                    catch (Exception)
                    {
                        num = 0;
                    }
                    try
                    {
                        pid = Convert.ToInt32(player.Attribute("id").Value);
                    }
                    catch (Exception)
                    {
                        pid = 0;
                    }
                    hr_hitters.Add(
                    new MLBBatter(pid,
                        player.Attribute("last").Value,
                        player.Attribute("first").Value,
                        num,
                        "HR",
                        0,
                        0,
                        0,
                        Convert.ToInt32(player.Attribute("hr").Value),
                        0,
                        0,
                        0,
                        0,
                        start)
                        );
                }
            }
        }

        public MLBFullGame GetFullGame()
        {
            return new MLBFullGame(this);
        }

        public MLBAtBat GetMostRecentAtBat()
        {
            MLBFullGame full = new MLBFullGame(this);

            return full.Innings.Last().MostRecent.AtBats.Last();
        }

        public override abstract string ToString();
    }
}
