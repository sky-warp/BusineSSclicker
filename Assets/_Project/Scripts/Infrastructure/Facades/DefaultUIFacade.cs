using _Project.Scripts.BusinessTotalAmount.View;

namespace _Project.Scripts.Infrastructure.Facades
{
    public class DefaultUIFacade : BaseUIFacade
    {
        private BaseBusinessView _businessWindowView;

        public DefaultUIFacade(BaseBusinessView businessWindowView) : base(businessWindowView)
        {
            _businessWindowView = businessWindowView;
        }

        public override void ShowTotalMoneyAmount(float amount)
        {
            _businessWindowView.ShowTotalAmountText(amount);
        }
    }
}