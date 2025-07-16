using Zenject;

public class MoneyTapLoader : Loader<MoneyTapStorage>
{
    [Inject]
    public MoneyTapLoader(IGameRepository gameRepository) : base(gameRepository) { }

    protected override MoneyTapStorage GetData()
    => new MoneyTapStorage();
}
