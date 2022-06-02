using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_PressCabinetBody1 : MonoBehaviour,IInteraction
{

    /*�����ִ� ������Ʈ*/
    public GameObject S_canPipe;
    public GameObject PlantRader;

    /*������Ʈ�� ��ȣ�ۿ� ��ư��*/
    private Button barkButton_S_PressCabinetBody1, sniffButton_S_PressCabinetBody1, 
        biteButton_S_PressCabinetBody1, pressButton_S_PressCabinetBody1, observeButton_S_PressCabinetBody1;

    ObjData pressCabinetBody1Data_M;
    public ObjectData canpressCabinetBody1Data_M;
    public ObjectData canPressCabinetDoor1Data_S;

    public ObjectData canPipeData_S;
    //BoxCollider cabinetCollider;

    /*�ƿ�����*/
    Outline canPipeOutline_M;

    /*Collider*/
    BoxCollider canPipe_Collider;
    BoxCollider cabinetCollider;
    BoxCollider PlantRader_Collider;

    public GameObject dialog;
    DialogManager dialogManager;

    public Button aiButton;
    // Start is called before the first frame update
    void Start()
    {
        Color aiColor = aiButton.GetComponent<Image>().color;
        aiColor.a = 0.5f;
        aiButton.GetComponent<Image>().color = aiColor;
        aiButton.interactable = false;

        dialogManager = dialog.GetComponent<DialogManager>();

        cabinetCollider = GetComponent<BoxCollider>();
        canPipe_Collider = S_canPipe.GetComponent<BoxCollider>();

        /*�����ִ� ������Ʈ*/

        pressCabinetBody1Data_M = GetComponent<ObjData>();
        PlantRader_Collider = PlantRader.GetComponent<BoxCollider>();


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


        /*���� ����*/
        canpressCabinetBody1Data_M.IsNotInteractable = true;
        PlantRader_Collider.enabled = false;

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

        /*�������� �׻� ��ȣ�ۿ� �����ϰ�*/

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


        Debug.Log("�������� ��ȣ�ۿ� �����ؿ�");
         canPipeData_S.IsNotInteractable = true;
        canPipeOutline_M.OutlineWidth = 8;

        canPipe_Collider.enabled = true;
        cabinetCollider.enabled = false;

        //S-7 ��� ��� �١١١١١١١١١١١١١١١١١١١١١١١١١١١١١١١١١١�
        Invoke("Comment", 2.5f);
        Invoke("ByePipeView", 8f);

        /*Ʃ�丮�� �Ϸ�*/
        GameManager.gameManager._gameData.IsEndTuto = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        /*�༺ Ž�� ����*/
        PlantRader_Collider.enabled = true;
    }

    public void Comment()
    {
        dialogManager.StartCoroutine(dialogManager.PrintSubtitles(23));
    }    

    void ByePipeView()
    {
        CameraController.cameraController.CancelObserve();
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



}
