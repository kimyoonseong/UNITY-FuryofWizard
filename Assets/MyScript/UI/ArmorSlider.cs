using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class ArmorSlider : MonoBehaviour
{
    public Slider armorSlider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        armorSlider.maxValue = GameManager.instance.ArmorMaxHp;
        armorSlider.value = GameManager.instance.ArmorHp;
    }
}
