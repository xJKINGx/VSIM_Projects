using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TMPro;
using UnityEngine;


public class TriangleScript : MonoBehaviour
{
    public static TriangleScript triangleInstance { get; private set; } 
    [SerializeField] TextAsset TriangleVertices;
    [SerializeField] TextAsset TriangleIndices;

    [System.NonSerialized]
    public List<Vector3> Vertices = new List<Vector3>();
    [System.NonSerialized]
    public int VertAmount;
    [System.NonSerialized]
    public List<int> Indices = new List<int>();
    [System.NonSerialized]
    public int IndAmount;
    [System.NonSerialized]
    public List<Vector3> triangleNormals = new List<Vector3>();
    public List<Triangle> madeTriangles = new List<Triangle>();

    // Start is called before the first frame update
    void Awake()
    {
        triangleInstance = this;
        FetchVertices();
        FetchIndices();
        MakeTriangles();

        Debug.Log("VERTICES:");
        for (int i = 0; i < Vertices.Count; i++)
        {
            Debug.Log("(" + Vertices[i][0] + ", " + Vertices[i][1] + ", " + Vertices[i][2] + ")");
        }
        Debug.Log("INDICES:");
        for (int i = 0; i < Indices.Count; i++)
        {
            Debug.Log(Indices[i]);
        }
        
        // var finds the type so we don't have to
        var filter = gameObject.AddComponent<MeshFilter>();
        var renderer = gameObject.AddComponent<MeshRenderer>();
          
        var mesh = new Mesh
        {
            vertices = Vertices.ToArray(),
            triangles = Indices.ToArray()
        };

        mesh.RecalculateNormals();
        mesh.RecalculateTangents();

        filter.sharedMesh = mesh;
    }
    
    void FetchVertices()
    {
        string vertText = TriangleVertices.text;

        Vector3 Vertex;
        List<string> lines = vertText.Split(new string[] {"\r\n","\r", "\n"}, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
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
        VertAmount = Vertices.Count;
    }

    void FetchIndices()
    {
        string indText = TriangleIndices.text;

        List<string> indLines = indText.Split(new string[] {"\r\n", "\r", "\n"}, StringSplitOptions.RemoveEmptyEntries).ToList<string>();

        for (int i = 0; i < indLines.Count; i++)
        {
            int x = int.Parse(indLines[i]);
            Indices.Add(x);
        }
        IndAmount = Indices.Count;
    }

    void MakeTriangles()
    {
        for (int i = 0; i < IndAmount - 2; i += 3)
        {
            madeTriangles.Add(new Triangle(Vertices[Indices[i]], Vertices[Indices[i + 1]], Vertices[Indices[i + 2]]));
        }
    }

    private void OnDrawGizmos() 
    {
        if (Vertices.Count == 0)
        {
            FetchVertices();
            FetchIndices();
        }

        for (int i = 0; i < Indices.Count - 2; i += 3)
        {
            Gizmos.DrawLine(Vertices[Indices[i]], Vertices[Indices[i + 1]]);
            Gizmos.DrawLine(Vertices[Indices[i + 1]], Vertices[Indices[i + 2]]);
            Gizmos.DrawLine(Vertices[Indices[i + 2]], Vertices[Indices[i]]);
        }
    }
}

public class Triangle
{
    float lowestY;
    public List<Vector3> mVertices = new List<Vector3>();
    public Vector3 NormalVector = new Vector3();
    public Vector3 UnitNormalVector = new Vector3();

    int[] neighbors = new int[3];

    public Triangle()
    {

    }

    public Triangle(Vector3 p1, Vector3 p2, Vector3 p3)
    {
        mVertices.Add(p1);
        mVertices.Add(p2);
        mVertices.Add(p3);

        GetNormalVectors();
        NormalizeNormal();
    }

    public void NormalizeNormal()
    {
        UnitNormalVector = NormalVector;
        UnitNormalVector.Normalize();
    }

    void GetNormalVectors()
    {
        Vector3 v1 = mVertices[1] - mVertices[0];
        Vector3 v2 = mVertices[2] - mVertices[0];
        Vector3 normal = Vector3.Cross(v1, v2);
        NormalVector = normal;
    }

    public bool IsInTriangle(Vector3 ballPos)
	{
		Vector3 baryc = new Vector3();
        baryc = BarycentricCoordinates.barycInstance.CalcBarycentricCoords
        (
            new Vector2(mVertices[0].x, mVertices[0].z),
            new Vector2(mVertices[1].x, mVertices[1].z),
            new Vector2(mVertices[2].x, mVertices[2].z),
            new Vector2(ballPos.x, ballPos.z)
        );

        if (baryc.x < 0 || baryc.y < 0 || baryc.z < 0)
		{
            return false;
		}

        return true;
	}
}