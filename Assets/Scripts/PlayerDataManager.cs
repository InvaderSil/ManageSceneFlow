using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
 
    public static PlayerDataManager Instance;

    public string BestPlayerName;
    public string CurrentPlayerName;
    public int BestScore;

    private string _saveFile;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        _saveFile = Application.persistentDataPath + "/saveFile.json";
        LoadData();
        DontDestroyOnLoad(gameObject);
    }

    public void SetCurrentPlayer(string playerName)
    {
        if(string.IsNullOrWhiteSpace(playerName) || CurrentPlayerName == playerName)
        {
            return;
        }
        CurrentPlayerName = playerName;

    }

    public void ClearBestData()
    {
        BestScore = 0;
        BestPlayerName = string.Empty;
        SaveData();
    }

    public void SetBestScore(int score)
    {
        BestScore = score;
        BestPlayerName = CurrentPlayerName;
    }
    
    public void SaveData()
    {

        PlayerData data = new PlayerData();
        data.Name = BestPlayerName;
        data.BestScore = BestScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(_saveFile, json);

    }

    public void LoadData()
    {
        if (File.Exists(_saveFile))
        {
            string json = File.ReadAllText(_saveFile);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);

            BestPlayerName = data.Name;
            BestScore = data.BestScore;
        }
    }
       

    [System.Serializable]
    class PlayerData
    {
        public string Name;
        public int BestScore;
    }

}
