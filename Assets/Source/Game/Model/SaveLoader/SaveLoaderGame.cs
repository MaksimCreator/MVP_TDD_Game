using System;
using System.IO;
using System.Text;
using UnityEngine;
using System.Collections.Generic;
using System.Security.Cryptography;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class SaveLoaderGame : ISaveLoaderGame
{
    private const string EncryptionKey = "c29tZSUyMHRleHQtJDEyMw==";

    private string FilePath => Application.persistentDataPath + "gameState.dat";

    public void Save(Dictionary<string, object> gameState)
    {
        string filePath = FilePath;

        string jsonData = JsonConvert.SerializeObject(gameState);
        byte[] data = Encoding.UTF8.GetBytes(jsonData);

        byte[] encryptedData = Encrypt(data, EncryptionKey);

        File.WriteAllBytes(filePath, encryptedData);
    }

    public void Load(out Dictionary<string, object> data, Type[] deserializeObjectType)
    {
        ValidateUniqueNames(deserializeObjectType);

        string filePath = FilePath;
        data = new();

        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            PreserveReferencesHandling = PreserveReferencesHandling.Objects,
            ReferenceLoopHandling = ReferenceLoopHandling.Serialize
        };
        JsonSerializer serializer = JsonSerializer.Create(settings);

        if (File.Exists(filePath) == false)
            return;

        byte[] encryptedDataHashed = File.ReadAllBytes(filePath);
        byte[] decryptedData = Decrypt(encryptedDataHashed, EncryptionKey);

        string jsonData = Encoding.UTF8.GetString(decryptedData);

        JObject fullJson = JObject.Parse(jsonData);

        foreach (Type type in deserializeObjectType)
        {
            // По умолчанию, мы предполагаем, что ключ в JSON соответствует имени типа
            string keyInJson = type.Name; // Например, "GameData", "ArmyStorage"

            if (fullJson.TryGetValue(keyInJson, out JToken jTokenForType))
            {
                object deserializedInstance = jTokenForType.ToObject(type, serializer);
                data.Add(keyInJson, deserializedInstance);
            }
        }
    }

    private byte[] Encrypt(byte[] data, string key)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Convert.FromBase64String(key);
            aes.GenerateIV(); // Генерация нового вектора инициализации

            using (MemoryStream ms = new MemoryStream())
            {
                ms.Write(aes.IV, 0, aes.IV.Length); // Сохранение IV в начало потока
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(data, 0, data.Length);
                }
                return ms.ToArray();
            }
        }
    }

    private byte[] Decrypt(byte[] data, string key)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Convert.FromBase64String(key);
            byte[] iv = new byte[aes.BlockSize / 8];
            Array.Copy(data, 0, iv, 0, iv.Length);

            aes.IV = iv;

            using (MemoryStream ms = new MemoryStream(data, iv.Length, data.Length - iv.Length))
            {
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    using (MemoryStream decryptedStream = new MemoryStream())
                    {
                        cs.CopyTo(decryptedStream);
                        return decryptedStream.ToArray();
                    }
                }
            }
        }
    }

    private void ValidateUniqueNames(Type[] types)
    {
        for (int i = 0; i < types.Length; i++)
        {
            for (int y = 0; y < types.Length; y++)
            {
                if (i == y)
                    continue;

                if (types[i].Name == types[y].Name)
                    throw new InvalidOperationException("Exeption system.The types should not be repeated");
            }
        }
    }
}