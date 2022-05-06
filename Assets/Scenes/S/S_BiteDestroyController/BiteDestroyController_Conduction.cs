using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/* Ŭ���� �̸� ��ũ��Ʈ �̸��̶� �Ȱ���
BiteDestroyController + ������Ʈ �̸����� �ٲ۴�. */

public class BiteDestroyController_Conduction : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public ObjectData biteRubberData_M;
    public ObjectData biteConductionData_M;

    /* ��ȣ�ۿ� ��ư ���� */
    // �̸� ���� ��Ģ : biteButton + ������Ʈ �̸�
    public Button biteButtonConduction, smashButtonConduction, barkButtonConduction, sniffButtonConduction, pushOrPressButtonConduction;
    [Header("�߰� ��ȣ�ۿ� ��ư")]
    public Button centerButton1_Conduction;
    public Button centerDisableButton1_Conduction;
    public Button centerButton2_Conduction;
    public Button centerDisableButton2_Conduction;

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
        ChangeButton(smashButtonConduction, biteButtonConduction);
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
        smashButtonConduction.transform.gameObject.SetActive(false);
        biteButtonConduction.transform.gameObject.SetActive(false);
        barkButtonConduction.transform.gameObject.SetActive(false);
        sniffButtonConduction.transform.gameObject.SetActive(false);
        pushOrPressButtonConduction.transform.gameObject.SetActive(false);
        centerButton1_Conduction.transform.gameObject.SetActive(false);

        if (centerDisableButton1_Conduction != null)
        {
            centerDisableButton1_Conduction.transform.gameObject.SetActive(false);
        }
        if (centerDisableButton2_Conduction != null)
        {
            centerDisableButton2_Conduction.transform.gameObject.SetActive(false);
        }
        if (centerButton2_Conduction != null)
        {
            centerButton2_Conduction.transform.gameObject.SetActive(false);
        }
    }

    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@



    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    /* ���� �Լ� */
    /* ����) ó������ �׳� ���⸸ �ϴٰ� Ư�� ���� �����ϸ� ���� + �ٸ� �ൿ�� �� �� */
    public void OnPointerDown(PointerEventData eventData)
    {
        // ���� ��ư�� ������
        isPointerDown = true;

        if (biteRubberData_M.IsBite /*&& biteConductionData_M.IsBite*/)
        {
            Debug.Log("�����մϴ�.");
            InteractionButtonController.interactionButtonController.PlayerBite();
        }

        else /*if (biteConductionData_M.IsBite)*/
        {
            Debug.Log("��������");
            InteractionButtonController.interactionButtonController.PlayerBite();
        }


/*        if (boxData.IsUpDown) // Ư�� ������ �����ϸ�
        {
            // ������ ���� ��ȣ�ۿ���� ���´�.
            CameraController.cameraController.CancelObserve();

            // 1.5�� �� ���� �ִϸ��̼� + IsBite ���� ������ �ٲ�
            Invoke("DelayBiteAnim", 1.5f);
        }
        else // ��ҿ��� 
        {
            // ���� �ִϸ��̼� + IsBite ���� ������ �ٲ�
            InteractionButtonController.interactionButtonController.PlayerBite();
        }*/
    

/*    void DelayBiteAnim()
    {
        InteractionButtonController.interactionButtonController.PlayerBite();
    }*/

    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
}
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