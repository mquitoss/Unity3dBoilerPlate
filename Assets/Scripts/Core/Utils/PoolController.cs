using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * La pool debe trabajar en modo lazy. Con la posibilidad de precargar cierto número de GameObject
 * al devolver un GameObject deberia resetear todos los GameElement que contenga.
 */
public class PoolController : GameElement
{
	private static PoolController singleton;
    public static PoolController Instance { get { return singleton; } set { singleton = value; } }

	public string[] resources;
	public PrefabController prefabController;
	
	private Dictionary<string, Dictionary<string,Queue<GameObject>>> elements;
	
	private int id = 0;
	
	void Awake()
	{
		singleton = this;
		
		elements = new Dictionary<string, Dictionary<string, Queue<GameObject>>>();
		
		for ( int i = 0; i < resources.Length; i++ ) {
			string resourceName = resources[i];
			elements[resourceName] = new Dictionary<string, Queue<GameObject>>();
		}
	}

    public GameObject getRandomInstance(string resourceName)
    {
        string objName = prefabController.getRandomInstanceName(resourceName);
       
        return getInstanceByName(resourceName,objName);
    }

	public GameObject getInstanceByName( string resourceName, string objName )
	{
		if ( elements.ContainsKey( resourceName ) ) {
			if ( !elements[resourceName].ContainsKey( objName ) ) {
				elements[resourceName][objName] = new Queue<GameObject>();
			}
			Queue<GameObject> q = elements[resourceName][objName];
			if ( q.Count == 0 ) {
				return create( resourceName, objName, prefabController.getPrefabByName( resourceName, objName ) );
			}
			else {
				return load( q.Dequeue() );
			}
		}
		else {
			Debug.LogError( "Resource '" + resourceName + "' not found" );
			return null;
		}
	}
	
	public void dumpElement( string resourceName, string objName, GameObject o )
	{
		if ( !elements[resourceName].ContainsKey( objName ) ) {
			elements[resourceName][objName] = new Queue<GameObject>();
		}
		
		Queue<GameObject> q = elements[resourceName][objName];
		
		GameElement ge = o.GetComponent<GameElement>();
		if ( ge != null ) {
			ge.cleanUp();
		}
		
		o.transform.parent = transform;
		o.SetActiveRecursively( false );
		q.Enqueue( o );
	}
	
	public void dumpElement( GameObject o )
	{
//		Debug.LogWarning( Time.timeSinceLevelLoad + "Push Object: "  + o.name );
		
		GameElement ge = o.GetComponent<GameElement>();
		if ( ge != null ) {
			dumpElement( ge.resourceName, ge.canonicalName, o );
		}
		else {
			Debug.LogError( "pushElement have not a GameElement Component" );
		}
	}
	
	public void preLoad( string resourceName, string objName, int count  )
	{
		Debug.Log("*** PRELOAD: " + resourceName + " . " + objName + " | count: " + count );
		for ( int i = 0; i < count; i++ ) {
			dumpElement( resourceName, objName, create( resourceName, objName, prefabController.getPrefabByName( resourceName, objName ) ) );
		}
	}
	
	private GameObject load( GameObject o )
	{
//		Debug.LogWarning(Time.timeSinceLevelLoad + " Load Object: " + o.name);
		
		o.SetActiveRecursively( true );
		return resetObject( o );
	}
	
	private GameObject create( string resourceName, string objName, GameObject prefab )
	{
        //Debug.Log(objName);
		GameObject o = Instantiate( prefab ) as GameObject;
		GameElement ge = o.GetComponent<GameElement>();
		if ( ge != null ) {
			ge.resourceName = resourceName;
			ge.canonicalName = objName;
			ge.init();
		}
		
		o.name = o.name + "_" + id++;
//		Debug.LogWarning(Time.timeSinceLevelLoad + "Create Object: " + o.name);
		
		return resetObject( o );
	}

	private GameObject resetObject( GameObject o )
	{
		o.transform.parent = null;
		GameElement ge = o.GetComponent<GameElement>();
		if ( ge != null ) {
			ge.reset();
		}

		return o;
	}
}
