using IncrementalSystem.Scripts.Examples;

namespace IncrementalSystem.Scripts.Managers
{
    public static class GoldManager
    {
        public static int Gold
        {
            get
            {
                return DataManager.Gold; // Your Gold Reference Here.
            }
            set
            {
                DataManager.Gold = value; // Your Gold Reference Here.
            }
        }
    }
}
