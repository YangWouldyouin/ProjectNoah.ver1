using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_InsertCabinetDoor1 : MonoBehaviour,IInteraction
{
    public bool IsInsertCabinetDoorOpen = false;

    /*�����ִ� ������Ʈ��*/
    //public GameObject S_IsInsertAreaClicked;
    public Image S_stopMoving;
    public Button S_InsertAreaButton;
    private Camera mainCamera;
    public GameObject S_InsertAreaButtonPos;

    private Button barkButton_S_InsertCabinetDoor1, sniffButton_S_InsertCabinetDoor1, biteButton_S_InsertCabinetDoor1,
        pressButton_S_InsertCabinetDoor1, insertButton_S_InsertCabinetDoor1, insertDisableButton_S_InsertCabinetDoor1;

    ObjData insertCabinetDoor1Data_S;
    public ObjectData canInsertCabinetDoor1Data_S;
    public ObjectData canInsertCabinetBody1Data_S;
    public ObjectData PipeForInsertData_S;

    /*�ƿ�����*/
    public Outline canInsertCabinetBody1Outline_S;
    Outline insertCabinetDoor1Outline_S;

    /*�ִϸ��̼�*/
    public Animator canInsertCabinetDoor1Anim;
    public Animator noahAnim_S;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        Vector3 screenPos = mainCamera.WorldToScreenPoint(new Vector3(S_InsertAreaButtonPos.transform.localPosition.x, S_InsertAreaButtonPos.transform.localPosition.y,
   S_InsertAreaButtonPos.transform.localPosition.z));
        S_InsertAreaButton.transform.position = new Vector3(screenPos.x, screenPos.y, transform.position.z);

        /*�����ִ� ������Ʈ*/
        insertCabinetDoor1Data_S = GetComponent<ObjData>();

        barkButton_S_InsertCabinetDoor1 = insertCabinetDoor1Data_S.BarkButton;
        barkButton_S_InsertCabinetDoor1.onClick.AddListener(OnBark);

        sniffButton_S_InsertCabinetDoor1 = insertCabinetDoor1Data_S.SniffButton;
        sniffButton_S_InsertCabinetDoor1.onClick.AddListener(OnSniff);

        biteButton_S_InsertCabinetDoor1 = insertCabinetDoor1Data_S.BiteButton;
        biteButton_S_InsertCabinetDoor1.onClick.AddListener(OnBite);

/*        smashButton_M_MiniCabinetDoor = miniCabinetDoorData_M.SmashButton;
        //biteButton_M_MiniCabinetDoor.onClick.AddListener(OnBite);*/

        pressButton_S_InsertCabinetDoor1 = insertCabinetDoor1Data_S.PushOrPressButton;
        pressButton_S_InsertCabinetDoor1.onClick.AddListener(OnPushOrPress);

        insertButton_S_InsertCabinetDoor1 = insertCabinetDoor1Data_S.CenterButton2;
        insertButton_S_InsertCabinetDoor1.onClick.AddListener(OnInsert);

        insertDisableButton_S_InsertCabinetDoor1 = insertCabinetDoor1Data_S.CenterButton1;

        /*�ƿ�����*/
        insertCabinetDoor1Outline_S = GetComponent<Outline>();
    }

    void DisableButton()
    {
        barkButton_S_InsertCabinetDoor1.transform.gameObject.SetActive(false);
        sniffButton_S_InsertCabinetDoor1.transform.gameObject.SetActive(false);
        biteButton_S_InsertCabinetDoor1.transform.gameObject.SetActive(false);
        pressButton_S_InsertCabinetDoor1.transform.gameObject.SetActive(false);
        insertButton_S_InsertCabinetDoor1.transform.gameObject.SetActive(false);
        insertDisableButton_S_InsertCabinetDoor1.transform.gameObject.SetActive(false);
    }

    void Awake()
    {
        S_InsertAreaButton.onClick.AddListener(InsertAreaButton1);
    }

    // Update is called once per frame
    void Update()
    {
        if (PipeForInsertData_S.IsBite)
        {
            insertCabinetDoor1Data_S.IsCenterButtonChanged = true;
        }

        else
        {
            insertCabinetDoor1Data_S.IsCenterButtonChanged = false;
        }
    }

    void InsertAreaButton1()
    {
        if (InsertDetect.insertDetect.Isdetected)// ����� ���� �ȿ� ������ �� ������ Ŭ���ϸ�
        {
            S_InsertAreaButton.transform.gameObject.SetActive(false); // ����� ���� ��Ȱ��ȭ

            noahAnim_S.SetBool("IsInserting", false); // ��� ����� �ִϸ��̼� �ߴ�

            //ĳ��� �� ���� �ִϸ��̼�
            Invoke("CabinetOpen1", 2f);

            S_stopMoving.transform.gameObject.SetActive(false); // �÷��̾� �ٽ� ������ �� �ֵ��� ȭ���� ������ �̹��� ��Ȱ��ȭ
            /* ������ ��� �ٽ� ǰ */

/*            GameManager.gameManager._gameData.IsCWDoorOpened_M_C1 = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");*/

            canInsertCabinetBody1Data_S.IsInsert = false;

            canInsertCabinetBody1Data_S.IsNotInteractable = false; //ĳ��� �� ��ȣ�ۿ� ����
            canInsertCabinetBody1Outline_S.OutlineWidth = 8;
        }
    }

    public void OnInsert()
    {
        canInsertCabinetBody1Data_S.IsInsert = true;
        DisableButton();
        PlayerScripts.playerscripts.currentInsertObj = this.gameObject;

        /* "�����" �� �̵��� ��ġ�� ���� �ֱ� */
        InteractionButtonController.interactionButtonController.insertPosOffset = new Vector3(-1f, 0.7599989f, -27.72f);
        InteractionButtonController.interactionButtonController.insertRotOffset = new Vector3(0, -20f, 0);

        /* ����� �ִϸ��̼� & �̵� */
        InteractionButtonController.interactionButtonController.PlayerInsert1();
       
        // ĳ��� �� ��Ȱ��ȭ
        insertCabinetDoor1Data_S.IsNotInteractable = true;
        insertCabinetDoor1Outline_S.OutlineWidth = 0;

        S_stopMoving.transform.gameObject.SetActive(true); // �÷��̾� �� �����̵��� ȭ�鿡 ������ �̹��� Ȱ��ȭ
        S_InsertAreaButton.transform.gameObject.SetActive(true); // ����� ���� Ȱ��ȭ

/*        if(*//*S_IsInsertAreaClicked &&*//* InsertDetect.insertDetect.Isdetected)
        {
            S_InsertAreaButton.transform.gameObject.SetActive(false);// ����� ���� ��Ȱ��ȭ

            noahAnim_S.SetBool("IsInserting", false); // ��� ����� �ִϸ��̼� �ߴ�

            //ĳ��� �� ���� �ִϸ��̼�
            Invoke("CabinetOpen1", 2f);

            S_stopMoving.transform.gameObject.SetActive(false);

            canInsertCabinetBody1Data_S.IsInsert = false;

            canInsertCabinetBody1Data_S.IsNotInteractable = false; //ĳ��� �� ��ȣ�ۿ� ����
            canInsertCabinetBody1Outline_S.OutlineWidth = 8;

            *//*            GameManager.gameManager._gameData.IsnsertCabinetOpened_M_C1 = true;
                        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");*//*
        }*/

    }

    public void OnBark()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnSniff()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }


    public void OnPushOrPress()
    {

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();
    }

    void CabinetOpen1()
    {

        canInsertCabinetDoor1Anim.SetBool("eInsertCabinetOpen", true);
        canInsertCabinetDoor1Anim.SetBool("eInsertCabinetEnd", true);

        //bool ĳ��� ���� ���ȴٸ� Ʈ��� üũ save�� �־���� �ǳ�?
        Debug.Log("ĳ��� ���� ��ȣ�ۿ� �����ؿ�");
        //ĳ��� �ٵ� ��ȣ�ۿ� �����ϰ�



        /*        IsminiCabinetDoorOpen = true;

                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");*/
    }



    public void OnUp()
    {
    }

    public void OnEat()
    {
    }
    public void OnObserve()
    {
    }

    public void OnBite()
    {
        //��ȣ�ۿ� ��ư�� ��
        DisableButton();
        //���⸸ �ϴ� �ִϸ��̼� & �� �� ���� ������Ʈ���� �˸�
        InteractionButtonController.interactionButtonController.PlayerCanNotBite();
    }

    public void OnSmash()
    {
        //throw new System.NotImplementedException();
    }
}
