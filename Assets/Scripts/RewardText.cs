using UnityEngine;

public class RewardText : MonoBehaviour
{
	private TextMesh[] textMeshes;

	public string text;

	private void Start()
	{
		textMeshes = GetComponentsInChildren<TextMesh>();
		textMeshes[0].text = text;
		textMeshes[1].text = text;
	}

	public void OnAnimationComplete()
	{
		UnityEngine.Object.Destroy(base.gameObject);
	}

	public void OnUpdate(float value)
	{
		TextMesh obj = textMeshes[0];
		Color color = textMeshes[0].color;
		float r = color.r;
		Color color2 = textMeshes[0].color;
		float g = color2.g;
		Color color3 = textMeshes[0].color;
		obj.color = new Color(r, g, color3.b, value);
		TextMesh obj2 = textMeshes[1];
		Color color4 = textMeshes[1].color;
		float r2 = color4.r;
		Color color5 = textMeshes[1].color;
		float g2 = color5.g;
		Color color6 = textMeshes[1].color;
		obj2.color = new Color(r2, g2, color6.b, value);
	}
}
