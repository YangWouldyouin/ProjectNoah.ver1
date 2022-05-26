using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class E_FA_Body : MonoBehaviour, IInteraction
{
    private Button barkButton, sniffButton, biteButton, pushButton, noCenterButton;
    PlayerEquipment playerEquipment;
    GameObject portableObject;

    ObjData FA_BodyData_E;

    public GameObject FA_fuelabsorberfixPart;
    public GameObject FA_fuelabsorber;

    public ObjectData FA_fuelabsorberfixPartData;

    public GameObject dialog_CS;
    DialogManager dialogManager;

    // Start is called before the first frame update
    void Start()
    {
        dialogManager = dialog_CS.GetComponent<DialogManager>();

        if (!GameManager.gameManager._gameData.IsFirstEnterEngine)
        {
            GameManager.gameManager._gameData.IsFirstEnterEngine = true;
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(11));
            GameManager.gameManager._gameData.ActiveMissionList[16] = true;
            MissionGenerator.missionGenerator.ActivateMissionList();

            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            //������ ������ ��ġ�� ����
        }

        playerEquipment = BaseCanvas._baseCanvas.equipment;
        portableObject = InteractionButtonController.interactionButtonController.portableObjects;

        FA_BodyData_E = GetComponent<ObjData>();

        /* ObjData �κ��� ��ȣ�ۿ� ��ư�� �����´�. */
        barkButton = FA_BodyData_E.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = FA_BodyData_E.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = FA_BodyData_E.BiteButton;
        biteButton.onClick.AddListener(OnBite);

        pushButton = FA_BodyData_E.PushOrPressButton;
        pushButton.onClick.AddListener(OnPushOrPress);

        noCenterButton = FA_BodyData_E.CenterButton1;
    }

    void DiableButton()
    {
        // ��Ȱ��ȭ ��ư���� �����Ͽ� ������ ���� ��� ��ư ������ ����.

        // ex. ������ ��ư, ��� ��ư�� ������ ��ư�ε� ó���� ��Ȱ��ȭ
        barkButton.transform.gameObject.SetActive(false);
        sniffButton.transform.gameObject.SetActive(false);
        biteButton.transform.gameObject.SetActive(false);
        pushButton.transform.gameObject.SetActive(false);
        noCenterButton.transform.gameObject.SetActive(false);
    }

    public void OnBark()
    {
        FA_BodyData_E.IsBark = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnPushOrPress()
    {
        DiableButton();
        InteractionButtonController.interactionButtonController.playerPressHead();

        if (FA_fuelabsorberfixPartData.IsBite) // ��ǰ�� ��������
        {
            Invoke("fuelabsorberDone", 1.5f); 
        }
    }

    public void fuelabsorberDone()
    {
        FA_fuelabsorber.SetActive(true);

        FA_fuelabsorberfixPart.GetComponent<Rigidbody>().isKinematic = false;
        FA_fuelabsorberfixPart.transform.parent = null;
        FA_fuelabsorberfixPart.transform.parent = portableObject.transform;

        FA_fuelabsorberfixPartData.IsBite = false;
        playerEquipment.biteObjectName = "";

        GameManager.gameManager._gameData.IsFuelabsorberFixed_E_E1 = true;

        GameManager.gameManager._gameData.ActiveMissionList[16] = false;
        MissionGenerator.missionGenerator.ActivateMissionList();

        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        FA_fuelabsorberfixPart.SetActive(false);
        gameObject.SetActive(false);

        //������ ������ ��ġ�� ��
    }

    public void OnSniff()
    {
        DiableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnEat()
    {
        //throw new System.NotImplementedException();
    }

    public void OnInsert()
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

    public void OnBite()
    {
        /* ��ȣ�ۿ� ��ư�� �� */
        DiableButton();
        /*  ���⸸ �ϴ� �ִϸ��̼� & �� �� ���� ������Ʈ���� �˸� */
        InteractionButtonController.interactionButtonController.PlayerCanNotBite();
    }

    public void OnSmash()
    {
        //throw new System.NotImplementedException();
    }
}
