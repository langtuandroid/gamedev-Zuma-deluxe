public class ButtonRate : CustomButton
{
	public override void WhenClicked()
	{
		base.WhenClicked();
		CUtils.RateGame();
	}
}
