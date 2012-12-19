using UnityEngine;
using System.Collections;

public class ColliderTrigger : ActionTrigger
{
	void OnTriggerEnter(Collider other)
	{
		performActions();
	}
}
