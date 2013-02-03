using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public delegate void TimelineCallback( Timeline timeline );

public class Timeline : GameElement
{
	public enum State { WAITING, RUNNING }
	public State state = State.WAITING;
	
	private List<TimelineEvent> events;
	private float currentTime = 0.0f;
	private int currentIdx = 0;
	
	public event TimelineCallback onTimelineDone;
	
	/**************************************************************************
	 * Main
	 */
	
	void Awake ()
	{
		events = new List<TimelineEvent>( GetComponentsInChildren<TimelineEvent>() );
		TimelineEventComparer comp = new TimelineEventComparer();
		events.Sort( comp );
	}

	public override void init ()
	{
		state = State.WAITING;
	}
		
	public override void reset ()
	{
		state = State.WAITING;
		currentTime = 0.0f;
		currentIdx = 0;
	}
	
	public override void update ()
	{
		switch ( state ) {
			case State.WAITING: waitingBehavior(); break;
			case State.RUNNING: runningBehavior(); break;
		}
	}
	
	/**************************************************************************
	 * Behavior
	 */
	
	public void waitingBehavior()
	{
		
	}
	
	public void runningBehavior()
	{
		currentTime += Time.deltaTime;
		while ( currentIdx < events.Count && events[currentIdx].time < currentTime ) {
			events[currentIdx].performActions();
			currentIdx++;
		}
		
		if ( currentIdx >= events.Count ) {
			onDone();
		}
	}

	/**************************************************************************
	 * Events
	 */
	
	public void onDone()
	{
		state = State.WAITING;
		
		if ( onTimelineDone != null )
			onTimelineDone( this );
	}
	
	public void play()
	{
		reset();
		state = State.RUNNING;
	}
}
