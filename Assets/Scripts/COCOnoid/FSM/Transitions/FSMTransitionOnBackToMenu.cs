using UnityEngine;
using System.Collections;

public class FSMTransitionOnBackToMenu : FSMTransition
{
	public FSMTransitionOnBackToMenu( FSMState destination ) : base ( destination )
	{
		
	}

	public override void execute ()
	{
		finish();
	}
	
	public override void enter ()
	{
		Debug.Log( "TRANSITION: enter " + this.ToString() );
	}
	
	public override void exit ()
	{
		Debug.Log( "TRANSITION: exit " + this.ToString() );
	}
}
