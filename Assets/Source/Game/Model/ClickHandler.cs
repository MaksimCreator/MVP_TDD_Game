using Zenject;

public class ClickHandler : IControl,IUpdateble
{
    private readonly MoneyTimeStorage _moneyTimeStorage;
    private readonly MoneyTapStorage _moneyTapStorage;
    private readonly MoneyStorage _moneyStorage;
    private readonly Timer _timer;

    private bool _isEnable;

    [Inject]
    public ClickHandler(MoneyLoader moneyLoader,MoneyTapLoader moneyTapLoader,MoneyTimeLoader moneyTimeLoader)
    {
        _moneyTimeStorage = moneyTimeLoader.Load();
        _moneyTapStorage = moneyTapLoader.Load();
        _moneyStorage = moneyLoader.Load();

        _timer = new Timer(Config.DelayIncrementMoneyMinut, OnUpdateMoneyTime);
    }

    public void Click()
    {
        if (_isEnable == false)
            return;

        _moneyStorage.AddMoney(_moneyTapStorage.GetValue());
    }

    public void Enable()
    {
        _timer.Enable();
        _isEnable = true;
    }

    public void Disable()
    {
        _timer.Disable();
        _isEnable = false;
    }

    public void Update(float deltaTime)
    => _timer.Update(deltaTime);

    private void OnUpdateMoneyTime()
    =>  _moneyStorage.AddMoney(_moneyTimeStorage.GetValue());
}