using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLiB
{
    public class MLBInning
    {
        private string aRuns;
        private string hRuns;

        public string AwayScored
        {
            get { return aRuns; }
        }

        public string HomeScored
        {
            get { return hRuns; }
        }

        public MLBInning(string a, string h)
        {
            if (a == "")
                a = "-";
            if (h == "")
                h = "-";
            aRuns = a;
            hRuns = h;
        }
    }
}