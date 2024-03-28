using Superpow;
using UnityEngine;
using UnityEngine.Serialization;

public class FooterBooster : MonoBehaviour
{
    public int boosterID;
    [FormerlySerializedAs("powerupCounter")] public BoosterNumber boosterNumber;

    private static float lastUsedTime;
    private const float boosterCooldown = 5f; // Таймер в секундах до восстановления бустера

    private void Start()
    {
        lastUsedTime = -boosterCooldown; // Устанавливаем время последнего использования в прошлое, чтобы бустер был доступен сразу при запуске игры
    }

    public void OnClick()
    {
        if (MainGameController.instance.status == MainGameController.Status.Completed)
        {
            return;
        }

        float timeSinceLastUse = Time.time - lastUsedTime;

        if (timeSinceLastUse >= boosterCooldown)
        {
            int num = Utils.GetBoosterNumber(boosterNumber.boosterID);
            Sphere sphere = BallShooter.instance.slots[0].sphere;

            if (num > 0)
            {
                switch (boosterID)
                {
                    case 0:
                        if (MonoUtils.instance.GetTotalBalls() != 0)
                        {
                            Utils.ChangeBoosterNumber(boosterNumber.boosterID, -1);
                            MonoUtils.instance.StartCoroutine(MonoUtils.instance.RainBomb());
                        }
                        break;
                    case 1:
                        if (sphere.type != Sphere.Type.Bomb)
                        {
                            Utils.ChangeBoosterNumber(boosterNumber.boosterID, -1);
                            BallShooter.instance.CreateBomb();
                        }
                        break;
                    case 2:
                        if (sphere.type != Sphere.Type.MultiColor)
                        {
                            Utils.ChangeBoosterNumber(boosterNumber.boosterID, -1);
                            BallShooter.instance.CreateMultiColors();
                        }
                        break;
                    case 3:
                        if (sphere.type != Sphere.Type.Color)
                        {
                            Utils.ChangeBoosterNumber(boosterNumber.boosterID, -1);
                            BallShooter.instance.CreateColor();
                        }
                        break;
                    case 4:
                        if (!GameState.IsBackwarding())
                        {
                            Utils.ChangeBoosterNumber(boosterNumber.boosterID, -1);
                            SphereController.Backward();
                        }
                        break;
                }

                lastUsedTime = Time.time;
            }
            else
            {
                ShopDialogBox shopDialogBox = (ShopDialogBox)UIManager.instance.GetDialog(DialogType.Shop);
                shopDialogBox.GetComponent<TabBehaviour>().SetCurrentTab(0);
                UIManager.instance.ShowDialog(shopDialogBox);
            }
        }
        else
        {
            Toast.instance.ShowMessage("The booster is not yet available. Wait another " + (boosterCooldown - timeSinceLastUse) + " seconds" );
        }
    }
}
