using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class W_LivingroomDoor_Open : MonoBehaviour, IInteraction

{
    private Button barkButton, sniffButton, biteButton, pressButton, nocenterButton;

    ObjData LivingroomDoorObjData;
    public ObjectData LivingroomDoorData;
    public GameObject LivingroomDoor;

    bool dontrootmore = false;

    void Start()
    {
        /*ObjData*/
        LivingroomDoorObjData = GetComponent<ObjData>();

        /*��ư*/
        barkButton = LivingroomDoorObjData.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = LivingroomDoorObjData.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = LivingroomDoorObjData.BiteButton;
        //biteButton.onClick.AddListener(OnBiteDestroy);

        pressButton = LivingroomDoorObjData.PushOrPressButton;
        pressButton.onClick.AddListener(OnPushOrPress);

        nocenterButton = LivingroomDoorObjData.CenterButton1;
        // nocenterButton.onClick.AddListener();
    }

    // Update is called once per frames
    void Update()
    {
        if (GameManager.gameManager._gameData.IsCompleteHalfOpenLivingRoom == true)
        {
            LivingroomDoor.transform.position = new Vector3(-260.95f, -0.67f, 694.04f);
        }

        if (GameManager.gameManager._gameData.IsCompleteOpenLivingRoom == true)
        {
            LivingroomDoor.transform.position = new Vector3(-263.12f, -0.67f, 694.04f);
        }

        if (LivingroomDoorData.IsClicked && !dontrootmore )
        {
            ////B-1 ��� ��� �١١١١١١١١١١١١١١١١١١١١�
            //dialogManager.StartCoroutine(dialogManager.PrintAIDialog(20));

            GameData gameData = SaveSystem.Load("save_001");
            {
                // ���� �̼� �߰� ������ Ȯ�� �� �߰�
                if (!gameData.CompleteMissionList[2])
                {
                    MissionGenerator.missionGenerator.AddNewMission(2);
                    GameManager.gameManager._gameData.CompleteMissionList[2] = true;
                    SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
                }
            }
            dontrootmore = true;
        }
    }

    void DisableButton()
    {
        barkButton.transform.gameObject.SetActive(false);
        sniffButton.transform.gameObject.SetActive(false);
        biteButton.transform.gameObject.SetActive(false);
        pressButton.transform.gameObject.SetActive(false);
        nocenterButton.transform.gameObject.SetActive(false);
    }



    public void OnBark()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnBite()
    {
        //��ȣ�ۿ� ��ư�� ��
        DisableButton();
        //���⸸ �ϴ� �ִϸ��̼� & �� �� ���� ������Ʈ���� �˸�
        InteractionButtonController.interactionButtonController.PlayerCanNotBite();
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


    public void OnInsert()
    {
    }
    public void OnObserve()
    {
    }
    public void OnSmash()
    {
    }
    public void OnEat()
    {
    }

    public void OnUp()
    {
    }
}
