using UnityEngine;
using System.Collections;

public abstract class FSMTransitionWithGUI : FSMTransition
{
	public GUITransition guiTransition;
	
	public FSMTransitionWithGUI ( FSMState destination, GUITransition guiTransition ) : base ( destination )
	{
		this.guiTransition = guiTransition;
	}
}
