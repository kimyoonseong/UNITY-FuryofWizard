using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.SceneManagement;
public class ButtonControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject FirstSeq;
    public GameObject SecondSeq;
    public GameObject ThirdSeq;
    public void MenuButton()
    {
           SceneManager.LoadScene("Title");
      
    }
    public void TittleButton()
    {
        SceneManager.LoadScene("Title");

    }
    public void TutorialButton()
    {
        SceneManager.LoadScene("PracticeScene");

    }
    public void GoToBossButton()
    {
        SceneManager.LoadScene("BossScene");

    }
    public void StoryButton()
    {
        SceneManager.LoadScene("Story");
    }
    public void RetryButton()
    {
        SceneManager.LoadScene("MainStage1");
        GameObject.Find("Player").GetComponent<StarterAssetsInputs>().SetCursorState(true);
        GameObject.Find("Player").GetComponent<StarterAssetsInputs>().cursorInputForLook = true;
        GameManager.instance.ArmorHp = 0;
        GameManager.instance.CurrentRage = 0;
        GameManager.instance.PlayerCurrentHp = 100;
    }
    public void FirstSeqButton()
    {
        FirstSeq.SetActive(false);
        SecondSeq.SetActive(true);
    }
    public void SecondSeqButton()
    {
        GameManager.instance.StoryFinish = true;
        SecondSeq.SetActive(false);
    }
    public void ThirdSequence()
    {
        ThirdSeq.SetActive(true);
        GameManager.instance.StoryFinish = false;
    }
}
