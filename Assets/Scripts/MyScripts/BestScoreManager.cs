using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class BestScoreManager : MonoBehaviour
{
    public static BestScoreManager Instance;

    public string ScoreName;
    public string BestScoreName;
    public int BestScorePoints;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public string ScoreName;
        public string BestScoreName;
        public int BestScorePoints;
    }

    public void SaveBestScore()
    {
        SaveData data = new SaveData();

        data.ScoreName = ScoreName;
        data.BestScoreName = BestScoreName;
        data.BestScorePoints = BestScorePoints;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "savefile.json", json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
        }
    }
}
