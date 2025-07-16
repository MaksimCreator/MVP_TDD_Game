using Newtonsoft.Json;
using System;

[Serializable]
public abstract class Storage : IUpdateble
{
    private const float TimeUpdate = Config.TimeUpdateStorage;

    [JsonProperty] private float _baseAddValue;
    [JsonProperty] private float _addValue;
    [JsonProperty] private float _baseRemoveValue;
    [JsonProperty] private float _removeValue; 
    [JsonProperty] private float _value;
    [JsonProperty] private float _timer;

    private bool _isAddTimer => _addValue > 0;
    private bool _isRemoveTimer => _removeValue > 0;

    public Storage(int startValue = 0)
    {
        _value = startValue;
    }

    public int GetValue()
    => (int)_value;

    public void Update(float deltaTime)
    {
        if (deltaTime <= 0)
            throw new InvalidOperationException();

        if (_isAddTimer == false && _isRemoveTimer == false)
            return;

        _timer += deltaTime;

        if (_timer >= TimeUpdate)
        {
            deltaTime -= _timer - TimeUpdate;
            _timer = 0;
        }

        float time = deltaTime / TimeUpdate;

        AddValueTime(time);
        RemoveValueTime(time);
    }

    protected void AddValue(int value)
    {
        if (value < 0)
            throw new InvalidOperationException();

        _baseAddValue = _addValue + value;
        _addValue += value;
        _timer = 0;
    }

    protected void RemoveValue(int value)
    {
        if(CanRemove(value) == false)
            throw new InvalidOperationException();

        _baseRemoveValue = _removeValue + value;
        _removeValue += value;
        _timer = 0;
    }

    protected bool CanRemove(int price)
    => _value >= price;

    private void AddValueTime(float delta)
    {
        if (_isAddTimer == false || _isRemoveTimer)
            return;

        _value += _baseAddValue * delta;
        _addValue -= _baseAddValue * delta;
    }

    private void RemoveValueTime(float delta)
    {
        if (_isRemoveTimer == false)
            return;

        _value -= _baseRemoveValue * delta;
        _removeValue -= _baseRemoveValue * delta;
    }
}