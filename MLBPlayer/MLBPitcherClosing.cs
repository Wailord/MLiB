using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLiB
{
    public class MLBPitcherClosing
    {
        private string last, first;
        private int num, w, l, sv, svo, id;
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

        public int Saves
        {
            get { return sv; }
        }
        
        public int SaveOps
        {
            get { return svo; }
        }

        public MLBPitcherClosing(int id, string last, string first, int num, float ERA, int sv, int svo, int w, int l)
        {
            this.id = id;
            this.last = last;
            this.first = first;
            this.era = ERA;
            this.num = num;
            this.sv = sv;
            this.svo = svo;
            this.w = w;
            this.l = l;
        }
    }
}
