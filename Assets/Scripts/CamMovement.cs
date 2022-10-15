using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    public GameObject Player;
    private Vector3 _offset = new Vector3(5.68f, 1f, -10);
    void Update()
    {
        transform.position = Player.transform.position + _offset;
    }
}
