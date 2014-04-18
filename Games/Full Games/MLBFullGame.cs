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
        List<MLBFullInning> innings;
        MLBLinescore linescore;
        MLBFullTeam away;
        MLBFullTeam home;

        public MLBFullGame(MLBGame snapshot)
        {
            // create full game from passed in snapshot
            IEnumerable<XElement> l_innings = XDocument.Load("http://gd2.mlb.com/components/game/mlb/year_"
                    + snapshot.StartTime.Year + "/month_" + (snapshot.StartTime.Month <= 9 ? "0" : "")
                    + snapshot.StartTime.Month + "/day_" + (snapshot.StartTime.Day <= 9 ? "0" : "")
                    + snapshot.StartTime.Day + "/" + snapshot.ID + "/inning/inning_all.xml").Elements("inning");

            foreach (XElement inning in l_innings)
                innings.Add(new MLBFullInning(inning));


        }
    }
}
