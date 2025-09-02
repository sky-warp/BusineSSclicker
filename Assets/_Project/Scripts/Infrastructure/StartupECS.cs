using _Project.Scripts.BusinessContainer.Systems;
using _Project.Scripts.BusinessContainer.View;
using _Project.Scripts.BusinessTotalAmount.Systems;
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

            var uiFacade = new DefaultUIFacade(_businessWindowView,
                new BusinessContainerFactory(_viewPrefab, _businessesParent));

            var initializersGroup = _world.CreateSystemsGroup();
            initializersGroup.AddInitializer(new BusinessesInitialize(_config));

            var drawGroup = _world.CreateSystemsGroup();
            drawGroup.AddSystem(new DrawTotalMoneyAmount(uiFacade));
            drawGroup.AddSystem(new DrawBusinessesView(uiFacade));

            var moneyCounterGroup = _world.CreateSystemsGroup();
            moneyCounterGroup.AddSystem(new IncomeCounter());
            moneyCounterGroup.AddSystem(new TotalMoneyCounter());

            _world.AddSystemsGroup(0, initializersGroup);
            _world.AddSystemsGroup(1, moneyCounterGroup);
            _world.AddSystemsGroup(2, drawGroup);
        }
    }
}