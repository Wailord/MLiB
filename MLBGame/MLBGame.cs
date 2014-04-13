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
        private string park;
        private string id;
        private string data_dir;
        private DateTime start;

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
            start = DateTime.ParseExact(game.Attribute("time_date").Value, "yyyy/MM/dd h:mm", CultureInfo.InvariantCulture);

            if (game.Attribute("ampm").Value == "PM")
                start = start.AddHours(12);
        }
    }
}
