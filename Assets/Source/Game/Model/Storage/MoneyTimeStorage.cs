using System;

[Serializable]
public class MoneyTimeStorage : Storage 
{
    public void AddIncrementTime(int increment)
    => AddValue(increment);
}