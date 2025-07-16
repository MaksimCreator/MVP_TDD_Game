using UnityEngine;

public static class ConstantAnimation
{
    public static int ImageMoney => Animator.StringToHash(nameof(ImageMoney));
    public static int ButtonAnimation => Animator.StringToHash(nameof(ButtonAnimation));
    public static int Click => Animator.StringToHash(nameof(Click));
    public static int StartGame => Animator.StringToHash(nameof(StartGame));
}