using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_Table2 : MonoBehaviour, IInteraction
{
    public ObjectData ChairData2;
    public ObjectData ChairData4;
    public ObjectData BoxData2;

    public GameObject Chair2;
    public GameObject Chair4;
    public GameObject MainComputer;

    BoxCollider Chair2_Collider;
    BoxCollider Chair4_Collider;
    BoxCollider MainComputer_Collider;

    /*연관있는 오브젝트*/
    public Vector3 Table2RisePos;
    public GameObject SuperDrugOnTable2;
    public GameObject NoahFoodOnTable2;
    public GameObject Line2OnTable2;
    public GameObject ConductionOnTable2;

    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_M_Table2, sniffButton_M_Table2,
        biteButton_M_Table2, pressButton_M_Table2, upButton_M_Table2,
        upDisableButton_M_Table2, observeButton_M_Table2;

    /*ObjData*/
    ObjData table2ObjData_M;
    public ObjectData table2Data_M;
    public ObjectData superDrugData_M;
    public ObjectData smartFormLine2Data_M;
    public ObjectData brokenDoorConduction_M;


    /*Outline*/
    public Outline superDrugOutline_M;
    public Outline smartFormLine2Outline_M;
    public Outline brokenDoorConductionOutline_M;

    /*Collider*/
    BoxCollider Table2_Collider;
    BoxCollider SuperDrugOnTable2_Collider;
    BoxCollider NoahFoodOnTable2_Collider;
    BoxCollider Line2OnTable2_Collider;
    BoxCollider ConductionOnTable2_Collider;

    void Start()
    {
        /*ObjData*/
        table2ObjData_M = GetComponent<ObjData>();

        /*Collider*/
        Table2_Collider = GetComponent<BoxCollider>();
        SuperDrugOnTable2_Collider = SuperDrugOnTable2.GetComponent<BoxCollider>();
        NoahFoodOnTable2_Collider = NoahFoodOnTable2.GetComponent<BoxCollider>();
        Line2OnTable2_Collider = Line2OnTable2.GetComponent<BoxCollider>();
        ConductionOnTable2_Collider = ConductionOnTable2.GetComponent<BoxCollider>();
        Chair2_Collider = Chair2.GetComponent<BoxCollider>();
        Chair4_Collider = Chair4.GetComponent<BoxCollider>();
        MainComputer_Collider = MainComputer.GetComponent<BoxCollider>();

        /*버튼 연결*/
        barkButton_M_Table2 = table2ObjData_M.BarkButton;
        barkButton_M_Table2.onClick.AddListener(OnBark);

        sniffButton_M_Table2 = table2ObjData_M.SniffButton;
        sniffButton_M_Table2.onClick.AddListener(OnSniff);

        biteButton_M_Table2 = table2ObjData_M.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_M_Table2 = table2ObjData_M.PushOrPressButton;
        pressButton_M_Table2.onClick.AddListener(OnPushOrPress);

        upButton_M_Table2 = table2ObjData_M.CenterButton1;
        upButton_M_Table2.onClick.AddListener(OnUp);

        observeButton_M_Table2 = table2ObjData_M.CenterButton2;
        observeButton_M_Table2.onClick.AddListener(OnObserve);

        // 비활성화 버튼은 버튼을 가져오기만 한다. 
        upDisableButton_M_Table2 = table2ObjData_M.CenterDisableButton1;

        /*선언시작*/

        table2Data_M.IsUpDown = false;
        table2Data_M.IsObserve = false;
        table2Data_M.IsCollision = false;

        SuperDrugOnTable2_Collider.enabled = false;
        NoahFoodOnTable2_Collider.enabled = false;
        Line2OnTable2_Collider.enabled = false;
        ConductionOnTable2_Collider.enabled = false;
    }

    void Update()
    {
        if(table2Data_M.IsClicked)
        {
            //B-3 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
        }

        //오를 수 있는 높이 확인
        if (ChairData2.IsUpDown || ChairData4.IsUpDown || table2Data_M.IsCollision)
        {
            table2Data_M.IsCenterButtonDisabled = false;
        }
        else if (!ChairData2.IsUpDown || !ChairData4.IsUpDown || !table2Data_M.IsCollision)
        {
            table2Data_M.IsCenterButtonDisabled = true;
        }

        /*노아의 높이가 책상 올라갈 높이가 되는지 확인*/
        /*        if (table2Data_M.IsCollision)
                {
                    table2Data_M.IsCenterButtonDisabled = false;
                }

                else if (table2Data_M.IsUpDown)
                {
                    table2Data_M.IsCenterButtonDisabled = false;
                }

                else
                {
                    table2Data_M.IsCenterButtonDisabled = true;
                }*/


        if (table2Data_M.IsUpDown==false)
        {
            table2Data_M.IsCenterButtonChanged = false;

            //B-3 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆

            /*            canPackData_M.IsNotInteractable = true;
                        canPackOutline_M.OutlineWidth = 0;*/
        }

        else
        {
            table2Data_M.IsCenterButtonChanged = true;

            superDrugData_M.IsNotInteractable = false;
            superDrugOutline_M.OutlineWidth = 8;

            smartFormLine2Data_M.IsNotInteractable = false;
            smartFormLine2Outline_M.OutlineWidth = 8;

            brokenDoorConduction_M.IsNotInteractable = false;
            brokenDoorConductionOutline_M.OutlineWidth = 8;
        }

        if(table2Data_M.IsObserve)
        {
            Table2_Collider.enabled = false;
            Chair2_Collider.enabled = false;
            Chair4_Collider.enabled = false;
            MainComputer_Collider.enabled = false;
        }

        else
        {
            Table2_Collider.enabled = true;
            Chair2_Collider.enabled = true;
            Chair4_Collider.enabled = true;
            MainComputer_Collider.enabled = true;
        }

        if(superDrugData_M.IsBite)
        {
            superDrugData_M.IsNotInteractable = false;
            superDrugOutline_M.OutlineWidth = 8;
        }

        if (smartFormLine2Data_M.IsBite)
        {
            smartFormLine2Data_M.IsNotInteractable = false;
            smartFormLine2Outline_M.OutlineWidth = 8;
        }


        if (brokenDoorConduction_M.IsBite)
        {
            brokenDoorConduction_M.IsNotInteractable = false;
            brokenDoorConductionOutline_M.OutlineWidth = 8;
        }
    }


    void DisableButton()
    {
        barkButton_M_Table2.transform.gameObject.SetActive(false);
        sniffButton_M_Table2.transform.gameObject.SetActive(false);
        biteButton_M_Table2.transform.gameObject.SetActive(false);
        pressButton_M_Table2.transform.gameObject.SetActive(false);
        observeButton_M_Table2.transform.gameObject.SetActive(false);
        upButton_M_Table2.transform.gameObject.SetActive(false);
        upDisableButton_M_Table2.transform.gameObject.SetActive(false);
    }
    public void OnBark()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }



    public void OnBite()
    {
      
    }


    public void OnUp()
    {
        DisableButton();

        table2Data_M.IsCenterButtonChanged = true;

        //Invoke("changeObserve", 3f);

        table2Data_M.IsObserve = false; //걍 오르기만 햇는데 관찰하기가 알아서 체크 되길래 넣어준거


        SuperDrugOnTable2_Collider.enabled = true;
        NoahFoodOnTable2_Collider.enabled = true;
        Line2OnTable2_Collider.enabled = true;
        ConductionOnTable2_Collider.enabled = true;

        /*테이블에 잘 올라갔으면 저장해서 게임 껐다켜도 테이블 위 물건들 항상 상호작용 가능하게*/
        GameManager.gameManager._gameData.IsUpTable2 = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        if (!table2Data_M.IsUpDown)
        {
            //table1Data_M.IsCenterButtonChanged = false;

            /* 오르기 취소할 때 참고하기 위해 오브젝트 저장 */
            PlayerScripts.playerscripts.currentUpObj = this.gameObject;
            /* 오브젝트의 오르기 변수 true 로 바꿈 */
            table2Data_M.IsUpDown = true;

            /* 실제 노아가 이동할 오르기 위치 좌표에 x, z 값을 넣음 */
            Table2RisePos.x = table2ObjData_M.UpPos.position.x;
            Table2RisePos.z = table2ObjData_M.UpPos.position.z;

            /* 오르기 애니메이션 1/2 실행 */
            InteractionButtonController.interactionButtonController.PlayerRise1();
            /* 오르기 위치 좌표를 보냄 */
            InteractionButtonController.interactionButtonController.risePosition = Table2RisePos;
            /* 나머지 오르기 애니메이션 실행 */
            InteractionButtonController.interactionButtonController.PlayerRise2();


        }


        ChairData2.IsUpDown = false;
        ChairData4.IsUpDown = false;
        BoxData2.IsUpDown = false;



        /*        if (!table1Data_M.IsUpDown)
                {
                    //table1Data_M.IsCenterButtonChanged = true;
                    //Invoke("changeObserve",2f);
                }

                else
                {
                    table1Data_M.IsCenterButtonChanged = false;
                }
        */
    }

    void changeObserve()
    {
        table2Data_M.IsCenterButtonChanged = true;
    }

    public void OnObserve()
    {

        DisableButton();

        PlayerScripts.playerscripts.currentObserveObj = this.gameObject;

        CameraController.cameraController.currentView = table2ObjData_M.ObserveView;

        InteractionButtonController.interactionButtonController.playerObserve();
    }

    public void OnPushOrPress()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();

    }


    public void OnSmash()
    {
        throw new System.NotImplementedException();
    }

    public void OnSniff()
    {

        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }


    public void OnEat()
    {

    }

    public void OnInsert()
    {

    }

}
