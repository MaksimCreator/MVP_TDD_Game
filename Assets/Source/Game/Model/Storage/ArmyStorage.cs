using System;

[Serializable]
public class ArmyStorage : Storage 
{
    public void AddArmy(int army)
    => AddValue(army);
}