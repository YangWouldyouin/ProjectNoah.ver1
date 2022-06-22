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

    public bool dontrootmore = false;



    // Start is called before the first frame update
    void Start()
    {
        /*ObjData*/
        LivingroomDoorObjData = GetComponent<ObjData>();

        /*버튼*/
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

        if (LivingroomDoorData.IsClicked && dontrootmore == false)
        {
            ////B-1 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
            //dialogManager.StartCoroutine(dialogManager.PrintAIDialog(20));

            GameManager.gameManager._gameData.ActiveMissionList[2] = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            MissionGenerator.missionGenerator.ActivateMissionList();

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
        //상호작용 버튼을 끔
        DisableButton();
        //물기만 하는 애니메이션 & 물 수 없는 오브젝트임을 알림
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
