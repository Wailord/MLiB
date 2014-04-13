using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLiB
{
    public class MLBPitcher : MLBPlayer
    {
        private int w, l;
        private float era;

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
            : base(id, last, first, num)
        {
            this.era = era;
            this.w = w;
            this.l = l;
        }
    }
}
