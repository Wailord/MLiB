﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLiB
{
    public class MLBTeamCompleted : MLBTeam
    {
        private int runs;
        private int hits;
        private int errors;
        private int sb;
        private int hr;
        private bool won;

        public bool Won
        {
            get { return won; }
        }

        public int Runs
        {
            get { return runs; }
        }

        public int Hits
        {
            get { return hits; }
        }

        public int Errors
        {
            get { return errors; }
        }

        public int StolenBases
        {
            get { return sb; }
        }

        public int HomeRuns
        {
            get { return hr; }
        }


        public MLBTeamCompleted(string city, string name, string division, string league, string gb,
            string gbwc, int wins, int losses, int runs, int hits, int errors, int hr, int sb, bool won)
            : base(city, name, division, league, gb, gbwc, wins, losses)
        {
            this.runs = runs;
            this.hits = hits;
            this.errors = errors;
            this.sb = sb;
            this.hr = hr;
            this.won = won;
        }
    }
}
