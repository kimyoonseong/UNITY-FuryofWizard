using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;
    private void Awake()
    {
        if (instance == null) //instance�� null. ��, �ý��ۻ� �����ϰ� ���� ������
        {
            instance = this; //���ڽ��� instance�� �־��ݴϴ�.
            DontDestroyOnLoad(gameObject); //OnLoad(���� �ε� �Ǿ�����) �ڽ��� �ı����� �ʰ� ����
        }
        else
        {
            if (instance != this) //instance�� ���� �ƴ϶�� �̹� instance�� �ϳ� �����ϰ� �ִٴ� �ǹ�
                Destroy(this.gameObject); //�� �̻� �����ϸ� �ȵǴ� ��ü�̴� ��� AWake�� �ڽ��� ����
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

    public int TutorialLevel=1;//Ʃ�丮�� �ǳ��� ����

    public bool StoryFinish = false;

    public float DefaultAttack = 10;//behavior tree
    public float BTWizardHP = 100;

    public float BossAttack = 10;//behavior tree
    public float BossHP = 100;
    public float BossMaxHP = 100;
}
