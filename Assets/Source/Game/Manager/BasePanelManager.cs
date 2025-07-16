using UnityEngine;
using Zenject;

public class BasePanelManager : MonoBehaviour
{
    private IControl[] _controls;
    private IUpdateble[] _updatebles;

    [Inject]
    private void Construct(
        AnimationImageMoney animationImageMoney,
        AnimationCatalog catalog,
        MoneyTimeLoader moneyTimeLoader,
        MoneyTapLoader moneyTapLoader,
        ArmyLoader armyLoader,
        MoneyLoader moneyLoader,
        ClickHandler clickHandler,
        IInputRouter inputRouter)
    {
        _controls = new IControl[]
        {
            inputRouter as InputRouter,
            animationImageMoney,
            clickHandler
        };

        _updatebles = new IUpdateble[]
        {
            moneyTimeLoader.Load(),
            moneyTapLoader.Load(),
            moneyLoader.Load(),
            armyLoader.Load(),
            clickHandler,
            catalog
        };
    }

    public void OnEnable()
    {
        for (int i = 0; i < _controls.Length; i++)
            _controls[i].Enable();
    }

    public void OnDisable()
    {
        for (int i = 0; i < _controls.Length; i++)
            _controls[i].Disable();
    }

    private void Update()
    {
        for (int i = 0; i < _updatebles.Length; i++)
            _updatebles[i].Update(Time.deltaTime);
    }
}
