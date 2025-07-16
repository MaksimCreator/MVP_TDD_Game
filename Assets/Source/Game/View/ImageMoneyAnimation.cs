using System;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class ImageMoneyAnimation
{
    private const int alphaStart = 0;
    private const int alphaEnd = 255;

    private readonly float _timeOfAppearance;
    private readonly float _cooldown;
    private readonly Image _image;
    private readonly TextMeshProUGUI _text;

    private float _timer;
    private bool _canActiveAnimation;

    public event Action<ImageMoneyAnimation,bool> onSetActive;

    public ImageMoneyAnimation(Image image, TextMeshProUGUI text, float time = 1)
    {
        _cooldown = time;
        _timeOfAppearance = time / 2;

        _image = image;
        _text = text;
        _timer = time;
    }

    public void EnterAnimation()
    {
        if (_canActiveAnimation)
            return;

        _canActiveAnimation = true;
        _timer = _cooldown;

        _image.color = CreatNewAlpha(_image.color, alphaStart);
        _text.color = CreatNewAlpha(_text.color, alphaStart);

        onSetActive.Invoke(this, true);
    }

    public void Update(float deltaTime)
    {
        if (deltaTime <= 0)
            throw new InvalidOperationException(nameof(deltaTime));

        if(_canActiveAnimation == false) 
            return;

        _timer += deltaTime;

        if (_timer <= 0)
        {
            _canActiveAnimation = false;
            deltaTime = _timer + deltaTime;
            
        }

        Animation(deltaTime);
    }

    private void Animation(float delta)
    {
        bool isTimeOfAppearance = true;

        if (_timer < _timeOfAppearance && isTimeOfAppearance)
        {
            delta = _timeOfAppearance - _timer;
            isTimeOfAppearance = false;
        }

        float alpha = _image.color.a;
        delta /= _timeOfAppearance;

        if(isTimeOfAppearance)
            alpha += delta * alphaEnd;
        else
            alpha -= delta * alphaEnd;

        _image.color = CreatNewAlpha(_image.color, alpha);
        _text.color = CreatNewAlpha(_text.color, alpha);

        if (_canActiveAnimation == false)
        {
            _timer = _cooldown;
            onSetActive.Invoke(this, false);
        }
    }

    private Color CreatNewAlpha(Color color, float alpha)
    {
        if (alpha < 0)
            alpha = 0;
        else if (alpha > 255)
            alpha = 255;

        Color newColor = new Color(color.r, color.g, color.b, alpha);
        return newColor;
    }
}