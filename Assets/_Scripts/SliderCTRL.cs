using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderCTRL : MonoBehaviour
{

    public GameObject AudioSource;

    public float oldVolume;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        
        oldVolume = slider.value;
    }

    // Update is called once per frame
    void Update()
    {
        if (oldVolume != slider.value){
            PlayerPrefs.SetFloat("volume", slider.value);
            PlayerPrefs.Save();
            oldVolume = slider.value;
        }

    }
}
