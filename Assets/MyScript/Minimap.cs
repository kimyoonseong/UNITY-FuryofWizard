using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public GameObject MiniCam;



    // Update is called once per frame
    void Update()
    {
        MiniCamPos();
    }
    void MiniCamPos()// 2022 0613 �̴ϸ�-> �÷��̾� ������ ī�޶����.
    {
        MiniCam.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 25, this.transform.position.z);
    }
}
