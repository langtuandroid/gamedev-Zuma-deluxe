using System;
using UnityEngine.Serialization;

public class ButtonReplay : CustomButton
{
	public bool displayConfirmationDialog;

	public bool useFadeEffect;

	public override void WhenClicked()
	{
		base.WhenClicked();
		if (displayConfirmationDialog)
		{
			Action onYesListener = delegate
			{
				RestartGame();
			};
			UIManager.instance.ShowYesNoDialog(null, "Do you want to replay the game ?", onYesListener, null, DialogShow.STACK);
		}
		else
		{
			RestartGame();
		}
	}

	private void RestartGame()
	{
		CUtils.ReloadScene(useFadeEffect);
	}
}
