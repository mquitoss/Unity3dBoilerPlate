using UnityEngine;
using System.Collections;

public class ActionFlurryLog : Action
{
	public string eventName = "<eventName>";

	public override void perform()
	{
		//FlurryBinding.logEvent( eventName, true );
	}
}
