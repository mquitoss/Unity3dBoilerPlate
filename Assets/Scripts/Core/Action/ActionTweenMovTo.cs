using UnityEngine;
using System.Collections;

public class ActionTweenMovTo : Action
{
	public enum Type { APPLICATION, GAME }
	public Type type;
	public GameObject target;
	public float time;
	public Ease ease;
	public Vector3 toPoint;
	
	public override void perform ()
	{
		if ( type == Type.APPLICATION ) {
			api.applicationTweenController.addTween ( new TweenMov ( target, time, ease, target.transform.position, toPoint ) );
		}
		else {
			api.gameTweenController.addTween ( new TweenMov ( target, time, ease, target.transform.position, toPoint ) );
		}
	}
}
