using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class S_IDConsole : MonoBehaviour, IInteraction
{
    /*클릭대사 다시 안나오게*/
    public bool StopIDConsoleSpeak = false;

    /*연관있는 오브젝트*/
    public GameObject S_canIDCard;
    /*    public GameObject S_BoxForConsole;*/
    public GameObject canPressCabinetDoor; 

    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_S_IDConsole, sniffButton_S_IDConsole, biteButton_S_IDConsole,
        pressButton_S_IDConsole, observeButton_S_IDConsole, observeDisableButton_S_IDConsole;


    /*ObjData*/
    ObjData iDConsoleData_S;
    public ObjectData IDConsoleData_S;
    public ObjectData canIDCardData_S;
/*    public ObjectData boxForConsoleData_S;*/

   /*아웃라인*/
   Outline iDConsoleOutline_S;
    Outline canIDCardOutline_S;

    /*BoxCollider*/
    BoxCollider IDConsole_Collider;
    BoxCollider BoxForConsole_Collider;
    BoxCollider canPressCabinetDoor_Collider;

    public GameObject dialog;
    DialogManager dialogManager;

    void Start()
    {
        dialogManager = dialog.GetComponent<DialogManager>();

        /*ObjData*/
        iDConsoleData_S = GetComponent<ObjData>();

        /*아웃라인*/
        iDConsoleOutline_S = GetComponent<Outline>();
        canIDCardOutline_S = S_canIDCard.GetComponent<Outline>();

        /*BoxCollider*//*
        IDConsole_Collider = GetComponent<BoxCollider>();
        BoxForConsole_Collider = S_BoxForConsole.GetComponent<BoxCollider>();*/

        canPressCabinetDoor_Collider = canPressCabinetDoor.GetComponent<BoxCollider>();

        barkButton_S_IDConsole = iDConsoleData_S.BarkButton;
        barkButton_S_IDConsole.onClick.AddListener(OnBark);

        sniffButton_S_IDConsole = iDConsoleData_S.SniffButton;
        sniffButton_S_IDConsole.onClick.AddListener(OnSniff);

        biteButton_S_IDConsole = iDConsoleData_S.BiteButton;
        biteButton_S_IDConsole.onClick.AddListener(OnBite);

        pressButton_S_IDConsole = iDConsoleData_S.PushOrPressButton;
        pressButton_S_IDConsole.onClick.AddListener(OnPushOrPress);

        observeButton_S_IDConsole = iDConsoleData_S.CenterButton2;
        observeButton_S_IDConsole.onClick.AddListener(OnObserve);

        observeDisableButton_S_IDConsole = iDConsoleData_S.CenterButton1;
    }

    void Update()
    {
        /*ID 콘솔 퍼즐 완료후에는 StopIDConsoleSpeak 이 트루가 되어서 더 이상 대사 안나옴*/
        if (IDConsoleData_S.IsClicked && StopIDConsoleSpeak == false)
        {
            dialogManager.StartCoroutine(dialogManager.PrintSubtitles(16));

            IDConsoleData_S.IsClicked = false;
        }
/*
        if(boxForConsoleData_S.IsUpDown)
        {
            IDConsole_Collider.enabled = true;
            BoxForConsole_Collider.enabled = false;
        }

        else
        {

        }*/

        /*노아의 높이가 책상 올라갈 높이가 되는지 확인*/
        if (IDConsoleData_S.IsCollision)
        {
            IDConsoleData_S.IsCenterButtonChanged = true;

        }

        else 
        {
            IDConsoleData_S.IsCenterButtonChanged = false;
        }


        if (IDConsoleData_S.IsObserve)
        {
            IDConsoleData_S.IsNotInteractable = false;
            iDConsoleOutline_S.OutlineWidth = 8;

        }
    }

    void DisableButton()
    {
        barkButton_S_IDConsole.transform.gameObject.SetActive(false);
        sniffButton_S_IDConsole.transform.gameObject.SetActive(false);
        biteButton_S_IDConsole.transform.gameObject.SetActive(false);
        pressButton_S_IDConsole.transform.gameObject.SetActive(false);
        observeButton_S_IDConsole.transform.gameObject.SetActive(false);
        observeDisableButton_S_IDConsole.transform.gameObject.SetActive(false);

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

        if (canIDCardData_S.IsBite && IDConsoleData_S.IsObserve)
        {
            // 끼우기 성공
            // 부모 자식 관계를 해제한다.
            S_canIDCard.GetComponent<Rigidbody>().isKinematic = false;
            S_canIDCard.transform.parent = null;

            // 해당 위치, 각도, 크기로 바꾸겠다.
            S_canIDCard.transform.position = new Vector3(-30.153f, 1.054f, -25.293f); //위치 고정
            S_canIDCard.transform.rotation = Quaternion.Euler(-53.609f, 0, 90); //각도 고정

            // 카드패드와 카드의 상호작용을 삭제한다.
            canIDCardData_S.IsNotInteractable = true;
            canIDCardOutline_S.OutlineWidth = 0;

            iDConsoleData_S.IsNotInteractable = true;
            iDConsoleOutline_S.OutlineWidth = 0;

            Invoke("CompleteCard",2f);

            /**/
            StopIDConsoleSpeak = true;

            /*튜토리얼 중간 완료*/
            GameManager.gameManager._gameData.IsMiddleTuto = true;
            //SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            //콜라이더 켜주는거
            canPressCabinetDoor_Collider.enabled = true;

            //S-5 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
            dialogManager.StartCoroutine(dialogManager.PrintSubtitles(21));

        }
    }

    void CompleteCard()
    {
        CameraController.cameraController.CancelObserve();
        //S-4 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
        dialogManager.StartCoroutine(dialogManager.PrintSubtitles(20));
    }

    public void OnSniff()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnObserve()
    {
        DisableButton();

        PlayerScripts.playerscripts.currentObserveObj = this.gameObject;

        CameraController.cameraController.currentView = iDConsoleData_S.ObserveView;

        InteractionButtonController.interactionButtonController.playerObserve();

        //S-3 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
        dialogManager.StartCoroutine(dialogManager.PrintSubtitles(19));

        IDConsoleData_S.IsNotInteractable = false;
        iDConsoleOutline_S.OutlineWidth = 8;

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

    public void OnSmash()
    {

    }

    public void OnUp()
    {
      
    }
}
