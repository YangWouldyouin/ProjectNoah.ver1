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
    }

    Animator noahAnim;
    private NavMeshAgent agent;
    private Camera mainCamera;
    private PlayerAnimation playerAnim = new PlayerAnimation();

    private bool turning; // default : false
    private Quaternion targetRot; // 플레이어의 처음 각도

    /* 상호작용 오브젝트로부터 받아온 데이터 담는 변수 */
    public GameObject currentObject;
    private ObjData objData;
    private string objectNameData, smellData;
    private Transform interactionDestinationData, observeData, observePlusData;
    private Button centerButton1Data, centerButton2Data, barkBtn, sniffBtn, biteBtn, smashBtn, pushOrPressBtn, centerBtn;
    private Vector3 interactionButtonOffset;
    public Vector3 nameTagPos =new Vector3(9, 54, 27.52853f);
    private ObjectData objectData;

    /* 상호작용 취소할 때 사용하는 변수 */
    [HideInInspector]
    public GameObject interactionButtons, currentPushOrPressObj, currentBiteObj, currentObserveObj, currentUpObj, currentInsertObj;

    /* 네임태그 관련 변수 */
    GameObject objectNameTag;
    TMPro.TextMeshProUGUI objectNameText;
    [HideInInspector]
    public Vector3 nameTagOffset;

    /* 정리 필요한 변수 */
    public bool IsClicked = false;
    [HideInInspector]
    public int transitionSpeed;

    public bool IsBored;
    public float boringTime;
    bool IsWalkPointSet;

    [SerializeField] float timeUntilBored;
    [SerializeField] float walkPointRange;

    Vector3 walkPoint;
    CameraFollow cameraFollow;
    LivingRoomCameraController livingRoomCamera;
    HorizontalCameraController horizontalCamera;
    ControlCameraController controlCamera;

    float elapsedTime = 0;
    float waitTime = 1.5f;

    [HideInInspector]
    public Vector3  turnAmount;
    PlayerEquipment playerEquipment;

    void Start()
    {
        playerEquipment = BaseCanvas._baseCanvas.equipment;
        objectNameTag = BaseCanvas._baseCanvas.objectNameTag;
        objectNameText = BaseCanvas._baseCanvas.objectNameText;
        noahAnim = GetComponent<Animator>();
        mainCamera = Camera.main; // Scene 에서 MainCamera 라고 Tag 가 첫번째로 활성화된 카메라를 나타냄
        cameraFollow = mainCamera.GetComponent<CameraFollow>();
        livingRoomCamera = mainCamera.GetComponent<LivingRoomCameraController>();
        horizontalCamera= mainCamera.GetComponent<HorizontalCameraController>();
        controlCamera= mainCamera.GetComponent<ControlCameraController>();
        agent = GetComponent<NavMeshAgent>();

        playerAnim.Init(GetComponentInChildren<Animator>()); // Player 의 자식인 noah_FBX 에 붙어있는 컴포넌트인 animator 초기화
    }

    void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        //if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        //{
        //    IsWalkPointSet = true;
        //}
    }

    IEnumerator WaitAndAnimation()
    {
        while (!CheckIfArrived())
        {
            yield return null;
        }

        if (cameraFollow != null)
        {
            Vector3 camerapos = new Vector3(Mathf.Clamp(transform.position.x, -264f, -251f), mainCamera.transform.position.y, Mathf.Clamp(transform.position.z, 670.1f, 690.52f));
            while (elapsedTime < waitTime)
            {
                mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, camerapos, (elapsedTime / waitTime));
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            cameraFollow.enabled = true;
        }

        if (livingRoomCamera != null)
        {
            Vector3 livingCameraPos = new Vector3(Mathf.Clamp(transform.position.x, -39f, -36f), mainCamera.transform.position.y, mainCamera.transform.position.z);
            while (elapsedTime < waitTime)
            {
                mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, livingCameraPos, (elapsedTime / waitTime));
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            livingRoomCamera.enabled = true;
        }

        if (horizontalCamera != null)
        {
            Vector3 engineCameraPos = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y, Mathf.Clamp(transform.position.z, -5.47f, 4.59f));
            while (elapsedTime < waitTime)
            {
                mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, engineCameraPos, (elapsedTime / waitTime));
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            horizontalCamera.enabled = true;
        }

        if (controlCamera != null)
        {
            Vector3 controlCameraPos = new Vector3(Mathf.Clamp(transform.position.x, -31.54f, -25.19f), mainCamera.transform.position.y, mainCamera.transform.position.z);
            while (elapsedTime < waitTime)
            {
                mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, controlCameraPos, (elapsedTime / waitTime));
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            controlCamera.enabled = true;
        }

        elapsedTime = 0;
        IsBored = false;
        boringTime = 0;
    }

    void Update()
    {      
        // 왼쪽 마우스 클릭 && 마우스가 UI 위에 있지 않음
        if(Input.GetMouseButtonDown(0)&&!Extensions.IsMouseOverUI()&&(!agent.isStopped))
        {
            Onclick();
        }

        if(!IsBored)
        {
            boringTime += Time.deltaTime;

            if(boringTime> timeUntilBored)
            {
                IsBored = true;
                if(cameraFollow!=null)
                {
                    cameraFollow.enabled = false;
                }
                if (livingRoomCamera != null)
                {
                    livingRoomCamera.enabled = false;
                }
                if (horizontalCamera != null)
                {
                    horizontalCamera.enabled = false;
                }
                if(controlCamera!=null)
                {
                    controlCamera.enabled = false;
                }
                SearchWalkPoint();
                agent.SetDestination(walkPoint);
                if(cameraFollow != null||livingRoomCamera!=null|| horizontalCamera!=null|| controlCamera!=null)
                {
                    StartCoroutine(WaitAndAnimation());
                }

                //if (!IsWalkPointSet)
                //{
                //    SearchWalkPoint();
                //}
                //if(IsWalkPointSet)
                //{

                //}
                // 노아 이동
            }
        }

        //if(targetRot.y-transform.rotation.y>)
        // 회전하는 중이고(참) && 플레이어의 현재 각도와 초기 각도가 다르면??  // Q. 여기 if 문이 뭔일하는지 솔직히 모르겠음
        //if (turning && transform.rotation != targetRot)
        //{
        //    transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, 30f * Time.deltaTime); // a 각도와 b 각도 사이를 보간해줌
        //} // NavMeshAgent 의 Velocity 전달, vector --> magnitude

        if (agent.velocity.magnitude > 1f)
        {
            turnAmount = agent.velocity;
            turnAmount.Normalize();
            turnAmount = transform.InverseTransformDirection(turnAmount);
        }

        playerAnim.UpdateAnimation(agent.velocity.sqrMagnitude, Mathf.Atan2(turnAmount.x*1000, turnAmount.z*1000)); // 두 점간의 거리     
    }

    // 순서 : PlayerScripts 에서 NPC 클릭 -> Interactable 스크립트 - Interact - actions -> messageAction 실행 - > DialogSystem - ShowMessages 실행 
    void Onclick()
    {
        TurnOffButton();
        RaycastHit hit; //  충돌이 일어나면 코드 실행, 
        Ray camToScreen = mainCamera.ScreenPointToRay(Input.mousePosition);
        // 왼쪽 마우스 클릭을 감지하면      // Q, 이거랑 아래 hit.collider!=nulll 한번에 쓰면 안됨?? 
        if (Physics.Raycast(camToScreen, out hit, Mathf.Infinity))
        {
            if (hit.collider != null) // 무언가를 치면
            {
                objData = hit.collider.GetComponent<ObjData>();
                if (objData != null)
                {
                    currentObject = hit.collider.gameObject;
                    // 오브젝트 기본 정보를 가져옴
                    objectNameData = objData.ObjectName;
                    smellData = objData.SmellText;
                    interactionDestinationData = objData.InteractionDestination;
                    observeData = objData.ObserveView;
                    observePlusData = objData.ObservePlusView;
                    interactionButtonOffset = objData.ButtonOffset;
                    objectData = objData.objectDATA;
                    // 오브젝트 기본 버튼을 가져옴
                    barkBtn = objData.BarkButton;
                    sniffBtn = objData.SniffButton;
                    biteBtn = objData.BiteButton;
                    smashBtn = objData.SmashButton;
                    pushOrPressBtn = objData.PushOrPressButton;

                    interactionButtons = objData.InteractButton;
                    Vector3 screenPos = mainCamera.WorldToScreenPoint(new Vector3(currentObject.transform.localPosition.x + interactionButtonOffset.x, currentObject.transform.localPosition.y + interactionButtonOffset.y, currentObject.transform.localPosition.z + interactionButtonOffset.z));
                    if(objectData!=null)
                    {
                        /* 오브젝트 추가 버튼을 특정 조건을 만족했는지 확인 후 가져옴 */
                        if (objectData.IsCenterButtonChanged)
                        {
                            if (objectData.IsCenterPlusButtonDisabled)
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
                            if (objectData.IsCenterButtonDisabled)
                            {
                                centerBtn = objData.CenterDisableButton1;
                            }
                            else
                            {
                                centerBtn = objData.CenterButton1;
                            }
                        }
                        objectData.IsClicked = true;
                        StartCoroutine(UnClickPortableObject());
                        //Invoke("UnClickPortableObject", 1f);


                        if (!objectData.IsNotInteractable)
                        {
                            //StartCoroutine(NameTagAppear());
                            //Invoke("NameTagAppear", 1f);
                            if(screenPos.y>500)
                            {
                                interactionButtons.transform.position = new Vector3(screenPos.x, screenPos.y-200, transform.position.z);
                            }
                            else if(screenPos.y < 200)
                            {
                                interactionButtons.transform.position = new Vector3(screenPos.x, screenPos.y + 200, transform.position.z);
                            }
                            else
                            {
                                interactionButtons.transform.position = new Vector3(screenPos.x, screenPos.y, transform.position.z);
                            }
                            

                            if (interactionDestinationData != null)
                            {
                                targetRot = objData.InteractionDestination.rotation;
                                MovePlayer(objData.InteractionDestination.position);
                            }
                            else
                            {
                                targetRot = objData.transform.rotation;
                                MovePlayer(objData.transform.position);
                            }
                            StartCoroutine(WaitforPlayerArriving());

                        }
                    }                      
                }
                else // 상호작용 가능한 오브젝트가 아니면 플레이어만 이동시킴. 
                {
                    targetRot = hit.transform.rotation;
                    //MovePlayer(new Vector3(0,0,hit.point.z));
                    MovePlayer(hit.point);
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
    public Transform PlayerobserveView { get { return observeData; } }
    public Transform PlayerobserveBoxView { get { return observePlusData; } }

    IEnumerator UnClickPortableObject()
    {
        yield return new WaitForSeconds(0.5f);
        if(objectData != null)
        {
            objectData.IsClicked = false;
        }       
    }

    /*  플레이어가 목적지에 도착하면 True 를 반환하는 메서드  */
    public bool CheckIfArrived()
    {
        // NavMeshAgent.pathPending : 계산 중이지만 아직 준비가 되지 않은 경로 -> false 면 계산 완료되었다는 뜻
        return (!agent.pathPending && agent.remainingDistance<=agent.stoppingDistance); // 경로가 계산완료됨 && 남은거리보다 감속거리가 더 큼 -> 참 반환
    }
    IEnumerator WaitforPlayerArriving()
    {
        // 1) 플레이어가 도착하지 않았으면 코루틴으로 딜레이하면서 기다림

        if(InteractionButtonController.interactionButtonController.IsUp||CameraController.cameraController.IsObserve)
        {
            yield return null;
        }
        else
        {
            while (!CheckIfArrived())
            {
                yield return null;
            }
        }
         // 안 지루함
        IsBored = false;
        boringTime = 0;

        // 네임태그 활성화
        if (objectNameData != null)
        {
            //objectNameTag.transform.position = Input.mousePosition + nameTagOffset;
            objectNameTag.transform.SetParent(sniffBtn.transform, true);
            objectNameTag.transform.localPosition = nameTagPos;
            objectNameTag.SetActive(true);
            objectNameText.text = objectNameData;
        }

        /* 상호작용 버튼 활성화 */
        barkBtn.transform.gameObject.SetActive(true);
        sniffBtn.transform.gameObject.SetActive(true);
        biteBtn.transform.gameObject.SetActive(true);
        pushOrPressBtn.transform.gameObject.SetActive(true);
        centerBtn.transform.gameObject.SetActive(true);
        // turning = false;

        if (objData.InteractionDestination != null)
        {
            SetDirection(objData.InteractionDestination);
        }
    }

    void TurnOffButton()
    {

        if (barkBtn != null)
        {
            barkBtn.transform.gameObject.SetActive(false);
        }
        if (sniffBtn != null)
        {
            sniffBtn.transform.gameObject.SetActive(false);
        }
        if (biteBtn != null)
        {
            biteBtn.transform.gameObject.SetActive(false);
            //biteBtn.GetComponent<Image>().sprite = BiteButtonimage;
        }
        if (smashBtn != null)
        {
            smashBtn.transform.gameObject.SetActive(false);
        }
        if (pushOrPressBtn != null)
        {
            pushOrPressBtn.transform.gameObject.SetActive(false);
        }
        if (centerBtn != null)
        {
            centerBtn.transform.gameObject.SetActive(false);
        }
        objectNameTag.transform.parent = null;
        objectNameTag.SetActive(false);
    }
    void MovePlayer(Vector3 targetPosition)
    {
        boringTime = 0;
        turning = false; // 움직일때마다 turning 을 거짓으로 만듬
                         //turnAmount = Mathf.Atan2(targetPosition.x, targetPosition.z);
        agent.SetDestination(targetPosition);

        //TurnOffButton();

    }

    /* 플레이어가 NPC 를 바라보도록 각도를 바꿔주는 메서드 */
    public void SetDirection(Transform targetDirection) // targetDirection : NPC 의 각도
    {
        IsBored = false;
        turning = true;
        transform.rotation = targetDirection.rotation;
    }

    IEnumerator NameTagAppear()
    {
        yield return new WaitForSeconds(1f);
        if (objectNameData != null)
        {
            objectNameTag.transform.position = Input.mousePosition + nameTagOffset;
            objectNameTag.SetActive(true);
            objectNameText.text = objectNameData;
        }
    }
}


