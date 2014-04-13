using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Net;
using System.IO;

namespace MLiB
{
    public class MLBBatter : MLBPlayer
    {
        private string pos;
        private int ab;
        private int h;
        private float avg;
        private int hr;
        private int rbi;
        private float slg;
        private float ops;
        private float obp;

        public Image Thumbnail
        {
            get
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create("http://mlb.mlb.com/images/players/assets/68_" + id + ".png");
                HttpWebResponse httpWebReponse = (HttpWebResponse)httpWebRequest.GetResponse();
                Stream stream = httpWebReponse.GetResponseStream();
                return Image.FromStream(stream);
            }
        }

        public string Position
        {
            get { return pos; }
        }

        public int AtBats
        {
            get { return ab; }
        }

        public int Hits
        {
            get { return h; }
        }

        public float AVG
        {
            get { return avg; }
        }

        public int HomeRuns
        {
            get { return hr; }
        }

        public int RBI
        {
            get { return rbi; }
        }

        public float SLG
        {
            get { return slg; }
        }

        public float OBP
        {
            get { return obp; }
        }

        public float OPS
        {
            get { return ops; }
        }

        public MLBBatter(int ID, string last, string first, int number, string pos,
            int ab, int h, float avg, int hr, int rbi, float slg, float ops, float obp)
            : base(ID, last, first, number)
        {
            this.pos = pos;
            this.ab = ab;
            this.h = h;
            this.avg = avg;
            this.hr = hr;
            this.rbi = rbi;
            this.slg = slg;
            this.ops = ops;
            this.obp = obp;
        }
    }
}
