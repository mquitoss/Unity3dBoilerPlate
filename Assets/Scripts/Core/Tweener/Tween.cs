using UnityEngine;
using System.Collections;

public delegate void TweenCallback( Tween tween );

abstract public class Tween
{
	protected GameObject target;
	private float time;
	private float currentTime;
	private Ease ease;
	private bool isDone;
	private bool isDelayed;
	private float delayTime;
	
	public event TweenCallback onTweenDone;
	
	public Tween ( GameObject target, float time, Ease ease )
	{
		this.target = target;
		this.time = time;
		this.ease = ease;
		currentTime = 0.0f;
		isDone = false;
	}
	
	public Tween withDelay ( float delayTime )
	{
		isDelayed = true;
		this.delayTime = delayTime;
		
		return this;
	}
	
	public void update ()
	{
		if ( isDone ) return;
		if ( isDelayed ) {
			delayTime -= Time.deltaTime;
			if ( delayTime < 0.0f ) {
				isDelayed = false;
			}
			else {
				return;
			}
		}
		
		currentTime += Time.deltaTime;
		if ( currentTime > time ) {
			perform ( 1.0f );
			onDone ();
		}
		else {
			float t = Equations.ChangeFloat ( currentTime, 0.0f, 1.0f, time, ease );
			perform ( t );
		}
	}
	
	abstract protected void perform ( float t );
	
	private void onDone()
	{
		isDone = true;
		
		if ( onTweenDone != null )
			onTweenDone( this );
	}
}
