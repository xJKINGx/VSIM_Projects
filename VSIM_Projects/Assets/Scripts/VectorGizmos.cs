using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorGizmos : MonoBehaviour
{
    [SerializeField] bool ShowLocal = false;
    [SerializeField] float GizmoLength = 2.0f;
    private void OnDrawGizmos() 
    {
        if (!ShowLocal)
        {
            // World orientation
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + GizmoLength,
                                                            transform.position.y,
                                                            transform.position.z)); 
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, new Vector3(transform.position.x,
                                                            transform.position.y + GizmoLength,
                                                            transform.position.z));
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, new Vector3(transform.position.x,
                                                            transform.position.y,
                                                            transform.position.z + GizmoLength));     
        }
        else
        {
            // Local orientation
        }
    
    }
}
