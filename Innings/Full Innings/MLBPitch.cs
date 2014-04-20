using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MLiB
{
    public class MLBPitch
    {
        public enum PitchResult
        {
            Ball, Strike, InPlay
        }

        PitchResult result;
        string desc;
        float top_of_zone;
        float bottom_of_zone;
        float px;
        float pz;
        float speed;
        int num;

        public float X
        {
            get { return px * 12; }
        }

        public float Y
        {
            get { return pz * 12; }
        }

        public float Velocity
        {
            get { return speed; }
        }

        public int PitchNumber
        {
            get { return num; }
        }

        public bool Strike
        {
            get { return result == PitchResult.Strike; }
        }

        public bool Ball
        {
            get { return result == PitchResult.Ball; }
        }

        public bool InPlay
        {
            get { return result == PitchResult.InPlay; }
        }

        public string Description
        {
            get { return desc; }
        }

        public float BottomOfZone
        {
            get { return bottom_of_zone * 12; }
        }

        public float TopOfZone
        {
            get { return top_of_zone * 12; }
        }

        public MLBPitch(XElement pitch)
        {
            switch(pitch.Attribute("type").Value.ToString())
            {
                case "S":
                    result = PitchResult.Strike;
                    break;
                case "B":
                    result = PitchResult.Ball;
                    break;
                case "X":
                    result = PitchResult.InPlay;
                    break;
            }
            
            desc = pitch.Attribute("des").Value.ToString();
            px = Convert.ToSingle(pitch.Attribute("px").Value);
            pz = Convert.ToSingle(pitch.Attribute("pz").Value);
            top_of_zone = Convert.ToSingle(pitch.Attribute("sz_top").Value);
            bottom_of_zone = Convert.ToSingle(pitch.Attribute("sz_bot").Value);
            
            if (pitch.Attribute("start_speed") != null)
                speed = Convert.ToSingle(pitch.Attribute("start_speed").Value);
            else
                speed = 0;
            num = Convert.ToInt32(pitch.Attribute("id").Value);
        }
    }
}
