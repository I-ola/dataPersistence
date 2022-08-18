using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataPersistence : MonoBehaviour
{
    public Text bestScore;
    public static DataPersistence instance;

    public GameObject stringInput;

    public GameObject stringValueText;

    public string stringValue;

    
   
    private void Awake()
    {
        BestScore();

        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void BestScore()
    {
        string highScore = PlayerPrefs.GetInt("BestScore", 0).ToString();
        bestScore.text = $"BestScore : {highScore}";
    }

    public void StoreName()
    {
        stringValue = stringInput.GetComponent<Text>().text;
        stringValueText.GetComponent<Text>().text = $"Name : {stringValue}";
        PlayerName.theName = stringValue;
    }
}
