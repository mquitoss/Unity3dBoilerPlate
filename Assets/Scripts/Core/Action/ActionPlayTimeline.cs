using UnityEngine;
using System.Collections;

public class ActionPlayTimeline : Action
{
	public enum Type { APPLICATION, GAME }
	public Type type;

	public string timelineName = "<timeline_name>";
	
	public override void perform ()
	{
		if ( type == Type.APPLICATION ) {
			api.applicationTimelineController.play ( timelineName );
		}
		else {
			api.gameTimelineController.play ( timelineName );
		}
	}
}
