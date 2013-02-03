using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimelineController : Controller
{
	private List<Timeline> timelines;
	private Dictionary<string,Timeline> timelinesDic;
	
	void Awake ()
	{
		// add static timelines
		timelines = new List<Timeline>( GetComponentsInChildren<Timeline>() );
		timelinesDic = new Dictionary<string,Timeline>();
		foreach ( Timeline timeline in timelines ) {
			timelinesDic[timeline.gameObject.name] = timeline;
		}
	}
	
	public Timeline play ( string timelineName )
	{
		if ( timelinesDic.ContainsKey ( timelineName ) ) {
			Timeline timeline = timelinesDic[timelineName];
			playTimeline ( timeline );
			return timeline;
		}
		else {
			// lookat the pool
			GameObject timelineObj = api.poolController.getInstanceByName( "Timelines", timelineName );
			if ( timelineObj != null ) {
				Timeline timeline = timelineObj.GetComponent<Timeline>();
				if ( timeline != null ) {
					timelines.Add ( timeline );
					timeline.transform.parent = transform;
					playTimeline ( timeline );
					return timeline;
				}
			}
			
			Debug.LogError ( "Timeline '" + timelineName + "' does not exists"  );
			return null;
		}
	}
	
	private void playTimeline ( Timeline timeline )
	{
		timeline.onTimelineDone += onTimelineDone;
		timeline.play ();
	}
	
	public override void init ()
	{
		base.init ();
		for ( int i = 0; i < timelines.Count; i++ ) {
			timelines[i].init ();
		}
	}
	
	public override void reset ()
	{
		base.reset ();
		for ( int i = 0; i < timelines.Count; i++ ) {
			timelines[i].init ();
		}
	}
	
	public override void update ()
	{
		base.update ();
		for ( int i = 0; i < timelines.Count; i++ ) {
			timelines[i].update ();
		}
	}
	
	public void onTimelineDone ( Timeline timeline )
	{
		timeline.onTimelineDone -= onTimelineDone;
		if ( !timelinesDic.ContainsKey ( timeline.gameObject.name ) ) {
			timelines.Remove ( timeline );
			api.poolController.dumpElement( timeline.gameObject );
		}
	}
}
