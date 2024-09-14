using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public float orbitSpeed;
    Vector3 offSet;
    void Start()
    {
        offSet = transform.position - target.position;//플레이어위치와 스피릿 위치 차이
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offSet;//스피릿위치에 현재타겟(플레이어)와 플레이어위치와 스피릿 위치 차이를 더해준다.
        transform.RotateAround(target.position,
                                Vector3.up,
                                orbitSpeed * Time.deltaTime);
        offSet = transform.position - target.position;
    }
}
