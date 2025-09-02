using _Project.Scripts.BusinessContainer.View;
using _Project.Scripts.BusinessTotalAmount.View;

namespace _Project.Scripts.Infrastructure.Facades
{
    public class DefaultUIFacade : BaseUIFacade
    {
        public DefaultUIFacade(BaseBusinessWindowView businessWindowView, BaseBusinessContainerFactory factory) :
            base(businessWindowView, factory)
        {
        }

        public override void ShowTotalMoneyAmount(float amount)
        {
            BusinessWindowView.ShowTotalAmountText(amount);
        }

        public override BaseBusinessContainerView CreateBusinessContainer()
        {
            return Factory.Create();
        }
    }
}