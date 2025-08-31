using _Project.Scripts.BusinessContainer.Components;
using _Project.Scripts.Configs;
using Scellecs.Morpeh;

namespace _Project.Scripts.BusinessContainer.Systems
{
    public class BusinessesInitialize : IInitializer
    {
        public World World { get; set; }

        private Stash<BusinessData> _businessData;
        private Stash<BusinessUpgrades> _businessUpgrades;
        private Stash<BusinessText> _businessText;
        private Stash<BusinessUpgradesChecker> _businessUpgradesChecker;

        private GlobalBusinessesConfig _config;

        public BusinessesInitialize(GlobalBusinessesConfig config)
        {
            _config = config;
        }

        public void OnAwake()
        {
            _businessData = this.World.GetStash<BusinessData>();
            _businessUpgrades = this.World.GetStash<BusinessUpgrades>();
            _businessText = this.World.GetStash<BusinessText>();

            InitializeBusinesses();
        }

        private void InitializeBusinesses()
        {
            foreach (var container in _config.Configs)
            {
                var business = this.World.CreateEntity();

                ref var data = ref _businessData.Add(business);
                data.CurrentLevel = container.StartupLevel;
                data.Income = container.BaseIncome;
                data.Delay = container.BaseDelay;

                ref var upgradesData = ref _businessUpgrades.Add(business);
                upgradesData.Upgrade1Price = container.Upgrade1Price;
                upgradesData.Upgrade1PercentageBoost = container.Upgrade1Boost;
                upgradesData.Upgrade2Price = container.Upgrade2Price;
                upgradesData.Upgrade2PercentageBoost = container.Upgrade2Boost;

                ref var textData = ref _businessText.Add(business);
                textData.Name = container.Name;
                textData.LevelUpText = container.LevelUpText;
                textData.Upgrade1Text = container.Upgrade1Text;
                textData.Upgrade2Text = container.Upgrade2Text;

                _businessUpgradesChecker = this.World.GetStash<BusinessUpgradesChecker>();
                _businessUpgradesChecker.Add(business);
            }
        }

        public void Dispose()
        {
            _businessData.Dispose();
            _businessUpgrades.Dispose();
            _businessUpgradesChecker.Dispose();
        }
    }
}