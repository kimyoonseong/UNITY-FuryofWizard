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
        offSet = transform.position - target.position;//�÷��̾���ġ�� ���Ǹ� ��ġ ����
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offSet;//���Ǹ���ġ�� ����Ÿ��(�÷��̾�)�� �÷��̾���ġ�� ���Ǹ� ��ġ ���̸� �����ش�.
        transform.RotateAround(target.position,
                                Vector3.up,
                                orbitSpeed * Time.deltaTime);
        offSet = transform.position - target.position;
    }
}
