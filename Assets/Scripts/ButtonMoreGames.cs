using UnityEngine;

public class ButtonMoreGames : MainButton
{
	public override void OnButtonClick()
	{
		base.OnButtonClick();
		Application.OpenURL("https://play.google.com");
	}
}
