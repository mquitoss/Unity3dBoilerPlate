using UnityEngine;
using System.Collections;

public class FSMTransitionOnNextLevel : FSMTransitionTimeline
{
	private TimelineController timeline;
	
	public FSMTransitionOnNextLevel( FSMState destination, string timeLineName ) : base ( destination, timeLineName )
	{
	}
	
	public override void execute ()
	{
		base.execute();
	}
	
	public override void enter ()
	{
		base.enter();
	}
	
	public override void exit ()
	{
		base.exit();
	}
}
