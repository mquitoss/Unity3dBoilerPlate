using UnityEngine;
using System.Collections;
#pragma warning disable 0414
#pragma warning disable 0108

public class GameElement : MonoBehaviour
{
    Transform   transform;
    AudioSource audio;
    Animation   animation;
    Rigidbody   rigidBody;
	
	[HideInInspector] 
	public string resourceName = "resource";
	[HideInInspector] 
	public string canonicalName = "name";

    public virtual void Start()
    {
        transform   = gameObject.transform;
        audio       = gameObject.audio;
        animation   = gameObject.animation;
        rigidBody   = gameObject.rigidbody;
    }

	// TODO: crear una bitmask para updatear solo en determinados estados del GameController

    public virtual void init()        {}
    public virtual void reset()       {}
    public virtual void update()      {}
    public virtual void fixedUpdate() {}
	
	// TODO: it is important to document this first!
	public virtual void cleanUp()     {}
}
