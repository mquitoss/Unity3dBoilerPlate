using UnityEngine;
using System.Collections;

public class FSMTransitionTimeline : FSMTransition
{
	private TimelineController timeline;
	
	public FSMTransitionTimeline( FSMState destination, string timeLineName ) : base ( destination )
	{
		GameObject timelineObj = PoolController.Instance.getInstanceByName( "GamePlay", timeLineName );
		timelineObj.transform.parent = destination.finiteStateMachine.gameElement.transform;
		timeline = timelineObj.GetComponent<TimelineController>();
		timeline.onTimelineDone += onDone;
	}
	
	public void onDone()
	{
		GameController.Instance.onDie();
		finish();
	}
	
	public override void execute ()
	{
		timeline.update();
	}
	
	public override void enter ()
	{
		timeline.play();
	}
}
