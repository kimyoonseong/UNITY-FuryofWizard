using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class BossHealthBar : MonoBehaviour
{
    public Slider BossSlider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BossSlider.maxValue = GameManager.instance.BossMaxHP;
        BossSlider.value = GameManager.instance.BossHP;
    }
}
