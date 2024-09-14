using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;
    private void Awake()
    {
        if (instance == null) //instance가 null. 즉, 시스템상에 존재하고 있지 않을때
        {
            instance = this; //내자신을 instance로 넣어줍니다.
            DontDestroyOnLoad(gameObject); //OnLoad(씬이 로드 되었을때) 자신을 파괴하지 않고 유지
        }
        else
        {
            if (instance != this) //instance가 내가 아니라면 이미 instance가 하나 존재하고 있다는 의미
                Destroy(this.gameObject); //둘 이상 존재하면 안되는 객체이니 방금 AWake된 자신을 삭제
        }
    }
    public float CurrentRage;
    public float MaxRage=100;


    public float PlayerMaxHp;
    public float PlayerCurrentHp;


    public float ArmorMaxHp;
    public float ArmorHp;
    public float Damaged;
    public float WeakDamaged;
    public float SkillDamaged;
    public float RockHp;
    public float DefaultAttackD;

    public float WallHp;

    public int TutorialLevel=1;//튜토리얼 판넬을 위한

    public bool StoryFinish = false;

    public float DefaultAttack = 10;//behavior tree
    public float BTWizardHP = 100;

    public float BossAttack = 10;//behavior tree
    public float BossHP = 100;
    public float BossMaxHP = 100;
}
