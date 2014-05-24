using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Threading.Tasks;

namespace MLiB
{
    public class MLBBatter : MLBPlayer
    {
        private string pos;
        private int ab;
        private int h;
        private float avg;
        private int hr;
        private int rbi;
        private float slg;
        private float ops;
        private float obp;
        private SingleGameBattingStatistics game_stats;

        public SingleGameBattingStatistics GameStats
        {
            get { return game_stats;  } 
        }

        public string Position
        {
            get { return pos; }
        }

        public int AtBats
        {
            get { return ab; }
        }

        public int Hits
        {
            get { return h; }
        }

        public float AVG
        {
            get { return avg; }
        }

        public int HomeRuns
        {
            get { return hr; }
        }

        public int RBI
        {
            get { return rbi; }
        }

        public float SLG
        {
            get { return slg; }
        }

        public float OBP
        {
            get { return obp; }
        }

        public float OPS
        {
            get { return ops; }
        }

        public MLBBatter(int ID, string last, string first, int number, string pos,
            int ab, int h, float avg, int hr, int rbi, float slg, float ops, float obp,
            DateTime date)
            : base(ID, last, first, number, date)
        {
            this.pos = pos;
            this.ab = ab;
            this.h = h;
            this.avg = avg;
            this.hr = hr;
            this.rbi = rbi;
            this.slg = slg;
            this.ops = ops;
            this.obp = obp;

             string player_page = "http://gd2.mlb.com/components/game/mlb/year_"
                    + time.Year + "/month_" + ((time.Month > 9) ? ("") : ("0")) + time.Month
                    + "/day_" + ((time.Day > 9) ? ("") : ("0"))+ time.Day
                    + "/batters/" + id + "_1.xml";

             this.game_stats = new SingleGameBattingStatistics(player_page);
        }

        public override string ToString()
        {
            return last + ", " + first;
        }
    }
}