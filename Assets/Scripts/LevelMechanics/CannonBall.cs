using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public float lifetime; 
    void Start()
    {
        StartCoroutine(Deleter());
    }

    IEnumerator Deleter()
    {
        yield return new WaitForSeconds(lifetime);
        
        Destroy(this.gameObject);
    }
}
