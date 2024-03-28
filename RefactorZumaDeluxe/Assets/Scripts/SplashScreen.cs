using UnityEngine;

public class SplashScreen : MonoBehaviour
{
	private void Start()
	{
	}

	public void TouchStartClick()
	{
		GetComponent<SceneTransition>().PerformTransition();
	}
}
