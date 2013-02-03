using UnityEngine;
using System.Collections;

public class TweenMov : Tween
{
	private Vector3 fromPosition;
	private Vector3 toPosition;
	
	public TweenMov ( GameObject target, float time, Ease ease, Vector3 fromPosition, Vector3 toPosition ) : base ( target, time, ease )
	{
		this.fromPosition = fromPosition;
		this.toPosition = toPosition;
	}
	
	protected override void perform ( float t )
	{
		target.transform.position = fromPosition * ( 1.0f - t ) + toPosition * t;
	}
}
