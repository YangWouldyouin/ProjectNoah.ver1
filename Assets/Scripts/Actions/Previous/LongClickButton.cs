/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LongClickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	private bool pointerDown;
	private float pointerDownTimer;

	[SerializeField] float requiredHoldTime = 1f;

	public UnityEvent onLongClick;


	public void OnPointerDown(PointerEventData eventData)
	{
		pointerDown = true;
		Debug.Log("OnPointerDown");
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		Reset();
		Debug.Log("OnPointerUp");
	}

	private void Update()
	{
		if (pointerDown)
		{
			pointerDownTimer += Time.deltaTime;
			if (pointerDownTimer >= requiredHoldTime)
			{
				if (onLongClick != null)
					onLongClick.Invoke();

				Reset();
			}
		}
	}

	private void Reset()
	{
		pointerDown = false;
		pointerDownTimer = 0;
	}
}

*/
//public Button biteButton, destroyButton;
////��ư�� Ŭ���� ���� && ������ 2���̻��̸�
//public void OnLongClick()
//{
//	biteButton.transform.gameObject.SetActive(false);
//	destroyButton.transform.gameObject.SetActive(true);
//}
