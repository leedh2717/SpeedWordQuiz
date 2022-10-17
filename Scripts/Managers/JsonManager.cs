using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static Define;

public class GameData
{
    public int money;
    public int basicBestScore;
    public int hardBestScore;
    public bool backgroundMusicVolume = true;
    public bool effectMusicVolume = true;
    public List<Define.CharactersName> isCharacters = new List<CharactersName>();
    public Define.CharactersName equipCharacter = Define.CharactersName.c1;
}

public class JsonDataManager : MonoBehaviour
{
    public GameData gameData = new GameData();

    public void SaveData()
    {
        string data = JsonUtility.ToJson(gameData);
        File.WriteAllText(Application.persistentDataPath + "/" + "GameData", data);

        LoadData();
    }

    public void LoadData()
    {
        if (!File.Exists(Application.persistentDataPath + "/" + "GameData"))
        {
            gameData.isCharacters.Add(Define.CharactersName.c1);
            SaveData();
        }            

        string data = File.ReadAllText(Application.persistentDataPath + "/" + "GameData");
        gameData = JsonUtility.FromJson<GameData>(data);
    }
}
