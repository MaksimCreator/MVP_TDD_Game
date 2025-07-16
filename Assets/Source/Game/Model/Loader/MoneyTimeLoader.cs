using Zenject;

public class MoneyTimeLoader : Loader<MoneyTimeStorage>
{
    [Inject]
    public MoneyTimeLoader(IGameRepository gameRepository) : base(gameRepository) { }

    protected override MoneyTimeStorage GetData()
    => new MoneyTimeStorage();
}
