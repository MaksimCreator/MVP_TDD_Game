using Zenject;

public class BaseGameplayPresenter
{
    private readonly MoneyStorage _moneyStorage;
    private readonly MoneyTapStorage _moneyTapStorage;
    private readonly MoneyTimeStorage _moneyTimeStorage;
    private readonly ArmyStorage _armyStorage;

    private readonly ClickHandler _clickHandler;
    private readonly ClickAnimator _clickAnimator;
    private readonly AnimationImageMoney _animationImage;
    private readonly StartGameAnimator _startGameAnimator;

    public string Money => StringConverter.GetConvertString(_moneyStorage.GetValue());

    public string MoneyTap => StringConverter.GetConvertString(_moneyTapStorage.GetValue()) + "/tap";

    public string MoneyTime => StringConverter.GetConvertString(_moneyTimeStorage.GetValue()) + "/мин";

    public string Army => StringConverter.GetConvertString(_armyStorage.GetValue()) + "/ед.сил";

    public string MoneyTapImageMoney => "+" + StringConverter.GetConvertString(_moneyTapStorage.GetValue());

    [Inject]
    public BaseGameplayPresenter(
        MoneyLoader moneyLoader, 
        MoneyTapLoader moneyTapLoader, 
        MoneyTimeLoader moneyTimeLoader,
        ArmyLoader armyLoader,
        ClickHandler clickManager,
        ClickAnimator clickAnimator,
        StartGameAnimator startGameAnimator,
        AnimationImageMoney animationImage)
    {
        _clickHandler = clickManager;
        _clickAnimator = clickAnimator;
        _startGameAnimator = startGameAnimator;
        _animationImage = animationImage;

        _moneyStorage = moneyLoader.Load();
        _moneyTapStorage = moneyTapLoader.Load();
        _moneyTimeStorage = moneyTimeLoader.Load();
        _armyStorage = armyLoader.Load();
    }

    public void Click()
    {
        _clickHandler.Click();
        _clickAnimator.EnterClick();
        _animationImage.EnterImage();
    }

    public void StartGame()
    {

    }
}