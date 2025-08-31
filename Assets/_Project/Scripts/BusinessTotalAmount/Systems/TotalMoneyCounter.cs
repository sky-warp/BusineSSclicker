using _Project.Scripts.BusinessTotalAmount.Components;
using Scellecs.Morpeh;

namespace _Project.Scripts.BusinessTotalAmount.Systems
{
    public class TotalMoneyCounter : ISystem
    {
        public World World { get; set; }

        private Filter _totalBalanceEntities;
        private Stash<TotalBalance> _totalAmountStash;

        public void OnAwake()
        {
            var totalAmount = this.World.CreateEntity();

            _totalAmountStash = this.World.GetStash<TotalBalance>();
            _totalAmountStash.Add(totalAmount);

            _totalBalanceEntities = this.World.Filter.With<TotalBalance>().Build();
        }

        public void OnUpdate(float deltaTime)
        {
            //Calculate total amount
        }

        public void Dispose()
        {
            _totalAmountStash.Dispose();
            _totalBalanceEntities.Dispose();
        }
    }
}