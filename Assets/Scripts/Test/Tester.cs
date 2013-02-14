using UnityEngine;
using System.Collections;

public class Tester : MonoBehaviour
{
	public GameObject target;
	public GameObject A;
	public GameObject B;
	
	void Start ()
	{
		BReached( null );
	}
	
	public void AReached ( Tween tween )
	{
		/*
		api.applicationTweenController.addTween ( new TweenMov( target, 2.0f, Ease.EaseOutQuad, B.transform.position, A.transform.position )
													.withOnDoneCallback( BReached ) );
		*/
		
		api.applicationTweenController.addTween ( TweenMov.moveFromOriginTo ( target, 2.0f, Ease.EaseOutQuad, A.transform.position )
													.withOnDoneCallback( BReached ) );
	}
	
	public void BReached ( Tween tween )
	{
		api.applicationTweenController.addTween ( new TweenMov( target, 2.0f, Ease.EaseOutQuad, A.transform.position, B.transform.position )
													.withOnDoneCallback( AReached ) );
	}
}
