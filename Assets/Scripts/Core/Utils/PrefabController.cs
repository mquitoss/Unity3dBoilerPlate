using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * Busca el prefab en la carpeta Resources
 */
public class PrefabController : GameElement
{
	public const string PREFAB_PATH  = "Prefabs/";

	private Dictionary<string,Dictionary<string,Object>> prefabs;
	
	void Awake()
	{
		api.prefabController = this;
		
		prefabs = new Dictionary<string, Dictionary<string, Object>>();
	}
	
	public GameObject getPrefabByName( string resourceName, string prefabName )
	{
		if ( !prefabs.ContainsKey( resourceName ) ) {
			addResource ( resourceName );
		}
		
		if ( prefabs[resourceName].ContainsKey( prefabName ) ) {
			return prefabs[resourceName][prefabName] as GameObject;
		}
		else {
			Debug.LogError( "PrefabName '" + prefabName + "' not found" );
			return null;
		}
	}
     
    public string getRandomInstanceName( string resourceName )
    {
        List <string> keys = new List<string>(this.prefabs[resourceName].Keys);
        int randomIdx = Random.Range(0, keys.Count);

        return keys[randomIdx];
    }
	
	public void addResource ( string resourceName )
	{
		prefabs[resourceName] = new Dictionary<string, Object>();

		List<Object> prefabList = new List<Object>( Resources.LoadAll( PREFAB_PATH + resourceName, typeof(Object) ) );
		for ( int j = 0; j < prefabList.Count; j++ ) {
			Object prefab = prefabList[j];
			prefabs[resourceName][prefab.name] = prefab;
		}
	}
}
