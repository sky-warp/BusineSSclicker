using TMPro;

namespace _Project.Scripts.BusinessContainer.View
{
    public class DefaultBusinessContainerView : BaseBusinessContainerView
    {
        public override void SetBusinessName(string businessName)
        {
            BusinessName.text = businessName;
        }

        public override void SetCurrentLevel(int level)
        {
            CurrentLevel.text = level.ToString();
        }

        public override void SetCurrentIncome(float income)
        {
            CurrentIncome.text = income.ToString();
        }

        public override void SetLvlUpButtonText(string text)
        {
            LevelUpButton.GetComponentInChildren<TextMeshProUGUI>().text = text;
        }

        public override void SetFirstUpgradeText(string text)
        {
            FirstUpgrade.GetComponentInChildren<TextMeshProUGUI>().text = text;
        }

        public override void SetSecondUpgradeText(string text)
        {
            SecondUpgrade.GetComponentInChildren<TextMeshProUGUI>().text = text;
        }
    }
}