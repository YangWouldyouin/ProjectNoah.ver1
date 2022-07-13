using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class drugBag_buttons : MonoBehaviour, IInteraction
{
    public ObjectData drugBagData, drugData;
    ObjData drugBagObjData;

    public GameObject drug;
    //Outline drugLine;

    public GameObject drugSmellArea;
    public GameObject smellCheckArea;

    private Button barkButton, sniffButton, biteButton, smashButton, pressButton, noCenterButton;

    public GameObject dialog;
    DialogManager dialogManager;

    AudioSource drugBag_Rip_Sound;
    public AudioClip drugBag_Rip;

    PortableObjectData workRoomData;
    PortableObjectData livingRoomData;
    PortableObjectData engineRoomData;
    PortableObjectData controlRoomData;

    void Start()
    {
        workRoomData = BaseCanvas._baseCanvas.workRoomData;
        livingRoomData = BaseCanvas._baseCanvas.livingRoomData;
        engineRoomData = BaseCanvas._baseCanvas.engineRoomData;
        controlRoomData = BaseCanvas._baseCanvas.controlRoomData;

        drugBag_Rip_Sound = GetComponent<AudioSource>();

        dialogManager = dialog.GetComponent<DialogManager>();

        //������Ʈ
        drugBagObjData = GetComponent<ObjData>();

        //drugLine = GetComponent<Outline>();

        //��ư
        barkButton = drugBagObjData.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = drugBagObjData.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = drugBagObjData.BiteButton;
        //biteButton.onClick.AddListener(OnBite);

        smashButton = drugBagObjData.SmashButton;
        smashButton.onClick.AddListener(OnSmash);

        pressButton = drugBagObjData.PushOrPressButton;
        pressButton.onClick.AddListener(OnPushOrPress);

        noCenterButton = drugBagObjData.CenterButton1;
    }

    void update()
    {

    }

    void DisableButton()
    {
        barkButton.transform.gameObject.SetActive(false);
        sniffButton.transform.gameObject.SetActive(false);
        biteButton.transform.gameObject.SetActive(false);
        pressButton.transform.gameObject.SetActive(false);
        smashButton.transform.gameObject.SetActive(false);
        noCenterButton.transform.gameObject.SetActive(false);
    }

    public void OnBark()
    {
        DisableButton();
        InteractionButtonController.interactionButtonController.playerBark();
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

    public void OnUp()
    {
        //throw new System.NotImplementedException();
    }

    public void OnBite()
    {
        /*
        //BiteButton�� ��ũ��Ʈ �ֱ�
        drugData.GetComponent<Rigidbody>().isKinematic = true;
        drugData.transform.parent = gameObject.transform;

        CancelInvoke("followDrug");

        if (drugBagData.IsSmash)
        {
            Invoke("noBag", 1.5f);
        }*/
    }

    public void OnSmash()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.PlayerSmash1();

        //Invoke("NoBag", 2f);

        StartCoroutine(NoBag());
        drugBag_Rip_Sound.clip = drugBag_Rip;
        drugBag_Rip_Sound.Play();

        InteractionButtonController.interactionButtonController.PlayerSmash2();
    }

    /*void cantSmell() //�����ñ� ���� ��Ȱ��ȭ
    {
        MeshCollider meshcollider = drugSmellArea.GetComponent<MeshCollider>();
        meshcollider.enabled = false;
    }*/

    IEnumerator NoBag()
    {
        yield return new WaitForSeconds(2.5f);

        MeshCollider meshcollider = drugSmellArea.GetComponent<MeshCollider>();
        meshcollider.enabled = false;

        this.GetComponent<Rigidbody>().isKinematic = true;
        this.transform.parent = null;

        drugBagData.IsBite = false;

        //gameObject.SetActive(false);
        drug.SetActive(true);
        workRoomData.IsObjectActiveList[38] = true;

        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(47));

        drug.transform.position = gameObject.transform.position;

        Destroy(drugSmellArea, 0f);
        Destroy(smellCheckArea, 0f);
        gameObject.SetActive(false);

        // 앞으로 모든씬에서 안보임
        workRoomData.IsObjectActiveList[37] = false;
        livingRoomData.IsObjectActiveList[37] = false;
        engineRoomData.IsObjectActiveList[37] = false;
        controlRoomData.IsObjectActiveList[37] = false;
        //Destroy(gameObject, 0.5f);
        //StartCoroutine(DestroyDrugBag());

        //GameManager.gameManager._gameData.ActiveMissionList[24] = false;
        //GameManager.gameManager._gameData.ActiveMissionList[25] = true;
        //SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        //MissionGenerator.missionGenerator.ActivateMissionList();
        MissionGenerator.missionGenerator.DeleteNewMission(24);
        StartCoroutine(Delay2Sec());

    }

    IEnumerator Delay2Sec()
    {
        yield return new WaitForSeconds(2f);
        MissionGenerator.missionGenerator.AddNewMission(25);
    }
    IEnumerator DestroyDrugBag()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);

        // 앞으로 모든씬에서 안보임
        workRoomData.IsObjectActiveList[37] = false;
        livingRoomData.IsObjectActiveList[37] = false;
        engineRoomData.IsObjectActiveList[37] = false;
        controlRoomData.IsObjectActiveList[37] = false;
    }
}
