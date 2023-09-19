using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TriangleScript : MonoBehaviour
{

    [SerializeField] TextAsset TriangleInfo;

    Vector3 NormalVector = new Vector3(0.0f, 0.0f, 0.0f);
    Vector3[] Vertices;
    int[] Indices;
    // Start is called before the first frame update
    void Awake()
    {
        // var finds the type so we don't have to
        // var filter = gameObject.AddComponent<MeshFilter>();
        // var renderer = gameObject.AddComponent<MeshRenderer>();

        // var mesh = new Mesh
        // {
        //     vertices = Vertices,
        //     triangles = Indices
        // };

        // filter.sharedMesh = mesh;
        Debug.Log(TriangleInfo.text);
        Debug.Log(TriangleInfo.text.ToString());
        Debug.Log(TriangleInfo.dataSize);

        for (int i = 0; i < TriangleInfo.dataSize; i++)
        {
            string lineCheck = TriangleInfo.ToString()[i].ToString();
            if (i + 1 < TriangleInfo.dataSize)
            {
                lineCheck.Concat(TriangleInfo.ToString()[i + 1].ToString());
            }

            if (lineCheck == "\n")
            {
                Debug.Log("testing");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 CalculateNormalVector()
    {
        Vector3 RetVector = new Vector3(0.0f, 0.0f, 0.0f);
        return RetVector;
    }
    
    void FetchVertices()
    {
        for(int i = 0; i < 5; i++)
        {
            
        }
    }

    void FetchIndices()
    {
        for(int i = 0; i < 5; i++)
        {
            
        }
    }
}
