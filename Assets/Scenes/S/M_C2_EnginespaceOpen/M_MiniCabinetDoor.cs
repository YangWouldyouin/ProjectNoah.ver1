using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_MiniCabinetDoor : MonoBehaviour,IInteraction
{

    public bool IsminiCabinetDoorOpen = false;

    private Button barkButton_M_MiniCabinetDoor, sniffButton_M_MiniCabinetDoor, biteButton_M_MiniCabinetDoor, pressButton_M_MiniCabinetDoor, noCenterButton_M_MiniCabinetDoor /*smashButton_M_MiniCabinetDoor*/;

    ObjData miniCabinetDoorObjData_M;
    public ObjectData miniCabinetDoorData_M;
    public ObjectData canMiniCabinetBodyData_M;

    /*�ƿ�����*/
    public Outline miniCabinetBodyOutline_M;
    Outline miniCabinetDoorOutline_M;

    /*�ִϸ��̼�*/
    public Animator canMiniCabinetDoorAnim;

    // Start is called before the first frame update
    void Start()
    {
        /*�����ִ� ������Ʈ*/
        miniCabinetDoorObjData_M = GetComponent<ObjData>();

        barkButton_M_MiniCabinetDoor = miniCabinetDoorObjData_M.BarkButton;
        barkButton_M_MiniCabinetDoor.onClick.AddListener(OnBark);

        sniffButton_M_MiniCabinetDoor = miniCabinetDoorObjData_M.SniffButton;
        sniffButton_M_MiniCabinetDoor.onClick.AddListener(OnSniff);

        biteButton_M_MiniCabinetDoor = miniCabinetDoorObjData_M.BiteButton;
        biteButton_M_MiniCabinetDoor.onClick.AddListener(OnBite);

/*        smashButton_M_MiniCabinetDoor = miniCabinetDoorData_M.SmashButton;
        //biteButton_M_MiniCabinetDoor.onClick.AddListener(OnBite);*/

        pressButton_M_MiniCabinetDoor = miniCabinetDoorObjData_M.PushOrPressButton;
        pressButton_M_MiniCabinetDoor.onClick.AddListener(OnPushOrPress);

        noCenterButton_M_MiniCabinetDoor = miniCabinetDoorObjData_M.CenterButton1;

        /*�ƿ�����*/
        miniCabinetDoorOutline_M = GetComponent<Outline>();
    }

    void DisableButton()
    {
        barkButton_M_MiniCabinetDoor.transform.gameObject.SetActive(false);
        sniffButton_M_MiniCabinetDoor.transform.gameObject.SetActive(false);
        biteButton_M_MiniCabinetDoor.transform.gameObject.SetActive(false);
        pressButton_M_MiniCabinetDoor.transform.gameObject.SetActive(false);
        noCenterButton_M_MiniCabinetDoor.transform.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

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

        //ĳ��� �� ���� �ִϸ��̼�
        Invoke("CabinetOpen", 2f);
    }

    void CabinetOpen()
    {
        canMiniCabinetDoorAnim.SetBool("eCabinetOpen", true);
        canMiniCabinetDoorAnim.SetBool("eCabinetEnd", true);

        //bool ĳ��� ���� ���ȴٸ� Ʈ��� üũ save�� �־���� �ǳ�?
        Debug.Log("ĳ��� ���� ��ȣ�ۿ� �����ؿ�");
        //ĳ��� �ٵ� ��ȣ�ۿ� �����ϰ�
        canMiniCabinetBodyData_M.IsNotInteractable = false;
        miniCabinetBodyOutline_M.OutlineWidth = 8;

        // ĳ��� �� ��Ȱ��ȭ
        miniCabinetDoorData_M.IsNotInteractable = true;
        miniCabinetDoorOutline_M.OutlineWidth = 0;


        /*        IsminiCabinetDoorOpen = true;

                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");*/
    }



    public void OnUp()
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
