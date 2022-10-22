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
    
    void OnCollisionStay(Collision col)
    {
        if(col.gameObject.CompareTag("MovingP"))
        {
            isOnPlatform = true;
            _platform = col.gameObject.GetComponent<MovingPlatform>();
            transform.parent = col.gameObject.transform;
        }
    }
 
    void OnCollisionExit(Collision col)
    {
        if(col.gameObject.CompareTag("MovingP"))
        {
            isOnPlatform = false;
            transform.parent = null;
        }
    }
}
