using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class BaseGameController : MonoBehaviour
{
	public GameObject donotDestroyOnLoad;

	public string sceneName;

	public Music.Type backgroundMusic;

	protected int numberOfSceneEntries;

	protected virtual void Awake()
	{
		if (DonotDestroyOnLoad.instance == null && donotDestroyOnLoad != null)
		{
			Object.Instantiate(donotDestroyOnLoad);
		}
		
		SecurePlayerPrefs.useRijndael(use: true);
		numberOfSceneEntries = CUtils.IncreaseNumofEnterScene(sceneName);
	}

	protected virtual void Start()
	{
		SecurePlayerPrefs.Save();
		if (JobWorker.instance.onEnterScene != null)
		{
			JobWorker.instance.onEnterScene(sceneName);
		}
		Music.instance.Play(backgroundMusic);
	}

	public virtual void OnApplicationPause(bool pause)
	{
		UnityEngine.Debug.Log("On Application Pause");
		SecurePlayerPrefs.Save();
	}

	private IEnumerator SavePlayerPrefsPeriodically()
	{
		while (true)
		{
			yield return new WaitForSeconds(5f);
			SecurePlayerPrefs.Save();
		}
	}
}
