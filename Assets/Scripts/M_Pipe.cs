using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_Pipe : MonoBehaviour, IInteraction
{
    [SerializeField] ObjectData pipeData;

    private Button barkButton_M_Pipe, biteButton_M_Pipe, smashButton_M_Pipe, 
        pressButton_M_Pipe, sniffButton_M_Pipe, noCenterButton_M_Pipe;

    private ObjData pipeData_M;


    void Start()
    {
        pipeData_M = GetComponent<ObjData>();
        
        /* �� ��ȣ�ۿ� ��ư�� �Լ��� �ִ´� */
        barkButton_M_Pipe = pipeData_M.BarkButton;
        barkButton_M_Pipe.onClick.AddListener(OnBark);

        biteButton_M_Pipe = pipeData_M.BiteButton;
        biteButton_M_Pipe.onClick.AddListener(OnBite);

        smashButton_M_Pipe = pipeData_M.SmashButton;
        smashButton_M_Pipe.onClick.AddListener(OnSmash);

        sniffButton_M_Pipe = pipeData_M.SniffButton;
        sniffButton_M_Pipe.onClick.AddListener(OnSniff);

        pressButton_M_Pipe = pipeData_M.PushOrPressButton;
        pressButton_M_Pipe.onClick.AddListener(OnPushOrPress);

        noCenterButton_M_Pipe = pipeData_M.CenterButton1;
    }

    /* ��ȣ�ۿ� ��ư ���� �Լ� */
    void DiableButton()
    {
        biteButton_M_Pipe.transform.gameObject.SetActive(false);
        smashButton_M_Pipe.transform.gameObject.SetActive(false);
        barkButton_M_Pipe.transform.gameObject.SetActive(false);
        pressButton_M_Pipe.transform.gameObject.SetActive(false);
        sniffButton_M_Pipe.transform.gameObject.SetActive(false);
        noCenterButton_M_Pipe.transform.gameObject.SetActive(false);
    }

    public void OnBite()
    {
        // ��¥ "����" �� �Ǵ� ������Ʈ�� �����
    }


    public void OnSmash()
    {
        /* ������Ʈ�� ¢�� ���� true�� �ٲ� */
        pipeData.IsSmash = true;
        /* ��ȣ�ۿ� ��ư�� �� */
        DiableButton();

        /* ������Ʈ ���� �ִϸ��̼� ����*/
        InteractionButtonController.interactionButtonController.PlayerSmash1();

        /* �ı��ϱ� ���� ���� (2�� ������ �ִϸ��̼��� �ڿ�������) */
        Invoke(" SmashInteraction", 2f);

        /* ������Ʈ ���� �ִϸ��̼� ���� */
        InteractionButtonController.interactionButtonController.PlayerSmash2();
    }

    void SmashInteraction()
    {
        // �θ� ��Ȱ��ȭ, �ڽ� Ȱ��ȭ ��� �� ������Ʈ�� ���缭 �ʿ��� �͵� ����
    }

    public void OnBark()
    {

        /* ������Ʈ�� ¢�� ���� true�� �ٲ� */
        pipeData.IsBark = true;

        /* ��ȣ�ۿ� ��ư�� �� */
        DiableButton();
        /* �ִϸ��̼� ������ */
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnSniff()
    {
        /* ������Ʈ�� �����ñ� ���� true�� �ٲ� */
        pipeData.IsSniff = true;
        /* ��ȣ�ۿ� ��ư�� �� */
        DiableButton();
        /* �ִϸ��̼� �����ְ� ���� �ؽ�Ʈ ��� */
        InteractionButtonController.interactionButtonController.playerSniff();

        /* �ӹ� ����Ʈ�� "AI �����" �̼� �߰� */
        GameManager.gameManager._gameData.ActiveMissionList[3] = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        MissionGenerator.missionGenerator.IsOn = false;
        MissionGenerator.missionGenerator.ShowMissionList();
    }

    public void OnPushOrPress()
    {
        /* ������Ʈ�� ������ ���� true�� �ٲ� */
        pipeData.IsPushOrPress = true;

        /* ��ȣ�ۿ� ��ư�� �� */
        DiableButton();

        /* �ִϸ��̼� ������ */
        InteractionButtonController.interactionButtonController.playerPressHand(); // ������ ������ �ִϸ��̼�

        /* 2�� �ڿ� Ispushorpress �� false �� �ٲ� */
        StartCoroutine(ChangePressFalse());

        /* �ӹ� ����Ʈ�� "AI �����" �̼� �߰� */
        GameManager.gameManager._gameData.ActiveMissionList[1] = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        MissionGenerator.missionGenerator.IsOn = false;
        MissionGenerator.missionGenerator.ShowMissionList();
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        pipeData.IsPushOrPress = false;
    }
    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    public void OnEat()
    {
        throw new System.NotImplementedException();
    }

    public void OnObserve()
    {
        throw new System.NotImplementedException();
    }

    public void OnUp()
    {
        throw new System.NotImplementedException();
    }

    public void OnInsert()
    {
        throw new System.NotImplementedException();
    }
}
