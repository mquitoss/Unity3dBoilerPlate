using UnityEngine;
using System.Collections;

public class ActionParticle : Action
{
	public ParticleSystem particle;
	
	public override void perform ()
	{
		particle.Play();
	}
}
