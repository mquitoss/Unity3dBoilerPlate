public abstract class FSMTransition
{
	public FiniteStateMachine finiteStateMachine { get { return destination.finiteStateMachine; } }
	public GameElement gameElement { get { return finiteStateMachine.gameElement; } }
	public FSMState destination;
	
	public FSMTransition( FSMState destination )
	{
		this.destination = destination;
	}
	
	protected void finish()
	{
		finiteStateMachine.enterState( destination );
	}
	
	public virtual void execute () {}
	public virtual void fixedExecute() {}
	public virtual void enter () {}
	public virtual void exit () {}
	
	public virtual void onControllerLoaded() {}
}
