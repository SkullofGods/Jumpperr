using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatFalling : MonoBehaviour
{
    private Animator _fall;
    private static readonly int IsTouched = Animator.StringToHash("IsTouched");

    private void Awake()
    {
        _fall = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
     if (other.gameObject.CompareTag("Player"))
         _fall.SetTrigger(IsTouched);
    }

    private void OnTriggerExit(Collider other)
    {
        _fall.ResetTrigger(IsTouched);
    }
}
