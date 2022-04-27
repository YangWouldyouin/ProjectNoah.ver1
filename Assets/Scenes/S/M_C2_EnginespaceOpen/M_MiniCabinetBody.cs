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

    ObjData miniCabinetBodyData_M;
    ObjData canRubberData_M;
    //BoxCollider cabinetCollider;

    /*아웃라인*/
    Outline rubberOutline_M;


    // Start is called before the first frame update
    void Start()
    {
        //cabinetCollider = GetComponent<BoxCollider>();
        /*연관있는 오브젝트*/
        canRubberData_M = M_canRubber.GetComponent<ObjData>();

        miniCabinetBodyData_M = GetComponent<ObjData>();


        barkButton_M_MiniCabinetBody = miniCabinetBodyData_M.BarkButton;
        barkButton_M_MiniCabinetBody.onClick.AddListener(OnBark);

        sniffButton_M_MiniCabinetBody = miniCabinetBodyData_M.SniffButton;
        sniffButton_M_MiniCabinetBody.onClick.AddListener(OnSniff);

        biteButton_M_MiniCabinetBody = miniCabinetBodyData_M.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_M_MiniCabinetBody = miniCabinetBodyData_M.PushOrPressButton;
        pressButton_M_MiniCabinetBody.onClick.AddListener(OnPushOrPress);

        observeButton_M_MiniCabinetBody = miniCabinetBodyData_M.CenterButton1;
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
         if(miniCabinetBodyData_M.IsObserve == false)
        {
            canRubberData_M.IsNotInteractable = true;
            rubberOutline_M.OutlineWidth = 0;
        }
    }

    public void OnObserve()
    {
        miniCabinetBodyData_M.IsObserve = true;
        //cabinetCollider.isTrigger = false;

        DisableButton();

        PlayerScripts.playerscripts.currentObserveObj = this.gameObject;

        CameraController.cameraController.currentView = miniCabinetBodyData_M.ObserveView;

        InteractionButtonController.interactionButtonController.playerObserve();


        Debug.Log("고무판에 상호작용 가능해요");
        canRubberData_M.IsNotInteractable = false;
        rubberOutline_M.OutlineWidth = 8;
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
        miniCabinetBodyData_M.IsBark = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnBiteDestroy()
    {
    }


    public void OnPushOrPress()
    {
        miniCabinetBodyData_M.IsPushOrPress = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();

        StartCoroutine(ChangePressFalse());
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        miniCabinetBodyData_M.IsPushOrPress = false;
    }

    public void OnSniff()
    {
        miniCabinetBodyData_M.IsSniff = true;

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
