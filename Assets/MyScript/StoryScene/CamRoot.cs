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
            GameObject.Find("UIController").GetComponent<ButtonControl>().ThirdSequence(); //시네머신 카메라 루트가 닿았을때, 판넬생성
            Debug.Log("판넬생성");
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
