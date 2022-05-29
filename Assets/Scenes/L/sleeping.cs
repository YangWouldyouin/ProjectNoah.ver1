using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sleeping : MonoBehaviour, IInteraction
{
    private Button barkButton, sniffButton, biteButton, pressButton, sleepButton;

    public GameObject Bed;
    public ObjectData BedData;
    ObjData BedData_obj;

    public Transform bedPos;
    public Vector3 bedRisePos;

    public GameObject cancelInteractions;
    CancelInteractions cancelInteract;

    void Start()
    {

        BedData_obj = Bed.GetComponent<ObjData>();

        barkButton = BedData_obj.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = BedData_obj.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = BedData_obj.BiteButton;
        biteButton.onClick.AddListener(OnBite);

        pressButton = BedData_obj.PushOrPressButton;
        pressButton.onClick.AddListener(OnPushOrPress);

        // ��Ȱ��ȭ ��ư�� ��ư�� �������⸸ �Ѵ�. 
        sleepButton = BedData_obj.CenterButton1;
        sleepButton.onClick.AddListener(OnUp);
        cancelInteract = cancelInteractions.GetComponent<CancelInteractions>();

    }


    public void DisableButton()
    {
        // ��Ȱ��ȭ ��ư���� �����Ͽ� ������ ���� ��� ��ư ������ ����.

        // ex. ������ ��ư, ��� ��ư�� ������ ��ư�ε� ó���� ��Ȱ��ȭ
        barkButton.transform.gameObject.SetActive(false);
        sniffButton.transform.gameObject.SetActive(false);
        biteButton.transform.gameObject.SetActive(false);
        pressButton.transform.gameObject.SetActive(false);
        sleepButton.transform.gameObject.SetActive(false);
    }



    public void OnBark()
    {
        DisableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnBite()
    {
        DisableButton();
    }


    public void OnPushOrPress()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHead();
    }


    public void OnSniff()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnUp()
    {
        DisableButton();
        if (cancelInteract!=null)
        {
            cancelInteract.enabled = false;
        }


        if (!BedData.IsUpDown)
        {
            PlayerScripts.playerscripts.currentUpObj = this.gameObject;
            BedData.IsUpDown = true;

            bedRisePos.x = bedPos.position.x;
            bedRisePos.z = bedPos.position.z;
            bedRisePos.y = bedPos.position.y;

            /* ������ �ִϸ��̼� 1/2 ���� */
            InteractionButtonController.interactionButtonController.PlayerRise1();
            /* ������ ��ġ ��ǥ�� ���� */
            InteractionButtonController.interactionButtonController.risePosition = bedRisePos;
            /* ������ ������ �ִϸ��̼� ���� */
            InteractionButtonController.interactionButtonController.PlayerRise2();
            //�ڱ� �ִϸ��̼�
            InteractionButtonController.interactionButtonController.PlayerSleep();
            //�Ͼ�� �ִϸ��̼�
            //Invoke("WakeUp", 4f);
            StartCoroutine(StopCancel());
            NoahStatController.noahStatController.IncreaseStatBar();


        }
    }

    public void WakeUp()
    {


    }

    IEnumerator StopCancel()
    {
        yield return new WaitForSeconds(11.5f);
        InteractionButtonController.interactionButtonController.WakeUp();
        yield return new WaitForSeconds(3f);
        InteractionButtonController.interactionButtonController.PlayerFall1();
        yield return new WaitForSeconds(3f);
        cancelInteract.enabled = true;
    }
    void IInteraction.OnSmash()
    {
        throw new System.NotImplementedException();
    }

    void IInteraction.OnEat()
    {
        throw new System.NotImplementedException();
    }

    void IInteraction.OnObserve()
    {
        throw new System.NotImplementedException();
    }

    void IInteraction.OnInsert()
    {
        throw new System.NotImplementedException();
    }
}
