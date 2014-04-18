using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Threading.Tasks;

namespace MLiB
{
    public class MLBFullInning
    {
        private MLBFullHalfInning top;
        private MLBFullHalfInning bottom;

        public MLBFullInning(XElement inning)
        {
            // parse top of the inning, then bottom
        }
    }
}
