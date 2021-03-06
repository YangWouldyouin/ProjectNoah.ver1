using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_InsertCabinetBody1 : MonoBehaviour,IInteraction
{

    /*연관있는 오브젝트*/
    public GameObject S_Food1;

    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_S_PressCabinetBody1, sniffButton_S_PressCabinetBody1, 
        biteButton_S_PressCabinetBody1, pressButton_S_PressCabinetBody1, observeButton_S_PressCabinetBody1;

    ObjData pressCabinetBody1Data_M;
    public ObjectData canPressCabinetDoor1Data_S;

    public ObjectData canFood1Data_S;
    //BoxCollider cabinetCollider;

    /*아웃라인*/
    Outline canFood1Outline_M;

    /*Collider*/
    BoxCollider canFood1_Collider;

    // Start is called before the first frame update
    void Start()
    {
        //cabinetCollider = GetComponent<BoxCollider>();
        canFood1_Collider = S_Food1.GetComponent<BoxCollider>();

        /*연관있는 오브젝트*/

        pressCabinetBody1Data_M = GetComponent<ObjData>();


        barkButton_S_PressCabinetBody1 = pressCabinetBody1Data_M.BarkButton;
        barkButton_S_PressCabinetBody1.onClick.AddListener(OnBark);

        sniffButton_S_PressCabinetBody1 = pressCabinetBody1Data_M.SniffButton;
        sniffButton_S_PressCabinetBody1.onClick.AddListener(OnSniff);

        biteButton_S_PressCabinetBody1 = pressCabinetBody1Data_M.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_S_PressCabinetBody1 = pressCabinetBody1Data_M.PushOrPressButton;
        pressButton_S_PressCabinetBody1.onClick.AddListener(OnPushOrPress);

        observeButton_S_PressCabinetBody1 = pressCabinetBody1Data_M.CenterButton1;
        observeButton_S_PressCabinetBody1.onClick.AddListener(OnObserve);

        canFood1Outline_M = S_Food1.GetComponent<Outline>();

    }

    void DisableButton()
    {
        barkButton_S_PressCabinetBody1.transform.gameObject.SetActive(false);
        sniffButton_S_PressCabinetBody1.transform.gameObject.SetActive(false);
        biteButton_S_PressCabinetBody1.transform.gameObject.SetActive(false);
        pressButton_S_PressCabinetBody1.transform.gameObject.SetActive(false);
        observeButton_S_PressCabinetBody1.transform.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

/*        if (canPressCabinetDoor1Data_S.IsObserve == false)
        {
            *//*canRubberData_M.IsNotInteractable = true;
            rubberOutline_M.OutlineWidth = 0;*//*


            canPipe_Collider.enabled = false;
        }*/

        /*파이프에 항상 상호작용 가능하게*/
        if (canFood1Data_S.IsBite)
        {
            canFood1Data_S.IsNotInteractable = false;
            canFood1Outline_M.OutlineWidth = 8;

            canFood1_Collider.enabled = true;
        }
    }

    public void OnObserve()
    {
        //cabinetCollider.isTrigger = false;

        DisableButton();

        PlayerScripts.playerscripts.currentObserveObj = this.gameObject;

        CameraController.cameraController.currentView = pressCabinetBody1Data_M.ObserveView;

        InteractionButtonController.interactionButtonController.playerObserve();


        Debug.Log("파이프에 상호작용 가능해요");
        canFood1Data_S.IsNotInteractable = false;
        canFood1Outline_M.OutlineWidth = 8;

        canFood1_Collider.enabled = true;

        //S-11 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
    }

    public void OnBark()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnBiteDestroy()
    {
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
    }

    public void OnEat()
    {
    }

    public void OnInsert()
    {
    }

    public void OnBite()
    {
        //throw new System.NotImplementedException();
    }

    public void OnSmash()
    {
        //throw new System.NotImplementedException();
    }
}
