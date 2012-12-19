using UnityEngine;
using System.Collections;

public class ChooserPoison : Chooser
{
	public float lamda = 1.0f;
	private const float time = 1.0f;
	public int lenght = 10;
	
	public float[] probs;
	
	public const float e = 2.71828f;
	
	void Awake()
	{
		probs = new float[lenght];
		float total = 0.0f;
		for ( int i = 0; i < lenght; i++ ) {
			probs[i] = probFunction( i, lamda, time );
			total += probs[i];
		}
		
		for ( int i = 0; i < lenght; i++ ) {
			probs[i] = probs[i] / total;
		}
	}
	
	public static float probFunction( int k, float lamda, float t )
	{
		float l = lamda * t;
		float a = Mathf.Pow( e, -l );
		float b = Mathf.Pow( l, (float) k );
		float c = (float) factorial( k );
		
		return ( a * b ) / c;
	}
	
	public static int factorial( int i )
	{
		if ( i <= 0 ) return 1;
		
		return i * factorial( i - 1 );
	}
	
	public int chooseByPoison()
	{
		return choose( probs );
	}
}
