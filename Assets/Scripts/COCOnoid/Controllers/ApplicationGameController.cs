using UnityEngine;
using System.Collections;

public class ApplicationGameController : Controller
{
	private static ApplicationGameController instance = null;
	public static ApplicationGameController Instance { get { return instance; } }

	private GameFiniteStateMachine stateMachine;
	
	/**************************************************************************
	 * Main
	 */
	
	void Awake()
	{
		instance = this;
	}
	
	void Start()
	{
		init();
		reset();
	}
	
	void Update()
	{
		update();
	}
	
	void FixedUpdate()
	{
		fixedUpdate();
	}
	
	/**************************************************************************
	 * Controller
	 */
	
	public override void init ()
	{
		stateMachine = new GameFiniteStateMachine( this );
	}
	
	public override void reset ()
	{
		
	}
	
	public override void update ()
	{
		stateMachine.execute();
	}
	
	public override void fixedUpdate ()
	{
		stateMachine.fixedExecute();
	}

	/**************************************************************************
	 * Interface
	 */

	public void onDie()
	{
		stateMachine.onDie();
	}	

	public void onNextLevel()
	{
		stateMachine.onNextLevel();
	}	

	public void onPause()
	{
		stateMachine.onPause();
	}	

	public void onResume()
	{
		stateMachine.onResume();
	}	

	public void onBackToMenu()
	{
		stateMachine.onBackToMenu();
	}
}
