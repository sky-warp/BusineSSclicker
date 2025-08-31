using _Project.Scripts.BusinessTotalAmount.Components;
using _Project.Scripts.Infrastructure.Facades;
using Scellecs.Morpeh;

namespace _Project.Scripts.BusinessTotalAmount.View
{
    public class DrawTotalMoneyAmount : ISystem
    {
        public World World { get; set; }

        private Filter _totalBalanceEntities;
        private Stash<TotalBalance> _totalAmountStash;

        private BaseUIFacade _uiFacade;

        public DrawTotalMoneyAmount(BaseUIFacade facade)
        {
            _uiFacade = facade;
        }

        public void OnAwake()
        {
            _totalAmountStash = this.World.GetStash<TotalBalance>();

            _totalBalanceEntities = this.World.Filter.With<TotalBalance>().Build();

            RedrawTotalBalance();
        }

        public void OnUpdate(float deltaTime)
        {
            if (_totalBalanceEntities.GetLengthSlow() != 0)
            {
                //Redraw total balance (maybe some ECS event system)
                ref var totalBalanceEntity = ref _totalAmountStash.Get(_totalBalanceEntities.First());
            }
        }

        private void RedrawTotalBalance()
        {
            ref var totalBalanceEntity = ref _totalAmountStash.Get(_totalBalanceEntities.First());

            _uiFacade.ShowTotalMoneyAmount(totalBalanceEntity.TotalMoneyAmount);
        }

        public void Dispose()
        {
            _totalBalanceEntities.Dispose();
        }
    }
}