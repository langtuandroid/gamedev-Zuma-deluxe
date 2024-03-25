public class InterfaceCamera : CCamera
{
	public static InterfaceCamera instance;

	protected override void Awake()
	{
		instance = this;
		base.Awake();
	}
}
