using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
	public GameObject stars;

	public GameObject star1;

	public GameObject star2;

	public GameObject star3;

	public GameObject starEffect;

	private int level;

	public Text levelText;

	private void Start()
	{
		CustomButton component = GetComponent<CustomButton>();
		int unlockLevel = LevelController.GetUnlockLevel();
		level = base.transform.GetSiblingIndex() + 1;
		levelText.text = level.ToString();
		if (level > unlockLevel)
		{
			component.SetActiveSprite(isActive: false);
		}
		else if (level < unlockLevel)
		{
			stars.gameObject.SetActive(value: true);
			switch (LevelController.GetNumStar(level, 1))
			{
			case 1:
				star1.SetActive(value: true);
				break;
			case 2:
				star1.SetActive(value: true);
				star2.SetActive(value: true);
				break;
			case 3:
				star1.SetActive(value: true);
				star2.SetActive(value: true);
				star3.SetActive(value: true);
				break;
			}
		}
		if (level == unlockLevel)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(starEffect, base.transform.position - Vector3.forward, Quaternion.identity);
			gameObject.transform.SetParent(base.transform);
		}
	}

	public void OnClick()
	{
		LevelController.SetCurrentLevel(level);
		CUtils.LoadScene(2, useScreenFader: true);
	}
}
