using Zenject;
using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using TMPro;

public class BaseSceneInstaller : MonoInstaller
{
    [Header("Animator")]
    [SerializeField] private List<Image> _listAnimatorsMoneyImage;
    [SerializeField] private List<TextMeshProUGUI> _listAnimatorsMoneyText;
    [SerializeField] private Animator _clickAnimator;

    [SerializeField] private Animator _buyDemocracyAnimator;
    [SerializeField] private Animator _buyClickAnimator;
    [SerializeField] private Animator _buyArmyAnimator;

    [SerializeField] private Animator _startGameButtonAnimator;

    [Header("Manager")]
    [SerializeField] private BasePanelManager _basePanelManager;

    private ImageMoneyAnimation[] _imageMoneyAnimations;

    public override void InstallBindings()
    {
        if (_listAnimatorsMoneyImage.Count != _listAnimatorsMoneyText.Count)
            throw new InvalidOperationException();

        RegistaryInput();
        RegistaryUpgrade();
        RegistaryShop();
        RegistaryClickHandler();
        RegistaryAnimation();
        RegistaryCatalog();
        RegistaryAnimator();
        RegistaryPresenter();
        RegistaryManager();
    }

    private ImageMoneyAnimation[] GetImageAnimation()
    {
        if(_imageMoneyAnimations != null)
            return _imageMoneyAnimations;

        for (int i = 0; i < _listAnimatorsMoneyText.Count; i++)
            _imageMoneyAnimations[i] = new ImageMoneyAnimation(_listAnimatorsMoneyImage[i], _listAnimatorsMoneyText[i]);

        return _imageMoneyAnimations;
    }

    private void RegistaryInput()
    {
        Container.Bind<IInputRouter>()
            .To<InputRouter>()
            .FromNew()
            .AsSingle();
    }

    private void RegistaryUpgrade()
    {
        Container.Bind<ArmyUpgrader>()
            .FromNew()
            .AsSingle();

        Container.Bind<MoneyTapUpgrade>()
            .FromNew()
            .AsSingle();

        Container.Bind<MoneyTimeUpgrader>()
            .FromNew()
            .AsSingle();
    }

    private void RegistaryClickHandler()
    {
        Container.Bind<ClickHandler>()
            .FromNew()
            .AsSingle();
    }

    private void RegistaryAnimation()
    {
        Container.Bind<AnimationImageMoney>()
            .FromInstance(new AnimationImageMoney(GetImageAnimation()))
            .AsSingle();
    }

    private void RegistaryCatalog()
    {
        Container.Bind<AnimationCatalog>()
            .FromInstance(new AnimationCatalog(GetImageAnimation()))
            .AsSingle();
    }

    private void RegistaryAnimator()
    {
        Container.Bind<IBuyArmy>()
            .To<ButtonAnimator>()
            .FromInstance(new ButtonAnimator(_buyArmyAnimator))
            .AsCached();

        Container.Bind<IBuyClick>()
            .To<ButtonAnimator>()
            .FromInstance(new ButtonAnimator(_buyClickAnimator))
            .AsCached();

        Container.Bind<IBuyDemocracy>()
            .To<ButtonAnimator>()
            .FromInstance(new ButtonAnimator(_buyDemocracyAnimator))
            .AsCached();

        Container.Bind<ClickAnimator>()
            .FromInstance(new ClickAnimator(_clickAnimator))
            .AsSingle();

        Container.Bind<StartGameAnimator>()
            .FromInstance(new StartGameAnimator(_startGameButtonAnimator))
            .AsSingle();
    }

    private void RegistaryPresenter()
    {
        Container.Bind<BaseGameplayPresenter>()
            .FromNew()
            .AsSingle();

        Container.Bind<ShopPresenter>()
            .FromNew()
            .AsSingle();
    }

    private void RegistaryManager()
    {
        Container.Bind<BasePanelManager>()
            .FromInstance(_basePanelManager)
            .AsSingle();
    }
    
    private void RegistaryShop()
    {
        Container.Bind<Shop>()
            .FromNew()
            .AsSingle();
    }
}
