using UnityEngine;
using System;

[CreateAssetMenu(fileName = "ItemInfo", menuName = "Scriptable Objects/Shop/ItemInfo")]
public class ItemInfo : ScriptableObject,IUpgradeArmy,IUpgradeMoneyTap,IUpgradeMoneyTime
{
    [SerializeField] private UpgradeInfo[] _queueUpgradeInfo;

    public int Lenght => _queueUpgradeInfo.Length;

    public UpgradeInfo GetCurentInfo(int index)
    {
        if (index < 0 || index > Lenght)
            throw new InvalidOperationException(nameof(index));

        return _queueUpgradeInfo[index];
    }
}
