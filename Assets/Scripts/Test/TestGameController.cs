using UnityEngine;
using System.Collections;

public class TestGameController : GameController
{
	// Test
	public RotateTest rotateTest;

	public override void init ()
	{
		if ( rotateTest != null ) {
			addElement( rotateTest );
		}
	}

	/**************************************************************************
	 * Interface
	 */
	
	public void onDie()
	{
		reset();
	}
	
	public void onNextLevel()
	{
		reset();
	}
}
