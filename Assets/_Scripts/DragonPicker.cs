using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DragonPicker : MonoBehaviour
{
    public GameObject energyShieldPrefab;

    public int numEnergyShield = 3;

    public float energyShieldBottomY = -6f;

    public float energyShieldRadius = 1.5f;
    //public TextMeshProUGUI healthGT;

    public List<GameObject> shieldList;
    // Start is called before the first frame update
    void Start()
    {
        //GameObject scoreGo = GameObject.Find("Health");
        //healthGT = scoreGo.GetComponent<TextMeshProUGUI>();
        //healthGT.text = "3";

        for (int i = 1; i <= numEnergyShield; i++){
            GameObject tShieldGo = Instantiate<GameObject>(energyShieldPrefab);
            tShieldGo.transform.position = new Vector3(0, energyShieldBottomY, 0);
            tShieldGo.transform.localScale = new Vector3(1*i, 1*i, 1*i);
            shieldList.Add(tShieldGo);
        }
    }

    
    void Update()
    {
        
    }
    public void DragonEggDestroyed() {
        GameObject[] tDragonEggArray = GameObject.FindGameObjectsWithTag("DragonEggs");
        foreach (GameObject tGO in tDragonEggArray) {
            Destroy (tGO);
        }
        int shieldIndex = shieldList.Count -1 ;
        GameObject tShieldGo = shieldList [shieldIndex];
        shieldList.RemoveAt(shieldIndex);
        Destroy(tShieldGo);

        /*(int health = int.Parse(healthGT.text);
            health --;
            healthGT.text = health.ToString();
 */
        if (shieldList.Count == 0) {
            SceneManager.LoadScene("_0Scene");
        }
       
    }
    
}
