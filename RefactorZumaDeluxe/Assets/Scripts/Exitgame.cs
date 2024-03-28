using UnityEngine;

public class Exitgame : MonoBehaviour
{
	public static Exitgame instance;

	private void Update()
	{
		if (UnityEngine.Input.GetKeyDown(KeyCode.Escape) && !UIManager.instance.IsDialogShowing())
		{
			UIManager.instance.ShowDialog(DialogType.QuitGame);
		}
	}

	private void Awake()
	{
	}
}
