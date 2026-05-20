using Gum.Forms.Controls;
using Gum.GueDeriving;
using Microsoft.Xna.Framework;
using MonoGameGum;
using QuestToCompileGum.Components;
using System;
using System.Collections.Generic;

namespace QuestToCompileGum.Screens
{
    partial class MainScreen
    {
        readonly GameState _state = new();

        List<FloatingLabel> _floatingLabels = new();

        GumService GumUi => GumService.Default;

        partial void CustomInitialize()
        {
            BigButton.Click += HandleBigButtonClick;
            UpgradeClickButton.Click += (_, _) => { _state.BuyClickUpgrade(); UpdateUI(); };
            AutoClickButton.Click += (_, _) => { _state.BuyAutoUpgrade(); UpdateUI(); };

            UpdateUI();
        }

        private void HandleBigButtonClick(object sender, EventArgs e)
        {
            _state.HandleClick(); 
            UpdateUI();

            // Not yet ready for this:
            FloatingLabel label = new();
            label.X = GumUi.Cursor.XRespectingGumZoomAndBounds();
            label.Y = GumUi.Cursor.YRespectingGumZoomAndBounds();
            label.Text = $"+{_state.ClickPower}";
            label.AddToRoot();
            _floatingLabels.Add(label);
        }

        public void Update(GameTime gameTime)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            long before = _state.Score;
            _state.Update(dt);
            if (_state.Score != before) UpdateUI();

            for(int i = _floatingLabels.Count - 1; i >= 0; i--)
            {
                var label = _floatingLabels[i];
                label.Y -= dt * 50;
                ((TextRuntime)label.Visual).Alpha --;
                if (label.Y < -50)
                {
                    label.RemoveFromRoot();
                    _floatingLabels.RemoveAt(i);
                }
            }
        }

        void UpdateUI()
        {
            ScoreValue.Text = NumberFormatter.Format(_state.Score);
            ScoreSubtext.Text = $"+{_state.ClickPower} per click  +{_state.AutoClickPower}/sec auto";

            BigButton.Text = $"Click";
            BigButton.SubTextInstance.Text = $"\n+{_state.ClickPower} PER TAP";

            UpgradeClickButton.CostText = $"Cost: {NumberFormatter.Format(_state.ClickUpgradeCost)}";
            UpgradeClickButton.SubText = $"+1 per click";

            AutoClickButton.CostText = $"Cost: {NumberFormatter.Format(_state.AutoUpgradeCost)}";
            AutoClickButton.SubText = $"+1 per sec";

            UpgradeClickButton.IsEnabled = _state.Score >= _state.ClickUpgradeCost;
            AutoClickButton.IsEnabled = _state.Score >= _state.AutoUpgradeCost;
        }
    }
}
