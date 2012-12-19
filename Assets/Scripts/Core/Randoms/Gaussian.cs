using System;

public class Gaussian 
{
	private static Random rand;
	
	/**
	 * Box-Muller transform 
	 */
	public static float random( float mean, float stdDev )
	{
		if ( rand == null )
			rand = new Random();
		
		//these are uniform(0,1) random doubles
		double u1 = rand.NextDouble(); 
		double u2 = rand.NextDouble();
		double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2); // random normal(0,1)
		double randNormal = mean + stdDev * randStdNormal;                                    // random normal(mean,stdDev^2)
		
		return (float) randNormal;		
	}
}
