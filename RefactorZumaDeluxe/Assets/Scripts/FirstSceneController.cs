using UnityEngine;

public class FirstSceneController : MonoBehaviour
{
	public static FirstSceneController instance;

	private void Awake()
	{
		instance = this;
		Application.targetFrameRate = 60;
		SecurePlayerPrefs.useRijndael(use: true);
		CUtils.SetAndroidVersion("1.0.0");
		CUtils.SetIOSVersion("1.0");
		CUtils.SetWindowsPhoneVersion("1.0.0.0");
	}

	private void Update()
	{
		if (UnityEngine.Input.GetKeyDown(KeyCode.Escape) && !UIManager.instance.IsDialogShowing())
		{
			UIManager.instance.ShowDialog(DialogType.QuitGame);
		}
	}
}
