using Microsoft.Xna.Framework;

namespace QuestToCompileGum.Screens
{
    partial class MainScreen
    {
        readonly GameState _state = new();

        partial void CustomInitialize()
        {
            BigButton.Click += (_, _) => { _state.HandleClick(); UpdateUI(); };
            UpgradeClickButton.Click += (_, _) => { _state.BuyClickUpgrade(); UpdateUI(); };
            AutoClickButton.Click += (_, _) => { _state.BuyAutoUpgrade(); UpdateUI(); };

            UpdateUI();
        }

        public void Update(GameTime gameTime)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            long before = _state.Score;
            _state.Update(dt);
            if (_state.Score != before) UpdateUI();
        }

        void UpdateUI()
        {
            ScoreValue.Text = NumberFormatter.Format(_state.Score);
            ScoreSubtext.Text = $"+{_state.ClickPower} per click  +{_state.AutoClickPower}/sec auto";

            BigButton.Text = $"Click\n+{_state.ClickPower} PER TAP";

            UpgradeClickButton.CostText = $"Cost: {NumberFormatter.Format(_state.ClickUpgradeCost)}";
            UpgradeClickButton.SubText = $"+1 per click";

            AutoClickButton.CostText = $"Cost: {NumberFormatter.Format(_state.AutoUpgradeCost)}";
            AutoClickButton.SubText = $"+1 per sec";

            UpgradeClickButton.IsEnabled = _state.Score >= _state.ClickUpgradeCost;
            AutoClickButton.IsEnabled = _state.Score >= _state.AutoUpgradeCost;
        }
    }
}
