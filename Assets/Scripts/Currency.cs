using UnityEngine;

public class Currency : MonoBehaviour
{
	private void OnMoveComplete()
	{
		Destroy(gameObject);
	}
}
