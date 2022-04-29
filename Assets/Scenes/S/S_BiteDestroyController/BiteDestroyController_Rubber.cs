using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/* Ŭ���� �̸� ��ũ��Ʈ �̸��̶� �Ȱ���
BiteDestroyController + ������Ʈ �̸����� �ٲ۴�. */

public class BiteDestroyController_Rubber : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    /*�����ִ� ������Ʈ*/
    public GameObject M_canCabinetBody;

    ObjData canCabinetBodyData_M;

    /* ��ȣ�ۿ� ��ư ���� */
    // �̸� ���� ��Ģ : biteButton + ������Ʈ �̸�
    public Button biteButtonRubber, smashButtonRubber, barkButtonRubber, sniffButtonRubber, pushOrPressButtonRubber;
    [Header("�߰� ��ȣ�ۿ� ��ư")]
    public Button centerButton1_Rubber;
    public Button centerDisableButton1_Rubber;
    public Button centerButton2_Rubber;
    public Button centerDisableButton2_Rubber;

    // ���⼭���� �Ʒ����� ����

    /* ���� ��ư�� ��� ������ ������ �ı��ϱ� ��ư���� �ٲٱ� ���� ���� */
    // Private ������ �̸� �״�� �ᵵ��

    // ���� ��ư�� ���ȴ��� üũ
    private bool isPointerDown = false;
    // �󸶳� ���� ������ �־�� �ϴ���
    private float requiredChangeTime = 0.5f;
    // ������ �ִ� �ð� ��� ���� ���� 
    private float pointerDownTimer = 0;

    void start()
    {
        canCabinetBodyData_M = M_canCabinetBody.GetComponent<ObjData>();
    }

    void Update()
    {
        // ������ ���� �ı��ϱ��ư, ���� ��ư ������ �ִ´�. 
        ChangeButton(smashButtonRubber, biteButtonRubber);
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
        smashButtonRubber.transform.gameObject.SetActive(false);
        biteButtonRubber.transform.gameObject.SetActive(false);
        barkButtonRubber.transform.gameObject.SetActive(false);
        sniffButtonRubber.transform.gameObject.SetActive(false);
        pushOrPressButtonRubber.transform.gameObject.SetActive(false);
        centerButton1_Rubber.transform.gameObject.SetActive(false);

        if (centerDisableButton1_Rubber != null)
        {
            centerDisableButton1_Rubber.transform.gameObject.SetActive(false);
        }
        if (centerDisableButton2_Rubber != null)
        {
            centerDisableButton2_Rubber.transform.gameObject.SetActive(false);
        }
        if (centerButton2_Rubber != null)
        {
            centerButton2_Rubber.transform.gameObject.SetActive(false);
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
        //canCabinetBodyData_M.IsObserve = false;
        //InteractionButtonController.interactionButtonController.PlayerCanNotBite();
        // ( ex. ���� ��� : ���� �����ϱ⸦ ����ϸ� �ɾҴ� �Ͼ�� �ִϸ��̼��� �־ 
        // 1.5�� ���� �����̸� �־�� �� )

        // 1.5�� �� ���� �ִϸ��̼� + IsBite ���� ������ �ٲ�
        Invoke("DelayBiteAnim", 1f);
    }

    void DelayBiteAnim()
    {
        InteractionButtonController.interactionButtonController.PlayerBite();
    }


    /* ���� ��ư Ŭ�� �� ����*/
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
