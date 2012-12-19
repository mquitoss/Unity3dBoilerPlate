using System.Collections;
using System.Collections.Generic;

public class FiniteStateMachine
{
	public enum StateType { IDLE, RUNNING, TRANSITION }
	public StateType stateType = StateType.RUNNING;
	
	public bool isRunning { get { return stateType == StateType.RUNNING; } }
	public bool isInTransition { get { return stateType == StateType.TRANSITION; } }
	
	public string currentStateName { get { return getCurrentStateName(); } }
	
	public GameElement gameElement;
	public FSMState currentState;
	public FSMTransition currentTransition;
	
	public FiniteStateMachine( GameElement gameElement )
	{
		this.gameElement = gameElement;
		stateType = StateType.IDLE;
		currentState = null;
		currentTransition = null;
	}

	public void execute()
	{
		switch ( stateType ) {
			case StateType.IDLE      : break;
			case StateType.RUNNING   : currentState.execute();      break;
			case StateType.TRANSITION: currentTransition.execute(); break;
		}
	}
	
	public void fixedExecute()
	{
		switch ( stateType ) {
			case StateType.IDLE      : break;
			case StateType.RUNNING   : currentState.fixedExecute();      break;
			case StateType.TRANSITION: currentTransition.fixedExecute(); break;
		}
	}
	
	public void enterState( FSMState state )
	{
		stateType = StateType.RUNNING;
		currentState = state;
		if ( currentTransition != null ) currentTransition.exit();
		currentState.enter();
	}
	
	public void doTransition( FSMTransition transition )
	{
		stateType = StateType.TRANSITION;
		currentTransition = transition;
		if ( currentState != null ) currentState.exit();
		currentTransition.enter();
	}
	
    private string getCurrentStateName()
    {
        if ( currentState != null )
            return currentState.ToString();
        else
            return "NONE";
    }
}
