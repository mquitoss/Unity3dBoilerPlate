using UnityEngine;
using System.Collections;

public class ActionTrigger : MonoBehaviour
{
	public Action[]  actions;
	
	public void Awake()
	{
		link();
	}
	
	public void link()
	{
		actions = GetComponentsInChildren<Action>();
	}
	
	public void performActions()
	{
		for ( int i = 0; i < actions.Length; i++ ) {
			actions[i].perform();
		}
	}
}
