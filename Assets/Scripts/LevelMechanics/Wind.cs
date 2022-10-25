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
       other.GetComponent<ConstantForce>().force= direction*force;
   }

   private void OnTriggerExit(Collider other)
   {
       other.GetComponent<ConstantForce>().force = Vector3.zero;
   }
}
