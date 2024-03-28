using UnityEngine;
using UnityEngine.UI;

public class TButton : CustomButton
{
	public bool isOn;

	public Sprite on;

	public Sprite off;

	public bool IsOn
	{
		get
		{
			return isOn;
		}
		set
		{
			isOn = value;
			UpdateButtons();
		}
	}

	public override void WhenClicked()
	{
		base.WhenClicked();
		IsOn = !IsOn;
	}

	public void UpdateButtons()
	{
		GetComponent<Image>().sprite = ((!isOn) ? off : on);
	}
}
