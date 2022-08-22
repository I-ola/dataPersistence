using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataPersistence : MonoBehaviour
{
    public Text bestScore;
    public static DataPersistence instance;

    public InputField userName;

    public Text inputedName;

    public string playerName;
    public string newName;
    

    
   
    private void Awake()
    {
        BestScore();

        instance = this;
        DontDestroyOnLoad(gameObject);

        inputedName.text = $"Name: {PlayerName.theName}";
       // DataPersistence.instance.inputedName = inputedName;
       // IsDone();
    }

    public void BestScore()
    {
        string highScore = PlayerPrefs.GetInt("BestScore", 0).ToString();
        bestScore.text = $"BestScore : {highScore}";
    }

    public void DisplayName()
    {
        
    }

    public void StoreName()
    {
        playerName = userName.text;
        DataPersistence.instance.playerName = playerName;  
    }

    /*public void IsDone()
    {
        if(MainManager.done == true)
        {
            Destroy(gameObject);
        }
    }*/
}
