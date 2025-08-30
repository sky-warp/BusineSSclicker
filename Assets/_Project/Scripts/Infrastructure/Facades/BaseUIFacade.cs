using _Project.Scripts.BusinessTotalAmount.View;

namespace _Project.Scripts.Infrastructure.Facades
{
    public abstract class BaseUIFacade
    {
        protected BaseUIFacade(BaseBusinessWindowView businessWindowWindowView)
        {
        }

        public abstract void ShowTotalMoneyAmount(float amount);
    }
}