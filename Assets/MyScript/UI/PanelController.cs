using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
public class PanelController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject TutorialPanel0;
    public GameObject TutorialPanel;
    public GameObject TutorialPanel2;
    public GameObject TutorialPanel3;
    public GameObject TutorialPanel4;
    public GameObject TutorialPanel5;
    void Start()
    {
        if (Time.timeScale == 0)
            Time.timeScale = 1;
    }
    
    public void Continue()
    {
        Time.timeScale = 1;
        TutorialPanel0.SetActive(false);
        TutorialPanel.SetActive(false);
        TutorialPanel2.SetActive(false);
        TutorialPanel3.SetActive(false);
        TutorialPanel4.SetActive(false);
        TutorialPanel5.SetActive(false);
        GameObject.Find("Player").GetComponent<StarterAssetsInputs>().SetCursorState(true);
        GameObject.Find("Player").GetComponent<StarterAssetsInputs>().cursorInputForLook = true;
        GameManager.instance.TutorialLevel += 1;
    }
    public void openPanel()//20221116 Æ©Åä¸®¾ó ÆÇ³Ú 
    {
        Time.timeScale = 0;
        if (GameManager.instance.TutorialLevel == 0)
        {
            TutorialPanel0.SetActive(true);
        }
        if (GameManager.instance.TutorialLevel == 1)
        {
            TutorialPanel.SetActive(true);
        }
        else if (GameManager.instance.TutorialLevel == 2)
        {
            TutorialPanel2.SetActive(true);
        }
        else if (GameManager.instance.TutorialLevel == 3)
        {
            TutorialPanel3.SetActive(true);
        }
        else if (GameManager.instance.TutorialLevel == 4)
        {
            TutorialPanel4.SetActive(true);
        }
        else if (GameManager.instance.TutorialLevel == 5)
        {
            TutorialPanel5.SetActive(true);
            GameManager.instance.TutorialLevel = 0;
        }
        GameObject.Find("Player").GetComponent<StarterAssetsInputs>().SetCursorState(false);      
        GameObject.Find("Player").GetComponent<StarterAssetsInputs>().cursorInputForLook = false;       
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
