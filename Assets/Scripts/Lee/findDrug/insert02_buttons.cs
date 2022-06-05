using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class insert02_buttons : MonoBehaviour, IInteraction
{
    public ObjectData drugMachineData, specificDrugData, drugInsert2Data;

    public GameObject SDrug;
    Outline SDrugLine;

    private Button barkButton, sniffButton, biteButton, pressButton, noCenterButton;

    ObjData Insert02Data;
    Outline Insert02Line;

    public GameObject D_LED;
    Renderer D_LEDColor;

    public GameObject dialog;
    DialogManager dialogManager;

    PlayerEquipment equipment;
    GameObject portableGroup;

    void Start()
    {
        equipment = BaseCanvas._baseCanvas.equipment;
        portableGroup = InteractionButtonController.interactionButtonController.portableObjects;

        dialogManager = dialog.GetComponent<DialogManager>();

        Insert02Data = GetComponent<ObjData>();
        Insert02Line = GetComponent<Outline>();

        SDrugLine = SDrug.GetComponent<Outline>();

        //��ư
        barkButton = Insert02Data.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = Insert02Data.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = Insert02Data.BiteButton;
        biteButton.onClick.AddListener(OnBite);

        pressButton = Insert02Data.PushOrPressButton;
        pressButton.onClick.AddListener(OnPushOrPress);

        noCenterButton = Insert02Data.CenterButton1;

        D_LEDColor = D_LED.GetComponent<Renderer>();

    }

    void Update()
    {
        /*if(!drugMachineData.IsObserve)
        {
            drugInsert2Data.IsNotInteractable = true;
            Insert02Line.OutlineWidth = 0f;
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
        Insert02Data.IsBark = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnSniff()
    {
        Insert02Data.IsSniff = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }


    public void OnPushOrPress()
    {
        Insert02Data.IsPushOrPress = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerPressHead();

        if (specificDrugData.IsBite)
        {
            D_LEDColor.material.color = Color.blue; //�˻� ��� ���� ��ȯ

            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(49));

            GameManager.gameManager._gameData.IsDetox = true;
            GameManager.gameManager._gameData.IsFindDrugDone_T_C2 = true;
            GameManager.gameManager._gameData.ActiveMissionList[26] = false;
            MissionGenerator.missionGenerator.ActivateMissionList();
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            Invoke("NoSDrug", 0.5f);
        }

        StartCoroutine(ChangePressFalse());
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        Insert02Data.IsPushOrPress = false;
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

    void NoSDrug() //Ư�� �๰ ������� �ϱ�
    {
        Debug.Log("Ư���� �๰ ����");

        specificDrugData.IsBite = false;

        SDrug.GetComponent<Rigidbody>().isKinematic = false;
        SDrug.transform.parent = null;

        SDrug.transform.position = new Vector3(-249.0776f, 0.1652f, 669.806f);
        SDrug.transform.rotation = Quaternion.Euler(0, 0, 90);

        SDrug.transform.parent = portableGroup.transform;
        equipment.biteObjectName = "";

        specificDrugData.IsNotInteractable = false;
        SDrugLine.OutlineWidth = 0;

        Insert02Data.IsNotInteractable = false;
        Insert02Line.OutlineWidth = 0;


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
}
