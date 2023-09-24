using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEditor.Timeline;
using UnityEngine;

public class SpherePhysics : MonoBehaviour
{
    public static SpherePhysics sphereInstance { get; private set; }

    [SerializeField] public float SphereRadius = 1.0f;
    [SerializeField] float SphereWeight = 0.06f;

    public float gravity = 9.81f;

    // They're both zero-vectors, AKA. Vector3(0.0f, 0.0f, 0.0f)
    Vector3 Velocity = Vector3.zero;
    Vector3 Acceleration = Vector3.zero;

    private void Awake() {
        sphereInstance = this;
    }

    void OnDrawGizmos() {
        Gizmos.color = new Color(1.0f, 0.0f, 0.0f, 0.3f);
        Gizmos.DrawSphere(transform.position, SphereRadius);    
    }
    
    // Fixed update runs at a constant FPS, important for physics
    // In FixedUpdate we used Time.fixedDeltaTime as opposed to Time.deltaTime in Update()
    void FixedUpdate() 
    {
        Triangle triangleRef = Collision.ColInstance.CurrentTriangle;
        
        // Velocity before potential collision
        Vector3 startVel = Velocity;
        Velocity += Vector3.down * gravity * Time.fixedDeltaTime;
        transform.position += Velocity * Time.fixedDeltaTime;

        Acceleration = Vector3.down * gravity * SphereWeight;
        
        if (triangleRef != null)
        {
            // Velocity after collision
            Vector3 colVel = Velocity - Vector3.Dot(Velocity, triangleRef.UnitNormalVector) * triangleRef.UnitNormalVector;
            float velNorm = Vector3.Dot(triangleRef.UnitNormalVector, colVel);
            colVel += -velNorm * triangleRef.UnitNormalVector;

            Velocity = colVel;

        }
       
        transform.position = new Vector3(transform.position.x, BarycentricCoordinates.barycInstance.HeightFromBaryc(new Vector2(transform.position.x, transform.position.z)) + sphereInstance.SphereRadius, transform.position.z);
        
        // Debug logs code originally from Mathias Mohn Mørch
        Debug.LogWarning($"Velocity : {Velocity} | Length : {Velocity.magnitude}");
        Debug.LogWarning($"Position : {transform.position} | Length : {Velocity.magnitude}");
            
        Acceleration = (Velocity - startVel) / Time.deltaTime;
        Debug.LogWarning($"Acceleration : {Acceleration} | Length : {Acceleration.magnitude}");        

    }  
}
