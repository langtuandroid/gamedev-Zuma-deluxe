public class ButtonPlay : CustomButton
{
	public int gotoIndex = 1;

	public bool useScreenFader;

	public override void WhenClicked()
	{
		base.WhenClicked();
		CUtils.LoadScene(gotoIndex, useScreenFader);
	}
}
