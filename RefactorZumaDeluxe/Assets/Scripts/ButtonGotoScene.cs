using UnityEngine;

public class ButtonGotoScene : CustomButton
{
	public int sceneIndex;

	public bool useScreenFader;

	public bool useKeyCode;

	public KeyCode keyCode;

	public override void WhenClicked()
	{
		base.WhenClicked();
		CUtils.LoadScene(sceneIndex, useScreenFader);
	}

	private void Update()
	{
		if (useKeyCode && UnityEngine.Input.GetKeyDown(keyCode) && !UIManager.instance.IsDialogShowing())
		{
			WhenClicked();
		}
	}
}
