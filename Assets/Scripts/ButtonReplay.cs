using System;

public class ButtonReplay : MainButton
{
	public bool showConfirmDialog;

	public bool useScreenFader;

	public override void OnButtonClick()
	{
		base.OnButtonClick();
		if (showConfirmDialog)
		{
			Action onYesListener = delegate
			{
				Replay();
			};
			ConversationManager.instance.ShowYesNoDialog(null, "Do you want to replay the game ?", onYesListener, null, DialogShow.STACK);
		}
		else
		{
			Replay();
		}
	}

	private void Replay()
	{
		CUtils.ReloadScene(useScreenFader);
	}
}
