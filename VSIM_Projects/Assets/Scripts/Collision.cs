using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField] GameObject collisionObject; 
    Vector3 centre;
    Vector3 barycVector;

    private void Start() {
        centre = collisionObject.transform.position;
        barycVector = collisionObject.transform.position;
        barycVector.y = BarycentricCoordinates.barycInstance.HeightFromBaryc(new Vector2(collisionObject.transform.position.x, collisionObject.transform.position.z));
    }
    // Update is called once per frame
    void Update()
    {
        
    }


}
