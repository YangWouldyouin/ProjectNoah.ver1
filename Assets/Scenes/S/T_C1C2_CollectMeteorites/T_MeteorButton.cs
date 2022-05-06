using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_MeteorButton : MonoBehaviour, IInteraction
{
    public bool meteorCollectanimOpen_T = false;

    /*연관있는 오브젝트*/
    public GameObject T_canMeteorCollectMachine;
    public GameObject T_canNormalMeteor1;
    public GameObject T_canImportantMeteor;

    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_T_MeteorButton, sniffButton_T_MeteorButton, biteButton_T_MeteorButton,
        pressButton_T_MeteorButton, noCenterButton_T_MeteorButton;

    /*ObjData*/
    ObjData meteorButtonObjData_T;
    public ObjectData meteorButtonData_T;

    public ObjectData canMeteorCollectMachineData_T;
    public ObjectData canNormalMeteor1Data_T;
    public ObjectData canImportantMeteorData_T;

    /*Outline*/
    Outline canMeteorCollectMachineOutline_T;
    Outline meteorButtonOutline_T;

    /*Animator*/
    public Animator meteorBoxAnim_T;

    /*Collider*/
    BoxCollider collectMachineCollider;
    BoxCollider NormalMeteor1Collider;
    BoxCollider ImportantMeteorCollider;

    // Start is called before the first frame update
    void Start()
    {
        /*Collider*/
        collectMachineCollider = T_canMeteorCollectMachine. GetComponent<BoxCollider>();
        NormalMeteor1Collider = T_canNormalMeteor1.GetComponent<BoxCollider>();
        ImportantMeteorCollider = T_canImportantMeteor.GetComponent<BoxCollider>();

        /*ObjData*/
        meteorButtonObjData_T = GetComponent<ObjData>();

        /*Outline*/
        canMeteorCollectMachineOutline_T = T_canMeteorCollectMachine.GetComponent<Outline>();
        meteorButtonOutline_T = GetComponent<Outline>();

        /*버튼 연결*/
        barkButton_T_MeteorButton = meteorButtonObjData_T.BarkButton;
        barkButton_T_MeteorButton.onClick.AddListener(OnBark);

        sniffButton_T_MeteorButton = meteorButtonObjData_T.SniffButton;
        sniffButton_T_MeteorButton.onClick.AddListener(OnSniff);

        biteButton_T_MeteorButton = meteorButtonObjData_T.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_T_MeteorButton = meteorButtonObjData_T.PushOrPressButton;
        pressButton_T_MeteorButton.onClick.AddListener(OnPushOrPress);

        noCenterButton_T_MeteorButton = meteorButtonObjData_T.CenterButton1;


        /*임무 시작*/
        //시간이 되면 
        GameManager.gameManager._gameData.IsStartCollectMeteorites = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        if (GameManager.gameManager._gameData.IsStartCollectMeteorites)
        {
            //C-1 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
        }

        if(meteorButtonData_T.IsPushOrPress)
        {
            //C-2 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
        }

        if(canNormalMeteor1Data_T.IsBite /*&& 고무를 물고*/
            || canImportantMeteorData_T.IsBite/*&& 고무를 물고*/)
        {
            //C-3 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
        }
    }

    void Update()
    {
        //운석 수집기계를 연것이 사실이고,
        if (meteorCollectanimOpen_T == true)
        {
            if (!canNormalMeteor1Data_T.IsBite || !canImportantMeteorData_T.IsBite) //일반 운석을 물지 않았다면
            {
                StartCoroutine(meteorBoxClose(0f, 30f)); // 30초 후에 문을 닫는 애니메이션을 실행하겠다.
            }
        }

        //운석을 물면 문이 닫히는 애니메이션 실행
        if(GameManager.gameManager._gameData.IsBiteimportantMeteor_T_C2)
        {
            StartCoroutine(meteorBoxClose(0f, 30f));
        }

        if (GameManager.gameManager._gameData.IsBiteNormalMeteor1_T_C2)
        {
            StartCoroutine(meteorBoxClose(0f, 30f));
        }

        //높이가 된다면 가운데 버튼이 활성화
        if (meteorButtonData_T.IsCollision)
        {
            meteorButtonData_T.IsNotInteractable = false; // 상호작용 가능하게
            meteorButtonOutline_T.OutlineWidth = 8;

            //canMeteorCollectMachineData_T.IsCenterPlusButtonDisabled = false; //관찰하기 가능하게
            canMeteorCollectMachineData_T.IsCenterButtonChanged = false;
        }

        else if (!meteorButtonData_T.IsCollision)
        {
            meteorButtonData_T.IsNotInteractable = true; // 상호작용 가능하게
            meteorButtonOutline_T.OutlineWidth = 0;

            canMeteorCollectMachineData_T.IsCenterButtonChanged = true;
        }

        //한번이라도 일반 운석을 물었다면
        if(canNormalMeteor1Data_T.IsBite)
        {
            NormalMeteor1Collider.enabled = true;
        }

        if(canImportantMeteorData_T.IsBite)
        {
            ImportantMeteorCollider.enabled = true;
        }

/*        if(!meteorButtonData_T.IsPushOrPress)
        {
            collectMachineCollider.enabled = false;
        }*/
    }

    void DisableButton()
    {
        barkButton_T_MeteorButton.transform.gameObject.SetActive(false);
        sniffButton_T_MeteorButton.transform.gameObject.SetActive(false);
        biteButton_T_MeteorButton.transform.gameObject.SetActive(false);
        pressButton_T_MeteorButton.transform.gameObject.SetActive(false);
        noCenterButton_T_MeteorButton.transform.gameObject.SetActive(false);
    }


    public void OnBark()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }


    public void OnPushOrPress()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();
               //운석 수집 기계 문 여는 애니메이션
        StartCoroutine(meteorBoxOpen());

        canMeteorCollectMachineData_T.IsNotInteractable = false; // 상호작용 가능하게
        canMeteorCollectMachineOutline_T.OutlineWidth = 8;

        meteorCollectanimOpen_T = true;

        collectMachineCollider.enabled = true;

    }

    public void OnSniff()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }


    //애니메이션
    IEnumerator meteorBoxOpen()
    {
        // 기본적으로 이 함수를 실행 할 때는 1초 지연한 후에 실행하겠다.
        yield return new WaitForSeconds(1f);

        meteorBoxAnim_T.SetBool("isMeteorBoxClose", false);
        meteorBoxAnim_T.SetBool("isMeteorBoxCloseEnd", false);
        meteorBoxAnim_T.SetBool("isMeteorBoxOpen", true);
        meteorBoxAnim_T.SetBool("isMeteorBoxOpenEnd", true);

        NormalMeteor1Collider.enabled = true;
        ImportantMeteorCollider.enabled = true;

        //count += 1;
    }

    // delay: 애니메이션 실행하기 전까지 시간지연 얼마나 할건지,
    // closeTimeCheck: 시간 제한 얼마로 걸어줄건지 예: 20초를 적으면 20초확인후에 애니메이션 실행하겠다.
    IEnumerator meteorBoxClose(float delay, float closeTimeCheck)
    {

        yield return new WaitForSeconds(delay);


        bool isTimeOver = false;
        float closeTime = 0f;

        while (isTimeOver == false)
        {
            yield return null;

            closeTime += Time.deltaTime;

            //현재 시간이>=제한 걸어둔 시간보다 크거나 같으면
            //isTimeOver = true;가 되어 이 (isTimeOver == false)에서 나가겠다.
            if (closeTime >= closeTimeCheck)
            {
                isTimeOver = true;
            }

            //혹은 운석을 물었다면 이 (isTimeOver == false)에서 나가겠다
            if (canNormalMeteor1Data_T.IsBite)
            {
                isTimeOver = true;
            }
        }

        // isTimeOver = true가 되었다면 아래에 있는 애니메이션을 실행하겠다.
        meteorBoxAnim_T.SetBool("isMeteorBoxOpen", false);
        meteorBoxAnim_T.SetBool("isMeteorBoxOpenEnd", false);
        meteorBoxAnim_T.SetBool("isMeteorBoxClose", true);
        meteorBoxAnim_T.SetBool("isMeteorBoxCloseEnd", true);

        meteorCollectanimOpen_T = false; // 다시 반복할 수 있게

        //Debug.Log("다시 반복할 수 있어요");

        canMeteorCollectMachineData_T.IsNotInteractable = true; // 상호작용 불가능하게
        canMeteorCollectMachineOutline_T.OutlineWidth = 0;
         
        NormalMeteor1Collider.enabled = false; //운석에 상호작용 불가능하게
        ImportantMeteorCollider.enabled = false;

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
