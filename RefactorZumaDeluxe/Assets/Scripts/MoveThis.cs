using System;
using UnityEngine;

[Serializable]
public class MoveThis : MonoBehaviour
{
	public float translationSpeedX;

	public float translationSpeedY;

	public float translationSpeedZ;

	public bool local;

	public MoveThis()
	{
		translationSpeedY = 1f;
		local = true;
	}

	public void Update()
	{
		if (local)
		{
			transform.Translate(new Vector3(translationSpeedX, translationSpeedY, translationSpeedZ) * Time.deltaTime);
		}
		if (!local)
		{
			transform.Translate(new Vector3(translationSpeedX, translationSpeedY, translationSpeedZ) * Time.deltaTime, Space.World);
		}
	}

	public void Main()
	{
	}
}
