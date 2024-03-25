using UnityEngine.Serialization;

public class ButtonOpenDialog : MainButton
{
	[FormerlySerializedAs("dialogType")] public DialogueForm dialogueForm;

	public DialogShow dialogShow;

	public override void OnButtonClick()
	{
		base.OnButtonClick();
		ConversationManager.instance.DisplayDialog(dialogueForm, dialogShow);
	}
}
