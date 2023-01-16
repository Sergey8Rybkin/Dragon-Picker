using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;
using TMPro;
public class CheckConnectYG : MonoBehaviour
{
    
    private void OnEnable() => YandexGame.GetDataEvent += CheckSDK;
    private void OnDisable() => YandexGame.GetDataEvent -= CheckSDK;
        
    private TextMeshProUGUI scoreBest;

    private TextMeshProUGUI playerName;
    void Start()
    {
        if (YandexGame.SDKEnabled == true) {
            CheckSDK();
        }
    }

   public void CheckSDK()
   {
    if (YandexGame.auth == true)
    {
        Debug.Log("User is authorized");
    }
    else 
    {
        Debug.Log("User is not authorized");
        YandexGame.AuthDialog();
    }

    YandexGame.RewVideoShow(0);
    GameObject scoreBO= GameObject.Find("BestScoreText");
    scoreBest = scoreBO.GetComponent<TextMeshProUGUI>();
    scoreBest.text = "Best Score: " + YandexGame.savesData.bestScore.ToString();
    
    GameObject playerNamePrefabGUI = GameObject.Find("WelcomePlayer");
    playerName = playerNamePrefabGUI.GetComponent<TextMeshProUGUI>();
    playerName.text =  "Hello " + YandexGame.playerName;

    /* 
    if ((YandexGame.savesData.achievement)[0] == null & !GameObject.Find("AchievementsList"))
    {
    
    }
    else
    {
        foreach (string value in YandexGame.savesData.achievement)
        {
            GameObject.Find("AchievementsList").GetComponent<TextMeshProUGUI>().text = GameObject.Find("AchievementsList").GetComponent<TextMeshProUGUI>().text + value + "\n";
        }
    }
    */
   }

}
