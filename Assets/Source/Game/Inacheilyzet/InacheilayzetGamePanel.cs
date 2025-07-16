using UnityEngine;
using Zenject;

public class InacheilayzetGamePanel
{
    [SerializeField] private Sprite _target;

    private AddresablesController _addresablesController;

    [Inject]
    private void Construct(AddresablesController addresablesController)
    {
        _addresablesController = addresablesController;
    }
}