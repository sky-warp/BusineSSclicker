using System;

namespace _Project.Scripts.Configs
{
    [Serializable]
    public class BusinessItemConfig
    {
        public string Name;
        public int StartupLevel;
        public float BaseIncome;
        public float BaseDelay;
        public float LevelUpPrice;
        public string LevelUpText;
        public float Upgrade1Price;
        public float Upgrade1Boost;
        public string Upgrade1Text;
        public float Upgrade2Price;
        public float Upgrade2Boost;
        public string Upgrade2Text;
    }
}