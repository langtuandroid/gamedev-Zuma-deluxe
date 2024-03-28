using System;
using UnityEngine;

public class RefineCanvas : MonoBehaviour
{
	public RectTransform[] canvases;

	public RectTransform[] screensizeCanvases;

	private void Start()
	{
		OnScreenSizeChanged();
		UICameraControllerController instance = UICameraControllerController.instance;
		instance.onScreenSizeChanged = (Action)Delegate.Combine(instance.onScreenSizeChanged, new Action(OnScreenSizeChanged));
	}

	private void OnScreenSizeChanged()
	{
		RectTransform[] array = canvases;
		foreach (RectTransform rectTransform in array)
		{
			rectTransform.sizeDelta = new Vector2(UICameraControllerController.instance.GetWidth() * 200f, UICameraControllerController.instance.GetHeight() * 200f);
		}
		RectTransform[] array2 = screensizeCanvases;
		foreach (RectTransform rectTransform2 in array2)
		{
			rectTransform2.sizeDelta = new Vector2(UICameraControllerController.instance.virtualWidth, UICameraControllerController.instance.virtualHeight);
		}
	}
}
