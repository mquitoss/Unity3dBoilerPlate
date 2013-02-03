using UnityEngine;
using System.Collections;

public class ActionActivate : Action
{
	public GameObject target;
	public bool isActive;
	
	public override void perform ()
	{
		target.SetActiveRecursively ( isActive );
	}
}
