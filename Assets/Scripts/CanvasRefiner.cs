using System;
using UnityEngine;

public class CanvasRefiner : MonoBehaviour
{
	public bool isFullScreen;

	private RectTransform tr;

	private void Start()
	{
		tr = GetComponent<RectTransform>();
		OnScreenSizeChanged();
		InterfaceCamera instance = InterfaceCamera.instance;
		instance.onScreenSizeChanged = (Action)Delegate.Combine(instance.onScreenSizeChanged, new Action(OnScreenSizeChanged));
	}

	private void OnLevelWasLoaded(int level)
	{
		tr = GetComponent<RectTransform>();
		OnScreenSizeChanged();
		InterfaceCamera instance = InterfaceCamera.instance;
		instance.onScreenSizeChanged = (Action)Delegate.Combine(instance.onScreenSizeChanged, new Action(OnScreenSizeChanged));
	}

	private void OnScreenSizeChanged()
	{
		if (isFullScreen)
		{
			tr.sizeDelta = new Vector2(InterfaceCamera.instance.virtualWidth, InterfaceCamera.instance.virtualHeight);
		}
		else
		{
			tr.sizeDelta = new Vector2(InterfaceCamera.instance.GetWidth() * 200f, InterfaceCamera.instance.GetHeight() * 200f);
		}
	}
}
