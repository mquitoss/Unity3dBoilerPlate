using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : Controller
{
	// GameElements
	private List<GameElement> elements;
	
	/**************************************************************************
	 * Main
	 */

	void Awake()
	{
		api.applicationGameController.gameController = this;
		elements = new List<GameElement>();
	}
	
	public override void init ()
	{
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
	
	public void addElement ( GameElement gameElement )
	{
		elements.Add( gameElement );
		gameElement.init ();
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
