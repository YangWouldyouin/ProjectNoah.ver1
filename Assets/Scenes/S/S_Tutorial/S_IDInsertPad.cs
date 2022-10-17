using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_IDInsertPad : MonoBehaviour, IInteraction
{
    public PlayerEquipment playerEquipment;
   
    /*연관있는 오브젝트*/
    public GameObject canPressCabinetDoor;
    public GameObject RealIDCard; // 카드키
    public GameObject RealIDConsole;



    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_S_IDInsertPad, sniffButton_S_IDInsertPad, biteButton_S_IDInsertPad,
        pressButton_S_IDInsertPad, noCenterButton_S_IDInsertPad; // eatDisableButton_T_SuperDrug;

    /*아웃라인*/
    public Outline realIDConsoleOutline_S;
    public Outline realIDCardOutline_S;

    /*ObjData*/
    ObjData IDInsertPadData_S;
    public ObjectData realIDConsoleData_S; //콘솔
    public ObjectData realIDCardData_S; // 카드

    /*BoxCollider*/
    BoxCollider IDInsertPad_Collider;
    BoxCollider canPressCabinetDoor_Collider;
    BoxCollider realIDInConsole_Collider;
    public BoxCollider PlantRader_Collider;

    public GameObject dialog;
    DialogManager dialogManager;

    public GameObject portable;

    void Start()
    {
        /*BoxCollider*/
        IDInsertPad_Collider = GetComponent<BoxCollider>();
        canPressCabinetDoor_Collider = canPressCabinetDoor.GetComponent<BoxCollider>();
        realIDInConsole_Collider = RealIDConsole.GetComponent<BoxCollider>();

        dialogManager = dialog.GetComponent<DialogManager>();

        /*아웃라인*//*
        realIDConsoleOutline_S = GetComponent<Outline>();
        realIDCardOutline_S = RealIDCard.GetComponent<Outline>();*/

        /*ObjData*/
        IDInsertPadData_S = GetComponent<ObjData>();

        barkButton_S_IDInsertPad = IDInsertPadData_S.BarkButton;
        barkButton_S_IDInsertPad.onClick.AddListener(OnBark);

        sniffButton_S_IDInsertPad = IDInsertPadData_S.SniffButton;
        sniffButton_S_IDInsertPad.onClick.AddListener(OnSniff);

        biteButton_S_IDInsertPad = IDInsertPadData_S.BiteButton;
        biteButton_S_IDInsertPad.onClick.AddListener(OnBite);

        pressButton_S_IDInsertPad = IDInsertPadData_S.PushOrPressButton;
        pressButton_S_IDInsertPad.onClick.AddListener(OnPushOrPress);

        noCenterButton_S_IDInsertPad = IDInsertPadData_S.CenterButton1;
        //noCenterButton_T_SuperDrug.onClick.AddListener(OnEat);

        //eatDisableButton_T_SuperDrug = SuperDrugData_T.CenterDisableButton1;


        IDInsertPad_Collider.enabled = false;
    }


    void DisableButton()
    {
        barkButton_S_IDInsertPad.transform.gameObject.SetActive(false);
        sniffButton_S_IDInsertPad.transform.gameObject.SetActive(false);
        biteButton_S_IDInsertPad.transform.gameObject.SetActive(false);
        pressButton_S_IDInsertPad.transform.gameObject.SetActive(false);
        noCenterButton_S_IDInsertPad.transform.gameObject.SetActive(false);
        //eatDisableButton_T_SuperDrug.transform.gameObject.SetActive(false);
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

        if (realIDCardData_S.IsBite && realIDConsoleData_S.IsObserve)
        {
            // 끼우기 성공
            // 부모 자식 관계를 해제한다.
            RealIDCard.GetComponent<Rigidbody>().isKinematic = false;
            RealIDCard.transform.parent = null;



            // 해당 위치, 각도, 크기로 바꾸겠다.
            RealIDCard.transform.position = new Vector3(-30.153f, 1.054f, -25.293f); //위치 고정
            RealIDCard.transform.rotation = Quaternion.Euler(-53.609f, 0, 90); //각도 고정
            RealIDCard.transform.parent = portable.transform;

            // 카드패드와 카드의 상호작용을 삭제한다.
            realIDCardData_S.IsNotInteractable = true;
            realIDCardOutline_S.OutlineWidth = 0;

            Debug.Log("아 아이디 콘솔 콜라이더 끄고싶어요");
            realIDInConsole_Collider.enabled = false;
            realIDConsoleData_S.IsNotInteractable = true;
            realIDConsoleOutline_S.OutlineWidth = 0;
            playerEquipment.biteObjectName = "";
            Invoke("CompleteCard", 1f);

            /*ID 콘솔 퍼즐 완료후에는 StopIDConsoleSpeak 이 트루가 되어서 더 이상 대사 안나옴*/
            GameManager.gameManager._gameData.StopIDConsoleSpeak = true;

            /*튜토리얼 중간 완료*/
            GameManager.gameManager._gameData.IsMiddleTuto = true;
            //SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            //콜라이더 켜주는거
            // canPressCabinetDoor_Collider.enabled = true;


            IDInsertPad_Collider.enabled = false;

            /*튜토리얼 완료*/
            GameManager.gameManager._gameData.IsEndTuto = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            /*행성 탐지 시작*/
            PlantRader_Collider.enabled = true;

        }

    }

    void CompleteCard()
    {
        CameraController.cameraController.CancelObserve();
        //S-4 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
        dialogManager.StartCoroutine(dialogManager.PrintSubtitles(20));
        // 캐비닛 대사 1
        //StartCoroutine(ComComment());
    }

    IEnumerator ComComment()
    {
        yield return new WaitForSeconds(3f);

        while (true)
        {
            if (dialogManager.IsTalking)
            {
                yield return new WaitForSeconds(1f);
            }

            else
            {

                dialogManager.StartCoroutine(dialogManager.PrintSubtitles(21));

                break;
            }
        }
    }

    public void OnSniff()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
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
