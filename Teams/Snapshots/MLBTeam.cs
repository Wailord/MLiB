﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Net;
using System.IO;

namespace MLiB
{
    public class MLBTeam
    {
        protected string m_city;
        protected string m_name;
        protected string m_division;
        protected string m_league;
        protected string m_gb;
        protected string m_gbwc;
        protected int m_wins;
        protected int m_losses;
        protected string abb;

        public Image Logo
        {
            get
            {
                HttpWebRequest httpWebRequest =
                    (HttpWebRequest)HttpWebRequest.Create("http://www.mlb.com/mlb/images/team_logos/logo_" + abb.ToLower() + "_79x76.jpg");
                HttpWebResponse httpWebReponse = (HttpWebResponse)httpWebRequest.GetResponse();
                Stream stream = httpWebReponse.GetResponseStream();
                return Image.FromStream(stream);
            }
        }

        public string Abbreviation
        {
            get { return abb; }
        }

        public string City
        {
            get { return m_city; }
        }

        public string Nickname
        {
            get { return m_name; }
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
            string gbwc, int wins, int losses, string abb)
        {
            m_city = city;

            if (m_city == "NY Yankees" || m_city == "NY Mets")
                m_city = "New York";
            else if (m_city == "LA Angels" || m_city == "LA Dodgers")
                m_city = "Los Angeles";

            m_name = name;
            m_division = division;
            m_league = league;
            m_gb = gb;
            m_gbwc = gbwc;
            m_wins = wins;
            m_losses = losses;
            this.abb = abb;
        }
    }
}
