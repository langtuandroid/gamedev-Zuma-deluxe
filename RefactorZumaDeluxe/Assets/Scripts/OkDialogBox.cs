using System;

public class OkDialogBox : DialogBox
{
	public Action onOkClick;

	public virtual void OnOkClick()
	{
		SoundController.instance.PlayButton();
		if (onOkClick != null)
		{
			onOkClick();
		}
		SoundController.instance.PlayButton();
		Close();
	}
}
