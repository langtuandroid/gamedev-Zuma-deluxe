using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class InviteFriendsCustomDialog : CustomDialog
{
	public InviteFriendLine Row;

	public RectTransform contentTransform;

	public Action<string> onInviteProcessed;

	public Scrollbar scrollBar;

	private List<InvitableFriend> data;

	public void Build(List<InvitableFriend> data)
	{
		this.data = data;
		for (int i = 0; i < data.Count; i++)
		{
			string name = data[i].name;
			string avatarUrl = data[i].avatarUrl;
			InviteFriendLine inviteFriendLine = UnityEngine.Object.Instantiate(Row);
			inviteFriendLine.Build(name, avatarUrl);
			inviteFriendLine.transform.SetParent(contentTransform);
			inviteFriendLine.rectTransform.localScale = Vector3.one;
			inviteFriendLine.rectTransform.anchoredPosition = new Vector3(0f, (25 - i) * 110);
		}
		RectTransform rectTransform = contentTransform;
		Vector2 sizeDelta = contentTransform.sizeDelta;
		rectTransform.sizeDelta = new Vector2(sizeDelta.x, 110 * data.Count);
	}

	protected override void Start()
	{
		base.Start();
		scrollBar.value = 1f;
	}

	public void Invite()
	{
		Sound.instance.PlayButton();
		if (CheckRequirement())
		{
			string recipients = GetRecipients();
			onInviteProcessed(recipients);
			Close();
		}
	}

	private bool CheckRequirement()
	{
		int num = 0;
		for (int i = 0; i < data.Count; i++)
		{
			InviteFriendLine component = contentTransform.GetChild(i).GetComponent<InviteFriendLine>();
			data[i].shouldInvite = component.toggleCheck.isOn;
			if (component.toggleCheck.isOn)
			{
				num++;
			}
		}
		if (num >= 40)
		{
			return true;
		}
		Toast.instance.ShowMessage(Language.Get("INVITE_MORE"));
		return false;
	}

	private string GetRecipients()
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < data.Count; i++)
		{
			if (data[i].shouldInvite)
			{
				string id = data[i].id;
				if (i != data.Count - 1)
				{
					stringBuilder.Append(id).Append(",");
				}
				else
				{
					stringBuilder.Append(id);
				}
			}
		}
		return stringBuilder.ToString();
	}
}
