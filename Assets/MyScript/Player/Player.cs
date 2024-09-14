using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using StarterAssets;
public class Player : MonoBehaviour
{
    public GameObject Helmet;
    public GameObject Pad;
    public GameObject Hair;
    
    
    //피격효과20221103
    public GameObject expParticle;
    Animator anim;
    //레이지 100 효과 2022 1128
    public GameObject RageParticle;
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.visible = true;
        Time.timeScale = 1;
    }
    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        
    }
    private void explosion()
    {
        expParticle.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyAttack")
        {
            expParticle.SetActive(true);
            anim.SetTrigger("GetHit");
            Invoke("explosion", 0.8f);
            GameManager.instance.CurrentRage +=8f;
        }
        if (other.tag == "EnemySkillAttack")
        {
            expParticle.SetActive(true);
            anim.SetTrigger("GetHit");
            Invoke("explosion", 0.8f);
            GameManager.instance.CurrentRage += 8f;
        }
        if (other.tag == "WeakAttack")
        {
            expParticle.SetActive(true);
            anim.SetTrigger("GetHit");
            Invoke("explosion", 0.8f);
            GameManager.instance.CurrentRage += 8f;
        }

        if (other.tag == "Armor")
        {
            if (Helmet.activeSelf == false)
            {
                
                Helmet.SetActive(true);
                Hair.SetActive(false);
            }
            else 
            {                
                Pad.SetActive(true);
            }
        }
        if (other.tag == "EnemyAttack")
        {
            
            if (GameManager.instance.ArmorHp > 0)
            {
                if (GameManager.instance.ArmorHp > GameManager.instance.Damaged)
                {
                    GameManager.instance.ArmorHp -= GameManager.instance.Damaged;
                }
                else
                {
                    GameManager.instance.ArmorHp = 0;
                    GameManager.instance.PlayerCurrentHp -= GameManager.instance.Damaged -
                        GameManager.instance.ArmorHp;
                }
            }
            else if(GameManager.instance.ArmorHp==0){
                GameManager.instance.PlayerCurrentHp -= GameManager.instance.Damaged;
                //Debug.Log("ok");
            }
            if (GameManager.instance.PlayerCurrentHp <= 0)
            {
                SceneManager.LoadScene("Fail");
                GameObject.Find("Player").GetComponent<StarterAssetsInputs>().SetCursorState(false);
                GameObject.Find("Player").GetComponent<StarterAssetsInputs>().cursorInputForLook = false;
            }

        }
        else if(other.tag=="WeakAttack")
        {
            if (GameManager.instance.ArmorHp > 0)
            {
                if (GameManager.instance.ArmorHp > GameManager.instance.WeakDamaged)
                {
                    GameManager.instance.ArmorHp -= GameManager.instance.WeakDamaged;
                }
                else
                {
                    GameManager.instance.ArmorHp = 0;
                    GameManager.instance.PlayerCurrentHp -= GameManager.instance.WeakDamaged -
                        GameManager.instance.ArmorHp;
                }
            }
            else if (GameManager.instance.ArmorHp == 0)
            {
                GameManager.instance.PlayerCurrentHp -= GameManager.instance.WeakDamaged;
                //Debug.Log("ok");
            }
            if (GameManager.instance.PlayerCurrentHp <= 0)
            {
                SceneManager.LoadScene("Fail");
                GameObject.Find("Player").GetComponent<StarterAssetsInputs>().SetCursorState(false);
                GameObject.Find("Player").GetComponent<StarterAssetsInputs>().cursorInputForLook = false;
            }
        }
        else if (other.tag == "EnemySkillAttack")
        {
            if (GameManager.instance.ArmorHp > 0)
            {
                if (GameManager.instance.ArmorHp > GameManager.instance.SkillDamaged)
                {
                    GameManager.instance.ArmorHp -= GameManager.instance.SkillDamaged;
                }
                else
                {
                    GameManager.instance.ArmorHp = 0;
                    GameManager.instance.PlayerCurrentHp -= GameManager.instance.SkillDamaged -
                        GameManager.instance.ArmorHp;
                }
            }
            else if (GameManager.instance.ArmorHp == 0)
            {
                GameManager.instance.PlayerCurrentHp -= GameManager.instance.SkillDamaged;
                //Debug.Log("ok");
            }
            if (GameManager.instance.PlayerCurrentHp <= 0)
            {
                SceneManager.LoadScene("Fail");
                GameObject.Find("Player").GetComponent<StarterAssetsInputs>().SetCursorState(false);
                GameObject.Find("Player").GetComponent<StarterAssetsInputs>().cursorInputForLook = false;
            }
        }
        else if (other.tag == "Lava")
        {
            SceneManager.LoadScene("Fail");
            GameObject.Find("Player").GetComponent<StarterAssetsInputs>().SetCursorState(false);
            GameObject.Find("Player").GetComponent<StarterAssetsInputs>().cursorInputForLook = false;
        }
        else if (other.tag == "Tutorial")
        {           
            GameObject.Find("UIController").GetComponent<PanelController>().openPanel();           
            
        }

        else if (other.tag == "Portal")
        {
            SceneManager.LoadScene("MainStage1");

        }
        else if (other.tag == "Clear")
        {
            SceneManager.LoadScene("Clear");
            GameObject.Find("Player").GetComponent<StarterAssetsInputs>().SetCursorState(false);
            GameObject.Find("Player").GetComponent<StarterAssetsInputs>().cursorInputForLook = false;

        }
        
    }
    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.ArmorHp <= 50 && GameManager.instance.ArmorHp > 0)
        {
            Pad.SetActive(false);

        }
        else if (GameManager.instance.ArmorHp == 0)
        {
            Helmet.SetActive(false);
            Hair.SetActive(true);
        }
        if(GameManager.instance.CurrentRage>= GameManager.instance.MaxRage)
        {
            RageParticle.SetActive(true);
           
        }
        if (GameManager.instance.CurrentRage < GameManager.instance.MaxRage)
        {
            RageParticle.SetActive(false);
            
        }
        
    }
    
}
