using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{ 
    public float force;
    public Vector3 direction;
   private void OnTriggerEnter(Collider other)
   {
       if (other.gameObject.CompareTag("Player"))
           other.GetComponent<ConstantForce>().force= direction*force;
   }

   private void OnTriggerExit(Collider other)
   {
       if (other.gameObject.CompareTag("Player"))
           other.GetComponent<ConstantForce>().force = Vector3.zero;
   }
}
