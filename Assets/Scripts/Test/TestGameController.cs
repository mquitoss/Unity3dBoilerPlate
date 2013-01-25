using UnityEngine;
using System.Collections;

public class TestGameController : GameController
{
	// Test
	public RotateTest rotateTest;

	public override void init ()
	{
		addElement( rotateTest );
	}
}
