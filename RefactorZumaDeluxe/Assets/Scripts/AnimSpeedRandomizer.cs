using System;
using UnityEngine;

[Serializable]
public class AnimSpeedRandomizer : MonoBehaviour
{
	public float minSpeed;

	public float maxSpeed;

	public AnimSpeedRandomizer()
	{
		minSpeed = 0.7f;
		maxSpeed = 1.5f;
	}

	public void Start()
	{
	}

	public void Main()
	{
	}
}
