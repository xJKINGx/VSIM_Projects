using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField] GameObject collisionObject; 
    Vector3 centre;
    Vector3 barycVector;
    Vector3 triangleUnitNormal;

    private void Start() {
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

    }
    // Update is called once per frame
    void Update()
    {
        
    }


}
