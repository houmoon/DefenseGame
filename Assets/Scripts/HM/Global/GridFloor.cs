using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridFloor : HM.Grid
{
	[SerializeField] private MeshFilter filter;
	[SerializeField] private BoxCollider collider;

	Mesh mesh;
	Vector3[] mVertices;
	Color[] mColors;
	int[] mIndices;


	public void GenerateFloorMesh()
	{
		mesh = new Mesh();
		mVertices = new Vector3[8];
		mIndices = new int[18];
		mColors = new Color[8];

		float sizex = CellSize.x * CellCount.x * 0.5f;
		float sizey = CellSize.y * CellCount.y * 0.5f;

		mVertices[0] = new Vector3(-sizex, 0, sizey);	//Left Up
		mVertices[1] = new Vector3(sizex, 0, sizey);	//Right Up
		mVertices[2] = new Vector3(-sizex, 0, -sizey);	//Left Down
		mVertices[3] = new Vector3(sizex, 0, -sizey);   //Right Down
		mVertices[4] = new Vector3(-sizex, -CellSize.z, sizey);   //Left Up
		mVertices[5] = new Vector3(sizex, -CellSize.z, sizey);    //Right Up
		mVertices[6] = new Vector3(-sizex, -CellSize.z, -sizey);  //Left Down
		mVertices[7] = new Vector3(sizex, -CellSize.z, -sizey);   //Right Down

		mIndices = new int[]
		{
			0, 1, 2, 1, 3, 2,
			2, 3, 6, 3, 7, 6,
			3, 1, 7, 1, 5, 7,
			1, 0, 5, 0, 4, 5,
			0, 2, 4, 2, 6, 4,
		};


		mColors[0] = Color.white;
		mColors[1] = Color.white;
		mColors[2] = Color.white;
		mColors[3] = Color.white;
		mColors[4] = Color.black;
		mColors[5] = Color.black;
		mColors[6] = Color.black;
		mColors[7] = Color.black;

		mesh.vertices = mVertices;
		mesh.triangles = mIndices;
		mesh.colors = mColors;
		mesh.name = "Floor";
		mesh.Optimize();
		mesh.RecalculateNormals();

		filter.mesh = mesh;
		collider.size = new Vector3(sizex * 2, 0.5f, sizey * 2);
		collider.center = new Vector3(0,-0.25f,0);
	}

	private void OnValidate()
	{
		GenerateFloorMesh();
	}

}


