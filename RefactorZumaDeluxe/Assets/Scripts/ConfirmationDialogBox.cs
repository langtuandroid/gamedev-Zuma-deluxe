using System;

public class ConfirmationDialogBox : DialogBox
{
	public Action onConfirm;

	public Action onCancel;

	public virtual void OnYesClick()
	{
		if (onConfirm != null)
		{
			onConfirm();
		}
		SoundController.instance.PlayButton();
		Close();
	}

	public virtual void OnNoClick()
	{
		if (onCancel != null)
		{
			onCancel();
		}
		SoundController.instance.PlayButton();
		Close();
	}
}
