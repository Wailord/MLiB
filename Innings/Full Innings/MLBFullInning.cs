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

        public MLBFullHalfInning Top
        {
            get { return top; }
        }

        public MLBFullHalfInning Bottom
        {
            get { return bottom; }
        }

        public MLBFullInning(XElement inning)
        {
            top = new MLBFullHalfInning(inning.Element("top"));
            bottom = new MLBFullHalfInning(inning.Element("bottom"));
        }
    }
}
