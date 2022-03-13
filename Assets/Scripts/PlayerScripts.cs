using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScripts : MonoBehaviour
{
    public static PlayerScripts playerscripts { get; private set; }

    private NavMeshAgent agent;
    private Camera mainCamera;
    private PlayerAnimation playerAnim = new PlayerAnimation();

    private bool turning; // default : false
    private Quaternion targetRot; // 플레이어의 처음 각도

    /* 플레이어와 NPC 사이의 거리가 얼마나 가까우면 상호작용 버튼 나타나게 할지 */
    private Vector3 PlayerPosition, NPCPosition = new Vector3();
    private float DistanceBetweenPlayerandNPC = 25f;

    /* 문 클릭 시 이동할 씬*/
    public string transferMapName;

    /* bite ~ destroy 버튼 예외 처리 */
    public GameObject biteButton;
    public Sprite BiteButtonimage;

    /* 상호작용 오브젝트로부터 받아온 데이터 담는 변수 */
    private string smellData;
    private Button pushOrPressButtonData, centerButtonData, centerPlusButtonData;
    private Transform observeData, ObservePlusData; // ObservePlusData : 박스 위에서 관찰 등
    


    private Vector3 interactionButtonPosition;
    private RectTransform rectTransform;

    public GameObject interactionButtons, currentObject;


    public bool IsDoorLocked = true;
    public bool IsDoorClicked= false;
    public bool isPipeInserted = false;
    public GameObject DoorClickArea;
    public bool isDoorClickAreaClicked = false;




    private void Awake()
    {
        playerscripts = this;
        rectTransform = interactionButtons.GetComponent<RectTransform>();
    }

    void Start()
    {
        mainCamera = Camera.main; // Scene 에서 MainCamera 라고 Tag 가 첫번째로 활성화된 카메라를 나타냄
        agent = GetComponent<NavMeshAgent>();
        playerAnim.Init(GetComponentInChildren<Animator>()); // Player 의 자식인 noah_FBX 에 붙어있는 컴포넌트인 animator 초기화
    }

    void Update()
    {      
        // 왼쪽 마우스 클릭 && 마우스가 UI 위에 있지 않음
        if(Input.GetMouseButtonDown(0)&&!Extensions.IsMouseOverUI()&&(!agent.isStopped))
        {
           Onclick();
           rectTransform.anchoredPosition = Input.mousePosition;
           //interactionButtonPosition = Input.mousePosition;
           //rectTransform.anchoredPosition = Input.mousePosition;
        }

        // 회전하는 중이고(참) && 플레이어의 현재 각도와 초기 각도가 다르면??  // Q. 여기 if 문이 뭔일하는지 솔직히 모르겠음
        if(turning&&transform.rotation!=targetRot)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, 15f * Time.deltaTime); // a 각도와 b 각도 사이를 보간해줌
        }
        // NavMeshAgent 의 Velocity 전달, vector --> magnitude
        playerAnim.UpdateAnimation(agent.velocity.sqrMagnitude); // 두 점간의 거리     
    }

    void Onclick()
    {
        RaycastHit hit; //  충돌이 일어나면 코드 실행, 
        Ray camToScreen = mainCamera.ScreenPointToRay(Input.mousePosition);
        // 왼쪽 마우스 클릭을 감지하면      // Q, 이거랑 아래 hit.collider!=nulll 한번에 쓰면 안됨?? 
        if (Physics.Raycast(camToScreen, out hit, Mathf.Infinity)) // out??
        {
            if (hit.collider != null) // 무언가를 치면
            {
                if(hit.collider.name == "DoorUnLocked"&&UnLockDoor.unlockDoor.isDoorPipeInserted)
                {
                    isPipeInserted = true;
                    DoorClickArea.SetActive(true);
                    Time.timeScale = 0;
                    
                }
                if (hit.collider.name == "OpenDoorClickArea")
                {
                    isDoorClickAreaClicked = true;
                    DoorClickArea.SetActive(false);

                }

                if (hit.collider.name == "GoToWork")
                {
                    Invoke("ChangePlayerScene", 1f);
                }

                PlayerPosition = this.gameObject.transform.position;
                //pushObjectData = hit.collider.gameObject;
                Interactable interactable = hit.collider.GetComponent<Interactable>(); // interactable : 부딪힌 오브젝트 or NPC 에 붙어있는 Interactable 컴포넌트         
                ObjData objData = hit.collider.GetComponent<ObjData>();

                if (objData != null)
                {
                    smellData = objData.SmellText;
                    pushOrPressButtonData = objData.PushOrPressButton;
                    centerButtonData = objData.CenterButton;
                    centerPlusButtonData = objData.CenterPlusButton;
                    observeData = objData.ObserveView;
                    ObservePlusData = objData.ObservePlusView;
                }

                if (interactable != null) // 부딪힌 오브젝트에 interactable 컴포넌트가 붙어있으면
                {
                    currentObject = hit.collider.gameObject;
                    NPCPosition = interactable.transform.position;

                    Vector3 offset = PlayerPosition - NPCPosition;
                    float sqrLen = offset.sqrMagnitude; // 플레이어의 이동 전 현재 위치와 오브젝트 사이의 거리

                    MovePlayer(interactable.InteractPosition()); // NPC 의 위치로 플레이어를 이동시킴
                    if (sqrLen < DistanceBetweenPlayerandNPC)
                    {
                        //rectTransform.anchoredPosition = interactionButtonPosition;
                        interactable.Interact(this); // this : PlayerScript 전달 ( argument ), 현재 PlayerScript 에 있으므로 this 로 전달 가능
                        
                        //if (hit.collider.name == "DoorLocked")
                        //{
                        //    IsDoorClicked = true;
                        //    if (IsDoorLocked)
                        //    {
                        //        DialogManager.dialogManager.DoorLock();
                        //    }
                        //}
                    } // 순서가 : PlayerScripts 에서 NPC 클릭 -> Interactable 스크립트 - Interact - actions -> messageAction 실행 - > DialogSystem - ShowMessages 실행 
                }

                else // 상호작용 가능한 오브젝트가 아니면 플레이어만 이동시킴. 
                {
                    MovePlayer(hit.point); // hit.point : 이동 목적지

                }
            }
        }

    }
    public string PlayerSmellText { get { return smellData; } }
    public Button ObjectpushOrpressbutton { get { return pushOrPressButtonData; } }
    public Button ObjectCenterButton { get { return centerButtonData; } }
    public Button ObjectCenterPlusButton { get { return centerPlusButtonData; } }
    public Transform PlayerobserveView { get { return observeData; } }
    public Transform PlayerobserveBoxView { get { return ObservePlusData; } }


    /*  플레이어가 목적지에 도착하면 True 를 반환하는 메서드  */
    public bool CheckIfArrived()
    {
        // NavMeshAgent.pathPending : 계산 중이지만 아직 준비가 되지 않은 경로 -> false 면 계산 완료되었다는 뜻
        // 경로가 계산완료됨 && 남은거리보다 감속거리가 더 큼 -> 참 반환
        return (!agent.pathPending && agent.remainingDistance<=agent.stoppingDistance);
    }

    void MovePlayer(Vector3 targetPosition)
    {
        turning = false; // 움직일때마다 turning 을 거짓으로 만듬
        agent.SetDestination(targetPosition);
        //DialogSystem.Instance.HideDialog(); // 대화 도중에 움직이면 대화창을 끔
        //IsDoorClicked = false;
        biteButton.GetComponent<Image>().sprite = BiteButtonimage;
        InteractionButtonController.interactionButtonController.TurnOffInteractionButton();
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

    /* 이 메서드가 없으면 스크립터블 오브젝트는 프로그램이 종료되어도 저장한 것을 계속 저장함 */
    //private void OnApplicationQuit()
    //{
    //    inventory.Container.Clear();
    //}
}


