using UnityEngine;
using System.Collections;

public class FSMTransitionOnResume : FSMTransition
{
	public FSMTransitionOnResume( FSMState destination ) : base ( destination )
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
