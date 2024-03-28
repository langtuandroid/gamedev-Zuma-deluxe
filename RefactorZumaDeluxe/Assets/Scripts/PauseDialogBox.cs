using UnityEngine.UI;

public class PauseDialogBox : ConfirmationDialogBox
{
	public Toggle music;

	public Toggle sound;

	protected override void Start()
	{
		base.Start();
		onConfirm = MenuClick;
		onCancel = ContinueClick;
		music.isOn = Music.instance.IsEnabled();
		sound.isOn = SoundController.instance.IsEnabled();
		Timer.Schedule(this, 0.5f, delegate
		{
			GameState.pauseGame = true;
		});
	}

	private void MenuClick()
	{
		GotoMenu();
	}

	private void GotoMenu()
	{
		GameState.pauseGame = false;
		SaveSetting();
		CUtils.LoadScene(1, useScreenFader: true);
	}

	private void ContinueClick()
	{
		GameState.pauseGame = false;
		SaveSetting();
	}

	public void ReplayClick()
	{
		GameState.pauseGame = false;
		CUtils.ReloadScene(useScreenFader: true);
		SoundController.instance.PlayButton();
		Close();
	}

	public void SaveSetting()
	{
		Music.instance.SetEnabled(music.isOn, updateMusic: true);
		SoundController.instance.SetEnabled(sound.isOn);
	}

	public void CloseDialog()
	{
		GameState.pauseGame = false;
	}

	public void OnToggleChanged()
	{
		SoundController.instance.PlayButton();
	}
}
