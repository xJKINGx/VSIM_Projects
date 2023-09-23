using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Unity.Android.Types;
using UnityEngine;
using UnityEngine.UIElements;

public class Collision : MonoBehaviour
{
    [SerializeField] GameObject collisionObject; 
    Vector3 centre;
    Vector3 barycVector;
    Vector3 triangleUnitNormal;
    //float ballRadius = SpherePhysics.sphereInstance.SphereRadius;
    Vector3 collisionPoint;

    private void Start() {
        
    }
    // Update is called once per frame
    void Update()
    {
        // Get me dem values
        centre = collisionObject.transform.position;
        barycVector = collisionObject.transform.position;
        barycVector.y = BarycentricCoordinates.barycInstance.HeightFromBaryc(new Vector2(collisionObject.transform.position.x, collisionObject.transform.position.z));
        for (int i = 0; i < TriangleScript.triangleInstance.triangleNormals.Count; i++)
    	{
        	if (i == BarycentricCoordinates.barycInstance.currentTriangle)
            {
                triangleUnitNormal = TriangleScript.triangleInstance.triangleNormals[i];
            }
    	}
        collisionPoint = centre + (Vector3.Dot(barycVector - centre, triangleUnitNormal)) * triangleUnitNormal;

        // Are we colliding?
        if (Mathf.Abs(Vector3.Dot(barycVector - centre, triangleUnitNormal)) < SpherePhysics.sphereInstance.SphereRadius)
        {
            centre += Vector3.Dot(collisionPoint + SpherePhysics.sphereInstance.SphereRadius, triangleUnitNormal); // <--- ?????
        }
    }
}
