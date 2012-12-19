using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimelineEvent : ActionTrigger
{
	public float time = 0.0f;
}

class TimelineEventComparer : IComparer<TimelineEvent>
{
    public int Compare( TimelineEvent x, TimelineEvent y )
    {
        return (int) Mathf.Sign( x.time - y.time );
    }
}
