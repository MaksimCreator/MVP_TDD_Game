using Zenject;

public class MoneyLoader : Loader<MoneyStorage>
{
    [Inject]
    public MoneyLoader(IGameRepository gameRepository) : base(gameRepository) { }

    protected override MoneyStorage GetData()
    => new MoneyStorage();
}