using UnityEngine;
using UnityEngine.UI;

public class CustomButton : MonoBehaviour
{
	protected Button customButton;

	protected virtual void Start()
	{
		customButton = GetComponent<Button>();
		if (customButton != null)
		{
			customButton.onClick.AddListener(WhenClicked);
		}
	}

	public virtual void WhenClicked()
	{
		SoundController.instance.PlayButton();
	}
}
