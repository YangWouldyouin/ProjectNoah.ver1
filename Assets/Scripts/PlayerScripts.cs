using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScripts : MonoBehaviour
{
    public static PlayerScripts playerscripts { get; private set; }
    private void Awake()
    {
        playerscripts = this;
        rectTransform = interactionButtons.GetComponent<RectTransform>();
    }

    private NavMeshAgent agent;
    private Camera mainCamera;
    private PlayerAnimation playerAnim = new PlayerAnimation();

    private bool turning; // default : false
    private Quaternion targetRot; // 플레이어의 처음 각도

    /* 문 클릭 시 이동할 씬*/
    public string transferMapName;

    /* bite ~ destroy 버튼 예외 처리 */
    public GameObject biteButton;
    public Sprite BiteButtonimage;

    /* 상호작용 오브젝트로부터 받아온 데이터 담는 변수 */
    [HideInInspector]
    public GameObject currentObject;
    private ObjData objData;
    private string objectNameData, smellData;
    private Transform observeData, observePlusData; // ObservePlusData : 박스 위에서 관찰 등
    private Button centerButton1Data, centerButton2Data, barkBtn, sniffBtn, biteDestroyBtn, pushOrPressBtn, centerBtn;

    /* 상호작용 취소할 때 사용하는 변수 */

    public GameObject currentPushOrPressObj, currentBiteObj, currentObserveObj, currentUpObj, currentInsertObj;

    public Vector3 biteFallPos, biteFallRot, biteOriginScale, pushOriginScale;

    /* 상호작용 버튼 생성 위치 관련 변수 */
    private Vector3 interactionButtonPosition;
    private RectTransform rectTransform;
    public GameObject interactionButtons;

    /* 네임태그 관련 변수 */
    public GameObject objectNameTag;
    public TMPro.TextMeshProUGUI objectNameText;
    public Vector3 offset;

    /* 정리 필요한 변수 */
    public bool IsClicked = false;
    public Animator noahAnim;
    public IPressController pressFunc;

    void Start()
    {
        mainCamera = Camera.main; // Scene 에서 MainCamera 라고 Tag 가 첫번째로 활성화된 카메라를 나타냄
        agent = GetComponent<NavMeshAgent>();
        playerAnim.Init(GetComponentInChildren<Animator>()); // Player 의 자식인 noah_FBX 에 붙어있는 컴포넌트인 animator 초기화
    }

    void Update()
    {
        // 왼쪽 마우스 클릭 && 마우스가 UI 위에 있지 않음
        if (Input.GetMouseButtonDown(0) && !Extensions.IsMouseOverUI() && (!agent.isStopped))
        {
            Onclick();
            if (Input.mousePosition.y >= 570)
            {
                rectTransform.anchoredPosition = Input.mousePosition + new Vector3(0, -150, 0);
            }
            else
            {
                rectTransform.anchoredPosition = Input.mousePosition;
            }
        }

        // 회전하는 중이고(참) && 플레이어의 현재 각도와 초기 각도가 다르면??  // Q. 여기 if 문이 뭔일하는지 솔직히 모르겠음
        if (turning && transform.rotation != targetRot)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, 15f * Time.deltaTime); // a 각도와 b 각도 사이를 보간해줌
        } // NavMeshAgent 의 Velocity 전달, vector --> magnitude
        playerAnim.UpdateAnimation(agent.velocity.sqrMagnitude); // 두 점간의 거리     
    }

    // 순서 : PlayerScripts 에서 NPC 클릭 -> Interactable 스크립트 - Interact - actions -> messageAction 실행 - > DialogSystem - ShowMessages 실행 
    void Onclick()
    {
        RaycastHit hit; //  충돌이 일어나면 코드 실행, 
        Ray camToScreen = mainCamera.ScreenPointToRay(Input.mousePosition);
        // 왼쪽 마우스 클릭을 감지하면      // Q, 이거랑 아래 hit.collider!=nulll 한번에 쓰면 안됨?? 
        if (Physics.Raycast(camToScreen, out hit, Mathf.Infinity))
        {
            if (hit.collider != null) // 무언가를 치면
            {
                //PlayerPosition = this.gameObject.transform.position;
                Interactable interactable = hit.collider.GetComponent<Interactable>(); // interactable : 부딪힌 오브젝트 or NPC 에 붙어있는 Interactable 컴포넌트         
                objData = hit.collider.GetComponent<ObjData>();
                if (objData != null)
                {
                    // 오브젝트 기본 정보를 가져옴
                    objectNameData = objData.ObjectName;
                    smellData = objData.SmellText;
                    centerButton1Data = objData.CenterButton1;
                    centerButton2Data = objData.CenterButton2;

                    observeData = objData.ObserveView;
                    observePlusData = objData.ObservePlusView;

                    // 오브젝트 기본 버튼을 가져옴
                    barkBtn = objData.BarkButton;
                    sniffBtn = objData.SniffButton;
                    biteDestroyBtn = objData.BiteDestroyButton;
                    pushOrPressBtn = objData.PushOrPressButton;

                    /* 오브젝트 추가 버튼을 특정 조건을 만족했는지 확인 후 가져옴 */
                    if (objData.IsCenterButtonChanged)
                    {
                        if (objData.IsCenterPlusButtonDisabled)
                        {
                            centerBtn = objData.CenterDisableButton2;
                        }
                        else
                        {
                            centerBtn = objData.CenterButton2;
                        }
                    }
                    else
                    {
                        if (objData.IsCenterButtonDisabled)
                        {
                            centerBtn = objData.CenterDisableButton1;
                        }
                        else
                        {
                            centerBtn = objData.CenterButton1;
                        }
                    }

                    currentObject = hit.collider.gameObject;

                    objData.IsClicked = true;
                    //Invoke("UnClickObject", 1f);
                    if (!objData.IsNotInteractable)
                    {
                        Invoke("NameTagAppear", 1f);
                        MovePlayer(objData.transform.position);

                        /* 상호작용 버튼 활성화 */
                        barkBtn.transform.gameObject.SetActive(true);
                        sniffBtn.transform.gameObject.SetActive(true);
                        biteDestroyBtn.transform.gameObject.SetActive(true);
                        pushOrPressBtn.transform.gameObject.SetActive(true);
                        centerBtn.transform.gameObject.SetActive(true);

                        //interactable.Interact(this); // this : PlayerScript 전달 ( argument ), 현재 PlayerScript 에 있으므로 this 로 전달 가능
                    }
                }
                else // 상호작용 가능한 오브젝트가 아니면 플레이어만 이동시킴. 
                {
                    MovePlayer(hit.point);

                    if (hit.collider.name == "ChangeScene")
                    {
                        Invoke("ChangePlayerScene", 1f);
                    }
                }


                //if (interactable != null) // 부딪힌 오브젝트에 interactable 컴포넌트가 붙어있으면
                //{
                //    currentObject = hit.collider.gameObject;

                //    objData.IsClicked = true;
                //    //Invoke("UnClickObject", 1f);
                //    if (!objData.IsNotInteractable)
                //    {
                //        Invoke("NameTagAppear", 1f);
                //        MovePlayer(interactable.InteractPosition());

                //        // 상호작용 버튼 활성화
                //        barkBtn.transform.gameObject.SetActive(true);
                //        sniffBtn.transform.gameObject.SetActive(true);
                //        biteDestroyBtn.transform.gameObject.SetActive(true);
                //        pushOrPressBtn.transform.gameObject.SetActive(true);
                //        centerBtn.transform.gameObject.SetActive(true);

                //        //interactable.Interact(this); // this : PlayerScript 전달 ( argument ), 현재 PlayerScript 에 있으므로 this 로 전달 가능
                //    }
                //}

            }
        }
    }
    public string PlayerObjectName { get { return objectNameData; } }
    public string PlayerSmellText { get { return smellData; } }
    public Button ObjectCenterButton { get { return centerButton1Data; } }
    public Button ObjectCenterPlusButton { get { return centerButton2Data; } }
    public Transform PlayerobserveView { get { return observeData; } }
    public Transform PlayerobserveBoxView { get { return observePlusData; } }

    void UnClickObject()
    {
        if (objData != null)
        {
            objData.IsClicked = false;
        }
    }

    /*  플레이어가 목적지에 도착하면 True 를 반환하는 메서드  */
    public bool CheckIfArrived()
    {
        // NavMeshAgent.pathPending : 계산 중이지만 아직 준비가 되지 않은 경로 -> false 면 계산 완료되었다는 뜻
        return (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance); // 경로가 계산완료됨 && 남은거리보다 감속거리가 더 큼 -> 참 반환
    }

    void MovePlayer(Vector3 targetPosition)
    {
        turning = false; // 움직일때마다 turning 을 거짓으로 만듬
        agent.SetDestination(targetPosition);
        //biteButton.GetComponent<Image>().sprite = BiteButtonimage;


        //IbarkBtnnteractionButtonController.interactionButtonController.TurnOffInteractionButton();
        if (barkBtn != null)
            barkBtn.transform.gameObject.SetActive(false);
        if (sniffBtn != null)
            sniffBtn.transform.gameObject.SetActive(false);
        if (biteDestroyBtn != null)
        {
            biteDestroyBtn.transform.gameObject.SetActive(false);
            biteDestroyBtn.GetComponent<Image>().sprite = BiteButtonimage;
        }

        if (pushOrPressBtn != null)
            pushOrPressBtn.transform.gameObject.SetActive(false);
        if (centerBtn != null)
            centerBtn.transform.gameObject.SetActive(false);

        objectNameTag.SetActive(false);
    }

    /* 플레이어가 NPC 를 바라보도록 각도를 바꿔주는 메서드 */
    public void SetDirection(Vector3 targetDirection) // targetDirection : NPC 의 각도
    {
        turning = true;
        targetRot = Quaternion.LookRotation(targetDirection - transform.position);
    }

    void ChangePlayerScene()
    {
        SceneManager.LoadScene(transferMapName);
    }

    void NameTagAppear()
    {
        if (objectNameData != null)
        {
            objectNameTag.transform.position = Input.mousePosition + offset;
            objectNameTag.SetActive(true);
            objectNameText.text = objectNameData;
        }
    }
    /* 이 메서드가 없으면 스크립터블 오브젝트는 프로그램이 종료되어도 저장한 것을 계속 저장함 */
    //private void OnApplicationQuit()
    //{
    //    inventory.Container.Clear();
    //}
}


