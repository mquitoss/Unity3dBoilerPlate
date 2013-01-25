using UnityEngine;
using System.Collections;

public class ApplicationGameController : Controller
{
	
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
	}
	
	public override void reset ()
	{
		
	}
	
	public override void update ()
	{
	}
	
	public override void fixedUpdate ()
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
