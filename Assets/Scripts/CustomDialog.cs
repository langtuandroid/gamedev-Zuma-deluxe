using System;
using UnityEngine;
using UnityEngine.Serialization;

public class CustomDialog : MonoBehaviour
{
	public Animator anim;

	public AnimationClip hidingAnimation;

	public GameObject title;

	public GameObject message;

	public Action<CustomDialog> onDialogOpened;

	public Action<CustomDialog> onDialogClosed;

	public Action onDialogCompleteClosed;

	public Action<CustomDialog> onButtonCloseClicked;

	[FormerlySerializedAs("dialogType")] public DialogueForm dialogueForm;

	private AnimatorStateInfo info;

	private bool isShowing;

	protected virtual void Awake()
	{
		if (anim == null)
		{
			anim = GetComponent<Animator>();
		}
	}

	protected virtual void Start()
	{
		onDialogCompleteClosed = (Action)Delegate.Combine(onDialogCompleteClosed, new Action(OnDialogCompleteClosed));
	}

	private void Update()
	{
		if (UnityEngine.Input.GetKeyDown(KeyCode.Escape) && dialogueForm != DialogueForm.Complete)
		{
			Close();
		}
	}

	public virtual void Show()
	{
		if (anim != null && IsIdle())
		{
			isShowing = true;
			anim.SetTrigger("show");
			onDialogOpened(this);
		}
		CUtils.ShowBannerAd();
	}

	public virtual void Close()
	{
		if (isShowing)
		{
			isShowing = false;
			if (anim != null && IsIdle() && hidingAnimation != null)
			{
				anim.SetTrigger("hide");
				Timekeeper.Schedule(this, hidingAnimation.length, DoClose);
			}
			else
			{
				DoClose();
			}
			CUtils.CloseBannerAd();
		}
	}

	private void DoClose()
	{
		onDialogClosed(this);
		UnityEngine.Object.Destroy(base.gameObject);
		if (onDialogCompleteClosed != null)
		{
			onDialogCompleteClosed();
		}
	}

	public void Hide()
	{
		base.gameObject.SetActive(value: false);
		isShowing = false;
	}

	public bool IsIdle()
	{
		info = anim.GetCurrentAnimatorStateInfo(0);
		return info.IsName("Idle");
	}

	public bool IsShowing()
	{
		return isShowing;
	}

	public virtual void OnDialogCompleteClosed()
	{
		onDialogCompleteClosed = (Action)Delegate.Remove(onDialogCompleteClosed, new Action(OnDialogCompleteClosed));
	}
}
