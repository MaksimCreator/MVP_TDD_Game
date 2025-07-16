using Zenject;

public class ArmyUpgrader : Upgrader
{
    private readonly ArmyStorage _armorStorage;

    [Inject]
    public ArmyUpgrader(
        ArmyLoader armyLoader,
        MoneyLoader moneyLoader,
        GameDataLoader dataLoader,
        IUpgradeArmy itemInfo) : base(
            dataLoader.Load(),
            moneyLoader.Load(),
            itemInfo as ItemInfo)
    {
        _armorStorage = armyLoader.Load();
    }

    protected override int GetCurentIndex(GameData gameData)
    => gameData.IndexArmy;

    protected override void OnAddValueStorage(int increment)
    => _armorStorage.AddArmy(increment);

    protected override void UpdateIdexInData(int newIndex)
    => __upgradeData.SetIndexArmy(newIndex);
}
