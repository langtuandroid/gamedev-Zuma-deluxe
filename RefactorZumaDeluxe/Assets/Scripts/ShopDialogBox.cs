using Superpow;

public class ShopDialogBox : DialogBox
{
	private const int BOOSTER_PRICE = 10;

	private int[] BOOSTER_NUMBERS = new int[5]
	{
		1,
		3,
		4,
		5,
		5
	};

	protected override void Start()
	{
		base.Start();
		Timer.Schedule(this, 0.5f, delegate
		{
			GameState.pauseGame = true;
		});
	}

	public void BuyProduct(int index)
	{
		Purchaser.instance.BuyProduct(index);
	}

	public void OnBuyBoosterClick(int boosterID)
	{
		if (BalanceController.GetBalance() >= 10)
		{
			Utils.ChangeBoosterNumber(boosterID, BOOSTER_NUMBERS[boosterID]);
			Toast.instance.ShowMessage("Succesful");
			BalanceController.DebitBalance(10);
		}
		else
		{
			Toast.instance.ShowMessage("Not enough rubies.");
			GetComponent<TabBehaviour>().SetCurrentTab(0);
		}
	}

	public void CloseDialog()
	{
		GameState.pauseGame = false;
		Toast.instance.ClearQueue();
	}
}
