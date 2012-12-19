using UnityEngine;
using System.Collections;

public class GameFiniteStateMachine : FiniteStateMachine
{
	// States
	public FSMState playingState;
	public FSMState pauseState;
	
	// Transitions
	public FSMTransition startTransition;
	public FSMTransition dieTransition;
	public FSMTransition nextLevelTransition;
	public FSMTransition pauseTransition;
	public FSMTransition resumeTransition;
	public FSMTransition backToMenuTransition;
	
	public GameFiniteStateMachine( GameElement gameElement ) : base ( gameElement )
	{
		// State
		playingState = new FSMStatePlaying( this );
		pauseState   = new FSMStatePause  ( this );
		
		// Transitions
		startTransition      = new FSMTransitionStart       ( playingState, "StartTimeline" );
		dieTransition        = new FSMTransitionOnDie       ( playingState, "DieTimeline" );
		nextLevelTransition  = new FSMTransitionOnNextLevel ( playingState, "NextLevelTimeline" );
		pauseTransition      = new FSMTransitionOnPause     ( pauseState   );
		resumeTransition     = new FSMTransitionOnResume    ( playingState );
		backToMenuTransition = new FSMTransitionOnBackToMenu( pauseState   );
		
		doTransition( startTransition );
	}
	
	public void onDie()
	{
		if ( currentState == playingState ) {
			doTransition( dieTransition );
		}
	}	

	public void onNextLevel()
	{
		if ( currentState == playingState ) {
			doTransition( nextLevelTransition );
		}
	}	

	public void onPause()
	{
		if ( currentState == playingState ) {
			doTransition( pauseTransition );
		}
	}	

	public void onResume()
	{
		if ( currentState == pauseState ) {
			doTransition( resumeTransition );
		}
	}	

	public void onBackToMenu()
	{
		if ( currentState == pauseState ) {
			doTransition( backToMenuTransition );
		}
	}	
}
