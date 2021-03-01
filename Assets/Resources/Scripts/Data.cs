using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    static class Data
    {
        static public bool characterAtacked = false;
        static public bool characterCrouched = false;
        static public float characterSpeed;
        private static int bestScore = PlayerPrefs.GetInt("DataScore");
        public static int Score
        {
            get
            {
                return bestScore;
            }
            set
            {
                if (value < 0)
                {
                    bestScore = 0;
                }
                else { bestScore = value; }
            }
        }

        static public int maxBottles;
        public static int BottlesCollected
        {
            get
            {
                return bottlesCollected;
            }
            set
            {
                if (value < 0)
                {
                    bottlesCollected = 0;
                }
                else if(value > maxBottles)
                {
                    bottlesCollected = maxBottles;
                }
                else { bottlesCollected = value; }
            }
        }

        private static int bottlesCollected = PlayerPrefs.GetInt("BottlesScore");

        public static Ponchos.PonchosType nowUsebelPoncho;

    }
}
