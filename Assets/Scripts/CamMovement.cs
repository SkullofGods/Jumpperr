using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    public GameObject Player;
    public Vector3 offset = new Vector3();
    void Update()
    {
        transform.position = Player.transform.position + offset;
    }
}
