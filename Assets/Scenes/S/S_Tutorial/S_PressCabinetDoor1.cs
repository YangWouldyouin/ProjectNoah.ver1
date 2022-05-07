using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_PressCabinetDoor1 : MonoBehaviour,IInteraction
{

    public bool IsPressCabinetDoorOpen = false;

    private Button barkButton_S_PressCabinetDoor1, sniffButton_S_PressCabinetDoor1, biteButton_S_PressCabinetDoor1, 
        pressButton_S_PressCabinetDoor1, noCenterButton_S_PressCabinetDoor1 /*smashButton_M_MiniCabinetDoor*/;

    ObjData pressCabinetDoor1Data_S;
    public ObjectData canPressCabinetDoor1Data_S;
    public ObjectData canPressCabinetBody1Data_S;

    /*�ƿ�����*/
    public Outline canPressCabinetBody1Outline_S;
    Outline pressCabinetDoor1Outline_S;

    /*�ִϸ��̼�*/
    public Animator canPressCabinetDoorAnim;

    // Start is called before the first frame update
    void Start()
    {
        /*�����ִ� ������Ʈ*/
        pressCabinetDoor1Data_S = GetComponent<ObjData>();

        barkButton_S_PressCabinetDoor1 = pressCabinetDoor1Data_S.BarkButton;
        barkButton_S_PressCabinetDoor1.onClick.AddListener(OnBark);

        sniffButton_S_PressCabinetDoor1 = pressCabinetDoor1Data_S.SniffButton;
        sniffButton_S_PressCabinetDoor1.onClick.AddListener(OnSniff);

        biteButton_S_PressCabinetDoor1 = pressCabinetDoor1Data_S.BiteButton;
        biteButton_S_PressCabinetDoor1.onClick.AddListener(OnBite);

/*        smashButton_M_MiniCabinetDoor = miniCabinetDoorData_M.SmashButton;
        //biteButton_M_MiniCabinetDoor.onClick.AddListener(OnBite);*/

        pressButton_S_PressCabinetDoor1 = pressCabinetDoor1Data_S.PushOrPressButton;
        pressButton_S_PressCabinetDoor1.onClick.AddListener(OnPushOrPress);

        noCenterButton_S_PressCabinetDoor1 = pressCabinetDoor1Data_S.CenterButton1;

        /*�ƿ�����*/
        pressCabinetDoor1Outline_S = GetComponent<Outline>();
    }

    void DisableButton()
    {
        barkButton_S_PressCabinetDoor1.transform.gameObject.SetActive(false);
        sniffButton_S_PressCabinetDoor1.transform.gameObject.SetActive(false);
        biteButton_S_PressCabinetDoor1.transform.gameObject.SetActive(false);
        pressButton_S_PressCabinetDoor1.transform.gameObject.SetActive(false);
        noCenterButton_S_PressCabinetDoor1.transform.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // �տ� ī��Ű �ȱ� ������ �Ϸ�Ǿ����� Ȯ��
        //S-5 ��� ��� �١١١١١١١١١١١١١١١١١١١١١١١١١١١١١١١١١١�
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

        canPressCabinetBody1Data_S.IsNotInteractable = false;
        canPressCabinetBody1Outline_S.OutlineWidth = 8;

        // ĳ��� �� ��Ȱ��ȭ
        pressCabinetDoor1Data_S.IsNotInteractable = true;
        pressCabinetDoor1Outline_S.OutlineWidth = 0;

        //ĳ��� �� ���� �ִϸ��̼�
        Invoke("CabinetOpen1", 2f);
    }

    void CabinetOpen1()
    {
        //S-6 ��� ��� �١١١١١١١١١١١١١١١١١١١١١١١١١١١١١١١١١١�

        canPressCabinetDoorAnim.SetBool("ePressCabinetOpen", true);
        canPressCabinetDoorAnim.SetBool("ePressCabinetEnd", true);

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
