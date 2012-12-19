using UnityEngine;
using System.Collections;

public class FSMStatePause : FSMState
{
	public FSMStatePause ( FiniteStateMachine finiteStateMachine ) : base ( finiteStateMachine )
	{
	}

	public override void execute ()
	{
		
	}
	
	public override void fixedExecute()
	{
		
	}
	
	public override void enter ()
	{
		Debug.Log( "STATE: enter " + this.ToString() );
	}
	
	public override void exit ()
	{
		Debug.Log( "STATE: exit" + this.ToString() );
	}
}