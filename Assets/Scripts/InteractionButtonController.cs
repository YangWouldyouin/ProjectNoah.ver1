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
    public Vector3 risePosition;

    /* "끼우기" 상호작용 관련 변수 */

    public Vector3 insertPosOffset;
    public Vector3 insertRotOffset;

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

    public GameObject myHead;

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
        BaseCanvas._baseCanvas.upDownButton.onClick.AddListener(PlayerRise1);
        BaseCanvas._baseCanvas.insertButton.onClick.AddListener(playerInserting);
        BaseCanvas._baseCanvas.pushButton.onClick.AddListener(playerPush1);
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
        BaseCanvas._baseCanvas.observeDisableButton.transform.gameObject.SetActive(false);
    }

    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    /* 짖기 */
    public void playerBark() // 이 함수가 실행되었다는 것은 현재 플레이어가 어떤 오브젝트에 "맡기" 버튼을 클릭했다는 뜻이다.
    {
        StartCoroutine(BarkAnim());
    }

    IEnumerator BarkAnim()
    {
        yield return new WaitForSeconds(0.5f);
        noahAnim.SetBool(IsBarking, true); // 동작 전환은 애니메이터의 bool 변수값을 바꿔서 전환시킬 수 있다. 
        yield return new WaitForSeconds(1.5f);
        noahAnim.SetBool(IsBarking, false);
        // Asset 폴더 - Animation - playerAnmationController 를 클릭하면 현재 애니메이션 동작들이 어떻게 연결되어있고 동작 사이의 bool 변수들이 있다. 
    }

    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    /* 냄새 맡기 */
    public void playerSniff()
    {
        StartCoroutine(SniffAnimAndText());
    }

    IEnumerator SniffAnimAndText()
    {
        yield return new WaitForSeconds(0.5f);
        noahAnim.SetBool("IsSniffing", true);
        yield return new WaitForSeconds(2f);
        noahAnim.SetBool("IsSniffing", false);
        DialogSystem.Instance.Smell(); // DialogSystem 스크립트의 smell 함수를 실행시키면 현재 상호작용 중인 오브젝트의 냄새 텍스트가 화면에 띄워진다.
    }

    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&\

    /* 관찰하기 */
    public void playerObserve()
    {
        StartCoroutine(ObserveAnimAndChangeView());
    }

    public IEnumerator ObserveAnimAndChangeView()
    {
        yield return new WaitForSeconds(0.5f);
        noahAnim.SetBool("IsObserving", true);
        yield return new WaitForSeconds(1f);
        noahAnim.SetBool("IsObserving2", true);
        yield return new WaitForSeconds(1f);
        noahAnim.SetBool("IsObserving", false);
        CameraController.cameraController.ObserveButtonClick(); // CameraController 스크립트의 관찰하기 함수를 실행한다. 
    }

    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    /* 오르기 */
    public void PlayerRise1()
    {
        if (playerAgent.enabled) // 오르기 동작은 NabMeshAgent을 사용하면서 원래 플레이어가 이동 가능했던 영역을 벗어나는 것이므로, navmeshagent를 잠시 끔
        {
            playerAgent.updatePosition = false;
            playerAgent.updateRotation = false;
            playerAgent.isStopped = true;
            StartCoroutine(RiseAnim1());
        }
    }

    public void PlayerRise2()
    {
        StartCoroutine(RiseAnim2());
        playerAgent.isStopped = false;
    }

    IEnumerator RiseAnim1()
    {
        yield return new WaitForSeconds(0.5f);
        noahAnim.SetBool("IsRising", true);
        yield return new WaitForSeconds(0.4f);
        noahAnim.SetBool("IsRising2", true);
    }

    IEnumerator RiseAnim2()
    {
        yield return new WaitForSeconds(1f);
        noahPlayer.transform.position = risePosition; // 동작 실행중에 플레이어의 위치를 바꿈
        yield return new WaitForSeconds(0.000001f);
        noahAnim.SetBool("IsRising3", true);
        yield return new WaitForSeconds(0.000001f);
        noahAnim.SetBool("IsRising4", true);
        yield return new WaitForSeconds(0.000001f);
        noahAnim.SetBool("IsRising5", true);
        yield return new WaitForSeconds(0.000001f);
        noahAnim.SetBool("IsRising", false);
    }

    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    /* 끼우기 */
    //void playerInserting()
    //{
    //        noahPlayer.transform.position = noahInsertObject.transform.position + new Vector3(1, 0, 1);
    //        noahPlayer.transform.rotation = noahInsertObject.transform.rotation;
            
        
    //}
    public void PlayerInsert1()
    {
        noahPlayer.transform.position = PlayerScripts.playerscripts.currentInsertObj.transform.position + insertPosOffset;
        //noahPlayer.transform.eulerAngles = PlayerScripts.playerscripts.currentInsertObj.transform.rotation + insertRotOffset;
    }

    public void PlayerInsert2()
    {
        StartCoroutine(InsertAnim());
    }

    IEnumerator InsertAnim()
    {
        yield return new WaitForSeconds(0.5f);
        noahAnim.SetBool("IsInserting", true);
    }

    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    /* 누르기 - 상자 등을 밀기 */
    public void playerPush1() // 도착했을 때 위치 조절하면 괜찮아질듯
    {
        noahPushObject = PlayerScripts.playerscripts.currentObject;
        ObjData pushObjData = noahPushObject.GetComponent<ObjData>();
        pushObjectText.text = "Noah N.113 - " + pushObjData.ObjectName;

        ISPUSH = true;

        noahPushObject.GetComponent<Rigidbody>().isKinematic = true;   //makes the rigidbody not be acted upon by forces
        noahPushObject.GetComponent<Rigidbody>().useGravity = false;
        //noahPushObject.transform.parent = myHead.transform;

        noahPushObject.transform.parent.position= myHead.transform.position; //makes the object become a child of the parent so that it moves with the mouth

        //noahPushObject.transform.localPosition = new Vector3(0, 0, 0); // sets the position of the object to your mouth position
        //noahPushObject.transform.localEulerAngles = new Vector3(0, 0, 0); // sets the position of the object to your mouth position  
        //noahPushObject.transform.parent = noahPlayer.transform; // 밀기 오브젝트를 플레이어의 자식으로 잠시 넣어서 같이 이동하게 함
    }

    public void PlayerPush2()
    {
        StartCoroutine(PushAnim());
    }
    IEnumerator PushAnim()
    {
         noahPushObject.transform.parent = noahPlayer.transform; // 밀기 오브젝트를 플레이어의 자식으로 잠시 넣어서 같이 이동하게 함
        yield return new WaitForSeconds(0.5f);
        noahAnim.SetBool("IsPushing", true);
        yield return new WaitForSeconds(0.5f);
        noahAnim.SetBool("IsPushing2", true);
    }


    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    public void playerPressHand()
    {
        StartCoroutine(HandPressAnim());
    }

    IEnumerator HandPressAnim()
    {
        yield return new WaitForSeconds(0.5f);
        noahAnim.SetBool("IsHandPressing", true);
        yield return new WaitForSeconds(0.5f);
        noahAnim.SetBool("IsHandPressing", false);
    }

    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    public void playerPressHead()
    {
        StartCoroutine(HeadPressAnim());
    }
    IEnumerator HeadPressAnim()
    {
        yield return new WaitForSeconds(0.5f);
        noahAnim.SetBool("IsHeadPressing", true);
        yield return new WaitForSeconds(0.5f);
        noahAnim.SetBool("IsHeadPressing", false);
    }

    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    /* 먹기 */
    public void playerEat()
    {
        noahEatObject = PlayerScripts.playerscripts.currentObject;
        StartCoroutine(EatAnim());
    }

    IEnumerator EatAnim()
    {
        yield return new WaitForSeconds(1f);
        noahAnim.SetBool("IsEating1", true);
        yield return new WaitForSeconds(1f);
        noahAnim.SetBool("IsEating2", true);
        yield return new WaitForSeconds(1f);
        noahAnim.SetBool("IsEating3", true);
        yield return new WaitForSeconds(0.1f);
        Destroy(noahEatObject);
        yield return new WaitForSeconds(0.9f);
        noahAnim.SetBool("IsEating1", false);
    }
}
