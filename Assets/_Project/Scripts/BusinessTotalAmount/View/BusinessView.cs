using TMPro;
using UnityEngine;

namespace _Project.Scripts.BusinessTotalAmount.View
{
    public class BusinessView : BaseBusinessView
    {
        [SerializeField] private TextMeshProUGUI _totalAmountText;

        public override void ShowTotalAmountText(float amount)
        {
            _totalAmountText.text = amount.ToString();
        }
    }
}