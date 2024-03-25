using System;
using System.Collections.Generic;
using UnityEngine;

public class ConversationManager : MonoBehaviour
{
	public static ConversationManager instance;

	[HideInInspector]
	public CustomDialog current;

	[HideInInspector]
	public CustomDialog[] baseDialogs;

	public Action onDialogsOpened;

	public Action onDialogsClosed;

	public Stack<CustomDialog> dialogs = new Stack<CustomDialog>();

	public void Awake()
	{
		instance = this;
	}

	public void DisplayDialog(int type)
	{
		DisplayDialog((DialogueForm)type, DialogShow.DONT_SHOW_IF_OTHERS_SHOWING);
	}

	public void DisplayDialog(DialogueForm type, DialogShow option = DialogShow.REPLACE_CURRENT)
	{
		CustomDialog customDialog = RetrieveDialog(type);
		DisplayDialog(customDialog, option);
		
	}

	public void ShowYesNoDialog(string title, string content, Action onYesListener, Action onNoListenter, DialogShow option = DialogShow.REPLACE_CURRENT)
	{
		ConfirmationDialogue confirmationDialogue = (ConfirmationDialogue)RetrieveDialog(DialogueForm.YesNo);
		if (confirmationDialogue.title != null)
		{
			confirmationDialogue.title.SetText(title);
		}
		if (confirmationDialogue.message != null)
		{
			confirmationDialogue.message.SetText(content);
		}
		confirmationDialogue.onYesClick = onYesListener;
		confirmationDialogue.onNoClick = onNoListenter;
		DisplayDialog(confirmationDialogue, option);
	}

	public void ShowOkDialog(string title, string content, Action onOkListener, DialogShow option = DialogShow.REPLACE_CURRENT)
	{
		OkCustomDialog okCustomDialog = (OkCustomDialog)RetrieveDialog(DialogueForm.Ok);
		if (okCustomDialog.title != null)
		{
			okCustomDialog.title.SetText(title);
		}
		if (okCustomDialog.message != null)
		{
			okCustomDialog.message.SetText(content);
		}
		okCustomDialog.onOkClick = onOkListener;
		DisplayDialog(okCustomDialog, option);
	}

	public void DisplayDialog(CustomDialog customDialog, DialogShow option = DialogShow.REPLACE_CURRENT)
	{
		if (current != null)
		{
			switch (option)
			{
			case DialogShow.DONT_SHOW_IF_OTHERS_SHOWING:
				UnityEngine.Object.Destroy(customDialog.gameObject);
				return;
			case DialogShow.REPLACE_CURRENT:
				current.Close();
				break;
			case DialogShow.STACK:
				current.Hide();
				break;
			}
		}
		current = customDialog;
		if (option != DialogShow.SHOW_PREVIOUS)
		{
			CustomDialog dialog2 = current;
			dialog2.onDialogOpened = (Action<CustomDialog>)Delegate.Combine(dialog2.onDialogOpened, new Action<CustomDialog>(OnOneDialogOpened));
			CustomDialog dialog3 = current;
			dialog3.onDialogClosed = (Action<CustomDialog>)Delegate.Combine(dialog3.onDialogClosed, new Action<CustomDialog>(OnOneDialogClosed));
			dialogs.Push(current);
		}
		current.Show();
		if (onDialogsOpened != null)
		{
			onDialogsOpened();
		}
	}

	public CustomDialog RetrieveDialog(DialogueForm type)
	{
		CustomDialog customDialog = baseDialogs[(int)type];
		customDialog.dialogueForm = type;
		return UnityEngine.Object.Instantiate(customDialog, customDialog.transform.position, base.transform.rotation);
	}

	public void EndCurrentDialog()
	{
		if (current != null)
		{
			current.Close();
		}
	}

	public void CloseDialog(DialogueForm type)
	{
		if (!(current == null) && current.dialogueForm == type)
		{
			current.Close();
		}
	}

	public bool IsDialogShowing()
	{
		return current != null;
	}

	public bool IsDialogShowing(DialogueForm type)
	{
		if (current == null)
		{
			return false;
		}
		return current.dialogueForm == type;
	}

	private void OnOneDialogOpened(CustomDialog customDialog)
	{
	}

	private void OnOneDialogClosed(CustomDialog customDialog)
	{
		if (current == customDialog)
		{
			current = null;
			dialogs.Pop();
			if (onDialogsClosed != null && dialogs.Count == 0)
			{
				onDialogsClosed();
			}
			if (dialogs.Count > 0)
			{
				DisplayDialog(dialogs.Peek(), DialogShow.SHOW_PREVIOUS);
			}
		}
	}
}
