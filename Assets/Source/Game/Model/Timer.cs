using System;

public class Timer : IControl,IUpdateble
{
    private readonly float _delay;
    private readonly Action _onEnd;

    private float _timer;
    private bool _isRunning;

    public Timer(float delay,Action onEnd)
    {
        _delay = delay;
        _timer = delay;
        _isRunning = false;
        _onEnd = onEnd;
    }

    public void Enable()
    => _isRunning = true;

    public void Disable()
    => _isRunning = false;

    public void Update(float deltaTime)
    {
        if (deltaTime <= 0)
            throw new InvalidOperationException(nameof(deltaTime));

        if (_isRunning == false)
            return;

        _timer -= deltaTime;

        if (_timer <= 0)
        {
            _timer = _delay;
            _onEnd?.Invoke();
        }
    }
}