using _Project.Scripts.BusinessContainer;
using _Project.Scripts.BusinessContainer.View;
using _Project.Scripts.BusinessTotalAmount;
using _Project.Scripts.BusinessTotalAmount.View;
using _Project.Scripts.Configs;
using _Project.Scripts.Infrastructure.Facades;
using Scellecs.Morpeh;
using UnityEngine;

namespace _Project.Scripts.Infrastructure
{
    public class StartupEcs
    {
        private BaseBusinessWindowView _businessWindowView;
        private GlobalBusinessesConfig _config;

        private BaseBusinessContainerView _viewPrefab;
        private Transform _businessesParent;

        private World _world;

        public void Init(BaseBusinessWindowView businessWindowView, GlobalBusinessesConfig config,
            BaseBusinessContainerView viewPrefab, Transform businessesParent)
        {
            _businessWindowView = businessWindowView;
            _config = config;
            _viewPrefab = viewPrefab;
            _businessesParent = businessesParent;
        }

        public void Startup()
        {
            _world = World.Default;

            var moneyCounterGroup = _world.CreateSystemsGroup();
            moneyCounterGroup.AddSystem(new TotalMoneyCounter(new DefaultUIFacade(_businessWindowView)));
            moneyCounterGroup.AddSystem(new IncomeCounter());
            moneyCounterGroup.AddInitializer(new BusinessesInitialize(_config,
                new BusinessContainerFactory(_viewPrefab, _businessesParent)));
            
            _world.AddSystemsGroup(0, moneyCounterGroup);
        }
    }
}