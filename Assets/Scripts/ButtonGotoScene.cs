using UnityEngine;

public class ButtonGotoScene : MainButton
{
	public int sceneIndex;

	public bool useScreenFader;

	public bool useKeyCode;

	public KeyCode keyCode;

	public override void OnButtonClick()
	{
		base.OnButtonClick();
		CUtils.LoadScene(sceneIndex, useScreenFader);
	}

	private void Update()
	{
		if (useKeyCode && UnityEngine.Input.GetKeyDown(keyCode) && !ConversationManager.instance.IsDialogShowing())
		{
			OnButtonClick();
		}
	}
}
