using TMPro;

namespace _Project.Scripts.BusinessContainer.View
{
    public class DefaultBusinessContainerView : BaseBusinessContainerView
    {
        protected override void SetBusinessName(string businessName)
        {
            BusinessName.text = businessName;
        }

        protected override void SetCurrentLevel(int level)
        {
            CurrentLevel.text = level.ToString();
        }

        protected override void SetCurrentIncome(float income)
        {
            CurrentIncome.text = income.ToString();
        }

        protected override void SetLvlUpButtonText(string text)
        {
            LevelUpButton.GetComponentInChildren<TextMeshProUGUI>().text = text;
        }

        protected override void SetFirstUpgradeText(string text)
        {
            FirstUpgrade.GetComponentInChildren<TextMeshProUGUI>().text = text;
        }

        protected override void SetSecondUpgradeText(string text)
        {
            SecondUpgrade.GetComponentInChildren<TextMeshProUGUI>().text = text;
        }
    }
}