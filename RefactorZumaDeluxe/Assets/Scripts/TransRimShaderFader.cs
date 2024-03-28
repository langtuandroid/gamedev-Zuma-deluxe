using System;
using UnityEngine;

[Serializable]
public class TransRimShaderFader : MonoBehaviour
{
	public float startStr;

	public float speed;

	private float timeGoes;

	private float currStr;

	public TransRimShaderFader()
	{
		startStr = 2f;
		speed = 3f;
	}

	public void Update()
	{
		timeGoes += Time.deltaTime * speed * startStr;
		currStr = startStr - timeGoes;
		GetComponent<Renderer>().material.SetFloat("_AllPower", currStr);
	}

	public void Main()
	{
	}
}
