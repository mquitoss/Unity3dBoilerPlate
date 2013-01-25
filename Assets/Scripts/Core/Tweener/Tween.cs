using UnityEngine;
using System.Collections;

public delegate void TweenCallback( Tween tween );

abstract public class Tween
{
	protected GameElement target;
	private float time;
	private float currentTime;
	private Ease ease;
	private bool isDone;
	
	public event TweenCallback onTweenDone;
	
	public Tween ( GameElement target, float time, Ease ease )
	{
		this.target = target;
		this.time = time;
		this.ease = ease;
		currentTime = 0.0f;
		isDone = false;
	}
	
	public void update ()
	{
		if ( isDone ) return;
			
		currentTime += Time.deltaTime;
		if ( currentTime > time ) {
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
