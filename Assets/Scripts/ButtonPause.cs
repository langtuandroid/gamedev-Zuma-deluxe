public class ButtonPause : MainButton
{
	public override void OnButtonClick()
	{
		base.OnButtonClick();
		ConversationManager.instance.DisplayDialog(DialogueForm.Pause);
	}
}
