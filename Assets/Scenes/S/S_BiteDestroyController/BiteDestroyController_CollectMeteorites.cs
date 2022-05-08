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
    public GameObject canMeteorCollectMachine;

    public ObjectData canMeteorCollectMachineData;
    public ObjectData canNormalMeteor1Data;
    public ObjectData canImportantMeteorData;

    public GameObject canNormalMeteor1;
    public GameObject canImportantMeteor;

    /*Animator*/
    public Animator meteorBoxAnim;

    /*Collider*/
    BoxCollider IsNormalMeteor1Collider;
    BoxCollider IsImportantMeteorCollider;

    /*Outline*/
    Outline canMeteorCollectMachineOutline;

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


    void Start()
    {
        /*Collider*/
        IsNormalMeteor1Collider = canNormalMeteor1.GetComponent<BoxCollider>();
        IsImportantMeteorCollider = canImportantMeteor.GetComponent<BoxCollider>();

        canMeteorCollectMachineOutline = canMeteorCollectMachine.GetComponent<Outline>();
    }

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
        canNormalMeteor1Data.IsBite = true;

        // ������ ���� ��ȣ�ۿ���� ���´�.
         CameraController.cameraController.CancelObserve();
        // ( ex. ���� ��� : ���� �����ϱ⸦ ����ϸ� �ɾҴ� �Ͼ�� �ִϸ��̼��� �־ 
        // 1.5�� ���� �����̸� �־�� �� )

        // 1.5�� �� ���� �ִϸ��̼� + IsBite ���� ������ �ٲ�
        //Invoke("DelayBiteAnim", 1.1f);
        StartCoroutine(Hello());

        // 2�� �� ���� �ִϸ��̼� + IsBite ���� ������ �ٲ�
        //Invoke("DoorClose", 1.1f);


    }

    IEnumerator Hello()
    {

        yield return new WaitForSeconds(2f);
        Debug.Log("���� �;��");
        InteractionButtonController.interactionButtonController.PlayerBite();

        //C-3 ��� ��� �١١١١١١١١١١١١١١١١١١١١�

    }

    void DelayBiteAnim()
    {
        Debug.Log("���� �;��");
        InteractionButtonController.interactionButtonController.PlayerBite();
    }

    void DoorClose()
    {
        meteorBoxAnim.SetBool("isMeteorBoxOpen", false);
        meteorBoxAnim.SetBool("isMeteorBoxOpenEnd", false);
        meteorBoxAnim.SetBool("isMeteorBoxClose", true);
        meteorBoxAnim.SetBool("isMeteorBoxCloseEnd", true);

        canMeteorCollectMachineData.IsNotInteractable = true; // ��ȣ�ۿ� �Ұ����ϰ�
        canMeteorCollectMachineOutline.OutlineWidth = 0;

        IsNormalMeteor1Collider.enabled = false; //��� ��ȣ�ۿ� �Ұ����ϰ�
        IsImportantMeteorCollider.enabled = false;

        GameManager.gameManager._gameData.IsMeteorCollectOpen = false;
        GameManager.gameManager._gameData.IsMeteorCollectClose = true;

        //meteorCollectanimOpen_T = false; // �ٽ� �ݺ��� �� �ְ�
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