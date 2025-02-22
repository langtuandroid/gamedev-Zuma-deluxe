using System;

namespace Superpow
{
	public class Utils
	{
		public static Action<int> onBoosterNumberChanged;

		public static bool IsNormalBall(Sphere sphere)
		{
			Sphere.Type[] array = new Sphere.Type[5]
			{
				Sphere.Type.Sphere1,
				Sphere.Type.Sphere2,
				Sphere.Type.Sphere3,
				Sphere.Type.Sphere4,
				Sphere.Type.Sphere5
			};
			return Array.IndexOf(array, sphere.type) != -1;
		}

		public static bool IsSpecialBall(Sphere sphere)
		{
			Sphere.Type[] array = new Sphere.Type[4]
			{
				Sphere.Type.MultiColor,
				Sphere.Type.Bomb,
				Sphere.Type.Color,
				Sphere.Type.Hidden
			};
			return Array.IndexOf(array, sphere.type) != -1;
		}

		public static void SetBoosterNumber(int boosterID, int number)
		{
			SecurePlayerPrefs.SetInt("booster_" + boosterID + "_number", number);
		}

		public static void ChangeBoosterNumber(int boosterID, int value)
		{
			int boosterNumber = GetBoosterNumber(boosterID);
			SetBoosterNumber(boosterID, boosterNumber + value);
			if (onBoosterNumberChanged != null)
			{
				onBoosterNumberChanged(boosterID);
			}
		}

		public static int GetBoosterNumber(int boosterID)
		{
			return SecurePlayerPrefs.GetInt("booster_" + boosterID + "_number", 2);
		}

		public static void IncreaseNumAttempts(int level)
		{
			int numAttempts = GetNumAttempts(level);
			SecurePlayerPrefs.SetInt("num_attempt_level_" + level, numAttempts + 1);
		}

		public static int GetNumAttempts(int level)
		{
			return SecurePlayerPrefs.GetInt("num_attempt_level_" + level);
		}

		public static void SetAskRateTime()
		{
			SecurePlayerPrefs.SetDouble("ask_rate_time", CUtils.GetCurrentTime());
		}

		public static double GetAskRateTime()
		{
			return SecurePlayerPrefs.GetDouble("ask_rate_time");
		}

		public static void ShowTip(int level)
		{
			SecurePlayerPrefs.SetBool("show_tip_level_" + level, value: true);
		}

		public static bool IsTipShown(int level)
		{
			return SecurePlayerPrefs.GetBool("show_tip_level_" + level);
		}
	}
}
