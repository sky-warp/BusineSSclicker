using _Project.Scripts.BusinessTotalAmount.View;

namespace _Project.Scripts.Infrastructure.Facades
{
    public class DefaultUIFacade : BaseUIFacade
    {
        private BaseBusinessWindowView _businessWindowWindowView;

        public DefaultUIFacade(BaseBusinessWindowView businessWindowWindowView) : base(businessWindowWindowView)
        {
            _businessWindowWindowView = businessWindowWindowView;
        }

        public override void ShowTotalMoneyAmount(float amount)
        {
            _businessWindowWindowView.ShowTotalAmountText(amount);
        }
    }
}