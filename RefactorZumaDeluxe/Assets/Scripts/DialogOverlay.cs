using System;
using UnityEngine;
using UnityEngine.UI;

public class DialogOverlay : MonoBehaviour
{
	private Image overlayImage;

	private void Awake()
	{
		overlayImage = GetComponent<Image>();
	}

	private void Start()
	{
		UIManager instance = UIManager.instance;
		instance.onDialogsOpened = (Action)Delegate.Combine(instance.onDialogsOpened, new Action(OnDialogOpened));
		UIManager instance2 = UIManager.instance;
		instance2.onDialogsClosed = (Action)Delegate.Combine(instance2.onDialogsClosed, new Action(OnDialogClosed));
	}

	private void OnLevelWasLoaded(int level)
	{
		overlayImage.enabled = false;
	}

	private void OnDialogOpened()
	{
		overlayImage.enabled = true;
	}

	private void OnDialogClosed()
	{
		overlayImage.enabled = false;
	}

	private void OnDestroy()
	{
		UIManager instance = UIManager.instance;
		instance.onDialogsOpened = (Action)Delegate.Remove(instance.onDialogsOpened, new Action(OnDialogOpened));
		UIManager instance2 = UIManager.instance;
		instance2.onDialogsClosed = (Action)Delegate.Remove(instance2.onDialogsClosed, new Action(OnDialogClosed));
	}
}
