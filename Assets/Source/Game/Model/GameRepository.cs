using Zenject;
using System.Collections.Generic;
public class GameRepository : IGameRepository
{
    private ISaveLoaderGame _gameLoader;
    private Dictionary<string, object> _gameState = default;

    [Inject]
    public GameRepository (ISaveLoaderGame saveLoader)
    {
        _gameLoader = saveLoader;
        _gameLoader.Load(out _gameState,SaveList.TypesSave);
    }

    public bool TryGetData<T>(out T data) 
    {
        string key = typeof(T).ToString();

        if (_gameState.TryGetValue(key, out object value) == false)
        {
            data = default;
            return false;
        }

        data = (T)_gameState[key];
        return true;
    }
    
    public void SetData<T>(T data)
    {
        string key = typeof(T).ToString();
        _gameState[key] = data;
    }

    public void Save()
    => _gameLoader.Save(_gameState);
}