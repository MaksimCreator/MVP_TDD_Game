using UnityEngine;
using Zenject;

public class InacheilayzetBasePanel : MonoBehaviour
{
    [SerializeField] private Sprite _putin;
    [SerializeField] private Sprite _figth;
    [SerializeField] private Sprite _background;
    [SerializeField] private Sprite _enterMenu;
    [SerializeField] private Sprite _buyClick;
    [SerializeField] private Sprite _buyPasive;
    [SerializeField] private Sprite _buyArmy;

    private AddresablesController _addresablesController;

    [Inject]
    private void Construct(AddresablesController addresablesController)
    {
        _addresablesController = addresablesController;
    }
}
