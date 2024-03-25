using System;
using UnityEngine;

[Serializable]
public class GameConfig
{
	

	[Header("")]
	public int adPeriod;

	public int rewardedVideoPeriod;

	public int rewardedVideoAmount;

	public string androidPackageID;

	public string iosAppID;

	public string macAppID;

	public string facebookPageID;
}
