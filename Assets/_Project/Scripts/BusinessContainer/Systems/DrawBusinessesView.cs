using _Project.Scripts.BusinessContainer.Components;
using _Project.Scripts.Infrastructure.Facades;
using Scellecs.Morpeh;
using UnityEngine.UI;

namespace _Project.Scripts.BusinessContainer.Systems
{
    public class DrawBusinessesView : ISystem
    {
        public World World { get; set; }

        private Filter _businessesEntities;

        private Stash<BusinessData> _businessData;
        private Stash<BusinessUpgrades> _businessUpgradesData;
        private Stash<BusinessText> _businessTextData;
        private Stash<BusinessUi> _businessesUi;

        private BaseUIFacade _uiFacade;

        public DrawBusinessesView(BaseUIFacade facade)
        {
            _uiFacade = facade;
        }

        public void OnAwake()
        {
            _businessData = this.World.GetStash<BusinessData>();
            _businessUpgradesData = this.World.GetStash<BusinessUpgrades>();
            _businessTextData = this.World.GetStash<BusinessText>();
            _businessesUi = this.World.GetStash<BusinessUi>();

            _businessesEntities = this.World.Filter.With<BusinessData>().With<BusinessUpgrades>().Build();

            DrawBusinesses();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var business in _businessesEntities)
            {
                ref var businessData = ref _businessData.Get(business);
                ref var businessUi = ref _businessesUi.Get(business);

                CalculateProgressBar(businessUi.ProgressBar, businessData.IncomeProgress);
            }
        }

        private void CalculateProgressBar(Image progressBar,  float currentIncome)
        {
            if (currentIncome > 0)
                progressBar.fillAmount = currentIncome;
        }

        private void DrawBusinesses()
        {
            foreach (var business in _businessesEntities)
            {
                ref var businessData = ref _businessData.Get(business);
                ref var businessTextData = ref _businessTextData.Get(business);
                ref var businessUpgradesData = ref _businessUpgradesData.Get(business);
                ref var businessUi = ref _businessesUi.Get(business);

                var businessView = _uiFacade.CreateBusinessContainer();

                businessUi.ProgressBar = businessView.ProgressBar;

                businessView.TemplateMethod(businessTextData.Name, businessData.CurrentLevel, businessData.Income,
                    businessTextData.LevelUpText,
                    businessTextData.Upgrade1Text, businessTextData.Upgrade2Text);
            }
        }

        public void Dispose()
        {
            _businessesEntities.Dispose();
            _businessData.Dispose();
            _businessUpgradesData.Dispose();
        }
    }
}