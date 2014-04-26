using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Threading.Tasks;

namespace MLiB
{
    public class SingleGameBattingStatistics
    {
        private int ab;
        private int r;
        private int h;
        private int hr;
        private int rbi;
        private int sb;
        private int singles;
        private int doubles;
        private int triples;
        private int walks;
        private int caught_stealing;
        private int strikeouts;
        private int hbp;

        public int AtBats
        {
            get { return ab; }
        }

        public int Runs
        {
            get { return r; }
        }

        public int Hits
        {
            get { return h; }
        }

        public int HomeRuns
        {
            get { return hr; }
        }

        public int RBI
        {
            get { return rbi; }
        }

        public int StolenBases
        {
            get { return sb; }
        }

        public int Singles
        {
            get { return singles; }
        }

        public int Doubles
        {
            get { return doubles; }
        }

        public int Triples
        {
            get { return triples; }
        }

        public int Walks
        {
            get { return walks; }
        }

        public int CaughtStealing
        {
            get { return caught_stealing; }
        }

        public int Strikeouts
        {
            get { return strikeouts; }
        }

        public int HitByPitches
        {
            get { return hbp; }
        }

        public SingleGameBattingStatistics(string xml_page)
        {
            XDocument player_page = XDocument.Load(xml_page);
            XElement batter = player_page.Element("batting");

            this.ab = Convert.ToInt32(batter.Attribute("ab").Value);
            this.r = Convert.ToInt32(batter.Attribute("r").Value);
            this.hr = Convert.ToInt32(batter.Attribute("hr").Value);
            this.rbi = Convert.ToInt32(batter.Attribute("rbi").Value);
            this.sb = Convert.ToInt32(batter.Attribute("sb").Value);
            this.singles = Convert.ToInt32(batter.Attribute("single").Value);
            this.doubles = Convert.ToInt32(batter.Attribute("double").Value);
            this.triples = Convert.ToInt32(batter.Attribute("triple").Value);
            this.walks = Convert.ToInt32(batter.Attribute("bb").Value);
            this.caught_stealing = Convert.ToInt32(batter.Attribute("cs").Value);
            this.strikeouts = Convert.ToInt32(batter.Attribute("so").Value);
            this.hbp = Convert.ToInt32(batter.Attribute("hbp").Value);
        }
    }
}
