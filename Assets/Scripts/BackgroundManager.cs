using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour
{
	public Image backgroundImage;

	public Sprite[] backgroundSprites;

	public int[] levelIndexes;

	private void Start()
	{
		int currentLevel = LevelController.GetCurrentLevel();
		backgroundImage.sprite = backgroundSprites[FindBackgroundIndex(currentLevel)];
	}

	private int FindBackgroundIndex(int level)
	{
		for (int num = levelIndexes.Length - 1; num >= 0; num--)
		{
			if (level >= levelIndexes[num])
			{
				return num;
			}
		}
		return 0;
	}
}
