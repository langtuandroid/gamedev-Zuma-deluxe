using UnityEngine;

public class LockRotation : MonoBehaviour
{
	private void Update()
	{
		base.transform.rotation = Quaternion.identity;
	}
}
