using Superpow;
using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class BoosterCounter : MonoBehaviour
{
	public int boosterIdentifier;

	private void Start()
	{
		Utils.onBoosterNumberChanged = (Action<int>)Delegate.Combine(Utils.onBoosterNumberChanged, new Action<int>(OnBoosterNumberChanged));
		UpdateUI();
	}

	private void UpdateUI()
	{
		GetComponent<Text>().text = Utils.GetBoosterNumber(boosterIdentifier).ToString();
	}

	private void OnBoosterNumberChanged(int changedBoosterID)
	{
		if (this.boosterIdentifier == changedBoosterID)
		{
			UpdateUI();
		}
	}

	private void OnDestroy()
	{
		Utils.onBoosterNumberChanged = (Action<int>)Delegate.Remove(Utils.onBoosterNumberChanged, new Action<int>(OnBoosterNumberChanged));
	}
}
