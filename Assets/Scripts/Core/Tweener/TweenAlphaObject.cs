using UnityEngine;
using System.Collections;

//Tween alpha object class
[System.Serializable]
public class TweenAlphaObject : BaseTweenObject
{
    public float tweenValue;

    private float _startValue;
    public float startValue
    {
        set { _startValue = value; }
        get { return _startValue; }
    }

    public TweenAlphaObject()
    {
        this.tweenType = TweenType.TweenAlpha;
    }
}
