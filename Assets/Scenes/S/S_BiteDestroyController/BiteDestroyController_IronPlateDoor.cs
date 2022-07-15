using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/* Ŭ���� �̸� ��ũ��Ʈ �̸��̶� �Ȱ���
BiteDestroyController + ������Ʈ �̸����� �ٲ۴�. */

public class BiteDestroyController_IronPlateDoor : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{

    /*�����ִ� ������Ʈ*/
    public GameObject T_DoIronPlateDoor;

    public ObjectData DoIronPlateDoorData_T;

    Outline DoIronPlateDoorOutline_T;

    BoxCollider ironPlateCollider_T;

    /* ��ȣ�ۿ� ��ư ���� */
    // �̸� ���� ��Ģ : biteButton + ������Ʈ �̸�
    public Button biteButtonIronPlateDoor, smashButtonIronPlateDoor, 
        barkButtonIronPlateDoor, sniffButtonIronPlateDoor, pushOrPressButtonIronPlateDoor;
    [Header("�߰� ��ȣ�ۿ� ��ư")]
    public Button centerButton1_IronPlateDoor;
    public Button centerDisableButton1_IronPlateDoor;
    public Button centerButton2_IronPlateDoor;
    public Button centerDisableButton2_IronPlateDoor;

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
        DoIronPlateDoorOutline_T = T_DoIronPlateDoor.GetComponent<Outline>();
        ironPlateCollider_T = T_DoIronPlateDoor.GetComponent<BoxCollider>();
    }

    void Update()
    {
        // ������ ���� �ı��ϱ��ư, ���� ��ư ������ �ִ´�. 
        ChangeButton(smashButtonIronPlateDoor, biteButtonIronPlateDoor);
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
        smashButtonIronPlateDoor.transform.gameObject.SetActive(false);
        biteButtonIronPlateDoor.transform.gameObject.SetActive(false);
        barkButtonIronPlateDoor.transform.gameObject.SetActive(false);
        sniffButtonIronPlateDoor.transform.gameObject.SetActive(false);
        pushOrPressButtonIronPlateDoor.transform.gameObject.SetActive(false);
        centerButton1_IronPlateDoor.transform.gameObject.SetActive(false);

        if (centerDisableButton1_IronPlateDoor != null)
        {
            centerDisableButton1_IronPlateDoor.transform.gameObject.SetActive(false);
        }
        if (centerDisableButton2_IronPlateDoor != null)
        {
            centerDisableButton2_IronPlateDoor.transform.gameObject.SetActive(false);
        }
        if (centerButton2_IronPlateDoor != null)
        {
            centerButton2_IronPlateDoor.transform.gameObject.SetActive(false);
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
        //Invoke("DelayBiteAnim", 1f);

        Invoke("IronPlateOpen", 1.7f);
    }

    void DelayBiteAnim()
    {
        InteractionButtonController.interactionButtonController.PlayerBite();
    }

    void IronPlateOpen()
    {
        DoIronPlateDoorData_T.IsBite = false;

        // �θ� �ڽ� ���踦 �����Ѵ�.
        T_DoIronPlateDoor.GetComponent<Rigidbody>().isKinematic = false;
        T_DoIronPlateDoor.transform.parent = null;

        // �ش� ��ġ, ����, ũ��� �ٲٰڴ�.
        T_DoIronPlateDoor.transform.position = new Vector3(-258.15f, 0.2092f, 670.1605f); //��ġ ����
        T_DoIronPlateDoor.transform.rotation = Quaternion.Euler(7.034f, 90, 90); //���� ����
        T_DoIronPlateDoor.transform.localScale = new Vector3(-2.882732f, -115.34f, -93.69196f); // ũ�� ����

        // ���� �� �̻� ��ȣ�ۿ� �Ұ�
        DoIronPlateDoorData_T.IsNotInteractable = true;
        DoIronPlateDoorOutline_T.OutlineWidth = 0;

        //�ݶ��̴��� ����.
        ironPlateCollider_T.enabled = false;
        GameManager.gameManager._gameData.IsIronDisappear_T_C2 = true;
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

