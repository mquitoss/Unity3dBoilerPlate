using UnityEngine;
using System.Collections;

public class DrawHandler : MonoBehaviour {

	void OnDrawGizmos()
	{
		Gizmos.color = new Color( 255, 255, 255, 0.5f );
		Gizmos.DrawSphere( transform.position, 0.5f );
	}
}
