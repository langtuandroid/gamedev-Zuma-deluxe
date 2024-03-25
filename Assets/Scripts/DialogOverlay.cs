using System;
using UnityEngine;
using UnityEngine.UI;

public class DialogOverlay : MonoBehaviour
{
	private Image overlay;

	private void Awake()
	{
		overlay = GetComponent<Image>();
	}

	private void Start()
	{
		ConversationManager instance = ConversationManager.instance;
		instance.onDialogsOpened = (Action)Delegate.Combine(instance.onDialogsOpened, new Action(OnDialogOpened));
		ConversationManager instance2 = ConversationManager.instance;
		instance2.onDialogsClosed = (Action)Delegate.Combine(instance2.onDialogsClosed, new Action(OnDialogClosed));
	}

	private void OnLevelWasLoaded(int level)
	{
		overlay.enabled = false;
	}

	private void OnDialogOpened()
	{
		overlay.enabled = true;
	}

	private void OnDialogClosed()
	{
		overlay.enabled = false;
	}

	private void OnDestroy()
	{
		ConversationManager instance = ConversationManager.instance;
		instance.onDialogsOpened = (Action)Delegate.Remove(instance.onDialogsOpened, new Action(OnDialogOpened));
		ConversationManager instance2 = ConversationManager.instance;
		instance2.onDialogsClosed = (Action)Delegate.Remove(instance2.onDialogsClosed, new Action(OnDialogClosed));
	}
}
