using TMPro;
using UnityEngine;

namespace _Project.Scripts.BusinessTotalAmount.View
{
    public class BusinessWindowView : BaseBusinessWindowView
    {
        [SerializeField] private TextMeshProUGUI _totalAmountText;

        public override void SetTotalAmountText(float amount)
        {
            _totalAmountText.text = $"{amount:0.00} $";
        }
    }
}