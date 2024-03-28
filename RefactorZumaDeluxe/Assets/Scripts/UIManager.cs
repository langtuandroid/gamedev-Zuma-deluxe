using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class UIManager : MonoBehaviour
{
	public static UIManager instance;

	[HideInInspector]
	public DialogBox current;

	[HideInInspector]
	public DialogBox[] baseDialogs;

	public Action onDialogsOpened;

	public Action onDialogsClosed;

	public Stack<DialogBox> dialogs = new Stack<DialogBox>();

	public void Awake()
	{
		instance = this;
	}

	public void ShowDialog(int type)
	{
		ShowDialog((DialogType)type, DialogShow.DONT_SHOW_IF_OTHERS_SHOWING);
	}

	public void ShowDialog(DialogType type, DialogShow option = DialogShow.REPLACE_CURRENT)
	{
		DialogBox dialogBox = GetDialog(type);
		ShowDialog(dialogBox, option);
	}

	public void ShowYesNoDialog(string title, string content, Action onYesListener, Action onNoListenter, DialogShow option = DialogShow.REPLACE_CURRENT)
	{
		ConfirmationDialogBox confirmationDialogBox = (ConfirmationDialogBox)GetDialog(DialogType.YesNo);
		if (confirmationDialogBox.title != null)
		{
			confirmationDialogBox.title.SetText(title);
		}
		if (confirmationDialogBox.message != null)
		{
			confirmationDialogBox.message.SetText(content);
		}
		confirmationDialogBox.onConfirm = onYesListener;
		confirmationDialogBox.onCancel = onNoListenter;
		ShowDialog(confirmationDialogBox, option);
	}

	public void ShowOkDialog(string title, string content, Action onOkListener, DialogShow option = DialogShow.REPLACE_CURRENT)
	{
		OkDialogBox okDialogBox = (OkDialogBox)GetDialog(DialogType.Ok);
		if (okDialogBox.title != null)
		{
			okDialogBox.title.SetText(title);
		}
		if (okDialogBox.message != null)
		{
			okDialogBox.message.SetText(content);
		}
		okDialogBox.onOkClick = onOkListener;
		ShowDialog(okDialogBox, option);
	}

	public void ShowDialog(DialogBox dialogBox, DialogShow option = DialogShow.REPLACE_CURRENT)
	{
		if (current != null)
		{
			switch (option)
			{
			case DialogShow.DONT_SHOW_IF_OTHERS_SHOWING:
				UnityEngine.Object.Destroy(dialogBox.gameObject);
				return;
			case DialogShow.REPLACE_CURRENT:
				current.Close();
				break;
			case DialogShow.STACK:
				current.Hide();
				break;
			}
		}
		current = dialogBox;
		if (option != DialogShow.SHOW_PREVIOUS)
		{
			DialogBox dialog2 = current;
			dialog2.onDialogOpened = (Action<DialogBox>)Delegate.Combine(dialog2.onDialogOpened, new Action<DialogBox>(OnOneDialogOpened));
			DialogBox dialog3 = current;
			dialog3.onDialogClosed = (Action<DialogBox>)Delegate.Combine(dialog3.onDialogClosed, new Action<DialogBox>(OnOneDialogClosed));
			dialogs.Push(current);
		}
		current.Show();
		if (onDialogsOpened != null)
		{
			onDialogsOpened();
		}
	}

	public DialogBox GetDialog(DialogType type)
	{
		DialogBox dialogBox = baseDialogs[(int)type];
		dialogBox.dialogType = type;
		return UnityEngine.Object.Instantiate(dialogBox, dialogBox.transform.position, base.transform.rotation);
	}

	public void CloseCurrentDialog()
	{
		if (current != null)
		{
			current.Close();
		}
	}

	public void CloseDialog(DialogType type)
	{
		if (!(current == null) && current.dialogType == type)
		{
			current.Close();
		}
	}

	public bool IsDialogShowing()
	{
		return current != null;
	}

	public bool IsDialogShowing(DialogType type)
	{
		if (current == null)
		{
			return false;
		}
		return current.dialogType == type;
	}

	private void OnOneDialogOpened(DialogBox dialogBox)
	{
	}

	private void OnOneDialogClosed(DialogBox dialogBox)
	{
		if (current == dialogBox)
		{
			current = null;
			dialogs.Pop();
			if (onDialogsClosed != null && dialogs.Count == 0)
			{
				onDialogsClosed();
			}
			if (dialogs.Count > 0)
			{
				ShowDialog(dialogs.Peek(), DialogShow.SHOW_PREVIOUS);
			}
		}
	}
}
