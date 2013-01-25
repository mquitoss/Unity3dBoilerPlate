using UnityEngine;
using System.Collections;

public class ActionDebugLog : Action
{
	public string message = "Message";
	
	public override void perform ()
	{
		Debug.Log( message );
	}
}
