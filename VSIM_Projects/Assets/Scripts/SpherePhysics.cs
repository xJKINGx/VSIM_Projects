using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEditor.Timeline;
using UnityEngine;


public class SpherePhysics : MonoBehaviour
{
    [SerializeField] float SphereRadius = 1.0f;
    [SerializeField] float SphereWeight = 1.0f;

    float SphereVelocity = 0.0f;
    float SphereAcceleration = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnDrawGizmos() {
        Gizmos.color = new Color(1.0f, 0.0f, 0.0f, 0.3f);
        Gizmos.DrawSphere(transform.position, SphereRadius);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Fixed update runs at a constant FPS, important for physics
    // In FixedUpdate we used Time.fixedDeltaTime as opposed to Time.deltaTime in Update()
    void FixedUpdate() 
    {
    
    }

    // Since we have no rigidbody we need to calculate the movement ourselves
    void Move()
    {
        float CurrentVelocity = FindVelocity(transform.position);
        float CurrentAcceleration = FindAcceleration();
    }

    float FindVelocity(Vector3 position)
    {
        return 1.0f;
    }

    float FindAcceleration()
    {
        return 1.0f;
    }

}
