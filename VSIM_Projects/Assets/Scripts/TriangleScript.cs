using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class TriangleScript : MonoBehaviour
{

    [SerializeField] TextAsset TriangleVertices;
    [SerializeField] TextAsset TriangleIndices;

    Vector3 NormalVector = new Vector3(0.0f, 0.0f, 0.0f);
    List<Vector3> Vertices = new List<Vector3>();
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
       //Debug.Log(TriangleInfo.text);
       //Debug.Log(TriangleInfo.text.ToString());
       // Debug.Log(TriangleInfo.dataSize);

        FetchVertices();
        for (int i = 0; i < Vertices.Count; i++)
        {
            Debug.Log("(" + Vertices[i][0] + ", " + Vertices[i][1] + ", " + Vertices[i][2] + ")");
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
        string text = TriangleVertices.text;

        Vector3 Vertex;
        List<string> lines = text.Split(new string[] {"\r\n","\r", "\n"}, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
        List<string> stringVertex = new List<string>();

        for (int i = 0; i < lines.Count; i++)
        {
            stringVertex = lines[i].Split(new char[] {'(', ',', ')'}, StringSplitOptions.RemoveEmptyEntries).ToList<string>();

            float x = float.Parse(stringVertex[0], CultureInfo.InvariantCulture);
            float y = float.Parse(stringVertex[1], CultureInfo.InvariantCulture);
            float z = float.Parse(stringVertex[2], CultureInfo.InvariantCulture);
            Vertex = new Vector3(x, y, z);
            Vertices.Add(Vertex);
        }

    }

    void FetchIndices()
    {
        
    }
}
