using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour {

    private string _dataFileName;
    private string _gameDataFilePath;


    public void Init()
    {
        _dataFileName = "data.json";
        _gameDataFilePath = "/StreamingAssets/data.json";
    }

    public DateTime GetAppLastClosingTime()
    {
        var filePath = Path.Combine(Application.streamingAssetsPath, _dataFileName);
        DateTime appLastClosingTime = DateTime.MinValue;

        if (File.Exists(filePath))
        {
            var dataString = File.ReadAllText(filePath);
            var loadedData = JsonUtility.FromJson<GameData>(dataString);
            appLastClosingTime = loadedData.AppLastClosingTime;
        }

        return appLastClosingTime;
    }

    public void SaveAppLastClosingTime()
    {
        var gameData = new GameData();
        gameData.AppLastClosingTime = NtpServerConnectionManager.Instance.GetTime();

        var gameDataJson = JsonUtility.ToJson(gameData);
        var filePath = Application.dataPath + _gameDataFilePath;
        File.WriteAllText(filePath, gameDataJson);
    }
}

[Serializable]
public class GameData
{
    public DateTime AppLastClosingTime;
}
