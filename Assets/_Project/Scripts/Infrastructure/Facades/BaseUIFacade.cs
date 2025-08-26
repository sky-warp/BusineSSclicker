using _Project.Scripts.BusinessTotalAmount.View;

namespace _Project.Scripts.Infrastructure.Facades
{
    public abstract class BaseUIFacade
    {
        protected BaseUIFacade(BaseBusinessView businessWindowView)
        {
        }

        public abstract void ShowTotalMoneyAmount(float amount);
    }
}