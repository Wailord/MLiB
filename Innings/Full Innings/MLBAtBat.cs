using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MLiB
{
    public class MLBAtBat
    {
        private List<MLBPitch> pitches = new List<MLBPitch>();

        public List<MLBPitch> Pitches
        {
            get { return pitches; }
        }

        public MLBAtBat(XElement atbat)
        {
            IEnumerable<XElement> lpitches = atbat.Elements("pitch");
            foreach (XElement pitch in lpitches)
            {
                pitches.Add(new MLBPitch(pitch));
            }
        }
    }
}
