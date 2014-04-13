using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLiB
{
    public class MLBPitcher
    {
        private string last, first;
        private int id, num, w, l;
        private float era;

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
            get { return num; }
        }

        public int Wins
        {
            get { return w; }
        }

        public int Losses
        {
            get { return l; }
        }

        public float ERA
        {
            get { return era; }
        }


        public MLBPitcher(int id, string last, string first, int num, float era, int w, int l)
        {
            this.id = id;
            this.last = last;
            this.first = first;
            this.num = num;
            this.era = era;
            this.w = w;
            this.l = l;
        }
    }
}
