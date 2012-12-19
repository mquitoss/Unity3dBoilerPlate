using UnityEngine;
using System.Collections;

public class FSMTransitionStart : FSMTransitionTimeline
{
	public FSMTransitionStart( FSMState destination, string timeLineName ) : base ( destination, timeLineName ) {}
	
	public override void execute ()
	{
		base.execute();
	}
	
	public override void enter ()
	{
		base.enter();
		GameController.Instance.init();
		GameController.Instance.reset();
	}
	
	public override void exit ()
	{
		base.exit();
	}	
}
