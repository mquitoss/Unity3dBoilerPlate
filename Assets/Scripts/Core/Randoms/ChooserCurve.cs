using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChooserCurve : Chooser
{
	public int numberOfCols = 10;

	public AnimationCurve propCurve_0;
	public AnimationCurve propCurve_1;
	public AnimationCurve propCurve_2;
	public AnimationCurve propCurve_3;
	public AnimationCurve propCurve_4;
	public AnimationCurve propCurve_5;

    public int chooseItemByCurve(float t)
    {
        float[] probs = new float[6];
        probs[0] = propCurve_0.Evaluate(t);
        probs[1] = propCurve_1.Evaluate(t);
        probs[2] = propCurve_2.Evaluate(t);
        probs[3] = propCurve_3.Evaluate(t);
        probs[4] = propCurve_4.Evaluate(t);
        probs[5] = propCurve_5.Evaluate(t);

        return choose(probs);
    }
    
    public int chooseItemByCurveByCols( int i )
	{
		return chooseItemByCurve( idxToInterpolation( i ) );
	}
	
	private float idxToInterpolation( int i )
	{
		float t = (float) i / (float) numberOfCols;
		return Mathf.Min( Mathf.Max( t, 0.0f ), 1.0f );
	}
}
