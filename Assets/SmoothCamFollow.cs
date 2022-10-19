using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamFollow : MonoBehaviour
{
    public GameObject player;
    public float speed = 3f;
    
    private void Start()
    {
    }

    private void LateUpdate()
    {
        LeanTween.moveLocalY(this.gameObject, player.transform.position.y, Time.deltaTime * speed);
    }
}


