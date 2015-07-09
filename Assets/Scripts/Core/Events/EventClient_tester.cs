using UnityEngine;
using System.Collections;

public class EventClient_tester : MonoBehaviour
{
	public string message;

	void OnEnable()
	{
		Events.instance.AddListener<MyCustomEvent>( OnCustomEventDone );
	}

	void OnDisable()
	{
		Events.instance.RemoveListener<MyCustomEvent>( OnCustomEventDone );
	}

	public void OnCustomEventDone( MyCustomEvent e )
	{
		Debug.Log( "event: " + message );
	}
}
