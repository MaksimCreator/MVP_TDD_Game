using Zenject;

public class MoneyTapUpgrade : Upgrader
{
    private readonly MoneyTapStorage _moneyStorage;

    [Inject]
    public MoneyTapUpgrade(MoneyLoader moneyLoader,
        MoneyTapLoader moneyTapLoader,
        GameDataLoader dataLoader,
        IUpgradeMoneyTap itemInfo) : base(
            dataLoader.Load(),
            moneyLoader.Load(),
            itemInfo as ItemInfo)
    {
        _moneyStorage = moneyTapLoader.Load();
    }

    protected override int GetCurentIndex(GameData gameData)
    => gameData.IndexMoneyTap;

    protected override void OnAddValueStorage(int increment)
    => _moneyStorage.AddIncrementTap(increment);

    protected override void UpdateIdexInData(int newIndex)
    => __upgradeData.SetIndexMoneyTap(newIndex);
}
