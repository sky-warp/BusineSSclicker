using _Project.Scripts.Infrastructure.Facades;
using Scellecs.Morpeh;

namespace _Project.Scripts.BusinessTotalAmount
{
    public class TotalMoneySystem : ISystem
    {
        public World World { get; set; }

        private Filter _filter;
        private Stash<TotalBalanceComponent> _totalAmountStash;

        private BaseUIFacade _uiFacade;

        public TotalMoneySystem(BaseUIFacade facade)
        {
            _uiFacade = facade;
        }
        
        public void OnAwake()
        {
            var entity = this.World.CreateEntity();

            _totalAmountStash = this.World.GetStash<TotalBalanceComponent>();
            ref var totalAmount = ref _totalAmountStash.Add(entity);
            
            _filter = this.World.Filter.With<TotalBalanceComponent>().Build();
        }

        public void OnUpdate(float deltaTime)
        {
            if (_filter.GetLengthSlow() < 1)
            {
                return;
            }

            foreach (var entity in _filter)
            {
                ref var totalAmount = ref _totalAmountStash.Get(entity);
                
                _uiFacade.ShowTotalMoneyAmount(totalAmount.TotalMoneyAmount);
            }
        }

        public void Dispose()
        {
        }
    }
}