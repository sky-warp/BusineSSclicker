using _Project.Scripts.BusinessTotalAmount.Components;
using _Project.Scripts.Infrastructure.Facades;
using Scellecs.Morpeh;

namespace _Project.Scripts.BusinessTotalAmount.Systems
{
    public class DrawTotalMoneyAmount : ISystem
    {
        public World World { get; set; }

        private Filter _totalBalanceFilter;
        private Filter _balanceChangedFilter;
        private Stash<TotalBalance> _totalAmountStash;

        private BaseUIFacade _uiFacade;

        public DrawTotalMoneyAmount(BaseUIFacade facade)
        {
            _uiFacade = facade;
        }

        public void OnAwake()
        {
            _totalAmountStash = this.World.GetStash<TotalBalance>();
            
            _totalBalanceFilter = this.World.Filter.With<TotalBalance>().Build();
            
            _balanceChangedFilter = this.World.Filter.With<BalanceChangeEvent>().Build();

            RedrawTotalBalance();
        }

        public void OnUpdate(float deltaTime)
        {
            if (_balanceChangedFilter.GetLengthSlow() != 0)
            {
                RedrawTotalBalance();
            }
        }

        private void RedrawTotalBalance()
        {
            ref var totalBalanceEntity = ref _totalAmountStash.Get(_totalBalanceFilter.First());

            _uiFacade.ShowTotalMoneyAmount(totalBalanceEntity.TotalMoneyAmount);
        }

        public void Dispose()
        {
            _totalBalanceFilter.Dispose();
        }
    }
}