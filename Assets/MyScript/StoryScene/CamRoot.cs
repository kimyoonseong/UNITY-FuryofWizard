using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRoot : MonoBehaviour
{
    // Start is called before the first frame update
    bool isMove;
    void Start()
    {
        isMove = true;
        
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Father")
        {
            isMove = false;
            GameObject.Find("UIController").GetComponent<ButtonControl>().ThirdSequence(); //�ó׸ӽ� ī�޶� ��Ʈ�� �������, �ǳڻ���
            Debug.Log("�ǳڻ���");
        }

        //explosion();
        //Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        if (isMove && GameManager.instance.StoryFinish)
        {
            transform.Translate(Vector3.right * Time.deltaTime * 8);
            //GameManager.instance.StoryFinish = false;
        }
    }
}
