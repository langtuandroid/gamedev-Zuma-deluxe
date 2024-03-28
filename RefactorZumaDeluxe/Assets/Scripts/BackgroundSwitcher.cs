using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class BackgroundSwitcher : MonoBehaviour
{
	public Image newImage;

	public Sprite[] newSprites;

	public int[] newLevelIndexes;

	private void Start()
	{
		int currentLevel = LevelController.GetCurrentLevel();
		newImage.sprite = newSprites[GetNewLevelIndex(currentLevel)];
	}

	private int GetNewLevelIndex(int level)
	{
		for (int num = newLevelIndexes.Length - 1; num >= 0; num--)
		{
			if (level >= newLevelIndexes[num])
			{
				return num;
			}
		}
		return 0;
	}
}
