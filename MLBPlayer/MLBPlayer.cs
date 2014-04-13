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
    public class MLBPlayer
    {
        protected int id;
        protected string last;
        protected string first;
        protected int number;

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

        public int ID
        {
            get { return id; }
        }

        public string LastName
        {
            get { return last; }
        }

        public string FirstName
        {
            get { return first; }
        }

        public int JerseyNumber
        {
            get { return number; }
        }

        public MLBPlayer(int id, string last, string first, int number)
        {
            this.id = id;
            this.last = last;
            this.first = first;
            this.number = number;
        }

        public override string ToString()
        {
            return last + ", " + first;
        }
    }
}
