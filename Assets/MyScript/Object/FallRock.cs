using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallRock : MonoBehaviour
{
    public float shakeTime = 1.0f;
    public float shakeSpeed = 2.0f;
    public float shakeAmount = 1.0f;
    [Tooltip("\"Fractured\" is the object that this will break into")]
    public GameObject fractured;
    private Transform Rock;

    private void Start()
    {
        Rock = this.transform;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(Shake());
            Invoke("FractureObject",1.5f);
        }
    }
    IEnumerator Shake()
    {
        Vector3 originPosition = Rock.localPosition;
        float elapsedTime = 0.0f;
        while(elapsedTime< shakeTime)
        {
            Vector3 randomPoint = originPosition + Random.insideUnitSphere * shakeAmount;
            Rock.localPosition = Vector3.Lerp(Rock.localPosition, randomPoint, Time.deltaTime * shakeSpeed);

            yield return null;
            elapsedTime += Time.deltaTime;
        }
        Rock.localPosition = originPosition;
    }
    public void FractureObject()
    {
        GameObject obj = Instantiate(fractured, transform.position, transform.rotation); //Spawn in the broken version
        Destroy(gameObject); //Destroy the object to stop it getting in the way
        Destroy(obj, 3f);

    }
}
