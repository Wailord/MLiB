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

        public MLBFullHalfInning MostRecent
        {
            get
            {
                if (bottom == null)
                    return top;
                else
                    return bottom;
            }
        }

        public MLBFullInning(XElement inning)
        {
            if(inning.Element("top") != null)
                top = new MLBFullHalfInning(inning.Element("top"));
            if(inning.Element("bottom") != null)
                bottom = new MLBFullHalfInning(inning.Element("bottom"));
        }
    }
}
