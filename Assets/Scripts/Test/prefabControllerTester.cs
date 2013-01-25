using UnityEngine;
using System.Collections;

public class prefabControllerTester : MonoBehaviour
{
	public KeyCode k;
	
	void Start () {
	
	}
	
	void Update ()
	{
		if ( Input.GetKeyDown ( k ) ) {
			api.poolController.getInstanceByPath ( "Test/CubeRed" );
		}
	}
}
