using System;
using System.Collections.Generic;

public interface ISaveLoaderGame
{
    void Save(Dictionary<string, object> gameState);

    void Load(out Dictionary<string, object> data, Type[] deserializeObjectType);
}