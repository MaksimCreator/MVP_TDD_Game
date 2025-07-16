using Zenject;

public class ArmyLoader : Loader<ArmyStorage>
{
    [Inject]
    public ArmyLoader(IGameRepository gameRepository) : base(gameRepository) { }

    protected override ArmyStorage GetData()
    => new ArmyStorage();
}