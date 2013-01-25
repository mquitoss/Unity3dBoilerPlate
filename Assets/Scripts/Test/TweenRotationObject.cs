using UnityEngine;
using System.Collections;

//Tween rotation object class
[System.Serializable]
public class TweenRotationObject : BaseTweenObject
{
    public Vector3 tweenValue;

    private Vector3 _startValue;
    public Vector3 startValue
    {
        set { _startValue = value; }
        get { return _startValue; }
    }

    public TweenRotationObject()
    {
        this.tweenType = TweenType.TweenRotation;
    }
}