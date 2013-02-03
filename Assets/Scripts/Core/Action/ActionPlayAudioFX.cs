using UnityEngine;
using System.Collections;

public class ActionPlayAudioFX : Action
{
	public string audioFXName = "<audioFXName>";
	public float pitch = 1.0f;
	
	public override void perform ()
	{
		api.audioFXController.play ( audioFXName, 0, pitch );
	}
}
