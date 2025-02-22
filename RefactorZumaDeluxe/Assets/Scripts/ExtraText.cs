using UnityEngine;
using UnityEngine.Serialization;

public class ExtraText : MonoBehaviour
{
	private TextMesh[] textMeshs;

	public string message;

	private void Start()
	{
		textMeshs = GetComponentsInChildren<TextMesh>();
		textMeshs[0].text = message;
		textMeshs[1].text = message;
	}

	public void OnAnimationComplete()
	{
		Destroy(gameObject);
	}

	public void OnUpdate(float value)
	{
		TextMesh obj = textMeshs[0];
		Color color = textMeshs[0].color;
		float r = color.r;
		Color color2 = textMeshs[0].color;
		float g = color2.g;
		Color color3 = textMeshs[0].color;
		obj.color = new Color(r, g, color3.b, value);
		TextMesh obj2 = textMeshs[1];
		Color color4 = textMeshs[1].color;
		float r2 = color4.r;
		Color color5 = textMeshs[1].color;
		float g2 = color5.g;
		Color color6 = textMeshs[1].color;
		obj2.color = new Color(r2, g2, color6.b, value);
	}
}
