using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class BasePanelView : MonoBehaviour
{
    [Header("Manager")]
    [SerializeField] private BasePanelManager _baseManager;

    [Header("ShopText")]
    [SerializeField] private TextMeshProUGUI _priceBuyArmy;
    [SerializeField] private TextMeshProUGUI _priceBuyClick;
    [SerializeField] private TextMeshProUGUI _priceBuyIncome;

    [SerializeField] private TextMeshProUGUI _descriptionsBuyArmy;
    [SerializeField] private TextMeshProUGUI _descriptionsBuyClick;
    [SerializeField] private TextMeshProUGUI _descriptionsBuyIncome;

    [Header("ShopButton")]
    [SerializeField] private Button _buyArmy;
    [SerializeField] private Button _buyClik;
    [SerializeField] private Button _buyPasiveIncome;

    [Header("ShopImageActive")]
    [SerializeField] private Image _activeBuyArmy;
    [SerializeField] private Image _activeBuyClik;
    [SerializeField] private Image _activeBuyPasiveIncome;

    [Header("ButtonGameActive")]
    [SerializeField] private Button _fight;
    [SerializeField] private Button _quet;

    [Header("TextGameCurency")]
    [SerializeField] private TextMeshProUGUI _army;
    [SerializeField] private TextMeshProUGUI _money;
    [SerializeField] private TextMeshProUGUI _paseveMoney;
    [SerializeField] private TextMeshProUGUI _moneyTap;

    [Header("TextImageMoneyTap")]
    [SerializeField] private List<TextMeshProUGUI> _listTextImageMoney;

    private IInputRouter _characterInput;
    private BaseGameplayPresenter _baseGameplayPresenter;
    private ShopPresenter _shopPresenter;

    [Inject]
    private void Construct(IInputRouter inputRouter, BaseGameplayPresenter baseGameplayPresenter, ShopPresenter shopPresenter)
    {
        _characterInput = inputRouter;
        _shopPresenter = shopPresenter;
        _baseGameplayPresenter = baseGameplayPresenter;
    }

    private void OnEnable()
    {
        _characterInput.onTap += _baseGameplayPresenter.Click;
        _fight.onClick.AddListener(_baseGameplayPresenter.StartGame);
        _buyArmy.onClick.AddListener(_shopPresenter.BuyArmy);
        _buyClik.onClick.AddListener(_shopPresenter.BuyClick);
        _buyPasiveIncome.onClick.AddListener(_shopPresenter.BuyDemocracy);
        _baseManager.OnEnable();
    }

    private void OnDisable()
    {
        _characterInput.onTap -= _baseGameplayPresenter.Click;
        _fight.onClick.RemoveListener(_baseGameplayPresenter.StartGame);
        _buyArmy.onClick.RemoveListener(_shopPresenter.BuyArmy);
        _buyClik.onClick.RemoveListener(_shopPresenter.BuyClick);
        _buyPasiveIncome.onClick.RemoveListener(_shopPresenter.BuyDemocracy);
        _baseManager.OnDisable();
    }

    private void Update()
    {
        _army.text = _baseGameplayPresenter.Army;
        _money.text = _baseGameplayPresenter.Money;
        _moneyTap.text = _baseGameplayPresenter.MoneyTap;
        _paseveMoney.text = _baseGameplayPresenter.MoneyTime;

        _descriptionsBuyArmy.text = _shopPresenter.ArmyIncrement;
        _descriptionsBuyClick.text = _shopPresenter.MoneyTapIncrement;
        _descriptionsBuyIncome.text = _shopPresenter.MoneyTimeIncrement;

        _priceBuyArmy.text = _shopPresenter.ArmyPrice;
        _priceBuyClick.text = _shopPresenter.MoneyTapPrice;
        _priceBuyIncome.text = _shopPresenter.MoneyTimePrice;

        for (int i = 0; i < _listTextImageMoney.Count; i++)
            _listTextImageMoney[i].text = _baseGameplayPresenter.MoneyTapImageMoney;

        TryActivatedShopButtons();
    }

    private void TryActivatedShopButtons()
    {
        if (_shopPresenter.CanBuyDemocracy)
        {
            _buyPasiveIncome.enabled = true;
            _activeBuyPasiveIncome.gameObject.SetActive(false);
        }
        else
        {
            _buyPasiveIncome.enabled = false;
            _activeBuyPasiveIncome.gameObject.SetActive(true);
        }

        if (_shopPresenter.CanBuyClick)
        {
            _buyClik.enabled = true;
            _activeBuyClik.gameObject.SetActive(false);
        }
        else
        {
            _buyClik.enabled = false;
            _activeBuyClik.gameObject.SetActive(true);
        }

        if (_shopPresenter.CanBuyArmy)
        {
            _buyArmy.enabled = true;
            _activeBuyArmy.gameObject.SetActive(false);
        }
        else
        {
            _buyArmy.enabled = false;
            _activeBuyArmy.gameObject.SetActive(true);
        }
    }
}