using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.BusinessContainer.View
{
    public abstract class BaseBusinessContainerView : MonoBehaviour
    {
        [SerializeField] protected TextMeshProUGUI BusinessName;
        [SerializeField] protected TextMeshProUGUI CurrentLevel;
        [SerializeField] protected TextMeshProUGUI CurrentIncome;
        [SerializeField] protected Button LevelUpButton;
        [SerializeField] protected Button FirstUpgrade;
        [SerializeField] protected Button SecondUpgrade;

        public void TemplateMethod(string businessName, int level, float income, string lvlupButtonText,
            string firstUpgradeText,
            string secondUpgradeText)
        {
            SetBusinessName(businessName);
            SetCurrentLevel(level);
            SetCurrentIncome(income);
            SetLvlUpButtonText(lvlupButtonText);
            SetFirstUpgradeText(firstUpgradeText);
            SetSecondUpgradeText(secondUpgradeText);
        }

        public abstract void SetBusinessName(string businessName);
        public abstract void SetCurrentLevel(int level);
        public abstract void SetCurrentIncome(float income);
        public abstract void SetLvlUpButtonText(string text);
        public abstract void SetFirstUpgradeText(string text);
        public abstract void SetSecondUpgradeText(string text);
    }
}