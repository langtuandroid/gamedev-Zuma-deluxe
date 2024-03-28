public class ButtonOpenDialog : CustomButton
{
	public DialogType dialogType;

	public DialogShow dialogShow;

	public override void WhenClicked()
	{
		base.WhenClicked();
		UIManager.instance.ShowDialog(dialogType, dialogShow);
	}
}
