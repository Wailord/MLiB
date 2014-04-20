using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Threading.Tasks;

namespace MLiB
{
    public class MLBFullGame
    {
        List<MLBFullInning> innings = new List<MLBFullInning>();
        MLBLinescore linescore;
        MLBFullTeam away;
        MLBFullTeam home;

        public List<MLBFullInning> Innings
        {
            get { return innings; }
        }

        public MLBFullGame(MLBGame snapshot)
        {
            // create full game from passed in snapshot
            IEnumerable<XElement> l_innings = XDocument.Load("http://gd2.mlb.com/" + snapshot.DataDirectory + "/inning/inning_all.xml").Element("game").Elements("inning");

            foreach (XElement inning in l_innings)
                innings.Add(new MLBFullInning(inning));

        }
    }
}
