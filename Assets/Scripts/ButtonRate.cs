public class ButtonRate : MainButton
{
	public override void OnButtonClick()
	{
		base.OnButtonClick();
		CUtils.RateGame();
	}
}
