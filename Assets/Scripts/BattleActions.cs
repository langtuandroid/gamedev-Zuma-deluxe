using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class BattleActions : ScriptableObject
{
	public float speed = 0.5f;

	public int numPaths = 1;

	public int maxSameBalls = 4;

	public int sameBallCoef = 200;

	public ItemConfig itemConfig;

	[FormerlySerializedAs("attacks")] public List<Attack> actions;

	public BallShooter.Type shooterType;

	public Transform cannonPosition;

	public GameObject quad;

	public GameObject paths;

	public int score = 2000;
}
