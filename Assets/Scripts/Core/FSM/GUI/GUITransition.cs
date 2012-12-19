using UnityEngine;
using System.Collections;

public abstract class GUITransition : MonoBehaviour
{
	protected FSMTransitionWithGUI transition;
	
	public virtual void init( FSMTransitionWithGUI transition )
	{
		this.transition = transition;
	}
}
