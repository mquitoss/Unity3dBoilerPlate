using UnityEngine;
using System.Collections;
#pragma warning disable 0414

public abstract class Touchable : ActionTrigger
{
	public const int WAITING_TOUCH_STATE   = 0;
	public const int DOING_PREACTION_STATE = 1;
	public const int DOING_ACTION_STATE    = 2;
	public const int DOING_POSTACTION      = 3;
	public const int DONE_STATE            = 4;
	protected int state = WAITING_TOUCH_STATE;
	
	public const float RAY_CAST_DISTANCE = 100.0f;
	
	public KeyCode   debugActionKey;
	private Collider  buttonCollider;
	
	private Vector3 lastTouchPoint = Vector3.zero;
	private bool isTouching = false;

    public Camera cam;

    public bool isSwipeEnabled { get { return triggerTouchPhase == TouchPhase.Moved; } }
	public TouchPhase triggerTouchPhase = TouchPhase.Began;
	
	/**********************************************************************************************
	 * Button Def
	 */

	public int getState() { return state; }

	public void Start()
	{
		buttonCollider = GetComponent<Collider>();
		if ( buttonCollider == null ) Debug.LogError( "Touchable <" + gameObject.name + "> collider is null" );
		
		setWaitingTouchState();
	}

	public void Update () 
	{
		switch( state ) {
			case WAITING_TOUCH_STATE:   waitingTouchBehavior();    break;
			case DOING_PREACTION_STATE: doingPreActionBehavior();  break;
			case DOING_ACTION_STATE:    doingActionBehavior();     break;
			case DOING_POSTACTION:      doingPostActionBehavior(); break;
			case DONE_STATE:            doneBehavior();            break;
		}
	}

	public void setWaitingTouchState()    { state = WAITING_TOUCH_STATE;   initializeWaitingState(); }
	public void setDoingPreActionState()  { state = DOING_PREACTION_STATE; initializeDoingPreActionState(); }
	public void setDoingActionState()     { state = DOING_ACTION_STATE;    initializeDoingActionState(); }
	public void setDoingPostActionState() { state = DOING_POSTACTION;      initializeDoingPostActionState(); }
	public void setDoneState()            { state = DONE_STATE;            initializeDoneState(); }

	public virtual void initializeWaitingState()         {}
	public virtual void initializeDoingPreActionState()  {}

	public virtual void initializeDoingActionState()
	{
		performActions();
	}
	
	public virtual void initializeDoingPostActionState() {}
	public virtual void initializeDoneState()            {}
		
	public virtual void waitingTouchBehavior()
	{
		// Keyboard input
		if ( Input.GetKeyUp ( debugActionKey ) ) {
			onTouch( transform.position );
		}
	
		// Mouse input
		if ( triggerTouchPhase == TouchPhase.Moved && Input.GetMouseButton(0) ) {
			rayCastFromScreenPosition( Input.mousePosition );
		}
		
		if ( triggerTouchPhase == TouchPhase.Began && Input.GetMouseButtonDown(0) ) {
			rayCastFromScreenPosition( Input.mousePosition );
		}

		if ( triggerTouchPhase == TouchPhase.Ended && Input.GetMouseButtonUp(0) ) {
			rayCastFromScreenPosition( Input.mousePosition );
		}
		
		// Touch input
		for ( int i = 0; i < Input.touchCount; i++ ) {
			Touch touch = Input.GetTouch( i );
			if ( touch.phase == triggerTouchPhase ) {
				rayCastFromScreenPosition( touch.position );
			}
		}
	}
	
	private void rayCastFromScreenPosition( Vector3 pos )
	{
		Ray ray = cam.ScreenPointToRay ( pos );
		RaycastHit hit = new RaycastHit();
		if ( GetComponent<Collider>().Raycast ( ray, out hit, RAY_CAST_DISTANCE ) ) {
			onTouch( hit.point );
		}
	}	
	
	public virtual void doingPreActionBehavior()  { onPreActionDone(); }
	public virtual void doingActionBehavior()     { onActionDone(); }
	public virtual void doingPostActionBehavior() { onPostActionDone(); }
	public virtual void doneBehavior()            { setWaitingTouchState(); }
		
	/**********************************************************************************************
	 * Button Events
	 */
	
	public void onTouch( Vector3 touchPoint )
	{
		lastTouchPoint = touchPoint;
		isTouching = true;
		setDoingPreActionState();
	}
	
	public void onPreActionDone()
	{
		setDoingActionState();
	}
	
	public void onActionDone()
	{
		setDoingPostActionState();
	}
	
	public void onPostActionDone()
	{
		setDoneState();
	}
}
