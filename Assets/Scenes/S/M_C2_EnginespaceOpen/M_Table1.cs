using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_Table1 : MonoBehaviour, IInteraction
{
    /*연관있는 오브젝트*/
    public Vector3 Table1RisePos;
    public GameObject PackOnTable1;
    public GameObject Beaker1OnTable1;
    public GameObject Beaker2OnTable1;
    public GameObject cylinder1OnTable1;
    public GameObject cylinder2OnTable1;
    public GameObject cylinder3OnTable1;
    public GameObject cylinder4OnTable1;

    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_M_Table1, sniffButton_M_Table1,
        biteButton_M_Table1, pressButton_M_Table1, upButton_M_Table1,
        upDisableButton_M_Table1, observeButton_M_Table1;

    /*ObjData*/
    ObjData table1ObjData_M;
    public ObjectData table1Data_M;
    public ObjectData canPackData_M;

    /*Outline*/
    public Outline canPackOutline_M;

    /*Collider*/
    BoxCollider Table1_Collider;
    BoxCollider PackOnTable1_Collider;
    BoxCollider Beaker1OnTable1_Collider;
    BoxCollider Beaker2OnTable1_Collider;
    BoxCollider cylinder1OnTable1_Collider;
    BoxCollider cylinder2OnTable1_Collider;
    BoxCollider cylinder3OnTable1_Collider;
    BoxCollider cylinder4OnTable1_Collider;

    public GameObject dialogManager_CS;
    DialogManager dialogManager;

    void Start()
    {
        dialogManager = dialogManager_CS.GetComponent<DialogManager>();

        /*ObjData*/
        table1ObjData_M = GetComponent<ObjData>();

        /*Collider*/
        Table1_Collider = GetComponent<BoxCollider>();
        PackOnTable1_Collider = PackOnTable1.GetComponent<BoxCollider>();
        Beaker1OnTable1_Collider = Beaker1OnTable1.GetComponent<BoxCollider>();
        Beaker2OnTable1_Collider = Beaker2OnTable1.GetComponent<BoxCollider>();
        cylinder1OnTable1_Collider = cylinder1OnTable1.GetComponent<BoxCollider>();
        cylinder2OnTable1_Collider = cylinder2OnTable1.GetComponent<BoxCollider>();
        cylinder3OnTable1_Collider = cylinder3OnTable1.GetComponent<BoxCollider>();
        cylinder4OnTable1_Collider = cylinder4OnTable1.GetComponent<BoxCollider>();

        /*버튼 연결*/
        barkButton_M_Table1 = table1ObjData_M.BarkButton;
        barkButton_M_Table1.onClick.AddListener(OnBark);

        sniffButton_M_Table1 = table1ObjData_M.SniffButton;
        sniffButton_M_Table1.onClick.AddListener(OnSniff);

        biteButton_M_Table1 = table1ObjData_M.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_M_Table1 = table1ObjData_M.PushOrPressButton;
        pressButton_M_Table1.onClick.AddListener(OnPushOrPress);

        upButton_M_Table1 = table1ObjData_M.CenterButton1;
        upButton_M_Table1.onClick.AddListener(OnUp);

        observeButton_M_Table1 = table1ObjData_M.CenterButton2;
        observeButton_M_Table1.onClick.AddListener(OnObserve);

        // 비활성화 버튼은 버튼을 가져오기만 한다. 
        upDisableButton_M_Table1 = table1ObjData_M.CenterDisableButton1;


        /*선언시작*/

        table1Data_M.IsUpDown = false;
        table1Data_M.IsObserve = false;
        table1Data_M.IsCollision = false;

        PackOnTable1_Collider.enabled = false;
        Beaker1OnTable1_Collider.enabled = false;
        Beaker2OnTable1_Collider.enabled = false;
        cylinder1OnTable1_Collider.enabled = false;
        cylinder2OnTable1_Collider.enabled = false;
        cylinder3OnTable1_Collider.enabled = false;
        cylinder4OnTable1_Collider.enabled = false;
    }

    void Update()
    {
        if(table1Data_M.IsClicked)
        {
            //B-3 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(22));
        }

        /*노아의 높이가 책상 올라갈 높이가 되는지 확인*/
        if (table1Data_M.IsCollision)
        {
            table1Data_M.IsCenterButtonDisabled = false;
        }

        else if (table1Data_M.IsUpDown)
        {
            table1Data_M.IsCenterButtonDisabled = false;
        }

        else
        {
            table1Data_M.IsCenterButtonDisabled = true;
        }


        if(table1Data_M.IsUpDown==false)
        {
            table1Data_M.IsCenterButtonChanged = false;

            /*            canPackData_M.IsNotInteractable = true;
                        canPackOutline_M.OutlineWidth = 0;*/
        }

        else
        {
            table1Data_M.IsCenterButtonChanged = true;

            canPackData_M.IsNotInteractable = false;
            canPackOutline_M.OutlineWidth = 8;
        }

        if(table1Data_M.IsObserve)
        {
            Table1_Collider.enabled = false;
        }

        else
        {
            Table1_Collider.enabled = true;
        }

        if(canPackData_M.IsBite)
        {
            canPackData_M.IsNotInteractable = false;
            canPackOutline_M.OutlineWidth = 8;
        }
    }


    void DisableButton()
    {
        barkButton_M_Table1.transform.gameObject.SetActive(false);
        sniffButton_M_Table1.transform.gameObject.SetActive(false);
        biteButton_M_Table1.transform.gameObject.SetActive(false);
        pressButton_M_Table1.transform.gameObject.SetActive(false);
        observeButton_M_Table1.transform.gameObject.SetActive(false);
        upButton_M_Table1.transform.gameObject.SetActive(false);
        upDisableButton_M_Table1.transform.gameObject.SetActive(false);
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

        table1Data_M.IsCenterButtonChanged = true;

        //Invoke("changeObserve", 3f);

        table1Data_M.IsObserve = false; //걍 오르기만 햇는데 관찰하기가 알아서 체크 되길래 넣어준거

        //B-4 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(23));

        /*책상 위에 올라가면 책상 위 오브젝트랑 상호작용 가능하도록*/
        PackOnTable1_Collider.enabled = true;
        Beaker1OnTable1_Collider.enabled = true;
        Beaker2OnTable1_Collider.enabled = true;
        cylinder1OnTable1_Collider.enabled = true;
        cylinder2OnTable1_Collider.enabled = true;
        cylinder3OnTable1_Collider.enabled = true;
        cylinder4OnTable1_Collider.enabled = true;

        /*테이블에 잘 올라갔으면 저장해서 게임 껐다켜도 테이블 위 물건들 항상 상호작용 가능하게*/
        GameManager.gameManager._gameData.IsUpTable1 = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        if (!table1Data_M.IsUpDown)
        {
            //table1Data_M.IsCenterButtonChanged = false;

            /* 오르기 취소할 때 참고하기 위해 오브젝트 저장 */
            PlayerScripts.playerscripts.currentUpObj = this.gameObject;
            /* 오브젝트의 오르기 변수 true 로 바꿈 */
            table1Data_M.IsUpDown = true;

            /* 실제 노아가 이동할 오르기 위치 좌표에 x, z 값을 넣음 */
            Table1RisePos.x = table1ObjData_M.UpPos.position.x;
            Table1RisePos.z = table1ObjData_M.UpPos.position.z;

            /* 오르기 애니메이션 1/2 실행 */
            InteractionButtonController.interactionButtonController.PlayerRise1();
            /* 오르기 위치 좌표를 보냄 */
            InteractionButtonController.interactionButtonController.risePosition = Table1RisePos;
            /* 나머지 오르기 애니메이션 실행 */
            InteractionButtonController.interactionButtonController.PlayerRise2();


        }



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
        table1Data_M.IsCenterButtonChanged = true;
    }

    public void OnObserve()
    {

        DisableButton();

        PlayerScripts.playerscripts.currentObserveObj = this.gameObject;

        CameraController.cameraController.currentView = table1ObjData_M.ObserveView;

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
