using System;

[Serializable]
public class GameData
{
    public int IndexArmy { get; private set; }
    
    public int IndexMoneyTap { get; private set; }
    
    public int IndexMoneyTime { get; private set; }

    public int CurentEnemy { get; private set; }

    public void SetIndexArmy(int index)
    {
        if (index < 0)
            throw new ArgumentOutOfRangeException(nameof(index));

        IndexArmy = index;
    }

    public void SetIndexMoneyTap(int index)
    {
        if (index < 0)
            throw new ArgumentOutOfRangeException(nameof(index));

        IndexMoneyTap = index;
    }

    public void SetIndexMoneyTime(int index)
    {
        if (index < 0)
            throw new ArgumentOutOfRangeException(nameof(index));

        IndexMoneyTime = index;
    }

}