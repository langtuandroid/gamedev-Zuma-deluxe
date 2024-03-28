using UnityEngine;

public class DevelopmentOnly : MonoBehaviour
{
	public bool setRuby;

	public int ruby;

	public bool setUnlockLevel;

	public int unlockLevel;

	public bool clearAllPrefs;

	private void Start()
	{
		if (setRuby)
		{
			BalanceController.SetBalance(ruby);
		}
		if (setUnlockLevel)
		{
			LevelController.SetUnlockLevel(unlockLevel);
		}
		if (clearAllPrefs)
		{
			SecurePlayerPrefs.DeleteAll();
			SecurePlayerPrefs.Save();
		}
	}
}
