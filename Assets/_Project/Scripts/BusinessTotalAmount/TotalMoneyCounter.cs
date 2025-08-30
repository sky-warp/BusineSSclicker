using _Project.Scripts.Infrastructure.Facades;
using Scellecs.Morpeh;

namespace _Project.Scripts.BusinessTotalAmount
{
    public class TotalMoneyCounter : ISystem
    {
        public World World { get; set; }

        private Filter _filter;
        private Stash<TotalBalance> _totalAmountStash;

        private BaseUIFacade _uiFacade;

        public TotalMoneyCounter(BaseUIFacade facade)
        {
            _uiFacade = facade;
        }
        
        public void OnAwake()
        {
            var totalAmount = this.World.CreateEntity();

            _totalAmountStash = this.World.GetStash<TotalBalance>();
            _totalAmountStash.Add(totalAmount);
            
            _filter = this.World.Filter.With<TotalBalance>().Build();
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
            _totalAmountStash.Dispose();
            _filter.Dispose();
        }
    }
}