using Zenject;
using System;

public class ShopPresenter
{
    private readonly Shop _shop;

    private readonly ButtonAnimator _buyClickAnimator;
    private readonly ButtonAnimator _buyDemocracyAnimator;
    private readonly ButtonAnimator _buyArmyAnimator;

    public bool CanBuyClick => _shop.CanBuyMoneyTap;

    public bool CanBuyDemocracy => _shop.CanBuyMoneyTime;

    public bool CanBuyArmy => _shop.CanBuyArmy;

    public string MoneyTapPrice => StringConverter.GetConvertString(_shop.PriceMoneyTap);

    public string MoneyTapIncrement => '+' + StringConverter.GetConvertString(_shop.IncrementMoneyTap) + "/tap";

    public string MoneyTimePrice => StringConverter.GetConvertString(_shop.PriceMoneyTime);

    public string MoneyTimeIncrement => '+' + StringConverter.GetConvertString(_shop.IncrementMoneyTime) + "/мин";

    public string ArmyPrice => StringConverter.GetConvertString(_shop.PriceArmy);

    public string ArmyIncrement => '+' + StringConverter.GetConvertString(_shop.IncrementArmy) + "/ед.сил";

    [Inject]
    public ShopPresenter(Shop shop,IBuyArmy buyArmyAnimator, IBuyClick buyClickAnimator,IBuyDemocracy buyDemocracyAnimator)
    {
        _shop = shop;
        _buyClickAnimator = buyClickAnimator as ButtonAnimator;
        _buyArmyAnimator = buyArmyAnimator as ButtonAnimator;
        _buyDemocracyAnimator = buyDemocracyAnimator as ButtonAnimator;
    }

    public void BuyClick()
    {
        if (CanBuyClick == false)
            throw new InvalidOperationException();

        _shop.UpgraderMoneyTap();
        _buyClickAnimator.EnterButtonAnimation();
    }

    public void BuyDemocracy()
    {
        if (CanBuyDemocracy == false)
            throw new InvalidOperationException();

        _shop.UpgraderMoneyTime();
        _buyDemocracyAnimator.EnterButtonAnimation();
    }

    public void BuyArmy()
    {
        if (CanBuyArmy == false)
            throw new InvalidOperationException();

        _shop.UpgraderArmy();
        _buyArmyAnimator.EnterButtonAnimation();
    }
}