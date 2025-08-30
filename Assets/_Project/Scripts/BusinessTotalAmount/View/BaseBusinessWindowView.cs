using UnityEngine;

namespace _Project.Scripts.BusinessTotalAmount.View
{
    public abstract class BaseBusinessWindowView : MonoBehaviour
    {
        public abstract void ShowTotalAmountText(float amount);
    }
}