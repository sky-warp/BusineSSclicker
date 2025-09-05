using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.BusinessContainer.View
{
    public abstract class BaseBusinessContainerView : MonoBehaviour
    {
        [field: SerializeField] public Image ProgressBar { get; private set; }
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

        protected abstract void SetBusinessName(string businessName);
        protected abstract void SetCurrentLevel(int level);
        protected abstract void SetCurrentIncome(float income);
        protected abstract void SetLvlUpButtonText(string text);
        protected abstract void SetFirstUpgradeText(string text);
        protected abstract void SetSecondUpgradeText(string text);
    }
}