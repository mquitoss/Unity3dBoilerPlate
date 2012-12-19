using UnityEngine;
using System.Collections;

public class FPSSetter : MonoBehaviour
{
	public const int DEFAULT_IPHONE_FPS = 60;

	void Start ()
	{
		Application.targetFrameRate = DEFAULT_IPHONE_FPS;
	}
}
