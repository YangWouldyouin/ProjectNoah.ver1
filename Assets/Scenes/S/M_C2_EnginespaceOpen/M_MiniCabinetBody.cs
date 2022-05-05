using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_MiniCabinetBody : MonoBehaviour,IInteraction
{

    /*연관있는 오브젝트*/
    public GameObject M_canRubber;

    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_M_MiniCabinetBody, sniffButton_M_MiniCabinetBody, biteButton_M_MiniCabinetBody, pressButton_M_MiniCabinetBody, observeButton_M_MiniCabinetBody;

    ObjData miniCabinetBodyObjData_M;
    public ObjectData miniCabinetBodyData_M;

    public ObjectData canRubberData_M;
    //BoxCollider cabinetCollider;

    /*아웃라인*/
    Outline rubberOutline_M;

    /*Collider*/
    BoxCollider rubber_Collider;

    // Start is called before the first frame update
    void Start()
    {
        //cabinetCollider = GetComponent<BoxCollider>();
        rubber_Collider = M_canRubber.GetComponent<BoxCollider>();

        /*연관있는 오브젝트*/

        miniCabinetBodyObjData_M = GetComponent<ObjData>();


        barkButton_M_MiniCabinetBody = miniCabinetBodyObjData_M.BarkButton;
        barkButton_M_MiniCabinetBody.onClick.AddListener(OnBark);

        sniffButton_M_MiniCabinetBody = miniCabinetBodyObjData_M.SniffButton;
        sniffButton_M_MiniCabinetBody.onClick.AddListener(OnSniff);

        biteButton_M_MiniCabinetBody = miniCabinetBodyObjData_M.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_M_MiniCabinetBody = miniCabinetBodyObjData_M.PushOrPressButton;
        pressButton_M_MiniCabinetBody.onClick.AddListener(OnPushOrPress);

        observeButton_M_MiniCabinetBody = miniCabinetBodyObjData_M.CenterButton1;
        observeButton_M_MiniCabinetBody.onClick.AddListener(OnObserve);

        rubberOutline_M = M_canRubber.GetComponent<Outline>();

    }

    void DisableButton()
    {
        barkButton_M_MiniCabinetBody.transform.gameObject.SetActive(false);
        sniffButton_M_MiniCabinetBody.transform.gameObject.SetActive(false);
        biteButton_M_MiniCabinetBody.transform.gameObject.SetActive(false);
        pressButton_M_MiniCabinetBody.transform.gameObject.SetActive(false);
        observeButton_M_MiniCabinetBody.transform.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (miniCabinetBodyData_M.IsObserve == false)
        {
            /*canRubberData_M.IsNotInteractable = true;
            rubberOutline_M.OutlineWidth = 0;*/


            rubber_Collider.enabled = false;
        }

        if (canRubberData_M.IsBite)
        {
            canRubberData_M.IsNotInteractable = false;
            rubberOutline_M.OutlineWidth = 8;

            rubber_Collider.enabled = true;
        }
    }

    public void OnObserve()
    {
        //cabinetCollider.isTrigger = false;

        DisableButton();

        PlayerScripts.playerscripts.currentObserveObj = this.gameObject;

        CameraController.cameraController.currentView = miniCabinetBodyObjData_M.ObserveView;

        InteractionButtonController.interactionButtonController.playerObserve();


        Debug.Log("고무판에 상호작용 가능해요");
        canRubberData_M.IsNotInteractable = false;
        rubberOutline_M.OutlineWidth = 8;

        rubber_Collider.enabled = true;

        //아웃라인

        /*        if (canRubberData_M.IsBite)
                {
                    CameraController.cameraController.CancelObserve();
                    //miniCabinetBodyData_M.IsObserve = false;
                }*/


        /*        else
                {
                    canRubberData_M.IsNotInteractable = true;
                    rubberOutline_M.OutlineWidth = 0;
                    //아웃라인
                }*/
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
