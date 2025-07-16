public interface IGameRepository
{
    bool TryGetData<T>(out T storage);

    void SetData<T>(T storage);

    void Save();
}