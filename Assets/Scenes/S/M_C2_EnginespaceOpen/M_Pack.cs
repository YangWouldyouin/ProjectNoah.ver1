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
    public ObjectData EngineKeyData_M;

    public GameObject dialog_CS;
    DialogManager dialogManager;

    PortableObjectData workRoomData;

    public bool One_Speack3 = false;

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
        if(packData_M.IsClicked && One_Speack3 == false)
        {
            //B-5 ��� ��� �١١١١١١١١١١١١١١١١١١١١�
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(24));
            One_Speack3 = true;
        }

        if(packData_M.IsSmash)
        {
            EngineKeyData_M.IsNotInteractable = false;
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

        InteractionButtonController.interactionButtonController.PlayerCanNotPush();
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

        //StartCoroutine(canLookCardKey1());
        //StartCoroutine(canLookCardKey2());

        Invoke("canLookCardKey", 3f); // �κ�ũ �Լ� �� �� �� ��...

        /* ������Ʈ ���� �ִϸ��̼� ���� */
        InteractionButtonController.interactionButtonController.PlayerSmash2();

        GameManager.gameManager._gameData.IsCompleteFindEngineKey = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        // �̼��� �߰��Ǿ��ִ��� Ȯ�� �� ����
        GameData mission2Data = SaveSystem.Load("save_001");
        if (mission2Data.ActiveMissionList[3])
        {
            MissionGenerator.missionGenerator.DeleteNewMission(3);
        }
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
        M_canCardKey.transform.position = new Vector3(transform.position.x, 0.08f, transform.position.z);
        EngineKeyData_M.IsNotInteractable = false;

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

    void canLookCardKey()
    {
        this.GetComponent<Rigidbody>().isKinematic = true;
        this.transform.parent = null;

        //��ġ ����: ������ �� ��ġ ���� ī��Ű ��ġ �����ϱ� ī��Ű�� ���� �ξ��ϱ� ������
        gameObject.transform.position = new Vector3(transform.position.x, 1.5412f, transform.position.z);
        packData_M.IsBite = false;
        M_canCardKey.SetActive(true);

        // �ϴ� ����Կ� �ֱ�

        //M_canCardKey.transform.position = new Vector3(transform.position.x, 0.08f, transform.position.z);
        //M_canCardKey.transform.eulerAngles = new Vector3(90, 0, 0);
        PlayerEquipment equipment = BaseCanvas._baseCanvas.equipment;
        equipment.biteObjectName = M_canCardKey.name;
        equipment.cancelBiteRot = new Vector3(90, 0, 0);
        equipment.cancelBiteScale = M_canCardKey.transform.localScale;
        ObjectData cardData = M_canCardKey.GetComponent<ObjData>().objectDATA;
        cardData.IsBite = true;


        M_canCardKey.GetComponent<Rigidbody>().isKinematic = true;   //makes the rigidbody not be acted upon by forces
        M_canCardKey.GetComponent<Rigidbody>().useGravity = false;

        GameObject myMouth = BaseCanvas._baseCanvas.myMouth;

        M_canCardKey.transform.SetParent(myMouth.transform, true);

        M_canCardKey.transform.localPosition = new Vector3(-0.072f, -0.012f, -0.003f);
        M_canCardKey.transform.localEulerAngles = new Vector3(-101.002f, 42.158f, -47.048f);

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
