using System;
using Zenject;

public class Shop
{
    private readonly MoneyTimeUpgrader _moneyTime;
    private readonly MoneyTapUpgrade _moneyTap;
    private readonly ArmyUpgrader _army;
    
    #region Property

    public int PriceMoneyTime => _moneyTime.Price;

    public int IncrementMoneyTime => _moneyTime.Increment;

    public bool CanBuyMoneyTime => _moneyTime.IsMaxIndex == false && _moneyTime.CanBuy;

    public bool CanIsMaxIndexMoneyTime => _moneyTime.IsMaxIndex;

    public int PriceMoneyTap => _moneyTap.Price;

    public int IncrementMoneyTap => _moneyTap.Increment;

    public bool CanBuyMoneyTap => _moneyTap.IsMaxIndex == false && _moneyTap.CanBuy;

    public bool CanIsMaxIndexMoneyTap => _moneyTap.IsMaxIndex;

    public int PriceArmy => _army.Price;

    public int IncrementArmy => _army.Increment;

    public bool CanBuyArmy => _army.IsMaxIndex == false && _army.CanBuy;

    public bool CanIsMaxIndexArmy => _army.IsMaxIndex;

    #endregion

    [Inject]
    public Shop(MoneyTimeUpgrader moneyTime, MoneyTapUpgrade moneyTap, ArmyUpgrader army)
    {
        _moneyTime = moneyTime;
        _moneyTap = moneyTap;
        _army = army;
    }

    public void UpgraderMoneyTime()
    {
        if (CanBuyMoneyTime == false)
            throw new InvalidOperationException();

        _moneyTime.Buy();
    }

    public void UpgraderMoneyTap()
    {
        if(CanBuyMoneyTap == false)
            throw new InvalidOperationException();

        _moneyTap.Buy();
    }

    public void UpgraderArmy()
    {
        if(CanBuyArmy == false)
            throw new InvalidOperationException();

        _army.Buy();
    }
}
