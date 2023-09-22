using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEditor.Timeline;
using UnityEngine;


public class SpherePhysics : MonoBehaviour
{
    [SerializeField] float SphereRadius = 1.0f;
    [SerializeField] float SphereWeight = 1.0f;

    public float gravity = -9.81f;

    // They're both zero-vectors, AKA. Vector3(0.0f, 0.0f, 0.0f)
    Vector3 Velocity = Vector3.zero;
    Vector3 Acceleration = Vector3.zero;

    void OnDrawGizmos() {
        Gizmos.color = new Color(1.0f, 0.0f, 0.0f, 0.3f);
        Gizmos.DrawSphere(transform.position, SphereRadius);    
    }
    
    // Fixed update runs at a constant FPS, important for physics
    // In FixedUpdate we used Time.fixedDeltaTime as opposed to Time.deltaTime in Update()
    void FixedUpdate() 
    {
        // Force applied to a free falling object
        Velocity.y += 0.5f * gravity * Time.fixedDeltaTime;
        // Since only the y-axis is affected by gravity, we can just add the velocity to the
        // transform, this might need to be changed later though
        transform.position += new Vector3(0, Velocity.y * Time.fixedDeltaTime, 0);
    }

    // Since we have no rigidbody we need to calculate the movement ourselves
    void Move()
    {

    }
}
