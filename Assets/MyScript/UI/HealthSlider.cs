using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;
using StarterAssets;
public class HealthSlider : MonoBehaviour
{
    public Slider healthSlider;
    

    // Update is called once per frame
    void Update()
    {
        healthSlider.maxValue = GameManager.instance.PlayerMaxHp;
        healthSlider.value = GameManager.instance.PlayerCurrentHp;
        
    }
}
