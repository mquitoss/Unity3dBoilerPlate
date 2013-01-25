using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * La pool debe trabajar en modo lazy. Con la posibilidad de precargar cierto número de GameObject
 * al devolver un GameObject deberia resetear todos los GameElement que contenga.
 */
public class PoolController : GameElement
{
	private Dictionary<string, Dictionary<string,Queue<GameObject>>> elements;
	
	private int id = 0;
	
	void Awake()
	{
		api.poolController = this;
		
		elements = new Dictionary<string, Dictionary<string, Queue<GameObject>>>();
	}
	
    public GameObject getRandomInstance(string resourceName)
    {
        string objName = api.prefabController.getRandomInstanceName(resourceName);
       
        return getInstanceByName(resourceName,objName);
    }
	
	public GameObject getInstanceByPath( string path )
	{
		int pos = path.LastIndexOf( '/' );
		if ( pos < 0 ) {
			Debug.LogError ( "Path incorrect content, must be 'path/obj_name': " + path );
			return null;
		}
		
		string resourceName = path.Substring ( 0, pos );
		string objName = path.Substring( pos + 1, path.Length - pos - 1 );
		
		return getInstanceByName ( resourceName, objName );
	}
	
	public GameObject getInstanceByName( string resourceName, string objName )
	{
		if ( !elements.ContainsKey( resourceName ) ) {
			addResource ( resourceName );
		}
		
		if ( !elements[resourceName].ContainsKey( objName ) ) {
			elements[resourceName][objName] = new Queue<GameObject>();
		}
		
		Queue<GameObject> q = elements[resourceName][objName];
		if ( q.Count == 0 ) {
			return create( resourceName, objName, api.prefabController.getPrefabByName( resourceName, objName ) );
		}
		else {
			return load( q.Dequeue() );
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
		for ( int i = 0; i < count; i++ ) {
			dumpElement( resourceName, objName, create( resourceName, objName, api.prefabController.getPrefabByName( resourceName, objName ) ) );
		}
	}
	
	private GameObject load( GameObject o )
	{
		o.SetActiveRecursively( true );
		return resetObject( o );
	}
	
	private GameObject create( string resourceName, string objName, GameObject prefab )
	{
		if ( prefab == null ) return null;
		
		GameObject o = Instantiate( prefab ) as GameObject;
		GameElement ge = o.GetComponent<GameElement>();
		if ( ge != null ) {
			ge.resourceName = resourceName;
			ge.canonicalName = objName;
			ge.init();
		}
		
		o.name = o.name + "_" + id++;
		
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
	
	public void addResource ( string resourceName )
	{
		elements[resourceName] = new Dictionary<string, Queue<GameObject>>();
	}
}
