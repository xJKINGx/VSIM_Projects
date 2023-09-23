using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField] GameObject collisionObject; 
    Vector3 centre;

    private void Start() {
        centre = collisionObject.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        
    }


}
