using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int damage;
    public int userage = 0;

    public Transform bulletPos;
    public GameObject bullet;
    //20221012 �ʻ��
    public GameObject specialbullet;
    
    public void Use()
    {
        StartCoroutine("Shot");
    }
    IEnumerator Shot()
    {
        //#1. ��ü �߻�
        GameObject intantBullet = Instantiate(bullet, bulletPos.position, bulletPos.rotation);
        Rigidbody bulletRigid = intantBullet.GetComponent<Rigidbody>();
        bulletRigid.velocity = bulletPos.forward * 20;
        yield return new WaitForSeconds(0.1f);
        

    }
    //20221012 �ʻ��
   public void Special()
    {
        StartCoroutine("SpecialShot");
    }
    IEnumerator SpecialShot()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject instantSpecial = Instantiate(specialbullet, bulletPos.position, bulletPos.rotation);
        Rigidbody SpecialBulletRigid = instantSpecial.GetComponent<Rigidbody>();

    }

    
}
