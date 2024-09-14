using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialMove : MonoBehaviour
{
    // Start is called before the first frame update
    public int Specialdamage;
    void Start()
    {
        Specialdamage = 20;
        Destroy(gameObject, 2.2f);
    }

}
