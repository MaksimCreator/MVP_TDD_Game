using System;

[Serializable]
public class MoneyStorage : Storage 
{
    public void AddMoney(int money)
    => AddValue(money);

    public void RemoveMoney(int money)
    => RemoveValue(money);

    public new bool CanRemove(int price)
    => base.CanRemove(price);
}