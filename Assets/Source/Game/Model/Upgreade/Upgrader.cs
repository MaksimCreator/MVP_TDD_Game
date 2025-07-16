using System;

public abstract class Upgrader
{
    protected readonly GameData __upgradeData;

    private readonly MoneyStorage _moneyStorage;
    private readonly ItemInfo _itemInfo;
    private readonly int _maxIndex;

    private UpgradeInfo _upgradeInfo;
    private int _curentIndex;

    public int Price => _upgradeInfo.Price;

    public int Increment => _upgradeInfo.Increment;

    public bool CanBuy => _moneyStorage.CanRemove(_upgradeInfo.Price);

    public bool IsMaxIndex => _curentIndex == _maxIndex;

    public Upgrader(GameData upgradeData,MoneyStorage moneyStorage,ItemInfo itemInfo)
    {
        __upgradeData = upgradeData;

        _moneyStorage = moneyStorage;
        _itemInfo = itemInfo;
        _maxIndex = itemInfo.Lenght;

        _curentIndex = GetCurentIndex(upgradeData);
        _upgradeInfo = itemInfo.GetCurentInfo(_curentIndex);
    }

    public void Buy()
    {
        if (IsMaxIndex)
            throw new InvalidOperationException();

        if (_curentIndex < 0)
            throw new InvalidOperationException();

        if (_curentIndex > _maxIndex)
            throw new InvalidOperationException();

        if (CanBuy == false)
            throw new InvalidOperationException();

        _moneyStorage.RemoveMoney(Price);
        OnAddValueStorage(Increment);
        _curentIndex++;

        UpdateIdexInData(_curentIndex);

        if(IsMaxIndex == false)
            _upgradeInfo = _itemInfo.GetCurentInfo(_curentIndex);
        else
            _upgradeInfo = null;
    }

    protected abstract int GetCurentIndex(GameData gameData);

    protected abstract void UpdateIdexInData(int newIndex);

    protected abstract void OnAddValueStorage(int increment);
}