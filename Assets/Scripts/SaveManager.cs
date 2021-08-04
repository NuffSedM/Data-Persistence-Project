using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;
    public string playerName;
    public string highScoreName;
    public int highScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        
        Load();
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public string highScoreName;
        public int highScore;
    }

    public void Save()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.highScoreName = highScoreName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.playerName;
            highScoreName = data.highScoreName;
            highScore = data.highScore;
        }
    }

    public void ClearData()
    {
        SaveData data = new SaveData();
        data.playerName = null;
        data.highScoreName = null;
        data.highScore = 0;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
}
