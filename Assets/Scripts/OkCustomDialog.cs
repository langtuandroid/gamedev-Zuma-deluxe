using System;

public class OkCustomDialog : CustomDialog
{
	public Action onOkClick;

	public virtual void OnOkClick()
	{
		Sound.instance.PlayButton();
		if (onOkClick != null)
		{
			onOkClick();
		}
		Sound.instance.PlayButton();
		Close();
	}
}
