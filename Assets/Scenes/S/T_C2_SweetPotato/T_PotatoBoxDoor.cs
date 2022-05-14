using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_PotatoBoxDoor : MonoBehaviour, IInteraction
{
    public bool DontClickPotato = false;

    /*연관있는 오브젝트*/
    //public GameObject SweetPotatoBoxDoor_T;

    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_T_PotatoBoxDoor, sniffButton_T_PotatoBoxDoor, biteButton_T_PotatoBoxDoor,
        pressButton_T_PotatoBox, noCenterButton_T_PotatoBox;

    /*ObjData*/
    ObjData PotatoBoxDoorData_T;
    public ObjectData IsPotatoBoxDoorData_T;

    public GameObject dialogManager_CS;
    DialogManager dialogManager;

    void Start()
    {
        dialogManager = dialogManager_CS.GetComponent<DialogManager>();

        /*ObjData*/
        PotatoBoxDoorData_T = GetComponent<ObjData>();

        /*ObjData*/
        barkButton_T_PotatoBoxDoor = PotatoBoxDoorData_T.BarkButton;
        barkButton_T_PotatoBoxDoor.onClick.AddListener(OnBark);

        sniffButton_T_PotatoBoxDoor = PotatoBoxDoorData_T.SniffButton;
        sniffButton_T_PotatoBoxDoor.onClick.AddListener(OnSniff);

        biteButton_T_PotatoBoxDoor = PotatoBoxDoorData_T.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_T_PotatoBox = PotatoBoxDoorData_T.PushOrPressButton;
        pressButton_T_PotatoBox.onClick.AddListener(OnPushOrPress);

        noCenterButton_T_PotatoBox = PotatoBoxDoorData_T.CenterButton1;

        if (IsPotatoBoxDoorData_T.IsClicked && DontClickPotato == false)
        {
            //A-3 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(15));

            DontClickPotato = true;

            // 영양분 섭취 임무리스트 시작 ♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧
            // 식물 배양 임무리스트 시작 ♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧
            // 영양제 투약 임무리스트 시작 ♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧
        }

    }

    void DisableButton()
    {
        barkButton_T_PotatoBoxDoor.transform.gameObject.SetActive(false);
        sniffButton_T_PotatoBoxDoor.transform.gameObject.SetActive(false);
        biteButton_T_PotatoBoxDoor.transform.gameObject.SetActive(false);
        pressButton_T_PotatoBox.transform.gameObject.SetActive(false);
        noCenterButton_T_PotatoBox.transform.gameObject.SetActive(false);

    }

    void Update()
    {
    }

    public void OnSmash()
    {

    }

    public void OnBark()
    {

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnPushOrPress()
    {

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHead();
    }

    public void OnSniff()
    {

        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnObserve()
    {
    }

    public void OnBite()
    {
        
    }

    public void OnEat()
    {
       
    }

    public void OnInsert()
    {
       
    }



    public void OnUp()
    {
       
    }
}
