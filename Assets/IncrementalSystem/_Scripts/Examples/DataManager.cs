using UnityEngine;

namespace IncrementalSystem.Scripts.Examples
{
    public static class DataManager
    {
        private const string GoldKey = "Gold";
        public static int Gold
        {
            get
            {
                return PlayerPrefs.GetInt(GoldKey, 0);
            }
            set
            {
                PlayerPrefs.SetInt(GoldKey, value);
            }
        }
    }
}