public class MusicToggleButton : TButton
{
	protected override void Start()
	{
		base.Start();
		base.IsOn = Music.instance.IsEnabled();
	}

	public override void WhenClicked()
	{
		base.WhenClicked();
		Music.instance.SetEnabled(base.IsOn, updateMusic: true);
		SoundController.instance.PlayButton();
	}
}
