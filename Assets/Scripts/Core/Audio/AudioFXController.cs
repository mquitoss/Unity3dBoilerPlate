using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioFXController : MonoBehaviour
{
	private Dictionary<string,AudioFX> dictionary = new Dictionary<string,AudioFX>();
	
	public bool mute = false;
	
	void Start ()
	{
		AudioFX[] audios = GetComponentsInChildren<AudioFX>();
		for ( int i = 0; i < audios.Length; i++ ) {
			AudioFX afx = audios[i];
			string key = afx.gameObject.name;
			dictionary.Add( key, afx );
		}
	}

	public AudioFX play( string audioFXKey )
	{
		return play( audioFXKey, 0.0f, 1.0f );
	}
	
	public AudioFX play( string audioFXKey, float delay )
	{
		return play( audioFXKey, delay, 1.0f );
	}
	
	public AudioFX play( string audioFXKey, float delay, float pitch )
	{
		if ( mute ) return null;
		if ( !dictionary.ContainsKey( audioFXKey ) ) return null;

		AudioFX afx = dictionary[audioFXKey];
		afx.play( delay, pitch );
		return afx;
	}
}
