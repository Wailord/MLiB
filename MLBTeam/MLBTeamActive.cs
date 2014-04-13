using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLiB
{
    public class MLBTeamActive : MLBTeam
    {
        private int runs;
        private int hits;
        private int errors;

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

        public MLBTeamActive(string city, string name, string division, string league, string gb,
            string gbwc, int wins, int losses, int runs, int hits, int errors)
            : base(city, name, division, league, gb, gbwc, wins, losses)
        {
            this.runs = runs;
            this.hits = hits;
            this.errors = errors;
        }
    }
}
