using _Project.Scripts.BusinessContainer.View;
using _Project.Scripts.Configs;
using Scellecs.Morpeh;

namespace _Project.Scripts.BusinessContainer
{
    public class BusinessesInitialize : IInitializer
    {
        public World World { get; set; }

        private Stash<BusinessData> _businessData;
        private Stash<BusinessUpgrades> _businessUpgrades;
        private Stash<BusinessUpgradesChecker> _businessUpgradesChecker;

        private GlobalBusinessesConfig _config;
        private BaseBusinessContainerFactory _factory;

        public BusinessesInitialize(GlobalBusinessesConfig config, BaseBusinessContainerFactory factory)
        {
            _config = config;
            _factory = factory;
        }

        public void OnAwake()
        {
            foreach (var container in _config.Configs)
            {
                var business = this.World.CreateEntity();

                _businessData = this.World.GetStash<BusinessData>();
                ref var data = ref _businessData.Add(business);
                data.Name = container.Name;
                data.CurrentLevel = container.StartupLevel;
                data.Income = container.BaseIncome;
                data.Delay = container.BaseDelay;

                _businessUpgrades = this.World.GetStash<BusinessUpgrades>();
                ref var upgradesData = ref _businessUpgrades.Add(business);
                upgradesData.Upgrade1Price = container.Upgrade1Price;
                upgradesData.Upgrade1PercentageBoost = container.Upgrade1Boost;
                upgradesData.Upgrade2Price = container.Upgrade2Price;
                upgradesData.Upgrade2PercentageBoost = container.Upgrade2Boost;

                _businessUpgradesChecker = this.World.GetStash<BusinessUpgradesChecker>();
                _businessUpgradesChecker.Add(business);

                var bussinesView = _factory.Create();

                bussinesView.TemplateMethod(data.Name, data.CurrentLevel, data.Income, container.LevelUpText,
                    container.Upgrade1Text, container.Upgrade2Text);
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