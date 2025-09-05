using _Project.Scripts.BusinessContainer.Components;
using _Project.Scripts.BusinessTotalAmount.Components;
using Scellecs.Morpeh;

namespace _Project.Scripts.BusinessTotalAmount.Systems
{
    public class TotalMoneyCounter : ISystem
    {
        public World World { get; set; }

        private Filter _allBusinesses;
        private Stash<TotalBalance> _totalAmountStash;
        private Stash<BusinessData> _businessDataStash;

        private TotalBalance _totalBalance;

        public void OnAwake()
        {
            var totalAmount = this.World.CreateEntity();

            _totalAmountStash = this.World.GetStash<TotalBalance>();
            ref var totalBalance = ref _totalAmountStash.Add(totalAmount);
            _totalBalance = totalBalance;

            _businessDataStash = this.World.GetStash<BusinessData>();

            _allBusinesses = this.World.Filter.With<BusinessData>().Build();
        }

        public void OnUpdate(float deltaTime)
        {
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
                }
            }
        }

        private void IncreaseTotalBalance(float value)
        {
            _totalBalance.TotalMoneyAmount += value;
        }

        private void DecreaseTotalBalance(float value)
        {
            _totalBalance.TotalMoneyAmount -= value;
        }

        public void Dispose()
        {
            _totalAmountStash.Dispose();
        }
    }
}