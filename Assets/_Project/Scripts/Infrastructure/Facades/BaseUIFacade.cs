using _Project.Scripts.BusinessContainer.View;
using _Project.Scripts.BusinessTotalAmount.View;

namespace _Project.Scripts.Infrastructure.Facades
{
    public abstract class BaseUIFacade
    {
        protected BaseBusinessWindowView BusinessWindowView;
        protected BaseBusinessContainerFactory Factory;

        protected BaseUIFacade(BaseBusinessWindowView businessWindowView, BaseBusinessContainerFactory factory)
        {
            BusinessWindowView = businessWindowView;
            Factory = factory;
        }

        public abstract void ShowTotalMoneyAmount(float amount);
        public abstract BaseBusinessContainerView CreateBusinessContainer();
    }
}