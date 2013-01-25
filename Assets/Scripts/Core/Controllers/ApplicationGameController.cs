using UnityEngine;
using System.Collections;

public class ApplicationGameController : Controller
{
	public enum State { LOADING, RUNNING, PAUSE }
	public State state;
	
	public GameController gameController;
	public TimelineController timelineController;
	
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
		
		if ( timelineController ) {
			timelineController.update();
		}
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
	}
	
	public override void reset ()
	{
		
	}
	
	/**************************************************************************
	 * Interface
	 */

	public void onDie()
	{
	}	

	public void onNextLevel()
	{
	}	

	public void onPause()
	{
	}	

	public void onResume()
	{
	}	

	public void onBackToMenu()
	{
	}
}
