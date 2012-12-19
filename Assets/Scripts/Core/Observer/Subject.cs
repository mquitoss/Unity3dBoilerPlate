using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Subject : MonoBehaviour
{
	private List<Observer> observers = new List<Observer>();
	
	public void subscribe( Observer o )
	{
		observers.Add( o );
	}
	
	public void unsubscribe( Observer o )
	{
		observers.Remove( o );
	}
	
	public void notify()
	{
		foreach ( Observer o in observers ) {
			o.notify();
		}
	}	
}
