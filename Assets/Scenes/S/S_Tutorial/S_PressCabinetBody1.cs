using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_PressCabinetBody1 : MonoBehaviour,IInteraction
{

    /*연관있는 오브젝트*/
    public GameObject S_canPipe;

    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_S_PressCabinetBody1, sniffButton_S_PressCabinetBody1, 
        biteButton_S_PressCabinetBody1, pressButton_S_PressCabinetBody1, observeButton_S_PressCabinetBody1;

    ObjData pressCabinetBody1Data_M;
    public ObjectData canpressCabinetBody1Data_M;
    public ObjectData canPressCabinetDoor1Data_S;

    public ObjectData canPipeData_S;
    //BoxCollider cabinetCollider;

    /*아웃라인*/
    Outline canPipeOutline_M;

    /*Collider*/
    BoxCollider canPipe_Collider;
    BoxCollider cabinetCollider;

    public GameObject dialog;
    DialogManager dialogManager;

    // Start is called before the first frame update
    void Start()
    {
        dialogManager = dialog.GetComponent<DialogManager>();

        cabinetCollider = GetComponent<BoxCollider>();
        canPipe_Collider = S_canPipe.GetComponent<BoxCollider>();

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

        canPipeOutline_M = S_canPipe.GetComponent<Outline>();

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

/*        if (canpressCabinetBody1Data_M.IsObserve)
        {
            cabinetCollider.enabled = false;
            canPipe_Collider.enabled = true;
        }

        else if (!canpressCabinetBody1Data_M.IsObserve)
        {
            cabinetCollider.enabled = true;
            canPipe_Collider.enabled = false;
        }


        if (canPipeData_S.IsBite)
        {
            canPipeData_S.IsNotInteractable = false;
            canPipeOutline_M.OutlineWidth = 8;

            canPipe_Collider.enabled = true;
        }*/
    }

    public void OnObserve()
    {
        //cabinetCollider.isTrigger = false;

        DisableButton();

        PlayerScripts.playerscripts.currentObserveObj = this.gameObject;

        CameraController.cameraController.currentView = pressCabinetBody1Data_M.ObserveView;

        InteractionButtonController.interactionButtonController.playerObserve();


        Debug.Log("파이프에 상호작용 가능해요");
        canPipeData_S.IsNotInteractable = false;
        canPipeOutline_M.OutlineWidth = 8;

        canPipe_Collider.enabled = true;
        cabinetCollider.enabled = false;

        //S-7 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
        Debug.Log("채현파트 완료, 마무리 대화 시작");
        dialogManager.StartCoroutine(dialogManager.PrintSubtitles(23));

        Invoke("Comment", 2f);

        /*튜토리얼 완료*/
        GameManager.gameManager._gameData.IsEndTuto = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
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

    }

    public void OnSmash()
    {

    }

    public void Comment()
    {
        Debug.Log("마이크랑 AI 티키타카 시작");

        dialogManager.StartCoroutine(dialogManager.PrintSubtitles(24));
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(63));
    }

}
