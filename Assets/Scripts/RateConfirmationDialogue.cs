using Superpow;

public class RateConfirmationDialogue : ConfirmationDialogue
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
