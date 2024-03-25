using UnityEngine;

public class QuitGameConfirmationDialogue : ConfirmationDialogue
{
	protected override void Start()
	{
		base.Start();
		onYesClick = Quit;
	}

	private void Quit()
	{
		Application.Quit();
	}
}
