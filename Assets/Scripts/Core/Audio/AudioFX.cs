using UnityEngine;
using System.Collections;

public class AudioFX : MonoBehaviour
{
	public AudioSource fx;

	public const float OUTPUT_RATE = 44100;

	public float pitchDev = 0.0f;

	public bool isPlaying { get { return fx.isPlaying; } }
	
	void Awake()
	{
		fx = GetComponent<AudioSource>();
		if ( fx == null )
			Debug.LogError( "AudioFX <" + gameObject.name + "> AudioSource null" );
	}
	
	public void play (float delay, float pitch)
	{
		float d = Random.Range (-pitchDev, pitchDev);
		fx.pitch = pitch + d;
		fx.Play ((ulong)(delay * OUTPUT_RATE));
	}

	public void stop ()
	{
		fx.Stop ();
	}
	
	public void setVolume( float volume )
	{
		fx.volume = Mathf.Min ( Mathf.Max ( volume, 0.0f ), 1.0f );
	}
}
