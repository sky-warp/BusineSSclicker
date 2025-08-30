using _Project.Scripts.BusinessTotalAmount;
using _Project.Scripts.BusinessTotalAmount.View;
using _Project.Scripts.Infrastructure.Facades;
using Scellecs.Morpeh;
using UnityEngine;

namespace _Project.Scripts.Infrastructure
{
    public class StartupECS : MonoBehaviour
    {
        [SerializeField] private BaseBusinessWindowView businessWindowView;
        
        private World _world;

        public void Start()
        {
            _world = World.Default;

            var totalMoneyAmountSystemGroup = _world.CreateSystemsGroup();
            totalMoneyAmountSystemGroup.AddSystem(new TotalMoneySystem(new DefaultUIFacade(businessWindowView)));

            _world.AddSystemsGroup(0, totalMoneyAmountSystemGroup);
        }
    }
}