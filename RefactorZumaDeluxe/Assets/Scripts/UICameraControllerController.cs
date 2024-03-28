public class UICameraControllerController : CameraController
{
	public static UICameraControllerController instance;

	protected override void Awake()
	{
		instance = this;
		base.Awake();
	}
}
