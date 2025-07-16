using NUnit.Framework;
using System;
using System.Reflection;
using UnityEditor.Animations;
using UnityEngine;

namespace UnitTest
{
    public abstract class BaseTest
    {
        protected int __priceFirstUpgradeInfo = 100;
        protected int __priceSecondUpgradeInfo = 200;
        protected int __incrementFirstUpgrade = 15;
        protected int __incrementSecondUpgrade = 27;

        [SetUp]
        public void RegistaryAllService()
        {
            #region RegistaryModel

            ISaveLoaderGame saveLoaderGame = new SaveLoaderGame();
            IGameRepository gameRepository = new GameRepository(saveLoaderGame);

            ArmyLoader armyLoader = new ArmyLoader(gameRepository);
            MoneyLoader moneyLoader = new MoneyLoader(gameRepository);
            GameDataLoader gameDataLoader = new GameDataLoader(gameRepository);
            MoneyTapLoader moneyTapLoader = new MoneyTapLoader(gameRepository);
            MoneyTimeLoader moneyTimeLoader = new MoneyTimeLoader(gameRepository);

            RegistaryService(saveLoaderGame);
            RegistaryService(gameRepository);

            #region RegistaryLoader

            RegistaryService(armyLoader);
            RegistaryService(moneyLoader);
            RegistaryService(gameDataLoader);
            RegistaryService(moneyTapLoader);
            RegistaryService(moneyTimeLoader);

            #endregion
            #region InitializeUpgradeData

            UpgradeInfo upgradeInfoFirst = new UpgradeInfo();
            UpgradeInfo upgradeInfoSecond = new UpgradeInfo();
            UpgradeInfo[] listUpgrades =
            {
            upgradeInfoFirst,
            upgradeInfoSecond
        };

            InitializeUpgradeInfo(upgradeInfoFirst, __priceFirstUpgradeInfo, __incrementFirstUpgrade);
            InitializeUpgradeInfo(upgradeInfoSecond, __priceSecondUpgradeInfo, __incrementSecondUpgrade);

            ItemInfo moneyTimeInfo = new ItemInfo();
            ItemInfo armyInfo = new ItemInfo();
            ItemInfo moneyTapInfo = new ItemInfo();

            InitializeItemInfo(moneyTimeInfo, listUpgrades);
            InitializeItemInfo(armyInfo, listUpgrades);
            InitializeItemInfo(moneyTapInfo, listUpgrades);

            #endregion
            #region RegistaryUpgrader

            ArmyUpgrader armyUpgrader = new ArmyUpgrader(armyLoader, moneyLoader, gameDataLoader, armyInfo);
            MoneyTapUpgrade moneyTapUpgrader = new MoneyTapUpgrade(moneyLoader, moneyTapLoader, gameDataLoader, moneyTapInfo);
            MoneyTimeUpgrader moneyTimeUpgrader = new MoneyTimeUpgrader(moneyTimeLoader, moneyLoader, moneyTimeInfo, gameDataLoader);

            RegistaryService(armyUpgrader);
            RegistaryService(moneyTapUpgrader);
            RegistaryService(moneyTimeUpgrader);

            #endregion

            Shop shop = new Shop(moneyTimeUpgrader, moneyTapUpgrader, armyUpgrader);
            ClickHandler clickHandler = new ClickHandler(moneyLoader, moneyTapLoader, moneyTimeLoader);

            RegistaryService(clickHandler);
            RegistaryService(shop);

            #endregion

            #region RegistaryAnimatorAnimation

            IBuyArmy buyArmyAnimator = new ButtonAnimator(CreatAnimator(nameof(ConstantAnimation.ButtonAnimation)));
            IBuyDemocracy buyDemocracyAnimator = new ButtonAnimator(CreatAnimator(nameof(ConstantAnimation.ButtonAnimation)));
            IBuyClick buyClickAnimator = new ButtonAnimator(CreatAnimator(nameof(ConstantAnimation.ButtonAnimation)));

            ClickAnimator clickAnimator = new ClickAnimator(CreatAnimator(nameof(ConstantAnimation.Click)));
            StartGameAnimator startGameAnimator = new StartGameAnimator(CreatAnimator(nameof(ConstantAnimation.StartGame)));

            RegistaryService(buyArmyAnimator);
            RegistaryService(buyDemocracyAnimator);
            RegistaryService(buyClickAnimator);

            RegistaryService(clickAnimator);
            RegistaryService(startGameAnimator);


            #endregion
        }

        protected TService GetSevice<TService>()
        => Implementation<TService>.Instance;

        protected Animator CreatAnimator(string name)
        {
            GameObject gameObject = new GameObject();
            Animator animator = gameObject.AddComponent<Animator>();

            AnimationClip clip = new AnimationClip();
            AnimationCurve curve = AnimationCurve.Constant(0, 1, 2);
            clip.SetCurve(String.Empty, typeof(Transform), "position.x", curve);

            AnimatorController controller = animator.runtimeAnimatorController as AnimatorController;
            controller.AddMotion(clip);
            clip.name = nameof(name);

            return animator;
        }

        private void RegistaryService<TService>(TService service)
        => Implementation<TService>.Instance = service;

        private void InitializeUpgradeInfo(UpgradeInfo upgradeInfo, int price, int increment)
        {
            const string PriceName = "_price";
            const string IncrementName = "_increment";

            Type type = typeof(UpgradeInfo);

            FieldInfo fieldInfoPrice = type.GetField(PriceName, BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo fieldInfoIncrement = type.GetField(IncrementName, BindingFlags.NonPublic | BindingFlags.Instance);

            if (fieldInfoIncrement == null)
                throw new InvalidOperationException(nameof(fieldInfoIncrement));

            if (fieldInfoPrice == null)
                throw new InvalidOperationException(nameof(fieldInfoPrice));

            fieldInfoIncrement.SetValue(upgradeInfo, increment);
            fieldInfoPrice.SetValue(upgradeInfo, price);
        }

        private void InitializeItemInfo(ItemInfo itemInfo, UpgradeInfo[] listUpgrade)
        {
            const string arrayInfo = "_queueUpgradeInfo";

            Type type = typeof(ItemInfo);

            FieldInfo fieldInfo = type.GetField(arrayInfo, BindingFlags.NonPublic | BindingFlags.Instance);

            if (fieldInfo == null)
                throw new InvalidOperationException();

            fieldInfo.SetValue(itemInfo, listUpgrade);
        }

        private static class Implementation<TService>
        {
            public static TService Instance;
        }
    }
}