using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class BarycentricCoordinates : MonoBehaviour
{
	public static BarycentricCoordinates barycInstance; 

	private void Start() {
		findNormalVectors();
	}
	public float HeightFromBaryc(Vector2 playerPos)
	{
		Vector3 v0 = new Vector3();
		Vector3 v1 = new Vector3(); 
		Vector3 v2 = new Vector3();
		Vector3 baryc = new Vector3(-1, -1, -1);

		for (int i = 0; i < TriangleScript.triangleInstance.IndAmount / 3; i++)
		{

			int i1, i2, i3;
			i1 = TriangleScript.triangleInstance.Indices[i * 3];
			i2 = TriangleScript.triangleInstance.Indices[i * 3 + 1];
			i3 = TriangleScript.triangleInstance.Indices[i * 3 + 2];

			v0 = TriangleScript.triangleInstance.Vertices[i1];
			v1 = TriangleScript.triangleInstance.Vertices[i2];
			v2 = TriangleScript.triangleInstance.Vertices[i3];

			baryc = CalcBarycentricCoords(new Vector2(v0.x, v0.z), new Vector2(v1.x, v1.z), new Vector2(v2.x, v2.z), playerPos);

			if (baryc.x >= 0 && baryc.y >= 0 && baryc.z >= 0)
			{
				break;
			}
		}

		float height = v0.y * baryc.x + v1.y * baryc.y + v2.y * baryc.z;
		
		return height;
	}

	Vector3 CalcBarycentricCoords(Vector2 v0, Vector2 v1, Vector2 v2, Vector2 playerPos)
	{
		Vector2 v10 = v1 - v0;
		Vector2 v21 = v2 - v1;

		float area = Vector3.Cross(new Vector3(v10.x, v10.y, 0.0f), new Vector3(v21.x, v21.y, 0.0f)).z;


		Vector2 v0p = v0 - playerPos;
		Vector2 v1p = v1 - playerPos;
		Vector2 v2p = v2 - playerPos;

		float u = Vector3.Cross(new Vector3(v0p.x, v0p.y, 0.0f), new Vector3(v1p.x, v1p.y, 0.0f)).z / area;
		float v = Vector3.Cross(new Vector3(v1p.x, v1p.y, 0.0f), new Vector3(v2p.x, v2p.y, 0.0f)).z / area;
		float w = Vector3.Cross(new Vector3(v2p.x, v2p.y, 0.0f), new Vector3(v0p.x, v0p.y, 0.0f)).z / area;

		Vector3 tempBaryc = new Vector3(u, v, w);

		return tempBaryc;
	}

	void findNormalVectors()
	{
		for (int i = 0; i < TriangleScript.triangleInstance.IndAmount; i += 3)
    	{
        	Vector3 v1 = TriangleScript.triangleInstance.Vertices[TriangleScript.triangleInstance.Indices[i + 1]] - TriangleScript.triangleInstance.Vertices[TriangleScript.triangleInstance.Indices[i]];
        	Vector3 v2 = TriangleScript.triangleInstance.Vertices[TriangleScript.triangleInstance.Indices[i + 2]] - TriangleScript.triangleInstance.Vertices[TriangleScript.triangleInstance.Indices[i]];
        	Vector3 normal = Vector3.Cross(v1, v2);
			Vector3 normalizedNormal = normal;
			normalizedNormal.Normalize();

			TriangleScript.triangleInstance.triangleNormals.Add(normalizedNormal);

        	//TriangleScript.Instance.Vertices[TriangleScript.Instance.Indices[i]].normal += normal;
        	//TriangleScript.Instance.Vertices[TriangleScript.Instance.Indices[i + 1]].normal += normal;
        	//TriangleScript.Instance.Vertices[TriangleScript.Instance.Indices[i + 2]].normal += normal;
    	}

		//for (int i = 0; i < TriangleScript.Instance.Vertices.size(); i++)
    	//{
       	//	TriangleScript.Instance.Vertices[i].normal = glm::normalize(TriangleScript.Instance.Vertices[i].normal);
    	//}
	}
}
