using _Project.Scripts.BusinessContainer.Components;
using _Project.Scripts.Infrastructure.Facades;
using Scellecs.Morpeh;

namespace _Project.Scripts.BusinessContainer.Systems
{
    public class DrawBusinessesView : ISystem
    {
        public World World { get; set; }

        private Filter _businessesEntities;

        private Stash<BusinessData> _businessData;
        private Stash<BusinessUpgrades> _businessUpgradesData;
        private Stash<BusinessText> _businessTextData;

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

            _businessesEntities = this.World.Filter.With<BusinessData>().With<BusinessUpgrades>().Build();

            DrawBusinesses();
        }

        public void OnUpdate(float deltaTime)
        {
            //Redraw each business window every frame
        }

        private void DrawBusinesses()
        {
            foreach (var businesses in _businessesEntities)
            {
                ref var businessData = ref _businessData.Get(businesses);
                ref var businessTextData = ref _businessTextData.Get(businesses);
                ref var businessUpgradesData = ref _businessUpgradesData.Get(businesses);

                var businessView = _uiFacade.CreateBusinessContainer();

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