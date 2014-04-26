using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLiB
{
    public class MLBPitcherClosing : MLBPitcher
    {
        private int sv, svo;

        public int Saves
        {
            get { return sv; }
        }
        
        public int SaveOps
        {
            get { return svo; }
        }

        public MLBPitcherClosing(int id, string last, string first, int num,
            float ERA, int sv, int svo, int w, int l, DateTime date)
            : base(id, last, first, num, ERA, w, l, date)
        {
            this.sv = sv;
            this.svo = svo;
        }
    }
}
