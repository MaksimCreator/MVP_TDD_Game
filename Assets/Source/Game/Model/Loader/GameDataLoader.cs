using Zenject;

public class GameDataLoader : Loader<GameData>
{
    [Inject]
    public GameDataLoader(IGameRepository gameRepository) : base(gameRepository) { }

    protected override GameData GetData()
    => new GameData();
}