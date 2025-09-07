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
            CurrentLevel.text = $"LVL: {level}";
        }

        protected override void SetCurrentIncome(float income)
        {
            CurrentIncome.text = $"Income: {income:0.00}";
        }

        protected override void SetLvlUpButtonText(string text, float price)
        {
            LevelUpButton.GetComponentInChildren<TextMeshProUGUI>().text = $"{text}: {price:0.00}";
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