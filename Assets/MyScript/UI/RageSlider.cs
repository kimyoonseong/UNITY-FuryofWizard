using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;
using StarterAssets;
public class RageSlider : MonoBehaviour
{
    public Slider rageSlider;
    public Color color;
    public void Start()
    {
        rageSlider.fillRect.GetComponent<Image>().color = color;
    }
    // Update is called once per frame
    void Update()
    {
        rageSlider.maxValue = GameManager.instance.MaxRage;
        rageSlider.value = GameManager.instance.CurrentRage;
        if(GameManager.instance.MaxRage<= GameManager.instance.CurrentRage)
        {
            rageSlider.fillRect.GetComponent<Image>().color = Color.red;
        }
        else {
            rageSlider.fillRect.GetComponent<Image>().color = new Color(255,255,255,255);
        }
    }
    

}
