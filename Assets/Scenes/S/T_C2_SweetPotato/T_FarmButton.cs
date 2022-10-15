using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_FarmButton : MonoBehaviour, IInteraction
{
    public bool EatPotato = false;

    /*연관있는 오브젝트*/
    public GameObject Pot1;
    public GameObject Pot2;
    public GameObject Pot3;
    public GameObject T_IsGrownHealthy1;
    public GameObject T_IsGrownHealthy2;
    public GameObject T_IsGrownHealthy3;
    public GameObject T_IsGrownHealthy4;
    public GameObject T_IsGrownHealthy5;
    public GameObject T_IsGrownHealthy6;
    public GameObject T_IsGrownHealthy7;
    public GameObject T_IsGrownHealthy8;
    public GameObject T_IsGrownHealthy9;

    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_T_FarmButton, sniffButton_T_FarmButton, biteButton_T_FarmButton, pressButton_T_FarmButton, noCenterButton_T_FarmButton;

    /*ObjData*/
    ObjData FarmButtonData_T;
    public ObjectData HeathlyPotatoEatData_T;
    public ObjectData BadPotatoEatData_T;

    /*Collider*/
    BoxCollider Pot1_Collider;
    BoxCollider Pot2_Collider;
    BoxCollider Pot3_Collider;

    public GameObject dialogManager_CS;
    DialogManager dialogManager;

    PortableObjectData portableData; // 이후 워크룸에서 안보이게 하기 위해

    void Start()
    {
        dialogManager = dialogManager_CS.GetComponent<DialogManager>();

        Pot1_Collider = Pot1.GetComponent<BoxCollider>();
        Pot2_Collider = Pot2.GetComponent<BoxCollider>();
        Pot3_Collider = Pot3.GetComponent<BoxCollider>();

        FarmButtonData_T = GetComponent<ObjData>();

        barkButton_T_FarmButton = FarmButtonData_T.BarkButton;
        barkButton_T_FarmButton.onClick.AddListener(OnBark);

        sniffButton_T_FarmButton = FarmButtonData_T.SniffButton;
        sniffButton_T_FarmButton.onClick.AddListener(OnSniff);

        biteButton_T_FarmButton = FarmButtonData_T.BiteButton;
        biteButton_T_FarmButton.onClick.AddListener(OnBite);

        pressButton_T_FarmButton = FarmButtonData_T.PushOrPressButton;
        pressButton_T_FarmButton.onClick.AddListener(OnPushOrPress);

        noCenterButton_T_FarmButton = FarmButtonData_T.CenterButton1;
    }

    void DisableButton()
    {
        barkButton_T_FarmButton.transform.gameObject.SetActive(false);
        sniffButton_T_FarmButton.transform.gameObject.SetActive(false);
        biteButton_T_FarmButton.transform.gameObject.SetActive(false);
        pressButton_T_FarmButton.transform.gameObject.SetActive(false);
        noCenterButton_T_FarmButton.transform.gameObject.SetActive(false);
    }

    void Update()
    {
        if(HeathlyPotatoEatData_T.IsEaten && GameManager.gameManager._gameData.IsFinishedEatingSweetPotatoes == false
            || BadPotatoEatData_T.IsEaten && GameManager.gameManager._gameData.IsFinishedEatingSweetPotatoes == false)
        {
            // 영양분 섭취 임무리스트 완료 ♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧
            MissionGenerator.missionGenerator.DeleteNewMission(18);
            Debug.Log("먹어버림");
            GameManager.gameManager._gameData.IsFinishedEatingSweetPotatoes = true;
        }

    }

    public void OnBark()
    {
        //FarmButtonData_T.IsBark = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnSniff()
    {
        //FarmButtonData_T.IsSniff = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnPushOrPress()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();

        //스마트팜 고치기 전에는 버튼 눌렀을 때 고쳐야합니다 문구 뜨게 하기
        if (GameManager.gameManager._gameData.IsCompleteSmartFarmOpen == false)
        {
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(75));
        }


        /*항상 pot 순서대로  덜자란 고구마를 심고, 상한 고구마를 심고, 성숙한 고구마를 심고 && 스마트팜 관리 기계 버튼을 누른다면*/

        /*Pot1*/
        GameData gameData = SaveSystem.Load("save_001");
        if (gameData.Pot1InPotato)
        {
            //A-6 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(18));
            Invoke("AppearSweetPotato1", 3f); //리얼 타임으로 5분 뒤에 미리 땅에 성장 시킨 고구마들이 켜져서 보이게 된다.

            if(!gameData.IsCanSeePotato1&& !gameData.IsCanSeePotato2 && !gameData.IsCanSeePotato3)
            {
                MissionGenerator.missionGenerator.DeleteNewMission(19);
                /*고구마가 나타난 상태를 저장한다.*/
                GameManager.gameManager._gameData.IsCanSeePotato1 = true;
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            }
        }

        if (gameData.Pot1InBadPotato)
        {
            //A-6 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(18));
        }

        if(gameData.Pot1InHealthyPotato)
        {
            //A-6대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(18));
        }


        /*Pot2*/
        if(gameData.Pot2InPotato)
        {
            //A-6 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(18));

            Invoke("AppearSweetPotato2", 3f); //리얼 타임으로 5분 뒤에 미리 땅에 성장 시킨 고구마들이 켜져서 보이게 된다.

            /*고구마가 나타난 상태를 저장한다.*/
            GameManager.gameManager._gameData.IsCanSeePotato2 = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            MissionGenerator.missionGenerator.DeleteNewMission(19);
        }

        if (gameData.Pot2InBadPotato)
        {
            //A-6 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(18));
        }

        if(gameData.Pot2InHealthyPotato)
        {
            //A-6대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(18));
        }

        /*Pot3*/
        if(gameData.Pot3InPotato)
        {
            //A-6 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(18));

            Invoke("AppearSweetPotato3", 3f); //리얼 타임으로 5분 뒤에 미리 땅에 성장 시킨 고구마들이 켜져서 보이게 된다.

            /*고구마가 나타난 상태를 저장한다.*/
            GameManager.gameManager._gameData.IsCanSeePotato3 = true;
            //GameManager.gameManager._gameData.ActiveMissionList[19] = false;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            //MissionGenerator.missionGenerator.ActivateMissionList();
            MissionGenerator.missionGenerator.DeleteNewMission(19);

        }

        if (gameData.Pot3InBadPotato)
        {
            //A-6 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(18));
        }

        if(gameData.Pot3InHealthyPotato)
        {
            //A-6대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(18));
        }
    }

    void AppearSweetPotato1()
    {
        T_IsGrownHealthy1.SetActive(true);
        T_IsGrownHealthy2.SetActive(true);
        T_IsGrownHealthy3.SetActive(true);

        // 이제 업무공간에 고구마 있으므로 직접 true로 변경
        portableData.IsObjectActiveList[21] = true;
        portableData.IsObjectActiveList[22] = true;
        portableData.IsObjectActiveList[23] = true;

        //A-7 알림 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(19));

        /*고구마 먹는 거 방해 안되게 + 이미 한 번 심은 땅에는 다시 못 심게*/
        Pot1_Collider.enabled = false;

        /*고구마가 나타난 상태를 저장한다.*//*
        GameManager.gameManager._gameData.IsCanSeePotato1 = true;
        GameManager.gameManager._gameData.ActiveMissionList[19] = false;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        MissionGenerator.missionGenerator.ActivateMissionList();*/

        // 식물 배양 연구 임무리스트 완료 ♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧
    }

    void AppearSweetPotato2()
    {
        T_IsGrownHealthy4.SetActive(true);
        T_IsGrownHealthy5.SetActive(true);
        T_IsGrownHealthy6.SetActive(true);

        // 이제 업무공간에 고구마 있으므로 직접 true로 변경
        portableData.IsObjectActiveList[18] = true;
        portableData.IsObjectActiveList[19] = true;
        portableData.IsObjectActiveList[20] = true;

        //A-7 알림 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(19));

        /*고구마 먹는 거 방해 안되게 + 이미 한 번 심은 땅에는 다시 못 심게*/
        Pot2_Collider.enabled = false;

        /*고구마가 나타난 상태를 저장한다.*//*
        GameManager.gameManager._gameData.IsCanSeePotato2 = true;
        GameManager.gameManager._gameData.ActiveMissionList[19] = false;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        MissionGenerator.missionGenerator.ActivateMissionList();*/

        // 식물 배양 연구 임무리스트 완료 ♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧
    }

    void AppearSweetPotato3()
    {
        T_IsGrownHealthy7.SetActive(true);
        T_IsGrownHealthy8.SetActive(true);
        T_IsGrownHealthy9.SetActive(true);

        // 이제 업무공간에 고구마 있으므로 직접 true로 변경
        portableData.IsObjectActiveList[15] = true;
        portableData.IsObjectActiveList[16] = true;
        portableData.IsObjectActiveList[17] = true;

        //A-7 알림 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(19));

        /*고구마 먹는 거 방해 안되게 + 이미 한 번 심은 땅에는 다시 못 심게*/
        Pot3_Collider.enabled = false;

        /*고구마가 나타난 상태를 저장한다.*//*
        GameManager.gameManager._gameData.IsCanSeePotato3 = true;
        GameManager.gameManager._gameData.ActiveMissionList[19] = false;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        MissionGenerator.missionGenerator.ActivateMissionList();*/

        // 식물 배양 연구 임무리스트 완료 ♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧
    }

    public void OnBite()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.PlayerCanNotBite();
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


    public void OnSmash()
    {
        
    }

    public void OnUp()
    {
        
    }
}
