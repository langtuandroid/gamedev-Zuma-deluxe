public class ButtonPause : CustomButton
{
	public override void WhenClicked()
	{
		base.WhenClicked();
		UIManager.instance.ShowDialog(DialogType.Pause);
	}
}
