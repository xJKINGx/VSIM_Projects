using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public static Collision ColInstance { get; private set; }
    [SerializeField] GameObject collisionObject; 
    Vector3 centre;
    Vector3 barycVector;
    Vector3 triangleUnitNormal;
    //float ballRadius = SpherePhysics.sphereInstance.SphereRadius;
    [System.NonSerialized]
    public Vector3 collisionPoint;

    public Triangle CurrentTriangle;



    private void Awake() 
    {
        ColInstance = this;   
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        centre = collisionObject.transform.position;
        CurrentTriangle = CheckCurrentTriangle();
        // Get me dem values
        barycVector = collisionObject.transform.position;
        barycVector.y = BarycentricCoordinates.barycInstance.HeightFromBaryc(new Vector2(collisionObject.transform.position.x, collisionObject.transform.position.z));

        if (CurrentTriangle != null)
        {
            collisionPoint = centre + (Vector3.Dot(barycVector - centre, CurrentTriangle.UnitNormalVector)) * CurrentTriangle.UnitNormalVector;
        }
        

/*         // Are we colliding?
        if (Mathf.Abs(Vector3.Dot(barycVector - centre, CurrentTriangle.UnitNormalVector)) < SpherePhysics.sphereInstance.SphereRadius)
        
            //collisionObject.transform.position = new Vector3(collisionObject.transform.position.x, barycVector.y, collisionObject.transform.position.z);
            //centre += Vector3.Dot(collisionPoint + SpherePhysics.sphereInstance.SphereRadius, triangleUnitNormal); // <--- ?????
        } */
    }

    Triangle CheckCurrentTriangle()
    {
        for (int i = 0; i < TriangleScript.triangleInstance.madeTriangles.Count; i++)
        {
            if (TriangleScript.triangleInstance.madeTriangles[i].IsInTriangle(centre))
            {
                //Debug.Log("Found triangle");
                return TriangleScript.triangleInstance.madeTriangles[i];
            }
        }

        //Debug.LogWarning("Could not find triangle");
        return null;
        
    }
}
