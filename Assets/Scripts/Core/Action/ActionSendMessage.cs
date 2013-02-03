using UnityEngine;
using System.Collections;

public class ActionSendMessage : Action
{
	public GameObject target;
	public string methodName = "<method_name>";
	
	public override void perform ()
	{
		target.SendMessage( methodName );
	}
}
