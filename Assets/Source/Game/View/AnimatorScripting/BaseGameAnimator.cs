using System;
using UnityEditor.Animations;
using UnityEngine;

public abstract class BaseGameAnimator
{
    protected readonly Animator __entityAnimator;

    public BaseGameAnimator(Animator entityAnimator)
    {
        __entityAnimator = entityAnimator;
    }   

    public float GetLengchClip(int animationHash)
    {
        AnimatorController animatorController = __entityAnimator.runtimeAnimatorController as AnimatorController;

        if (animatorController != null)
        {
            foreach (var layer in animatorController.layers)
            {
                foreach (var state in layer.stateMachine.states)
                {
                    if (state.state.nameHash == animationHash)
                    {
                        AnimationClip clip = state.state.motion as AnimationClip;
                        return clip.length + Config.NormalizedTransitionDuration;
                    }
                }
            }
        }

        throw new InvalidOperationException();
    }

    protected void TryEnterAnimation(Action enterAnimation)
    {
        if (__entityAnimator != null)
            enterAnimation();
    }
}