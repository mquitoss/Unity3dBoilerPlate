public abstract class FSMState
{
	public FiniteStateMachine finiteStateMachine;
	public GameElement gameElement { get { return finiteStateMachine.gameElement; } }
	
	public FSMState ( FiniteStateMachine finiteStateMachine )
	{
		this.finiteStateMachine = finiteStateMachine;
	}
	
	public virtual void execute () {}
	public virtual void fixedExecute() {}
	public virtual void enter () {}
	public virtual void exit () {}
}
