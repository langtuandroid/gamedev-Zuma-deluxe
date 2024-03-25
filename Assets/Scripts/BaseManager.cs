using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class BaseManager : MonoBehaviour
{
	public GameObject donotDestroyOnLoad;

	public string sceneName;

	public Music.Type backgroundMusic;

	protected int numberOfEnterScene;

	protected virtual void Awake()
	{
		if (DonotDestroyOnLoad.instance == null && donotDestroyOnLoad != null)
		{
			Object.Instantiate(donotDestroyOnLoad);
		}
		
		CPlayerPrefs.useRijndael(true);
		numberOfEnterScene = CUtils.IncreaseNumofEnterScene(sceneName);
	}

	protected virtual void Start()
	{
		CPlayerPrefs.Save();
		if (JobWorker.instance.onEnterScene != null)
		{
			JobWorker.instance.onEnterScene(sceneName);
		}
		Music.instance.Play(backgroundMusic);
	}

	public virtual void OnApplicationPause(bool pause)
	{
		UnityEngine.Debug.Log("On Application Pause");
		CPlayerPrefs.Save();
	}

	private IEnumerator SavePlayerPrefs()
	{
		while (true)
		{
			yield return new WaitForSeconds(5f);
			CPlayerPrefs.Save();
		}
	}
}
