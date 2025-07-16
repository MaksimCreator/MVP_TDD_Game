using UnityEngine;

public class ButtonAnimator : BaseGameAnimator,IBuyClick,IBuyDemocracy,IBuyArmy
{
    public ButtonAnimator(Animator entityAnimator) : base(entityAnimator) { }

    public void EnterButtonAnimation()
    => TryEnterAnimation(() => __entityAnimator.CrossFade(ConstantAnimation.ButtonAnimation, Config.NormalizedTransitionDuration));
}
