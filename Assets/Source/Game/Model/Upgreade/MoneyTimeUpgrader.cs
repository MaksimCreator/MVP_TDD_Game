using Zenject;

public class MoneyTimeUpgrader : Upgrader
{
    private readonly MoneyTimeStorage _moneyTimeStorage;

    [Inject]
    public MoneyTimeUpgrader(MoneyTimeLoader armyLoader,
        MoneyLoader moneyLoader,
        IUpgradeMoneyTime itemInfo,
        GameDataLoader dataLoader) : base(
            dataLoader.Load(),
            moneyLoader.Load(),
            itemInfo as ItemInfo)
    {
        _moneyTimeStorage = armyLoader.Load();
    }

    protected override int GetCurentIndex(GameData gameData)
    => gameData.IndexMoneyTime;

    protected override void OnAddValueStorage(int increment)
    => _moneyTimeStorage.AddIncrementTime(increment);

    protected override void UpdateIdexInData(int newIndex)
    => __upgradeData.SetIndexMoneyTime(newIndex);
}