namespace QuestToCompileGum;

public class GameState
{
    public long Score;
    public int ClickPower = 1;
    public int AutoClickPower = 0;
    public int ClickUpgradeCost = 10;
    public int AutoUpgradeCost = 50;
    public float AutoClickTimer = 0f;

    const float CostMultiplier = 1.15f;

    public void HandleClick() => Score += ClickPower;

    public bool BuyClickUpgrade()
    {
        if (Score < ClickUpgradeCost) return false;
        Score -= ClickUpgradeCost;
        ClickPower++;
        ClickUpgradeCost = (int)(ClickUpgradeCost * CostMultiplier);
        return true;
    }

    public bool BuyAutoUpgrade()
    {
        if (Score < AutoUpgradeCost) return false;
        Score -= AutoUpgradeCost;
        AutoClickPower++;
        AutoUpgradeCost = (int)(AutoUpgradeCost * CostMultiplier);
        return true;
    }

    public void Update(float dt)
    {
        if (AutoClickPower == 0) return;
        AutoClickTimer += dt;
        while (AutoClickTimer >= 1.0f)
        {
            Score += AutoClickPower;
            AutoClickTimer -= 1.0f;
        }
    }
}
