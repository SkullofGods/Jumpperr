using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FingerSlingshot : MonoBehaviour
{
   
    private Vector3 SlingshotMiddleVector;

    public LineRenderer TrajectoryLineRenderer;
    
    public GameObject Player;
    public float ThrowSpeed;
    private bool _isFlying = false;
    Vector3 _loca = new Vector3();
    Vector2 _mousePos = new Vector2();
    
    public Projectile liver;
    public MovementWithButtons speed;

    private float _startSpeed;

    void Start()
    {
        TrajectoryLineRenderer.sortingLayerName = "Foreground";
        _startSpeed = speed.speed;
    }
    
    public void Update()
    {
        _mousePos.x = Input.mousePosition.x;
        _mousePos.y = Input.mousePosition.y;
        SlingshotMiddleVector = Player.transform.position;
        _loca = Camera.main.ScreenToWorldPoint(new Vector3(_mousePos.x, _mousePos.y, 10) );
    }

    private void OnMouseDrag()
    {
        if (!_isFlying && !liver.Dead)
        {
            float distance = Vector3.Distance(SlingshotMiddleVector, _loca);
            //display projected trajectory based on the distance
            DisplayTrajectoryLineRenderer2(distance);
        }
    }

    private void OnMouseUp()
    {
        if (!_isFlying && !liver.Dead)
        {
            SetTrajectoryLineRenderesActive(false);
            float distance = Vector3.Distance(SlingshotMiddleVector, _loca);
            ThrowBird(distance);
        }
    }

    private void ThrowBird(float distance)
    {
        //get velocity
        Vector3 velocity = SlingshotMiddleVector - _loca;
        if (velocity.x >= 2.5f)
            velocity.x = 2.5f;
        if (velocity.y >= 2.5f)
            velocity.y = 2.5f;
        if (velocity.x <= -2.5f)
            velocity.x = -2.5f;
        if (velocity.y <= -2.5f)
            velocity.y = -2.5f;
        if (distance >= 6f)
            distance = 6f;
        Player.GetComponent<Rigidbody>().velocity = new Vector3(velocity.x, velocity.y, 0f) * ThrowSpeed * distance;
    }
    
    void SetTrajectoryLineRenderesActive(bool active)
    {
        TrajectoryLineRenderer.enabled = active;
    }

    void DisplayTrajectoryLineRenderer2(float distance)
    {
        SetTrajectoryLineRenderesActive(true);
        Vector3 v2 = SlingshotMiddleVector - Player.transform.position;
        int segmentCount = 15;
        float segmentScale = 2;
        Vector3[] segments = new Vector3[segmentCount];

        // The first line point is wherever the player's cannon, etc is
        segments[0] = Player.transform.position;

        // The initial velocity
        Vector3 segVelocity = new Vector3(v2.x, v2.y, 0f) * ThrowSpeed * distance;

        float angle = Vector2.Angle(segVelocity, new Vector2(1, 0));
        float time = segmentScale / segVelocity.magnitude;
        for (int i = 1; i < segmentCount; i++)
        {
            //x axis: spaceX = initialSpaceX + velocityX * time
            //y axis: spaceY = initialSpaceY + velocityY * time + 1/2 * accelerationY * time ^ 2
            //both (vector) space = initialSpace + velocity * time + 1/2 * acceleration * time ^ 2
            float time2 = i * Time.fixedDeltaTime * 5;
            segments[i] = segments[0] + segVelocity * time2 + 0.5f * Physics.gravity * Mathf.Pow(time2, 2);
        }

        TrajectoryLineRenderer.SetVertexCount(segmentCount);
        for (int i = 0; i < segmentCount; i++)
            TrajectoryLineRenderer.SetPosition(i, segments[i]);
    }

    private void OnCollisionStay(Collision other)
    {
        speed.speed = _startSpeed;
        _isFlying = false;
    }

    private void OnCollisionExit(Collision other)
    {
        speed.speed = _startSpeed/2f;
        _isFlying = true;
    }
}
