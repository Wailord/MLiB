using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLiB
{
    public class MLBTeam
    {
        private string m_city;
        private string m_name;
        private string m_division;
        private string m_league;
        private string m_gb;
        private string m_gbwc;
        private int m_wins;
        private int m_losses;

        public string City
        {
            get { return m_city; }
        }

        public string Nickname
        {
            get { return m_name;  }
        }

        public string Division
        {
            get { return m_division; }
        }

        public string League
        {
            get
            {
                if (m_league == "103")
                    return "AL";
                else
                    return "NL";
            }
        }

        public string GamesBack
        {
            get { return m_gb; }
        }

        public string GamesBackWildCard
        {
            get { return m_gbwc; }
        }

        public int Wins
        {
            get { return m_wins; }
        }

        public int Losses
        {
            get { return m_losses; }
        }

        public MLBTeam(string city, string name, string division, string league, string gb,
            string gbwc, int wins, int losses)
        {
            m_city = city;
            m_name = name;
            m_division = division;
            m_league = league;
            m_gb = gb;
            m_gbwc = gbwc;
            m_wins = wins;
            m_losses = losses;
        }
    }
}
