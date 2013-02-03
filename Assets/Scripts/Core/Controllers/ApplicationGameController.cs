using UnityEngine;
using System.Collections;

public class ApplicationGameController : Controller
{
	public enum State { LOADING, RUNNING, PAUSE }
	public State state;
	
	public GameController gameController;
	public TimelineController timelineController;
	public TweenController tweenController;
	
	/**************************************************************************
	 * Main
	 */
	
	void Awake()
	{
		api.applicationGameController = this;
	}
	
	public override void Start()
	{
		base.Start ();
		init();
		reset();
	}
	
	void Update()
	{
		switch ( state ) {
			case State.LOADING: loadingBehavior (); break;
			case State.RUNNING: runningBehavior (); break;
			case State.PAUSE: pauseBehavior (); break;
		}
		
		if ( timelineController != null ) timelineController.update ();
		if ( tweenController != null ) tweenController.update ();
	}
	
	void FixedUpdate()
	{
	}
	
	/**************************************************************************
	 * Behavior
	 */
	
	private void loadingBehavior()
	{
		
	}
	
	private void runningBehavior()
	{
		if ( gameController != null ) {
			gameController.update ();
		}
	}
	
	private void pauseBehavior()
	{
		
	}

	/**************************************************************************
	 * Controller
	 */
	
	public override void init ()
	{
		if ( gameController != null ) gameController.init ();
		if ( timelineController != null ) timelineController.init ();
		if ( tweenController != null ) tweenController.init ();
	}
	
	public override void reset ()
	{
		state = State.LOADING;
		
		if ( timelineController != null ) timelineController.reset ();
		if ( tweenController != null ) tweenController.reset ();
	}
	
	/**************************************************************************
	 * Interface
	 */
	
	public void onPlay ()
	{
		state = State.RUNNING;
		if ( gameController != null ) gameController.reset ();
	}
	
	public void onGameOver()
	{
		state = State.PAUSE;
		api.applicationTimelineController.play ( "TimelineGameOver" );
	}
}
