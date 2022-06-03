using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_Pack : MonoBehaviour, IInteraction
{
    /*�����ִ� ������Ʈ*/
    public GameObject M_canCardKey;

    /*������Ʈ�� ��ȣ�ۿ� ��ư��*/
    private Button barkButton_M_Pack, sniffButton_M_Pack, 
        biteButton_M_Pack, pressButton_M_Pack, noCenterButton_M_Pack, smashButton_M_Pack;

    ObjData packObjData_M;
    public ObjectData packData_M;

    public GameObject dialog_CS;
    DialogManager dialogManager;

    PortableObjectData workRoomData;
   

    void Start()
    {
        workRoomData = BaseCanvas._baseCanvas.workRoomData;
        dialogManager = dialog_CS.GetComponent<DialogManager>();

        packObjData_M = GetComponent<ObjData>();


        barkButton_M_Pack = packObjData_M.BarkButton;
        barkButton_M_Pack.onClick.AddListener(OnBark);

        sniffButton_M_Pack = packObjData_M.SniffButton;
        sniffButton_M_Pack.onClick.AddListener(OnSniff);

        biteButton_M_Pack = packObjData_M.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_M_Pack = packObjData_M.PushOrPressButton;
        pressButton_M_Pack.onClick.AddListener(OnPushOrPress);

        noCenterButton_M_Pack = packObjData_M.CenterButton1;

        smashButton_M_Pack = packObjData_M.SmashButton;
        smashButton_M_Pack.onClick.AddListener(OnSmash);
    }

    void Update()
    {
        if(packData_M.IsClicked)
        {
            //B-5 ��� ��� �١١١١١١١١١١١١١١١١١١١١�
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(24));
        }

    }

    void DisableButton()
    {
        barkButton_M_Pack.transform.gameObject.SetActive(false);
        sniffButton_M_Pack.transform.gameObject.SetActive(false);
        biteButton_M_Pack.transform.gameObject.SetActive(false);
        pressButton_M_Pack.transform.gameObject.SetActive(false);
        smashButton_M_Pack.transform.gameObject.SetActive(false);
        noCenterButton_M_Pack.transform.gameObject.SetActive(false);
    }
    public void OnBark()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }


    public void OnPushOrPress()
    {

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();
    }


    public void OnSniff()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnSmash()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.PlayerSmash1();

        StartCoroutine(canLookCardKey1());
        //StartCoroutine(canLookCardKey2());

        //Invoke(" canLookCardKey", 2f); // �κ�ũ �Լ� �� �� �� ��...

        /* ������Ʈ ���� �ִϸ��̼� ���� */
        InteractionButtonController.interactionButtonController.PlayerSmash2();

    }

    IEnumerator canLookCardKey1()
    {
        yield return new WaitForSeconds(3f);

        //Destroy(gameObject, 0f);

        this.GetComponent<Rigidbody>().isKinematic = true;
        this.transform.parent = null;

        //��ġ ����: ������ �� ��ġ ���� ī��Ű ��ġ �����ϱ� ī��Ű�� ���� �ξ��ϱ� ������
        gameObject.transform.position = new Vector3(transform.position.x, 1.5412f, transform.position.z);

        packData_M.IsBite = false;

        M_canCardKey.SetActive(true);
        M_canCardKey.transform.position = gameObject.transform.position;

        /*ī��Ű ã�� ���� �Ϸ�*//*
        GameManager.gameManager._gameData.IsCompleteFindEngineKey = true;
        GameManager.gameManager._gameData.ActiveMissionList[3] = false;
        MissionGenerator.missionGenerator.ActivateMissionList();
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");*/

        // ������ ī���� ������������ �����Ƿ� üũ����
        workRoomData.IsObjectActiveList[31] = false;
        //����Ű�� üũȰ��ȭ
        workRoomData.IsObjectActiveList[32] = true;

        gameObject.SetActive(false);



        // ������ ī��Ű ã�� �ӹ�����Ʈ �� ����������������������������������������������������������������������

    }


    /*    IEnumerator canLookCardKey2()
        {
            yield return new WaitForSeconds(3f);

            M_canCardKey.SetActive(true);
            M_canCardKey.transform.position = gameObject.transform.position;
        }*/

    /*    void canLookCardKey()
        {
            M_canCardKey.SetActive(true);
            M_canCardKey.transform.position = gameObject.transform.position;
            GameManager.gameManager._gameData.IsDestroyPack_M_C2 = true;   

        }*/

    public void OnUp()
    {
        
    }

    public void OnBite()
    {

    }

    public void OnEat()
    {

    }

    public void OnInsert()
    {

    }

    public void OnObserve()
    {

    }

}
