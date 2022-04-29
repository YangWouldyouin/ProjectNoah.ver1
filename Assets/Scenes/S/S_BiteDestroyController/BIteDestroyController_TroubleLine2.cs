using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/* Ŭ���� �̸� ��ũ��Ʈ �̸��̶� �Ȱ���
BiteDestroyController + ������Ʈ �̸����� �ٲ۴�. */

public class BIteDestroyController_TroubleLine2 : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    /*�����ִ� ������Ʈ*//*
    public GameObject T_DoLineHome2;

    ObjData DoDoLineHome2Data_T;

    Outline DoLineHome2Outline_T;*/

    /* ��ȣ�ۿ� ��ư ���� */
    // �̸� ���� ��Ģ : biteButton + ������Ʈ �̸�
    public Button biteButtonTroubleLine2, smashButtonTroubleLine2,
        barkButtonTroubleLine2, sniffButtonTroubleLine2, pushOrPressButtonTroubleLine2;
    [Header("�߰� ��ȣ�ۿ� ��ư")]
    public Button centerButton1_TroubleLine2;
    public Button centerDisableButton1_TroubleLine2;
    public Button centerButton2_TroubleLine2;
    public Button centerDisableButton2_TroubleLine2;

    // ���⼭���� �Ʒ����� ����

    /* ���� ��ư�� ��� ������ ������ �ı��ϱ� ��ư���� �ٲٱ� ���� ���� */
    // Private ������ �̸� �״�� �ᵵ��

    // ���� ��ư�� ���ȴ��� üũ
    private bool isPointerDown = false;
    // �󸶳� ���� ������ �־�� �ϴ���
    private float requiredChangeTime = 0.5f;
    // ������ �ִ� �ð� ��� ���� ���� 
    private float pointerDownTimer = 0;

/*    void Start()
    {
        DoDoLineHome2Data_T = T_DoLineHome2.GetComponent<ObjData>();
        DoLineHome2Outline_T = T_DoLineHome2.GetComponent<Outline>();
    }*/

    void Update()
    {
        // ������ ���� �ı��ϱ��ư, ���� ��ư ������ �ִ´�. 
        ChangeButton(smashButtonTroubleLine2, biteButtonTroubleLine2);
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
        smashButtonTroubleLine2.transform.gameObject.SetActive(false);
        biteButtonTroubleLine2.transform.gameObject.SetActive(false);
        barkButtonTroubleLine2.transform.gameObject.SetActive(false);
        sniffButtonTroubleLine2.transform.gameObject.SetActive(false);
        pushOrPressButtonTroubleLine2.transform.gameObject.SetActive(false);
        centerButton1_TroubleLine2.transform.gameObject.SetActive(false);

        if (centerDisableButton1_TroubleLine2 != null)
        {
            centerDisableButton1_TroubleLine2.transform.gameObject.SetActive(false);
        }
        if (centerDisableButton2_TroubleLine2 != null)
        {
            centerDisableButton2_TroubleLine2.transform.gameObject.SetActive(false);
        }
        if (centerButton2_TroubleLine2 != null)
        {
            centerButton2_TroubleLine2.transform.gameObject.SetActive(false);
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
        Invoke("DelayBiteAnim", 1f);
    }

    void DelayBiteAnim()
    {
        InteractionButtonController.interactionButtonController.PlayerBite();

        GameManager.gameManager._gameData.IsOutTroubleLine2_T_C2 = true;

/*        DoDoLineHome2Data_T.IsNotInteractable = false; // ��ȣ�ۿ� �����ϰ�
        DoLineHome2Outline_T.OutlineWidth = 8; // �ƿ����ε� ���ݴϴ�.*/
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
