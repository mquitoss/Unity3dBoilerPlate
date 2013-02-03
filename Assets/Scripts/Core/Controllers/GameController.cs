using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : Controller
{
	// GameElements
	private List<GameElement> elements;
	public TimelineController timelineController;
	public TweenController tweenController;
	
	/**************************************************************************
	 * Main
	 */

	void Awake()
	{
		elements = new List<GameElement>();
	}
	
	public override void init ()
	{
		if ( timelineController != null ) {
			addElement ( timelineController );
		}

		if ( tweenController != null ) {
			addElement ( tweenController );
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
	
	public void addElement ( GameElement gameElement )
	{
		elements.Add( gameElement );
		gameElement.init ();
	}
}
