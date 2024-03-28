using UnityEngine;

public class QuitGameDialogBox : ConfirmationDialogBox
{
	protected override void Start()
	{
		base.Start();
		onConfirm = Quit;
	}

	private void Quit()
	{
		Application.Quit();
	}
}
