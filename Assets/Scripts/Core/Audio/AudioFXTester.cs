using UnityEngine;
using System.Collections;

public class AudioFXTester : MonoBehaviour
{
	public KeyCode k;
	public string audioFXKey = "<key>";
	public AudioFXController audioFXController;
	public float pitch = 1.0f;
	
	void Update ()
	{
		if ( Input.GetKeyUp( k ) ) {
			audioFXController.play( audioFXKey, 0.0f, pitch );
		}	
	}
}
