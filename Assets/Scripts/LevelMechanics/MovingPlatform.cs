using System;
using System.Collections;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 start, target;
    public float speed;

    private void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, target, Time.deltaTime * speed);
            if(Mathf.Abs(transform.localPosition.x - target.x) <= 0.01f || Mathf.Abs(transform.localPosition.y - target.y) <= 0.01)
                (start, target) = (target, start);
    }
}
