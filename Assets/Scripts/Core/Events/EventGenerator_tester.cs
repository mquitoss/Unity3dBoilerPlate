using UnityEngine;
using System.Collections;

public class MyCustomEvent: GameEvent {}

public class EventGenerator_tester : MonoBehaviour
{
	private const float REFRESH_TIME = 5.0f;
	private float currentTime;


	void Start ()
	{
		currentTime = REFRESH_TIME;
	}
	
	void Update ()
	{
		currentTime -= Time.deltaTime;
		if ( currentTime < 0.0f ) {
			Events.instance.Raise( new MyCustomEvent() );
			currentTime = REFRESH_TIME;
		}
	}
}
