using UnityEngine;
using System.Collections;

public abstract class AccelerometerFilter 
{
	public Vector3 acceleration { get { return currentAccel; } }
	
	protected float rate;
	protected float freq;
	protected float filterConstant;
	protected bool isAdaptative;
	protected Vector3 currentAccel;
	protected Vector3 previousAccel;
	
	protected const float kAccelerometerMinStep = 0.02f;
	protected const float kAccelerometerNoiseAttenuation = 3.0f;
	
	public AccelerometerFilter( float rate, float freq, bool isAdaptative )
	{
		this.rate = rate;
		this.freq = freq;
		this.isAdaptative = isAdaptative;
		float dt = 1.0f / rate;
		float RC = 1.0f / freq;
		filterConstant = dt / ( dt + RC );
	}
	
	public abstract void addAcceleration( Vector3 accel );
}

/**
 * See http://en.wikipedia.org/wiki/Low-pass_filter for details low pass filtering
 */
public class AccelerometerHighpassFilter : AccelerometerFilter
{
	public AccelerometerHighpassFilter( float rate, float freq, bool isAdaptative ): base( rate, freq, isAdaptative ) {}
	
	public override void addAcceleration (Vector3 accel)
	{
		float alpha = filterConstant;
		
		if ( isAdaptative ) {
			float d = Mathf.Clamp( Mathf.Abs( currentAccel.magnitude - accel.magnitude ) / kAccelerometerMinStep, 0.0f, 1.0f );
			alpha = ( 1.0f - d ) * filterConstant / kAccelerometerNoiseAttenuation + d * filterConstant;
		}
		
		currentAccel = accel * alpha + currentAccel * ( 1.0f - alpha );
	}
}

/**
 * See http://en.wikipedia.org/wiki/High-pass_filter for details on high pass filtering
 */
public class AccelerometerLowpassFilter : AccelerometerFilter
{
	public AccelerometerLowpassFilter( float rate, float freq, bool isAdaptative ): base( rate, freq, isAdaptative ) {}

	public override void addAcceleration (Vector3 accel)
	{
		float alpha = filterConstant;
		
		if ( isAdaptative ) {
			float d = Mathf.Clamp( Mathf.Abs( currentAccel.magnitude - accel.magnitude ) / kAccelerometerMinStep, 0.0f, 1.0f );
			alpha = d * filterConstant * kAccelerometerNoiseAttenuation + ( 1.0f - d ) * filterConstant;
		}
		
		currentAccel = ( currentAccel + accel - previousAccel ) * alpha;
		previousAccel = accel;
	}
}
