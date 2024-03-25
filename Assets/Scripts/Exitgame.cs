using UnityEngine;

public class Exitgame : MonoBehaviour
{
	public static Exitgame instance;

	private void Update()
	{
		if (UnityEngine.Input.GetKeyDown(KeyCode.Escape) && !ConversationManager.instance.IsDialogShowing())
		{
			ConversationManager.instance.DisplayDialog(DialogueForm.QuitGame);
		}
	}

	private void Awake()
	{
	}
}
