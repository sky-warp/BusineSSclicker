using _Project.Scripts.BusinessContainer.Components;
using _Project.Scripts.BusinessTotalAmount.Components;
using Scellecs.Morpeh;

namespace _Project.Scripts.BusinessTotalAmount.Systems
{
    public class TotalMoneyCounter : ISystem
    {
        public World World { get; set; }

        private Filter _allBusinesses;
        private Filter _changeBalanceEvent;

        private Stash<BalanceChangeEvent> _balanceChangeEventStash;
        private Stash<TotalBalance> _totalAmountStash;
        private Stash<BusinessData> _businessDataStash;

        private Entity _totalAmount;

        public void OnAwake()
        {
            _totalAmount = this.World.CreateEntity();

            _totalAmountStash = this.World.GetStash<TotalBalance>();
            ref var totalBalance = ref _totalAmountStash.Add(_totalAmount);

            _businessDataStash = this.World.GetStash<BusinessData>();

            _balanceChangeEventStash = this.World.GetStash<BalanceChangeEvent>();

            _allBusinesses = this.World.Filter.With<BusinessData>().Build();
            _changeBalanceEvent = this.World.Filter.With<BalanceChangeEvent>().Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var balanceEvent in _changeBalanceEvent)
            {
                _balanceChangeEventStash.Remove(balanceEvent);
            }

            foreach (var business in _allBusinesses)
            {
                ref var data = ref _businessDataStash.Get(business);

                if (data.CurrentLevel == 0)
                    continue;

                data.Timer += deltaTime;
                data.IncomeProgress = data.Timer / data.Delay;

                if (data.IncomeProgress >= 1)
                {
                    data.Timer = 0;
                    data.IncomeProgress = 0;
                    IncreaseTotalBalance(data.Income);

                    if (!_balanceChangeEventStash.Has(_totalAmount))
                    {
                        _balanceChangeEventStash.Add(_totalAmount);
                    }
                }
            }
        }

        private void IncreaseTotalBalance(float value)
        {
            ref var totalBalance = ref _totalAmountStash.Get(_totalAmount);

            totalBalance.TotalMoneyAmount += value;
        }

        private void DecreaseTotalBalance(float value)
        {
            ref var totalBalance = ref _totalAmountStash.Get(_totalAmount);
            
            totalBalance.TotalMoneyAmount -= value;
        }

        public void Dispose()
        {
            _totalAmountStash.Dispose();
            _balanceChangeEventStash.Dispose();
            _changeBalanceEvent.Dispose();
        }
    }
}