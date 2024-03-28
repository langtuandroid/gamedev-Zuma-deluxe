using UnityEngine;

public class ButtonMoreGames : CustomButton
{
	public override void WhenClicked()
	{
		base.WhenClicked();
		Application.OpenURL("https://play.google.com");
	}
}
