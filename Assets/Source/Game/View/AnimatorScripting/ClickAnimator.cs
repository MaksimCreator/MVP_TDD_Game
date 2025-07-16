using UnityEngine;

public class ClickAnimator : BaseGameAnimator
{
    public ClickAnimator(Animator entityAnimator) : base(entityAnimator) { }

    public void EnterClick()
   => TryEnterAnimation(() => __entityAnimator.CrossFade(ConstantAnimation.Click, Config.NormalizedTransitionDuration));
}
