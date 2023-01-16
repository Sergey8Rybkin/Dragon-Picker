using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class AddReward : MonoBehaviour
{
    
    private void OnEnable() => YandexGame.CloseVideoEvent += Rewarded;

    private void OnDisable() => YandexGame.CloseVideoEvent += Rewarded;

    void Rewarded(int id) 
    {
        if (id == 1)
        {
            Debug.Log("Пользователь получил вознаграждение");
        }
        else 
        {
            Debug.Log("Пользователь без награды");
        }
    }
   
   public void OpenAd()
   {
        YandexGame.RewVideoShow(Random.Range(0,2));
   }

}
