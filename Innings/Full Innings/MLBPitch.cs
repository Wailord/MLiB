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
        float x;
        float y;
        float speed;
        int num;

        public float X
        {
            get { return x; }
        }

        public float Y
        {
            get { return y; }
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
            x = Convert.ToSingle(pitch.Attribute("x").Value);
            y = Convert.ToSingle(pitch.Attribute("y").Value);
            if (pitch.Attribute("start_speed") != null)
                speed = Convert.ToSingle(pitch.Attribute("start_speed").Value);
            else
                speed = 0;
            num = Convert.ToInt32(pitch.Attribute("id").Value);
        }
    }
}
