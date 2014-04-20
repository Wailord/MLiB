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
        private int strikes;
        private int balls;
        private int outs;
        private string result;
        private bool vs_righty;

        public bool RightHandedBatter
        {
            get { return vs_righty; }
        }

        public bool LeftHandedBatter
        {
            get { return !vs_righty; }
        }

        public int Strikes
        {
            get { return strikes; }
        }

        public int Balls
        {
            get { return balls; }
        }

        public int Outs
        {
            get { return outs; }            
        }

        public string Result
        {
            get { return result; }
        }

        public List<MLBPitch> Pitches
        {
            get { return pitches; }
        }

        public MLBAtBat(XElement atbat)
        {
            IEnumerable<XElement> lpitches = atbat.Elements("pitch");

            strikes = Convert.ToInt32(atbat.Attribute("s").Value);
            balls = Convert.ToInt32(atbat.Attribute("b").Value);
            outs = Convert.ToInt32(atbat.Attribute("o").Value);
            result = atbat.Attribute("des").Value;
            vs_righty = (atbat.Attribute("stand").Value == "R");

            foreach (XElement pitch in lpitches)
            {
                pitches.Add(new MLBPitch(pitch));
            }
        }
    }
}
