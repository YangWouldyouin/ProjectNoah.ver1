using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/* Ŭ���� �̸� ��ũ��Ʈ �̸��̶� �Ȱ���
BiteDestroyController + ������Ʈ �̸����� �ٲ۴�. */

public class BiteDestroyController_Meteor : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    /* ��ȣ�ۿ� ��ư ���� */
    // �̸� ���� ��Ģ : biteButton + ������Ʈ �̸�
    public Button biteButtonMeteor, smashButtonMeteor, barkButtonMeteor, sniffButtonMeteor, pushOrPressButtonMeteor;
    [Header("�߰� ��ȣ�ۿ� ��ư")]
    public Button centerButton1_Meteor;
    public Button centerDisableButton1_Meteor;
    public Button centerButton2_Meteor;
    public Button centerDisableButton2_Meteor;

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
        ChangeButton(smashButtonMeteor, biteButtonMeteor);
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
        smashButtonMeteor.transform.gameObject.SetActive(false);
        biteButtonMeteor.transform.gameObject.SetActive(false);
        barkButtonMeteor.transform.gameObject.SetActive(false);
        sniffButtonMeteor.transform.gameObject.SetActive(false);
        pushOrPressButtonMeteor.transform.gameObject.SetActive(false);
        centerButton1_Meteor.transform.gameObject.SetActive(false);

        if (centerDisableButton1_Meteor != null)
        {
            centerDisableButton1_Meteor.transform.gameObject.SetActive(false);
        }
        if (centerDisableButton2_Meteor != null)
        {
            centerDisableButton2_Meteor.transform.gameObject.SetActive(false);
        }
        if (centerButton2_Meteor != null)
        {
            centerButton2_Meteor.transform.gameObject.SetActive(false);
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
        Invoke("DelayBiteAnim", 3f);
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