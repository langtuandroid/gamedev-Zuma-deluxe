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
		UICameraControllerController instance = UICameraControllerController.instance;
		instance.onScreenSizeChanged = (Action)Delegate.Combine(instance.onScreenSizeChanged, new Action(OnScreenSizeChanged));
	}

	private void OnLevelWasLoaded(int level)
	{
		tr = GetComponent<RectTransform>();
		OnScreenSizeChanged();
		UICameraControllerController instance = UICameraControllerController.instance;
		instance.onScreenSizeChanged = (Action)Delegate.Combine(instance.onScreenSizeChanged, new Action(OnScreenSizeChanged));
	}

	private void OnScreenSizeChanged()
	{
		if (isFullScreen)
		{
			tr.sizeDelta = new Vector2(UICameraControllerController.instance.virtualWidth, UICameraControllerController.instance.virtualHeight);
		}
		else
		{
			tr.sizeDelta = new Vector2(UICameraControllerController.instance.GetWidth() * 200f, UICameraControllerController.instance.GetHeight() * 200f);
		}
	}
}
