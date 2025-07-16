public class AnimationCatalog : IUpdateble
{
    private ImageMoneyAnimation[] _animations;

    public AnimationCatalog(ImageMoneyAnimation[] animations)
    {
        _animations = animations;
    }

    public void Update(float deltaTime)
    {
        for (int i = 0; i < _animations.Length; i++)
            _animations[i].Update(deltaTime);
    }
}