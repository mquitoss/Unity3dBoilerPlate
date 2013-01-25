using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimelineController : Controller
{
	private List<Timeline> timelines;
	private Dictionary<string,Timeline> timelinesDic;
	
	void Awake ()
	{
		timelines = new List<Timeline>( GetComponentsInChildren<Timeline>() );
		timelinesDic = new Dictionary<string,Timeline>();
		foreach ( Timeline timeline in timelines ) {
			timelinesDic[timeline.gameObject.name] = timeline;
		}
	}
	
	public void play ( string timelineName )
	{
		if ( timelinesDic.ContainsKey( timelineName ) ) {
			timelinesDic[timelineName].play ();
		}
		else {
			Debug.LogError ( "Timeline '" + timelineName + "' does not exists"  );
		}
	}
	
	public override void init ()
	{
		base.init ();
		foreach ( Timeline timeline in timelines ) {
			timeline.init ();
		}
	}
	
	public override void reset ()
	{
		base.reset ();
		
		foreach ( Timeline timeline in timelines ) {
			timeline.init ();
		}
	}
	
	public override void update ()
	{
		base.update ();
		
		foreach ( Timeline timeline in timelines ) {
			timeline.update ();
		}
	}
}
