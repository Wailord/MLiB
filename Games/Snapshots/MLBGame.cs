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

        public enum GameStatus
        {
            Completed, Future, InProgress
        };

        public GameStatus Status
        {
            get { return status; }
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
        }

        public MLBFullGame GetFullGame()
        {
            return new MLBFullGame(this);
        }

        public MLBPitch GetLastPitch()
        {
            MLBFullGame full = new MLBFullGame(this);

            return full.Innings.Last().MostRecent.AtBats.Last().Pitches.Last();
        }

        public override abstract string ToString();
    }
}
