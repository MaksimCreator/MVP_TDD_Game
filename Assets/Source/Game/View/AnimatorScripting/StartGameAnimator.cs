using UnityEngine;

public class StartGameAnimator : BaseGameAnimator
{
    public StartGameAnimator(Animator entityAnimator) : base(entityAnimator) { }

    public void EnterStartGame()
    => TryEnterAnimation(() => __entityAnimator.CrossFade(ConstantAnimation.StartGame, Config.NormalizedTransitionDuration));
}