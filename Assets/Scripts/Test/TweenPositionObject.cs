using UnityEngine;
using System.Collections;

//Tween position object class
[System.Serializable]
public class TweenPositionObject : BaseTweenObject
{
    public Vector3 tweenValue;

    private Vector3 _startValue;
    public Vector3 startValue
    {
        set { _startValue = value; }
        get { return _startValue; }
    }

    public TweenPositionObject()
    {
        this.tweenType = TweenType.TweenPosition;
    }
}
