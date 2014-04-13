using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLiB
{
    public class MLBBatter
    {
        private int id;
        private string last;
        private string first;
        private int number;
        private string pos;
        private int ab;
        private int h;
        private float avg;
        private int hr;
        private int rbi;
        private float slg;
        private float ops;
        private float obp;

        public int ID
        {
            get { return id; }
        }

        public string LastName
        {
            get { return last; }
        }

        public string FirstName
        {
            get { return first; }
        }

        public int JerseyNumber
        {
            get { return number; }
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
            int ab, int h, float avg, int hr, int rbi, float slg, float ops, float obp)
        {
            this.id = ID;
            this.last = last;
            this.first = first;
            this.number = number;
            this.pos = pos;
            this.ab = ab;
            this.h = h;
            this.avg = avg;
            this.hr = hr;
            this.rbi = rbi;
            this.slg = slg;
            this.ops = ops;
            this.obp = obp;
        }
    }
}
