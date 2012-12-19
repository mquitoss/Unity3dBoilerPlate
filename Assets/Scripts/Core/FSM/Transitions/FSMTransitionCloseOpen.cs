using UnityEngine;
using System.Collections;

public abstract class FSMTransitionCloseOpen : FSMTransitionWithGUI
{
	protected GUITransitionCloseOpen guiTransitionCloseOpen;
		
	public FSMTransitionCloseOpen( FSMState destination, GUITransitionCloseOpen guiTransition ) : base( destination, guiTransition )
	{
		guiTransitionCloseOpen = guiTransition;
	}
	
	public override void enter()
	{
		guiTransitionCloseOpen.close();		
	}
	
	public virtual void onCloseFinished()
	{
		guiTransitionCloseOpen.open();
	}
	
	public virtual void onOpenFinished()
	{
		finish();			
	}
}
