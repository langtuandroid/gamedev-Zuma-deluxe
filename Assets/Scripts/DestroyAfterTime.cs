using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
	public float time;

	private void Start()
	{
		Destroy(gameObject, time);
	}
}
