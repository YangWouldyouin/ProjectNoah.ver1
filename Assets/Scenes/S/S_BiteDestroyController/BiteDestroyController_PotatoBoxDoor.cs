using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/* Ŭ���� �̸� ��ũ��Ʈ �̸��̶� �Ȱ���
BiteDestroyController + ������Ʈ �̸����� �ٲ۴�. */

public class BiteDestroyController_PotatoBoxDoor : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{

    /*�����ִ� ������Ʈ*/
    public GameObject T_PotatoBoxDoor;
    public GameObject T_PotatoBoxBody;

    public ObjectData DoPotatoBoxDoorData_T;
    public ObjectData DoPotatoBoxBodyData_T;


    Outline DoPotatoBoxDoorOutline_T;
    Outline DoPotatoBoxBodyOutline_T;

    BoxCollider PotatoBoxDoorCollider_T;

    /* ��ȣ�ۿ� ��ư ���� */
    // �̸� ���� ��Ģ : biteButton + ������Ʈ �̸�
    public Button biteButtonPotatoBoxDoor, smashButtonPotatoBoxDoor, 
        barkButtonPotatoBoxDoor, sniffButtonPotatoBoxDoorr, pushOrPressButtonPotatoBoxDoor;
    [Header("�߰� ��ȣ�ۿ� ��ư")]
    public Button centerButton1_PotatoBoxDoor;
    public Button centerDisableButton1_PotatoBoxDoor;
    public Button centerButton2_PotatoBoxDoor;
    public Button centerDisableButton2_PotatoBoxDoor;

    // ���⼭���� �Ʒ����� ����

    /* ���� ��ư�� ��� ������ ������ �ı��ϱ� ��ư���� �ٲٱ� ���� ���� */
    // Private ������ �̸� �״�� �ᵵ��

    // ���� ��ư�� ���ȴ��� üũ
    private bool isPointerDown = false;
    // �󸶳� ���� ������ �־�� �ϴ���
    private float requiredChangeTime = 0.5f;
    // ������ �ִ� �ð� ��� ���� ���� 
    private float pointerDownTimer = 0;

    void Start()
    {
        DoPotatoBoxDoorOutline_T = T_PotatoBoxDoor.GetComponent<Outline>();
        DoPotatoBoxBodyOutline_T = T_PotatoBoxBody.GetComponent<Outline>();
        PotatoBoxDoorCollider_T = T_PotatoBoxDoor.GetComponent<BoxCollider>();
    }

    void Update()
    {
        // ������ ���� �ı��ϱ��ư, ���� ��ư ������ �ִ´�. 
        ChangeButton(smashButtonPotatoBoxDoor, biteButtonPotatoBoxDoor);
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
        smashButtonPotatoBoxDoor.transform.gameObject.SetActive(false);
        biteButtonPotatoBoxDoor.transform.gameObject.SetActive(false);
        barkButtonPotatoBoxDoor.transform.gameObject.SetActive(false);
        sniffButtonPotatoBoxDoorr.transform.gameObject.SetActive(false);
        pushOrPressButtonPotatoBoxDoor.transform.gameObject.SetActive(false);
        centerButton1_PotatoBoxDoor.transform.gameObject.SetActive(false);

        if (centerDisableButton1_PotatoBoxDoor != null)
        {
            centerDisableButton1_PotatoBoxDoor.transform.gameObject.SetActive(false);
        }
        if (centerDisableButton2_PotatoBoxDoor != null)
        {
            centerDisableButton2_PotatoBoxDoor.transform.gameObject.SetActive(false);
        }
        if (centerButton2_PotatoBoxDoor != null)
        {
            centerButton2_PotatoBoxDoor.transform.gameObject.SetActive(false);
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
        //CameraController.cameraController.CancelObserve();
        // ( ex. ���� ��� : ���� �����ϱ⸦ ����ϸ� �ɾҴ� �Ͼ�� �ִϸ��̼��� �־ 
        // 1.5�� ���� �����̸� �־�� �� )

        // 1.5�� �� ���� �ִϸ��̼� + IsBite ���� ������ �ٲ�
        Invoke("DelayBiteAnim", 1f);

        Invoke("PotatoBoxDoorOpen", 1.7f);
    }

    void DelayBiteAnim()
    {
        InteractionButtonController.interactionButtonController.PlayerBite();
    }

    void PotatoBoxDoorOpen()
    {
        // �θ� �ڽ� ���踦 �����Ѵ�.
        T_PotatoBoxDoor.GetComponent<Rigidbody>().isKinematic = false;
        T_PotatoBoxDoor.transform.parent = null;

        // �ش� ��ġ, ����, ũ��� �ٲٰڴ�.
        T_PotatoBoxDoor.transform.position = new Vector3(-267.07f, 0.0562f, 671.847f); //��ġ ����
        T_PotatoBoxDoor.transform.rotation = Quaternion.Euler(182.235f, -89.98401f, 180f); //���� ����
        T_PotatoBoxDoor.transform.localScale = new Vector3(57.88517f, 4.21771f, 56.0183f); // ũ�� ����

        // ���� �� �̻� ��ȣ�ۿ� �Ұ�
        DoPotatoBoxDoorData_T.IsNotInteractable = true;
        DoPotatoBoxDoorOutline_T.OutlineWidth = 0;

        Debug.Log("���� ��ȣ�ۿ� �����ؿ�");
        // ��ü�� ��ȣ�ۿ� ����
        DoPotatoBoxBodyData_T.IsNotInteractable = false;
        DoPotatoBoxBodyOutline_T.OutlineWidth = 8;

        //�ݶ��̴��� ����.
        PotatoBoxDoorCollider_T.enabled = false;
        //GameManager.gameManager._gameData.IsIronDisappear_T_C2 = true;
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

