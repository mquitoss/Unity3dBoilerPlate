using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : Controller
{
	private static GameController instance = null;
	public static GameController Instance { get { return instance; } }
	
	// Test
	public RotateTest rotateTest;

	// GameElements
	private List<GameElement> elements;
	
	/**************************************************************************
	 * Main
	 */

	void Awake()
	{
		instance = this;
		elements = new List<GameElement>();
	}
	
	public override void init ()
	{
		// add here game elements, order is rellevant
		elements.Add( rotateTest );
		
		// init elements
		for ( int i = 0; i < elements.Count; ++i ) {
			elements[i].init();
		}
	}
	
	public override void reset ()
	{
		// reset elements
		for ( int i = 0; i < elements.Count; ++i ) {
			elements[i].reset();
		}
	}
	
	public override void cleanUp ()
	{
		// cleanUp elements
		for ( int i = 0; i < elements.Count; ++i ) {
			elements[i].cleanUp();
		}
	}
	
	public override void update ()
	{
		// update elements
		for ( int i = 0; i < elements.Count; ++i ) {
			elements[i].update();
		}
	}
	
	/**************************************************************************
	 * Interface
	 */
	
	public void onDie()
	{
		reset();
	}
	
	public void onNextLevel()
	{
		reset();
	}
}
