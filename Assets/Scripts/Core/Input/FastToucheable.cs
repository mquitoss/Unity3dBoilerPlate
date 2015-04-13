using UnityEngine;
using System.Collections;

public abstract class FastToucheable : ActionTrigger
{
	public const float RAY_CAST_DISTANCE = 100.0f;
	
	void Update ()
	{
		// Check mouse input
		if( Input.GetMouseButtonDown( 0 ) ){
			rayCastFromScreenPosition( Input.mousePosition );
		}		
		
		// Check touches
		for ( int i = 0; i < Input.touchCount; i++ )
		{
			Touch touch = Input.GetTouch( i );
			if ( touch.phase == TouchPhase.Began )
			{
				rayCastFromScreenPosition( touch.position );
			}
		}
	}

	private void rayCastFromScreenPosition( Vector3 pos )
	{
		Ray ray = Camera.main.ScreenPointToRay ( pos );
		RaycastHit hit = new RaycastHit();
		if ( GetComponent<Collider>().Raycast ( ray, out hit, RAY_CAST_DISTANCE ) )
		{
			onTouch();
		}
	}
	
	public void onTouch()
	{
		performActions();	
	}
}
