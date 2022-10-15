using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MovementWithButtons : MonoBehaviour
{
    public GameObject player;
    public bool isLeftPressed = false, isRightPressed = false;
    public float speed;
    
    public Projectile liver;


    private void Update()
    {
        if (isLeftPressed && !liver.Dead)
        {
            player.transform.Translate(Vector3.left*Time.deltaTime*speed, Space.World);
        }

        if (isRightPressed && !liver.Dead)
        {
            player.transform.Translate(Vector3.right*Time.deltaTime*speed, Space.World);
        }
    }
    
    public void onPointerDownleftButton()
    {
        isLeftPressed = true;
    }

    public void onPointerUpleftButton()
    {
        isLeftPressed = false;
    }
    
    public void onPointerDownrightButton()
    {
        isRightPressed = true;
    }

    public void onPointerUprightButton()
    {
        isRightPressed = false;
    }
}
