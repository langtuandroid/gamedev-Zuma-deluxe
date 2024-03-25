using UnityEngine;

public class NoRotation : MonoBehaviour
{
	private void Update()
	{
		transform.rotation = Quaternion.identity;
	}
}
