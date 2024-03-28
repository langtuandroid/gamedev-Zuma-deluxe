using System;
using UnityEngine;

[Serializable]
public class ScaleRandomizer : MonoBehaviour
{
	public float minScale;

	public float maxScale;

	public ScaleRandomizer()
	{
		minScale = 1f;
		maxScale = 2f;
	}

	public void Start()
	{
		float num = UnityEngine.Random.Range(minScale, maxScale);
		transform.localScale = new Vector3(num, num, num);
	}


	public void Main()
	{
	}
}
