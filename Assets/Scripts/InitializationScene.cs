using UnityEngine;

public class InitializationScene : MonoBehaviour
{
	private void Start()
	{
	}

	public void TouchStartClick()
	{
		GetComponent<SceneTransition>().PerformTransition();
	}
}
