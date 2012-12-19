using UnityEngine;
using System.Collections;

public class FSMStatePlaying : FSMState
{
	public FSMStatePlaying ( FiniteStateMachine finiteStateMachine ) : base ( finiteStateMachine )
	{
	}

	public override void execute ()
	{
		if ( GameController.Instance != null ) {
			GameController.Instance.update();
		}
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
		Debug.Log( "STATE: exit " + this.ToString() );
	}
}
