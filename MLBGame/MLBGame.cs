using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace MLiB
{
    public class MLBGame
    {
        protected string park;
        protected string id;
        protected string data_dir;
        protected DateTime start;

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
    }
}
