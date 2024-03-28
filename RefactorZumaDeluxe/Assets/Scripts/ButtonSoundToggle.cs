public class ButtonSoundToggle : TButton
{
	protected override void Start()
	{
		base.Start();
		base.IsOn = SoundController.instance.IsEnabled();
	}

	public override void WhenClicked()
	{
		base.WhenClicked();
		SoundController.instance.SetEnabled(base.IsOn);
		SoundController.instance.PlayButton();
	}
}
