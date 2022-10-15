using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    private Rigidbody rbody;
    private bool isOnPlatform;
    private MovingPlatform _platform;
    private void Awake()
    {
        rbody = GetComponent<Rigidbody>();
    }
 
    void Update()
    {
        if(isOnPlatform)
            transform.position = Vector3.Lerp(transform.localPosition, _platform.gameObject.transform.position+Vector3.up*0.5f,
            Time.deltaTime * _platform.speed*3);
    }
 
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("MovingP"))
        {
            isOnPlatform = true;
            _platform = col.gameObject.GetComponent<MovingPlatform>();
        }
    }
 
    void OnCollisionExit(Collision col)
    {
        if(col.gameObject.CompareTag("MovingP"))
        {
            isOnPlatform = false;
        }
    }
}
