using UnityEngine;
using System.Collections;

public class Chooser : MonoBehaviour
{
	public int choose( float[] probs )
	{
		float total = 0.0f;
		foreach ( float p in probs ) {
			total += p;
		}
		
		float randomPoint = Random.value * total;
		for ( int i = 0; i < probs.Length; i++ ) {
			if ( randomPoint < probs[i] )
				return i;
			else
				randomPoint -= probs[i];
		}
	
		return probs.Length - 1;	
	}
}
