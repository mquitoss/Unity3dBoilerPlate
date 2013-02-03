using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TweenController : Controller
{
	private List<Tween> tweens;
	
	public override void init ()
	{
		base.init ();
		tweens = new List<Tween>();
	}
	
	public override void reset ()
	{
		base.reset ();
		
		//foreach ( Tween tween in tweens ) {
		//	onTweenOn ( tween );
		//}
	}
	
	public override void update ()
	{
		base.update ();

		for ( int i = 0; i < tweens.Count; i++ ) {
			Tween tween = tweens[i];
			tween.update ();
		}
	}
	
	public void addTween ( Tween tween )
	{
		tweens.Add ( tween );
		tween.onTweenDone += onTweenOn;
	}
	
	public void onTweenOn ( Tween tween )
	{
		tween.onTweenDone -= onTweenOn;
		tweens.Remove ( tween );
	}
}
