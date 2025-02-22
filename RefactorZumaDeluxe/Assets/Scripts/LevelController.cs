using UnityEngine;

public class LevelController
{
	public static int GetCurrentLevel()
	{
		return SecurePlayerPrefs.GetInt("current_level", 1);
	}

	public static void SetCurrentLevel(int level)
	{
		SecurePlayerPrefs.SetInt("current_level", level);
	}

	public static int GetUnlockLevel()
	{
		return SecurePlayerPrefs.GetInt("unlocked_level", 73);
	}

	public static void SetUnlockLevel(int level)
	{
		SecurePlayerPrefs.SetInt("unlocked_level", level);
	}

	public static int GetMovedLevel()
	{
		return SecurePlayerPrefs.GetInt("moved_level", 1);
	}

	public static void SetMovedLevel(int value)
	{
		SecurePlayerPrefs.SetInt("moved_level", value);
	}

	public static int GetNumStar(int level, int defaultStar = 0)
	{
		return SecurePlayerPrefs.GetInt("num_star_level_" + level, defaultStar);
	}

	public static void SetNumStar(int level, int value)
	{
		int numStar = GetNumStar(level);
		SecurePlayerPrefs.SetInt("num_star_level_" + level, Mathf.Max(numStar, value));
	}
}
