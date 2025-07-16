using Zenject;

public abstract class Loader<TService>
{
    private readonly IGameRepository _gameRepository;

    [Inject]
    public Loader(IGameRepository gameRepository)
    => _gameRepository = gameRepository;

    public TService Load()
    {
        if(_gameRepository.TryGetData(out TService data))
            return data;

        data = GetData();
        _gameRepository.SetData(data);
        return data;
    }

    protected abstract TService GetData();
}
