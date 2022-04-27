using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_Table1 : MonoBehaviour, IInteraction
{
    /*연관있는 오브젝트*/
    public GameObject M_canPack;

    public Transform Table1Pos;

    public Vector3 Table1RisePos;

    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_M_Table1, sniffButton_M_Table1,
        biteButton_M_Table1, pressButton_M_Table1, upButton_M_Table1,
        upDisableButton_M_Table1, observeButton_M_Table1;

    ObjData table1Data_M;
    ObjData canPackData_M;

    Outline canPackOutline_M;

    void Start()
    {
        table1Data_M = GetComponent<ObjData>();
        canPackData_M = M_canPack.GetComponent<ObjData>();

        canPackOutline_M = M_canPack.GetComponent<Outline>();


        barkButton_M_Table1 = table1Data_M.BarkButton;
        barkButton_M_Table1.onClick.AddListener(OnBark);

        sniffButton_M_Table1 = table1Data_M.SniffButton;
        sniffButton_M_Table1.onClick.AddListener(OnSniff);

        biteButton_M_Table1 = table1Data_M.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_M_Table1 = table1Data_M.PushOrPressButton;
        pressButton_M_Table1.onClick.AddListener(OnPushOrPress);

        upButton_M_Table1 = table1Data_M.CenterButton1;
        upButton_M_Table1.onClick.AddListener(OnUp);

        observeButton_M_Table1 = table1Data_M.CenterButton2;
        observeButton_M_Table1.onClick.AddListener(OnObserve);

        // 비활성화 버튼은 버튼을 가져오기만 한다. 
        upDisableButton_M_Table1 = table1Data_M.CenterDisableButton1;
    }

    void Update()
    {
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
        table1Data_M.IsBark = true;

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


        if (!table1Data_M.IsUpDown)
        {
            //table1Data_M.IsCenterButtonChanged = false;

            /* 오르기 취소할 때 참고하기 위해 오브젝트 저장 */
            PlayerScripts.playerscripts.currentUpObj = this.gameObject;
            /* 오브젝트의 오르기 변수 true 로 바꿈 */
            table1Data_M.IsUpDown = true;

            /* 실제 노아가 이동할 오르기 위치 좌표에 x, z 값을 넣음 */
            Table1RisePos.x = Table1Pos.position.x;
            Table1RisePos.z = Table1Pos.position.z;

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
        table1Data_M.IsObserve = true;

        DisableButton();

        PlayerScripts.playerscripts.currentObserveObj = this.gameObject;

        CameraController.cameraController.currentView = table1Data_M.ObserveView;

        InteractionButtonController.interactionButtonController.playerObserve();
    }

    public void OnPushOrPress()
    {
        table1Data_M.IsPushOrPress = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();

        StartCoroutine(ChangePressFalse());
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        table1Data_M.IsPushOrPress = false;
    }

    public void OnSmash()
    {
        throw new System.NotImplementedException();
    }

    public void OnSniff()
    {
        table1Data_M.IsSniff = true;

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
