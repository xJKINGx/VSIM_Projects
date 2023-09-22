using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

/*public class BarycentricCoordinates : MonoBehaviour
{

float Heightmap::HeightFromBaryc(const glm::vec2& playerPos)
{
	glm::vec3 v0, v1, v2;
	glm::vec3 baryc{ -1, -1, -1 };

	for (int i = 0; i < mIndices.size() / 3; i++)
	{

		int i1, i2, i3;
		i1 = mIndices[i * 3];
		i2 = mIndices[i * 3 + 1];
		i3 = mIndices[i * 3 + 2];

		v0 = { mVertices[i1].pos };
		v1 = { mVertices[i2].pos };
		v2 = { mVertices[i3].pos };

		baryc = CalcBarycentricCoords(glm::vec2(v0[0], v0[2]), glm::vec2(v1[0], v1[2]), glm::vec2(v2[0], v2[2]), playerPos);

		if (baryc[0] >= 0 && baryc[1] >= 0 && baryc[2] >= 0)
		{
			//std::cout << "Found at triangle number: " + std::to_string(i / 3) << std::endl;
			break;
		}
	}

	float height = v0[1] * baryc[0] + v1[1] * baryc[1] + v2[1] * baryc[2];
	
	//std::cout << "v0: " << v0[1] << std::endl;
	//std::cout << "v1: " << v1[1] << std::endl;
	//std::cout << "v2: " << v2[1] << std::endl;
	//std::cout << "Players apparent height: " << std::to_string(height) << std::endl;
	
	return height;
}

glm::vec3 Heightmap::CalcBarycentricCoords(const glm::vec2& v0, const glm::vec2& v1, const glm::vec2& v2, const glm::vec2& playerPos)
{
	glm::vec2 v10 = v1 - v0;
	glm::vec2 v21 = v2 - v1;

	float area = glm::cross(glm::vec3(v10, 0.f), glm::vec3(v21, 0.0f))[2];


	glm::vec2 v0p = v0 - playerPos;
	glm::vec2 v1p = v1 - playerPos;
	glm::vec2 v2p = v2 - playerPos;

	float u = glm::cross(glm::vec3(v0p, 0.0f), glm::vec3(v1p, 0.0f))[2] / area;
	float v = glm::cross(glm::vec3(v1p, 0.0f), glm::vec3(v2p, 0.0f))[2] / area;
	float w = glm::cross(glm::vec3(v2p, 0.0f), glm::vec3(v0p, 0.0f))[2] / area;

	glm::vec3 tempBaryc = { u, v, w };

	//std::cout << "U: " << tempBaryc[0] << std::endl;
	//std::cout << "V: " << tempBaryc[1] << std::endl;
	//std::cout << "W: " << tempBaryc[2] << std::endl;

	return tempBaryc;
}
*/
}

public class BarycentricCoordinates : MonoBehaviour
{
	float HeightFromBaryc(Vector2 playerPos)
	{
		Vector3 v0, v1, v2;
		Vector3 baryc = new Vector3(-1, -1, -1);

		for (int i = 0; i < mIndices.size() / 3; i++)
		{

			int i1, i2, i3;
			i1 = mIndices[i * 3];
			i2 = mIndices[i * 3 + 1];
			i3 = mIndices[i * 3 + 2];

			v0 = { mVertices[i1].pos };
			v1 = { mVertices[i2].pos };
			v2 = { mVertices[i3].pos };

			baryc = CalcBarycentricCoords(new Vector2(v0.x, v0.z), new Vector2(v1.x, v1.z), new Vector2(v2.x, v2.z), playerPos);

			if (baryc[0] >= 0 && baryc[1] >= 0 && baryc[2] >= 0)
			{
				//std::cout << "Found at triangle number: " + std::to_string(i / 3) << std::endl;
				break;
			}
		}

		float height = v0[1] * baryc[0] + v1[1] * baryc[1] + v2[1] * baryc[2];
		
		//std::cout << "v0: " << v0[1] << std::endl;
		//std::cout << "v1: " << v1[1] << std::endl;
		//std::cout << "v2: " << v2[1] << std::endl;
		//std::cout << "Players apparent height: " << std::to_string(height) << std::endl;
		
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

		//std::cout << "U: " << tempBaryc[0] << std::endl;
		//std::cout << "V: " << tempBaryc[1] << std::endl;
		//std::cout << "W: " << tempBaryc[2] << std::endl;

		return tempBaryc;
	}
}
