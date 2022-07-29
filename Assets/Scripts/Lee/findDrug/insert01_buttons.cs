using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class insert01_buttons : MonoBehaviour, IInteraction
{
    public ObjectData insertCheck1Data, drugData, drugMachineData;
    public GameObject ReportUI;
    public bool IsReported = false;

    public GameObject drug;
    Outline drugLine;

    private Button barkButton, sniffButton, biteButton, pressButton, noCenterButton;

    ObjData Insert01Data;
    Outline Insert01Line;

    public GameObject LED;
    Renderer LEDColor;

    public GameObject dialog;
    DialogManager dialogManager;

    PlayerEquipment equipment;
    GameObject portableGroup;

    BoxCollider drugCol;


    void Start()
    {
        equipment = BaseCanvas._baseCanvas.equipment;
        portableGroup = InteractionButtonController.interactionButtonController.portableObjects;

        dialogManager = dialog.GetComponent<DialogManager>();

        Insert01Data = GetComponent<ObjData>();
        Insert01Line = GetComponent<Outline>();

        drugLine = drug.GetComponent<Outline>();
        drugCol = drug.GetComponent<BoxCollider>();

        //��ư
        barkButton = Insert01Data.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = Insert01Data.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = Insert01Data.BiteButton;
        biteButton.onClick.AddListener(OnBite);

        pressButton = Insert01Data.PushOrPressButton;
        pressButton.onClick.AddListener(OnPushOrPress);

        noCenterButton = Insert01Data.CenterButton1;

        LEDColor = LED.GetComponent<Renderer>();
                                           
    }

    void Update()
    {
        /*if(!drugMachineData.IsObserve)
        {
            insertCheck1Data.IsNotInteractable = true;
            Insert01Line.OutlineWidth = 0f;
        }*/

    }

    // Update is called once per frame

    void DisableButton()
    {
        barkButton.transform.gameObject.SetActive(false);
        sniffButton.transform.gameObject.SetActive(false);
        biteButton.transform.gameObject.SetActive(false);
        pressButton.transform.gameObject.SetActive(false);
        noCenterButton.transform.gameObject.SetActive(false);
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
        InteractionButtonController.interactionButtonController.playerPressHead();

        if (drugData.IsBite)
        {            
            GameManager.gameManager._gameData.IsCheckDrug = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            Invoke("NoDrug", 1.5f);
            Invoke("ShowUI", 2f);
        }
    }

    public void OnEat()
    {
        //throw new System.NotImplementedException();
    }

    public void OnObserve()
    {
        //throw new System.NotImplementedException();
    }

    public void OnUp()
    {
        //throw new System.NotImplementedException();
    }

    public void OnInsert()
    {
        //throw new System.NotImplementedException();
    }

    public void OnBite()
    {
        DisableButton();
        InteractionButtonController.interactionButtonController.PlayerCanNotBite();
    }

    public void OnSmash()
    {
        //throw new System.NotImplementedException();
    }

    void NoDrug()
    {
        Debug.Log("�๰����");
        
        drugData.IsBite = false;

        LEDColor.material.color = Color.red; //�˻� ��� ���� ��ȯ

        drug.GetComponent<Rigidbody>().isKinematic = false;
        drug.transform.parent = null;

        drug.transform.position = new Vector3(-249.0776f, 0.4852f, 669.806f);
        drug.transform.rotation = Quaternion.Euler(0, 0, 90);
        drug.transform.localScale = new Vector3(1f, 1f, 1f);

        drug.transform.parent = portableGroup.transform;
        equipment.biteObjectName = "";

        insertCheck1Data.IsNotInteractable = true;
        Insert01Line.OutlineWidth = 0f;

        drugData.IsNotInteractable = true;
        drugLine.OutlineWidth = 0f;
        drugCol.enabled = false;

        // 미션이 추가되어있는지 확인 후 삭제
        GameData missionData = SaveSystem.Load("save_001");
        if (missionData.ActiveMissionList[25])
        {
            MissionGenerator.missionGenerator.DeleteNewMission(25);
        }

        StartCoroutine(Delay2Sec());
    }

    IEnumerator Delay2Sec()
    {
        yield return new WaitForSeconds(2f);

        GameData missionData = SaveSystem.Load("save_001");
        if (!missionData.CompleteMissionList[26])
        {
            MissionGenerator.missionGenerator.AddNewMission(26);
            GameManager.gameManager._gameData.CompleteMissionList[26] = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        }
    }

    public void Report()
    {
        Debug.Log("보고했음");
        IsReported = true;
        ReportUI.SetActive(false);

        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(48));

        GameManager.gameManager._gameData.IsFindDrugDone_T_C2 = true;
        GameManager.gameManager._gameData.ActiveMissionList[26] = false;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }

    public void Cancel()
    {
        Debug.Log("보고하기 취소했음");
        GameManager.gameManager._gameData.IsReportCancleCount += 1;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        //거시기... 보고하기 취소했다는거 카운트하기
        IsReported = true;
        ReportUI.SetActive(false);
    }

    public void ShowUI()
    {
        if (!IsReported)
        {
            ReportUI.SetActive(true);
        }
        
        else
        {
            ReportUI.SetActive(false);
        }
    }
}
