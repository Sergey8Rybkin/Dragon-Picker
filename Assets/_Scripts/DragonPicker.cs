using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using YG;

public class DragonPicker : MonoBehaviour
{

    private void OnEnable() => YandexGame.GetDataEvent += GetLoadSave;
    private void OnDisable() => YandexGame.GetDataEvent -= GetLoadSave;
    public GameObject energyShieldPrefab;

    public int numEnergyShield = 3;

    public float energyShieldBottomY = -6f;

    public float energyShieldRadius = 1.5f;

    public TextMeshProUGUI Score;



    public List<GameObject> shieldList;
    // Start is called before the first frame update
    void Start()
    {


        if (YandexGame.SDKEnabled == true)
        {
            GetLoadSave();
        }

        GameObject scoreGo = GameObject.Find("Score");
        Score = scoreGo.GetComponent<TextMeshProUGUI>();

        for (int i = 1; i <= numEnergyShield; i++)
        {
            GameObject tShieldGo = Instantiate<GameObject>(energyShieldPrefab);
            tShieldGo.transform.position = new Vector3(0, energyShieldBottomY, 0);
            tShieldGo.transform.localScale = new Vector3(1 * i, 1 * i, 1 * i);
            shieldList.Add(tShieldGo);
        }
    }


    void Update()
    {

    }
    public void DragonEggDestroyed()
    {
        GameObject[] tDragonEggArray = GameObject.FindGameObjectsWithTag("DragonEggs");
        foreach (GameObject tGO in tDragonEggArray)
        {
            Destroy(tGO);
        }
        int shieldIndex = shieldList.Count - 1;
        GameObject tShieldGo = shieldList[shieldIndex];
        shieldList.RemoveAt(shieldIndex);
        Destroy(tShieldGo);

        if (shieldList.Count == 0)
        {
            GameObject scoreGo = GameObject.Find("Score");
            Score = scoreGo.GetComponent<TextMeshProUGUI>();

           /* string[] achievementList;
            achievementList = YandexGame.savesData.achievement;
            achievementList[0] = "Be carefull with shields";
            UserSave(int.Parse(Score.text), YandexGame.savesData.bestScore, achievementList); */

            YandexGame.NewLeaderboardScores("BestPlayerScore", int.Parse(Score.text));

            YandexGame.RewVideoShow(0);

            SceneManager.LoadScene("_0Scene");

            GetLoadSave();
        }

    }

    public void GetLoadSave()
    {
        Debug.Log(YandexGame.savesData.score);
    }

    public void UserSave(int currentScore, int currentBestScore, string[] currentAchievement)
    {
        YandexGame.savesData.score = currentScore;
        if (currentScore > currentBestScore)
        {
            YandexGame.savesData.bestScore = currentScore;
        }
        YandexGame.savesData.achievement = currentAchievement;
        YandexGame.SaveProgress();
    }

}
