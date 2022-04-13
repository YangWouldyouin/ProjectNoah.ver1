using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class InteractionButtonController : MonoBehaviour
{
    public static InteractionButtonController interactionButtonController { get; private set; }

    public Animator noahAnim; // 애니메이션 전환 위한 변수

    [SerializeField] GameObject noahPlayer;
    private static readonly int IsBarking = Animator.StringToHash("IsBarking"); // 문자열 비교보다 int 비교가 더 빠름
    //public bool isBark = false;

    /* "오르기" 상호작용 관련 변수*/
    public Rigidbody playerRigidbody;
    public NavMeshAgent playerAgent;
    private Vector3 risePosition;

    /* 현재 상호작용 중인 오브젝트를 받아오기 위한 변수 */
    [HideInInspector]
    public GameObject noahPushOrPressObject, noahSniffObject, noahBarkObject, noahUpDownObject, noahInsertObject, noahObserveObject, noahEatObject;

    /* 정리 필요한 변수들 */   
    [HideInInspector]
    public GameObject noahPushObject;
    public static GameObject noahpushobject;
    public static bool ISPUSH = false;
    [Header("정리 필요한 변수들")]
    public bool ispush = false;
    public static string pushObjectName;
    public TMPro.TextMeshProUGUI pushObjectText;

    void Awake()
    {
        interactionButtonController = this;


    }

    private void Start()
    {
        /* 각 상호작용 버튼에 함수를 추가한다. */
        BaseCanvas._baseCanvas.barkButton.onClick.AddListener(playerBark);
        BaseCanvas._baseCanvas.sniffButton.onClick.AddListener(playerSniff);
        BaseCanvas._baseCanvas.eatButton.onClick.AddListener(playerEat);
        BaseCanvas._baseCanvas.observeButton.onClick.AddListener(playerObserve);
        BaseCanvas._baseCanvas.upDownButton.onClick.AddListener(playerRising);
        BaseCanvas._baseCanvas.insertButton.onClick.AddListener(playerInserting);
        BaseCanvas._baseCanvas.pushButton.onClick.AddListener(playerPush);
        //BaseCanvas._baseCanvas.pressButton.onClick.AddListener(playerPress);
    }

    private void Update()
    {
        //  추후 정리 필요 지금은 무시 
        if (ispush == false)
        {
            ISPUSH = false;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("ispush : " + ISPUSH);
            Debug.Log(pushObjectName);
        }
    }

    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    /* 5가지 상호작용 버튼 중 하나를 선택하고 나서 이 함수를 실행하면 상호작용 버튼이 꺼진다. */
    public void TurnOffInteractionButton()
    {
        BaseCanvas._baseCanvas.barkButton.transform.gameObject.SetActive(false);
        BaseCanvas._baseCanvas.pushButton.transform.gameObject.SetActive(false);
        BaseCanvas._baseCanvas.pressButton.transform.gameObject.SetActive(false);
        BaseCanvas._baseCanvas.noCenterButton.transform.gameObject.SetActive(false);
        BaseCanvas._baseCanvas.eatButton.transform.gameObject.SetActive(false);
        BaseCanvas._baseCanvas.upDownButton.transform.gameObject.SetActive(false);
        BaseCanvas._baseCanvas.insertButton.transform.gameObject.SetActive(false);
        BaseCanvas._baseCanvas.observeButton.transform.gameObject.SetActive(false);
        BaseCanvas._baseCanvas.sniffButton.transform.gameObject.SetActive(false);
        BaseCanvas._baseCanvas.biteDestroyButton.transform.gameObject.SetActive(false);
        BaseCanvas._baseCanvas.insertDisableButton.transform.gameObject.SetActive(false);
        BaseCanvas._baseCanvas.upDownDisableButton.transform.gameObject.SetActive(false);
        BaseCanvas._baseCanvas.observeDisableButton.transform.gameObject.SetActive(false);

    }

    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    /* 짖기 */
    void playerBark() // 이 함수가 실행되었다는 것은 현재 플레이어가 어떤 오브젝트에 "맡기" 버튼을 클릭했다는 뜻이다.
    {
        noahBarkObject = PlayerScripts.playerscripts.currentObject; // 플레이어가 현재 선택한 오브젝트를 가져온다.
        if(noahBarkObject!=null) // 오류를 방지하기 위해 진짜 가져왔는지 한 번 확인한다. 
        {
            ObjData noahBarkData = noahBarkObject.GetComponent<ObjData>(); // 오브젝트에 대한 정보를 불러온다. 
            noahBarkData.IsBark = true; // 짖기했음 -> 이 오브젝트의 데이터에서 "짖기"를 true 로 변경

            //GameManager.gameManager.isBark = true; // 나중에 수정 필요 */
            TurnOffInteractionButton(); // 짖기 버튼이 클릭됬으므로 나머지 버튼들을 모두 끈다. 

            Invoke("ChangeBarkTrue", 0.5f); // 버튼이 클릭된지 0.5초 후 짖기 동작 실행
            Invoke("ChangeBarkFalse", 2); // 2초 후 짖기 동작을 끝냄
        }
    }

    void ChangeBarkTrue()
    {
        noahAnim.SetBool(IsBarking, true); // 동작 전환은 애니메이터의 bool 변수값을 바꿔서 전환시킬 수 있다. 
        // Asset 폴더 - Animation - playerAnmationController 를 클릭하면 현재 애니메이션 동작들이 어떻게 연결되어있고 동작 사이의 bool 변수들이 있다. 
    }

    void ChangeBarkFalse()
    {
        noahAnim.SetBool(IsBarking, false);
    }

    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    /* 냄새 맡기 */
    void playerSniff()
    {
        noahSniffObject = PlayerScripts.playerscripts.currentObject;
        ObjData noahSniffData = noahSniffObject.GetComponent<ObjData>();
        noahSniffData.IsSniff = true;
        TurnOffInteractionButton();
        Invoke("ChangeSniffTrue", 0.5f);
        Invoke("ChangeSniffFalse", 2);
        Invoke("TurnOnTheSmellPanel", 2); // 2초 후 냄새 텍스트를 띄운다. 
    }

    void ChangeSniffTrue()
    {
        noahAnim.SetBool("IsSniffing", true);
    }

    void ChangeSniffFalse()
    {
        noahAnim.SetBool("IsSniffing", false);
    }

    void TurnOnTheSmellPanel()
    {
        DialogSystem.Instance.Smell(); // DialogSystem 스크립트의 smell 함수를 실행시키면 현재 상호작용 중인 오브젝트의 냄새 텍스트가 화면에 띄워진다.
    }

    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&\

    /* 관찰하기 */
    void playerObserve()
    {
        noahObserveObject = PlayerScripts.playerscripts.currentObject;
        ObjData noahObserveData = noahObserveObject.GetComponent<ObjData>();
        noahObserveData.IsObserve = true;
        TurnOffInteractionButton();

        Invoke("ChangeObserveTrue", 0.5f); // 2개의 관찰하기 동작을 실행함
        Invoke("ChangeObserve2True", 1f);
        Invoke("ChangeObserveFalse", 2); // 관찰하기 동작을 끝냄

        Invoke("ChangeCameraView", 2); // 2초 후 관찰하기 화면으로 전환
    }

    void ChangeObserveTrue()
    {
        noahAnim.SetBool("IsObserving", true);
    }

    void ChangeObserve2True()
    {
        noahAnim.SetBool("IsObserving2", true);
    }

    void ChangeObserveFalse()
    {
        noahAnim.SetBool("IsObserving", false);
    }

    void ChangeCameraView()
    {
        CameraController.cameraController.ObserveButtonClick(); // CameraController 스크립트의 관찰하기 함수를 실행한다. 
    }

    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    /* 오르기 */
    void playerRising()
    {
        noahUpDownObject = PlayerScripts.playerscripts.currentObject;
        ObjData noahUpDownData = noahUpDownObject.GetComponent<ObjData>();

        risePosition = noahUpDownObject.transform.position; // 플레이어가 올라갈 위치를 상호작용 오브젝트로부터 받아옴
        TurnOffInteractionButton();

        if (noahUpDownData.IsUpDown == false) // 오르기 동작 전, 혹시 이미 오르기 중인지 확인함
        {
            noahUpDownData.IsUpDown = true; 

            if (playerAgent.enabled) // 오르기 동작은 NabMeshAgent을 사용하면서 원래 플레이어가 이동 가능했던 영역을 벗어나는 것이므로, navmeshagent를 잠시 끔
            {
                playerAgent.updatePosition = false;
                playerAgent.updateRotation = false;
                playerAgent.isStopped = true;
            }

            Invoke("ChangeRiseTrue", 0.5f); // 오르기 동작 5개를 실행함
            Invoke("ChangeRise2True", 1f);
            Invoke("ChangeRise3True", 1.1f);
            Invoke("ChangeRise4True", 1.2f);
            Invoke("ChangeRise5True", 1.3f);

            Invoke("noahJump", 1f); // 동작 실행중에 플레이어의 위치를 바꿈

            Invoke("ChangeRiseFalse", 1.3f); // 오르기 동작을 끝냄 

            playerAgent.isStopped = false;
        }
    }

    void ChangeRiseTrue()
    {
        noahAnim.SetBool("IsRising", true);

    }
    void ChangeRise2True()
    {
        noahAnim.SetBool("IsRising2", true);
    }
    void ChangeRise3True()
    {
        noahAnim.SetBool("IsRising3", true);
    }
    void ChangeRise4True()
    {
        noahAnim.SetBool("IsRising4", true);
    }
    void ChangeRise5True()
    {
        noahAnim.SetBool("IsRising5", true);
    }

    void ChangeRiseFalse()
    {
        noahAnim.SetBool("IsRising", false);
    }
    void noahJump()
    {
        noahPlayer.transform.position = new Vector3(risePosition.x, risePosition.y + 0.2f, risePosition.z);
    }

    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    /* 누르기 - 상자 등을 밀기 */
    void playerPush()
    {
        noahPushObject = PlayerScripts.playerscripts.currentObject;
        ObjData pushObjData = noahPushObject.GetComponent<ObjData>();
        pushObjectText.text = "Noah N.113 - " + pushObjData.ObjectName;
        noahpushobject = noahPushObject;
        pushObjectName = noahPushObject.name;
        //PlayerManager.playermanager.ISPUSH = true; 
        ispush = true;
        ISPUSH = true;
        TurnOffInteractionButton();
        Invoke("ChangePushTrue", 0.5f);
        Invoke("ChangePush2True", 0.5f);

        noahPushObject.transform.parent = noahPlayer.transform; // 밀기 오브젝트를 플레이어의 자식으로 잠시 넣어서 같이 이동하게 함
    }

    void ChangePushTrue()
    {
        noahAnim.SetBool("IsPushing", true);
    }
    void ChangePush2True()
    {
        noahAnim.SetBool("IsPushing2", true);
    }


    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    /* 끼우기 */
    void playerInserting()
    {
        noahInsertObject = PlayerScripts.playerscripts.currentObject;
        if(noahInsertObject!=null)
        {
            ObjData noahInsertData = noahInsertObject.GetComponent<ObjData>();
            noahInsertData.IsInsert = true;
            TurnOffInteractionButton();
            noahPlayer.transform.position = noahInsertObject.transform.position + new Vector3(1, 0, 1);
            noahPlayer.transform.rotation = noahInsertObject.transform.rotation;
            Invoke("ChangeInsertTrue", 0.5f);
            //Invoke("ChangeInsertFalse", 2f);
        }
    }

    void ChangeInsertTrue()
    {
        noahAnim.SetBool("IsInserting", true);
    }

    public void ChangeInsertFalse()
    {
        noahAnim.SetBool("IsInserting", false);
    }

    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    /* 먹기 */
    void playerEat()
    {
        noahEatObject = PlayerScripts.playerscripts.currentObject;
        if(noahEatObject!=null)
        {
            ObjData noahEatData = noahEatObject.GetComponent<ObjData>();
            noahEatData.IsEaten = true;
            TurnOffInteractionButton();
            Invoke("ChangeEat1True", 1f);
            Invoke("ChangeEat2True", 2f);
            Invoke("ChangeEat3True", 3f);
            Invoke("DestroyEatObject", 3.1f);
            Invoke("ChangeEat1False", 4f);
        }
    }

    void ChangeEat1True()
    {
        noahAnim.SetBool("IsEating1", true);
    }

    void ChangeEat2True()
    {
        noahAnim.SetBool("IsEating2", true);
    }
    void ChangeEat3True()
    {
        noahAnim.SetBool("IsEating3", true);
    }

    void DestroyEatObject()
    {
        Destroy(noahEatObject);
    }

    void ChangeEat1False()
    {
        noahAnim.SetBool("IsEating1", false);
    }

}
