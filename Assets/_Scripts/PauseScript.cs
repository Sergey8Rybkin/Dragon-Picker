using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    private bool paused = false;

    public GameObject textPanel;
    public GameObject panel;

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            if (!paused){
                Time.timeScale = 0;
                paused = true;
                panel.SetActive(true);
                textPanel.SetActive(true);
            }
            else {
                Time.timeScale = 1;
                paused = false;
                panel.SetActive(false);
                textPanel.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

}
