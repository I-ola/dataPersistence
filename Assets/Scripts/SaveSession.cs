using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveSession : MonoBehaviour
{
    public static SaveSession instance;
    public string userName;
    // Start is called before the first frame update
    private void Awake()
    {
       if(instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        SaveSession.instance.userName = userName;
        LoadPlayerData();
    }

    [System.Serializable]
    class SaveData
    {
        public string userName;
      
    }

    public void SavePlayerData()
    {
        SaveData data = new SaveData();
        data.userName = userName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            userName = data.userName;
        }
    }
}
