using UnityEngine;
using System.Collections;

public class ApplicationGameController : Controller
{
	public enum State { LOADING, RUNNING, PAUSE }
	public State state;
	
	public GameController gameController;
	
	/**************************************************************************
	 * Main
	 */
	
	void Awake()
	{
		api.applicationGameController = this;
	}
	
	void Start()
	{
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
		gameController.update ();
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
