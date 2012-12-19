using UnityEngine;
using System.Collections;

public abstract class GUITransitionCloseOpen : GUITransition
{
	public abstract void close();
	public abstract void open();
	public abstract void onCloseFinished();
	public abstract void onOpenFinished();	
}
