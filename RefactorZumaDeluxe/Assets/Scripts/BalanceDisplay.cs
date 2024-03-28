using System;
using UnityEngine;

public class BalanceDisplay : MonoBehaviour
{
	private void Start()
	{
		UpdateBalance();
		BalanceController.onBalanceChanged = (Action)Delegate.Combine(BalanceController.onBalanceChanged, new Action(OnBalanceChanged));
	}

	private void UpdateBalance()
	{
		base.gameObject.SetText(BalanceController.GetBalance().ToString());
	}

	private void OnBalanceChanged()
	{
		UpdateBalance();
	}

	private void OnDestroy()
	{
		BalanceController.onBalanceChanged = (Action)Delegate.Remove(BalanceController.onBalanceChanged, new Action(OnBalanceChanged));
	}
}
