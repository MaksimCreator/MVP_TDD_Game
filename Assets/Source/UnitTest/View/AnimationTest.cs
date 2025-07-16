using NUnit.Framework;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.TestTools;
using Cysharp.Threading.Tasks;

namespace UnitTest
{
    [TestFixture]
    public class AnimationTest : BaseTest
    {
        public void AnimatorButtonTest()
        {
            GameObject gameObject = new GameObject();
            Animator animator = gameObject.AddComponent<Animator>();

            AnimationClip clip = new AnimationClip();

            AnimatorController controller = animator.runtimeAnimatorController as AnimatorController;
            controller.AddMotion(clip);
            clip.name = nameof(ConstantAnimation.ButtonAnimation);
            AnimatorStateInfo animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);

            int hashActiveAnimation = animatorStateInfo.fullPathHash;
            int hashIdel = animatorStateInfo.fullPathHash;
        }
    }
}