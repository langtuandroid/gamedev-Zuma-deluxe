public class MusicToggleFunctionButton : FunctionButton
{
	protected override void Start()
	{
		base.Start();
		IsOn = Music.instance.IsEnabled();
	}

	public override void OnButtonClick()
	{
		base.OnButtonClick();
		Music.instance.SetEnabled(IsOn, updateMusic: true);
		Sound.instance.PlayButton();
	}
}
