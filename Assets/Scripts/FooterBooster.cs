using Superpow;
using UnityEngine;
using UnityEngine.Serialization;

public class FooterBooster : MonoBehaviour
{
	public int boosterID;

	[FormerlySerializedAs("boosterNumber")] public BoosterCounter boosterCounter;

	public void OnClick()
	{
		if (MainManager.instance.status == MainManager.Status.Completed)
		{
			return;
		}
		int num = Utils.GetBoosterNumber(boosterCounter.boosterIdentifier);
		Sphere sphere = BallShooter.instance.slots[0].sphere;
		if (num > 0)
		{
			switch (boosterID)
			{
			case 0:
				if (MonoUtils.instance.GetTotalBalls() != 0)
				{
					Utils.ChangeBoosterNumber(boosterCounter.boosterIdentifier, -1);
					MonoUtils.instance.StartCoroutine(MonoUtils.instance.RainBomb());
				}
				break;
			case 1:
				if (sphere.type != Sphere.Type.Bomb)
				{
					Utils.ChangeBoosterNumber(boosterCounter.boosterIdentifier, -1);
					BallShooter.instance.CreateBomb();
				}
				break;
			case 2:
				if (sphere.type != Sphere.Type.MultiColor)
				{
					Utils.ChangeBoosterNumber(boosterCounter.boosterIdentifier, -1);
					BallShooter.instance.CreateMultiColors();
				}
				break;
			case 3:
				if (sphere.type != Sphere.Type.Color)
				{
					Utils.ChangeBoosterNumber(boosterCounter.boosterIdentifier, -1);
					BallShooter.instance.CreateColor();
				}
				break;
			case 4:
				if (!GameState.IsBackwarding())
				{
					Utils.ChangeBoosterNumber(boosterCounter.boosterIdentifier, -1);
					SphereController.Backward();
				}
				break;
			}
		}
		else
		{
			StoreDialogue storeDialogue = (StoreDialogue)ConversationManager.instance.RetrieveDialog(DialogueForm.Shop);
			storeDialogue.GetComponent<TabInteraction>().SetCurrentTab(0);
			ConversationManager.instance.DisplayDialog(storeDialogue);
		}
	}
}
