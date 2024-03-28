using System;
using UnityEngine;

[Serializable]
public class DestroyThisTimed : MonoBehaviour
{
	public float destroyTime;

	public DestroyThisTimed()
	{
		destroyTime = 5f;
	}

	public void Start()
	{
		UnityEngine.Object.Destroy(gameObject, destroyTime);
	}

	public void Update()
	{
	}

	public void Main()
	{
	}
}
