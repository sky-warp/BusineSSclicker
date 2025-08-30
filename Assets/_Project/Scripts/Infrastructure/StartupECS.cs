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
    public class StartupEcs : MonoBehaviour
    {
        [SerializeField] private BaseBusinessWindowView businessWindowView;
        [SerializeField] private GlobalBusinessesConfig _config;

        [SerializeField] private BaseBusinessContainerView _viewPrefab;
        [SerializeField] private Transform _bussinessesParent;

        private World _world;

        public void Start()
        {
            _world = World.Default;

            var moneyCounterGroup = _world.CreateSystemsGroup();
            moneyCounterGroup.AddSystem(new TotalMoneyCounter(new DefaultUIFacade(businessWindowView)));
            moneyCounterGroup.AddSystem(new IncomeCounter());
            moneyCounterGroup.AddInitializer(new BusinessesInitialize(_config,
                new BusinessContainerFactory(_viewPrefab, _bussinessesParent)));


            _world.AddSystemsGroup(0, moneyCounterGroup);
        }
    }
}