using System;

public class BalanceController
{
	public const string CURRENCY = "coins";

	public const int DEFAULT_CURRENCY = 500;

	public static Action onBalanceChanged;

	public static Action<int> onBallanceIncreased;

	public static int GetBalance()
	{
		return SecurePlayerPrefs.GetInt("coins", 500);
	}

	public static void SetBalance(int value)
	{
		SecurePlayerPrefs.SetInt("coins", value);
		SecurePlayerPrefs.Save();
	}

	public static void CreditBalance(int value)
	{
		int balance = GetBalance();
		SetBalance(balance + value);
		if (onBalanceChanged != null)
		{
			onBalanceChanged();
		}
		if (onBallanceIncreased != null)
		{
			onBallanceIncreased(value);
		}
	}

	public static bool DebitBalance(int value)
	{
		int balance = GetBalance();
		if (balance < value)
		{
			return false;
		}
		SetBalance(balance - value);
		if (onBalanceChanged != null)
		{
			onBalanceChanged();
		}
		return true;
	}
}
