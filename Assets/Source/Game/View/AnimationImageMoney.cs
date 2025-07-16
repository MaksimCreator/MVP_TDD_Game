using System.Collections.Generic;

public class AnimationImageMoney : IControl
{
    private readonly ImageMoneyAnimation[] _animators;
    private readonly Dictionary<ImageMoneyAnimation,bool> _canActiveAnimation;

    public AnimationImageMoney(ImageMoneyAnimation[] imageMoneyAnimators)
    {
        _canActiveAnimation = new();
        _animators = new ImageMoneyAnimation[imageMoneyAnimators.Length];

        for (int i = 0; i < imageMoneyAnimators.Length; i++)
            _canActiveAnimation.Add(_animators[i], false);
    }

    public void Enable()
    {
        for (int i = 0; i < _animators.Length; i++)
            _animators[i].onSetActive += SetActive;
    }

    public void Disable()
    {
        for (int i = 0; i < _animators.Length; i++)
            _animators[i].onSetActive -= SetActive;
    }

    public void EnterImage()
    {
        int index;
        List<ImageMoneyAnimation> imagesAnimator = new();

        for (int i = 0; i < _canActiveAnimation.Count; i++)
        {
            if (_canActiveAnimation[_animators[i]] == false)
                imagesAnimator.Add(_animators[i]);
        }

        if (imagesAnimator.Count == 0)
            return;

        index = UnityEngine.Random.Range(0, imagesAnimator.Count);
        imagesAnimator[index].EnterAnimation();
    }

    private void SetActive(ImageMoneyAnimation gameAnimator,bool value)
    => _canActiveAnimation[gameAnimator] = value;
}