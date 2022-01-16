using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string CurrentPlayerName;
    public string RecordHolderName;
    public int HighScore;

    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
        LoadScoreInfo();
    }

    [System.Serializable]
    class SaveData {
        public string RecordHolderName;
        public int HighScore;
    }

    public void SaveScoreInfo() {
        SaveData data = new SaveData();
        data.RecordHolderName = RecordHolderName;
        data.HighScore = HighScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScoreInfo() {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path)) {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            RecordHolderName = data.RecordHolderName;
            HighScore = data.HighScore;
        }
    }
}
