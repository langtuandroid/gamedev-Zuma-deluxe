
using UnityEngine;

public class RewardedButton : MonoBehaviour
{
	public GameObject content;

    

    private const string ACTION_NAME = "rewarded_video";

	

	public void OnClick()
	{
		SoundController.instance.PlayButton();
	}

	

	
}
