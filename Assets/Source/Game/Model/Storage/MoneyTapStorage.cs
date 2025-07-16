using System;

[Serializable]
public class MoneyTapStorage : Storage
{
    private const int StartValueStorage = 1;

    public MoneyTapStorage(int value = StartValueStorage) : base(value) { }

    public void AddIncrementTap(int increment)
    => AddValue(increment);
}