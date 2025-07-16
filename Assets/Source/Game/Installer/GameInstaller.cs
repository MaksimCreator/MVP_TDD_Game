using Zenject;
using UnityEngine;
public class GameInstaller : MonoInstaller
{
    [Header("SO")]
    [SerializeField] private ItemInfo _soUpgradeTap;
    [SerializeField] private ItemInfo _soUpgradeMoneyTime;
    [SerializeField] private ItemInfo _soUpgradeArmy;

    public override void InstallBindings()
    {
        RegistarySO();
        RegistarySaveLoaderGame();
        RegistaryGameRepositiory();
        RegistaryLoader();
    }

    private void RegistarySO()
    {
        Container.Bind<IUpgradeArmy>()
            .To<ItemInfo>()
            .FromInstance(_soUpgradeArmy)
            .AsCached();

        Container.Bind<IUpgradeMoneyTap>()
            .To<ItemInfo>()
            .FromInstance(_soUpgradeTap)
            .AsCached();

        Container.Bind<IUpgradeMoneyTime>()
            .To<ItemInfo>()
            .FromInstance(_soUpgradeMoneyTime)
            .AsCached();
    }

    private void RegistarySaveLoaderGame()
    {
        Container.Bind<ISaveLoaderGame>()
            .To<SaveLoaderGame>()
            .FromNew()
            .AsSingle();
    }

    private void RegistaryGameRepositiory()
    {
        Container.Bind<IGameRepository>()
            .To<GameRepository>()
            .FromNew()
            .AsSingle();
    }

    private void RegistaryLoader()
    {
        Container.Bind<ArmyLoader>()
            .FromNew()
            .AsSingle();

        Container.Bind<MoneyLoader>()
            .FromNew()
            .AsSingle();

        Container.Bind<MoneyTapLoader>()
            .FromNew()
            .AsSingle();

        Container.Bind<MoneyTimeLoader>()
            .FromNew()
            .AsSingle();

        Container.Bind<GameDataLoader>()
            .FromNew()
            .AsSingle();
    }
}