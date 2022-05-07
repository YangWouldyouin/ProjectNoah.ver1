using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/* Ŭ���� �̸� ��ũ��Ʈ �̸��̶� �Ȱ���
BiteDestroyController + ������Ʈ �̸����� �ٲ۴�. */

public class BiteDestroyController_CollectMeteorites : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    /* ��ȣ�ۿ� ��ư ���� */
    // �̸� ���� ��Ģ : biteButton + ������Ʈ �̸�
    public Button biteButtonCollectMeteorites, smashButtonCollectMeteorites, barkButtonCollectMeteorites, sniffButtonCollectMeteorites, pushOrPressButtonCollectMeteorites;
    [Header("�߰� ��ȣ�ۿ� ��ư")]
    public Button centerButton1_CollectMeteorites;
    public Button centerDisableButton1_CollectMeteorites;
    public Button centerButton2_CollectMeteorites;
    public Button centerDisableButton2_CollectMeteorites;

    // ���⼭���� �Ʒ����� ����

    /* ���� ��ư�� ��� ������ ������ �ı��ϱ� ��ư���� �ٲٱ� ���� ���� */
    // Private ������ �̸� �״�� �ᵵ��

    // ���� ��ư�� ���ȴ��� üũ
    private bool isPointerDown = false;
    // �󸶳� ���� ������ �־�� �ϴ���
    private float requiredChangeTime = 0.5f;
    // ������ �ִ� �ð� ��� ���� ���� 
    private float pointerDownTimer = 0;

    void Update()
    {
        // ������ ���� �ı��ϱ��ư, ���� ��ư ������ �ִ´�. 
        ChangeButton(smashButtonCollectMeteorites, biteButtonCollectMeteorites);
    }

    /* ��ư�� ������ �ִ� �ð��� �缭 0.5�� �̻� �������� �ı��ϱ� ��ư���� �ٲٴ� �Լ� */
    void ChangeButton(Button smashButton, Button biteButton)
    {
        // ���� ��ư�� ������ 
        if (isPointerDown)
        {
            // ������ �ִ� �ð��� ��� 
            pointerDownTimer += Time.deltaTime;
            if (pointerDownTimer >= requiredChangeTime)
            {
                /* 0.5�� �̻� Ŭ���� ���� ��ư ��Ȱ��ȭ, �ı��ϱ� ��ư Ȱ��ȭ */
                smashButton.transform.gameObject.SetActive(true);
                biteButton.transform.gameObject.SetActive(false);

                Reset();
            }
        }
    }

    /* ��ȣ�ۿ� ��ư ���� �Լ� */
    void DiableButton()
    {
        smashButtonCollectMeteorites.transform.gameObject.SetActive(false);
        biteButtonCollectMeteorites.transform.gameObject.SetActive(false);
        barkButtonCollectMeteorites.transform.gameObject.SetActive(false);
        sniffButtonCollectMeteorites.transform.gameObject.SetActive(false);
        pushOrPressButtonCollectMeteorites.transform.gameObject.SetActive(false);
        centerButton1_CollectMeteorites.transform.gameObject.SetActive(false);

        if (centerDisableButton1_CollectMeteorites != null)
        {
            centerDisableButton1_CollectMeteorites.transform.gameObject.SetActive(false);
        }
        if (centerDisableButton2_CollectMeteorites != null)
        {
            centerDisableButton2_CollectMeteorites.transform.gameObject.SetActive(false);
        }
        if (centerButton2_CollectMeteorites != null)
        {
            centerButton2_CollectMeteorites.transform.gameObject.SetActive(false);
        }
    }

    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    /* ���� �Լ� */
    /* ����) ���� ��ư�� Ŭ���ϸ� - ���� ���� �ٸ� �ൿ�� �ؾ� �� �� / 
���������� �Ͼ�� �����϶� ���� �� �����ϸ� �����ϱ� ���� �����Ǵ� ���� ���� */
    public void OnPointerDown(PointerEventData eventData)
    {
        // ���� ��ư�� ������
        isPointerDown = true;

        // ������ ���� ��ȣ�ۿ���� ���´�.
         CameraController.cameraController.CancelObserve();
        // ( ex. ���� ��� : ���� �����ϱ⸦ ����ϸ� �ɾҴ� �Ͼ�� �ִϸ��̼��� �־ 
        // 1.5�� ���� �����̸� �־�� �� )

        // 1.5�� �� ���� �ִϸ��̼� + IsBite ���� ������ �ٲ�
        Invoke("DelayBiteAnim", 1.1f);
    }

    void DelayBiteAnim()
    {
        InteractionButtonController.interactionButtonController.PlayerBite();
    }

    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    /* ���� ��ư Ŭ�� �� ���� */
    public void OnPointerUp(PointerEventData eventData)
    {
        /* ��ȣ�ۿ� ��ư ��Ȱ��ȭ */
        DiableButton();
        /* �չ�ư Ÿ�̸�  & IsPointerDown ������� ���� */
        Reset();
    }

    private void Reset()
    {
        isPointerDown = false;
        pointerDownTimer = 0;
    }

}