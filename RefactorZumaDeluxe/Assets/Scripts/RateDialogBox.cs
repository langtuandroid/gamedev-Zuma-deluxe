using Superpow;

public class RateDialogBox : ConfirmationDialogBox
{
	public override void OnYesClick()
	{
		base.OnYesClick();
		CUtils.RateGame();
	}

	public override void OnNoClick()
	{
		base.OnNoClick();
		Utils.SetAskRateTime();
	}
}
