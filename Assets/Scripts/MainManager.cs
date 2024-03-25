using Superpow;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : BaseManager
{
	public enum Status
	{
		Playing,
		Completed
	}

	public static MainManager instance;

	public GameObject sphereControllersObject;

	public CProgress progress;

	public Compliment compliment;

	public Sphere test;

	[HideInInspector]
	public SphereController[] sphereControllers;

	[HideInInspector]
	public int numPaths;

	[HideInInspector]
	public bool isWin;

	[HideInInspector]
	public float lastShootTime = -1f;

	[HideInInspector]
	public float lastSuccessShootTime = -2f;

	public Status status;

	private BattleActions _battleActions;

	public List<GameState.State> state;

	private int numCompletePaths;

	private int numBallFallHoles;

	private int numContinuousExplode;

	private int numItems;

	private float lastItemTime;

	private int level;

	private int numStars;

	private float completeTime;

	protected override void Awake()
	{
		base.Awake();
		instance = this;
	}

	protected override void Start()
	{
		base.Start();
		level = LevelController.GetCurrentLevel();
		_battleActions = Resources.Load<BattleActions>("Level_" + level);
		numPaths = _battleActions.numPaths;
		sphereControllers = new SphereController[numPaths];
		SphereController.battleActions = _battleActions;
		for (int i = 0; i < numPaths; i++)
		{
			SphereController sphereController = sphereControllersObject.AddComponent<SphereController>();
			sphereController.index = i;
			sphereControllers[i] = sphereController;
		}
		progress.maxProgress = _battleActions.score;
		GameState.Init();
		Timekeeper.Schedule(this, 1f, delegate
		{
			Music.Type random = CUtils.GetRandom<Music.Type>(Music.Type.Main1, Music.Type.Main1, Music.Type.Main3);
			Music.instance.Play(random);
		});
		if (Guide.IsDone(Guide.Type.SwitchBalls))
		{
			if (level == 2 || level == 4 || level == 6 || !Guide.IsDone(Guide.Type.TipSkipBall))
			{
				GuideController.instance.Show(Guide.Type.TipSkipBall);
				Utils.ShowTip(level);
			}
			else if (level == 3 || level == 5 || level == 7 || !Guide.IsDone(Guide.Type.TipSwitchBalls))
			{
				GuideController.instance.Show(Guide.Type.TipSwitchBalls);
				Utils.ShowTip(level);
			}
		}
		Utils.IncreaseNumAttempts(level);
		GameState.pauseGame = false;
	}

	private void Update()
	{
		if (UnityEngine.Input.GetKeyDown(KeyCode.Escape) && status == Status.Playing)
		{
			ConversationManager.instance.DisplayDialog(DialogueForm.Pause);
		}
	}

	public void SpawnRandomItem(List<Sphere> explodedBalls)
	{
		if (explodedBalls.Count >= _battleActions.itemConfig.minExplodeBalls && !((float)Random.Range(0, 100) > _battleActions.itemConfig.randomCoef) && numItems < _battleActions.itemConfig.maxItems && !(lastItemTime + _battleActions.itemConfig.gapTime > Time.time))
		{
			Sphere sphere = explodedBalls[explodedBalls.Count / 2];
			Vector3 position = sphere.transform.position - Vector3.forward * 0.3f;
			if (Mathf.Abs(position.x) < InterfaceCamera.instance.GetWidth() - 0.3f && Mathf.Abs(position.y) < InterfaceCamera.instance.GetHeight() - 1f)
			{
				float[] probs = new float[6]
				{
					100f,
					100f,
					100f,
					100f,
					100f,
					20f
				};
				Item original = MonoUtils.instance.items[CUtils.ChooseRandomWithProbs(probs)];
				Object.Instantiate(original, position, Quaternion.identity);
			}
			numItems++;
			lastItemTime = Time.time;
		}
	}

	public void OnCompletePath(int pathIndex)
	{
		numCompletePaths++;
		if (numCompletePaths == numPaths)
		{
			isWin = true;
			Invoke("OnComplete", completeTime - Time.time);
		}
	}

	public void SetCompleteTime(float _completeTime)
	{
		completeTime = Mathf.Max(completeTime, _completeTime);
	}

	public void OnComplete()
	{
		if (status == Status.Completed)
		{
			return;
		}
		status = Status.Completed;
		CompleteCustomDialog completeCustomDialog = (CompleteCustomDialog)ConversationManager.instance.RetrieveDialog(DialogueForm.Complete);
		completeCustomDialog.numStars = progress.GetReachedTarget();
		completeCustomDialog.score = (int)progress.Current;
		completeCustomDialog.isWin = isWin;
		ConversationManager.instance.DisplayDialog(completeCustomDialog);
		if (isWin)
		{
			numStars = progress.GetReachedTarget();
			LevelController.SetNumStar(level, numStars);
			if (level == LevelController.GetUnlockLevel())
			{
				LevelController.SetUnlockLevel(level + 1);
			}
			Sound.instance.Play(Sound.Others.Win);
			if (level % 2 == 0)
			{
				CUtils.ShowInterstitialAd();
			}
		}
		else
		{
			Sound.instance.Play(Sound.Others.Fail);
			CUtils.ShowInterstitialAd();
		}
	}

	public void IncreaseFallingHole()
	{
		numBallFallHoles++;
		if (numBallFallHoles == 5)
		{
			isWin = false;
			OnComplete();
		}
	}

	public void GiveCompliment(List<Sphere> explodedBalls)
	{
		lastSuccessShootTime = Time.time;
		numContinuousExplode++;
		int count = explodedBalls.Count;
		int num = 0;
		if (count == 5 || numContinuousExplode == 5)
		{
			compliment.DoTask(Compliment.Type.GoodJob);
			num = 500;
		}
		else if (count == 6 || numContinuousExplode == 6)
		{
			compliment.DoTask(Compliment.Type.Welldone);
			num = 1000;
		}
		else if (count == 7 || numContinuousExplode == 7)
		{
			compliment.DoTask(Compliment.Type.Great);
			num = 2000;
		}
		else if (count == 8 || numContinuousExplode == 8)
		{
			compliment.DoTask(Compliment.Type.Excellent);
			num = 4000;
		}
		else if (count > 8 || numContinuousExplode > 8)
		{
			compliment.DoTask(Compliment.Type.Awesome);
			num = 8000;
		}
		else if (numContinuousExplode == 3)
		{
			compliment.DoTask(Compliment.Type.Threehit);
		}
		else if (numContinuousExplode == 4)
		{
			compliment.DoTask(Compliment.Type.Fourhit);
		}
		if (num > 0)
		{
			GiveCompliment(explodedBalls[count / 2].transform.position, num);
		}
	}

	public void GiveCompliment(Vector3 beginPosition, int bonusScore)
	{
		Vector3 position = MonoUtils.instance.scoreMoveTarget.position;
		Vector3 middlePoint = CUtils.GetMiddlePoint(beginPosition, position, 0.5f);
		Vector3 middlePoint2 = CUtils.GetMiddlePoint(beginPosition, position, -0.5f);
		Vector3 a = (!(middlePoint.magnitude < middlePoint2.magnitude)) ? middlePoint2 : middlePoint;
		ObjectGenerationAndMovement component = GetComponent<ObjectGenerationAndMovement>();
		component.SetWaypoints(beginPosition, a - Vector3.forward, position - Vector3.right * 0.3f);
		component.StartCoroutine(component.DoTask());
		float delay = Vector3.Distance(beginPosition, position) / 7f;
		Timekeeper.Schedule(this, delay, delegate
		{
			ScoreCounter.instance.AddScore(bonusScore);
		});
		GameObject gameObject = Object.Instantiate(MonoUtils.instance.bonusText);
		gameObject.transform.position = beginPosition;
		gameObject.GetComponent<RewardText>().text = "+" + bonusScore;
		iTween.ValueTo(gameObject, iTween.Hash("from", 1, "to", 0, "time", 0.3f, "onupdate", "OnUpdate", "delay", 0.7f));
	}

	public void BreakContinuousExplode()
	{
		numContinuousExplode = 0;
	}

	public void OnCannonShoot()
	{
		if (lastSuccessShootTime < lastShootTime)
		{
			BreakContinuousExplode();
		}
		lastShootTime = Time.time;
	}
}