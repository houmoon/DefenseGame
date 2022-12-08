using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HM
{
	public class Grid : MonoBehaviour
	{
		[SerializeField] protected Vector2Int CellCount;
		[SerializeField] protected Vector3 CellSize;


		private void OnDrawGizmosSelected()
		{
			Vector3 pivot, v0, v1;
			Gizmos.color = Color.green;
			pivot = transform.position + (transform.right * CellCount.x * CellSize.x * -0.5f) + (transform.forward * CellCount.y * CellSize.y * -0.5f) + (transform.up * 0.01f);

			for (int i = 0; i < CellCount.x+1; i++)
			{
				v0 = pivot + (transform.right * CellSize.x * i);
				v1 = pivot + (transform.right * CellSize.x * i) + (transform.forward * CellSize.y * CellCount.y);

				Gizmos.DrawLine(v0,v1);

			}

			for (int j = 0; j < CellCount.y+1; j++)
			{
				v0 = pivot + (transform.forward * CellSize.y * j);
				v1 = pivot + (transform.forward * CellSize.y * j) + (transform.right * CellSize.x * CellCount.x);

				Gizmos.DrawLine(v0, v1);

			}
		}
	}
}


