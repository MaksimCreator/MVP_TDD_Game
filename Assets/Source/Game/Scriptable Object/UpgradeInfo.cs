using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeInfo", menuName = "Scriptable Objects/Shop/UpgradeInfo")]
public class UpgradeInfo : ScriptableObject
{
    [SerializeField] private int _price;
    [SerializeField] private int _increment;

    public int Price => _price;

    public int Increment => _increment;
}