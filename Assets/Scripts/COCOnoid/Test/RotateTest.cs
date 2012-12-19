using UnityEngine;
using System.Collections;

public class RotateTest : GameElement
{
	private const float angleSpeed = 50.0f;

	public override void reset ()
	{
		transform.rotation = Quaternion.identity;
	}
	
	public override void update ()
	{
		transform.Rotate( Vector3.one * angleSpeed * Time.deltaTime );
	}
}
