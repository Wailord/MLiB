using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MLiB
{
    public class MLBFullHalfInning
    {
        private List<MLBAtBat> at_bats = new List<MLBAtBat>();

        public List<MLBAtBat> AtBats
        {
            get { return at_bats; }
        }

        public MLBFullHalfInning(XElement half)
        {
            if (half != null)
            {
                IEnumerable<XElement> atbats = half.Elements("atbat");
                foreach (XElement atbat in atbats)
                {
                    at_bats.Add(new MLBAtBat(atbat));
                }
            }
        }
    }
}
