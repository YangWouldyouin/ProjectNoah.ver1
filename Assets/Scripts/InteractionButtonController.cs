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

    public GameObject portableObjects;

    GameObject noahPlayer, noahFBX, myMouth;
    Animator noahAnim;

    /* "오르기" 상호작용 관련 변수*/
    Rigidbody playerRigidbody;
    NavMeshAgent playerAgent;
    [HideInInspector]
    public Vector3 risePosition;

    /* "끼우기" 상호작용 관련 변수 */
    [HideInInspector]
    public Vector3 insertPosOffset;
    [HideInInspector]
    public Vector3 insertRotOffset;

    /* 현재 상호작용 중인 오브젝트를 받아오기 위한 변수 */
    [HideInInspector]
    public GameObject noahBiteObject, noahSmashObject, noahPressObject, noahPushObject, noahSniffObject, 
        noahBarkObject, noahUpDownObject, noahInsertObject, noahObserveObject, noahEatObject;

    TMPro.TextMeshProUGUI objectText, statText;
    GameObject statPanel;

    ObjData objData, biteData, upDownData, pushData, pressData;
    //ObjectData objectData;
    PlayerEquipment equipment;

    private static readonly int IsBarking = Animator.StringToHash("IsBarking"); // 문자열 비교보다 int 비교가 더 빠름

    [Header("< 사운드 관련 변수 >")]
    AudioSource interactionAudio; // 오디오 소스는 하나만 있어도 됨
    public AudioClip BasicUI_Click; // UI 클릭
    public AudioClip Noah_Bark; // 노아_짖기
    public AudioClip Noah_Eat; // 노아_먹기
    public AudioClip DropBox; // 상자 내려놓기

    [Header("< 스팀 업적 관련 변수 >")]
    public SteamAchieveData achieveData;

    Camera mainCamera;
    CameraFollow cameraFollow;
    Vector3 camerapos;

    void Awake()
    {
        interactionButtonController = this;
    }

    private void Start()
    {
        mainCamera = Camera.main; // Scene 에서 MainCamera 라고 Tag 가 첫번째로 활성화된 카메라를 나타냄
        cameraFollow = mainCamera.GetComponent<CameraFollow>();

        interactionAudio = GetComponent<AudioSource>();

        noahPlayer = BaseCanvas._baseCanvas.noahPlayer;
        noahFBX = BaseCanvas._baseCanvas.noahFBX;
        equipment = BaseCanvas._baseCanvas.equipment;

        objectText = BaseCanvas._baseCanvas.objectText;
        statText = BaseCanvas._baseCanvas.statText;
        statPanel = BaseCanvas._baseCanvas.statPanel;
        myMouth = BaseCanvas._baseCanvas.myMouth;

        playerRigidbody = noahPlayer.GetComponent<Rigidbody>();
        playerAgent = noahPlayer.GetComponent<NavMeshAgent>();
        noahAnim = noahPlayer.GetComponent<Animator>();
    }

    private void Update()
    {
        //if(Input.GetKeyDown(KeyCode.O))
        //{
        //    noahAnim.SetBool("Die1", true);
        //}
    }
    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    /* 짖기 */
    public void playerBark() // 이 함수가 실행되었다는 것은 현재 플레이어가 어떤 오브젝트에 "맡기" 버튼을 클릭했다는 뜻이다.
    {
        /* 스팀 업적 카운트 */
        if (achieveData.barkCount < 50)
        {
            achieveData.barkCount += 1;
        }
        /* 버튼 누르는 소리 */
        interactionAudio.clip = BasicUI_Click; // 1. 오디오소스에 플레이하고 싶은 소리 클립을 넣는다. 
        interactionAudio.Play(); // 2. 재생한다.

        noahBarkObject = PlayerScripts.playerscripts.currentObject;
        objData = noahBarkObject.GetComponent<ObjData>();
        objData.objectDATA.IsBark = true;

        StartCoroutine(BarkAnim());
    }

    IEnumerator BarkAnim()
    {
        yield return new WaitForSeconds(0.5f);
        noahAnim.SetBool(IsBarking, true); 

        /* 짖는 소리 */
        interactionAudio.clip = Noah_Bark; // 1. 오디오소스에 플레이하고 싶은 소리 클립을 넣는다. 
        interactionAudio.Play(); // 2. 재생한다.

        yield return new WaitForSeconds(1.5f);
        noahAnim.SetBool(IsBarking, false);
    }

    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    /* 물기 - 물기 불가능 오브젝트 일 때 */
    public void PlayerCanNotBite()
    {
        StartCoroutine(BiteAnim());
    }

    IEnumerator BiteAnim()
    {
        yield return new WaitForSeconds(0.5f);
        noahAnim.SetBool("IsBiting", true);
        yield return new WaitForSeconds(1f);
        noahAnim.SetBool("IsBiting", false);
        statPanel.SetActive(true);
        statText.text = " 물 수 없는 오브젝트 입니다. ";
        yield return new WaitForSeconds(3f);
        statPanel.SetActive(false);
    }

    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    /* 물기 - 가능한 오브젝트 일때 */
    public void PlayerBite()
    {
        if(equipment.biteObjectName=="" && equipment.pushObjectName=="") // 물기 2번 or 물기 밀기 같이 방지
        {
            /* 스팀 업적 카운트 */
            if (achieveData.biteCount < 50)
            {
                achieveData.biteCount += 1;
            }

            /* 버튼 누르는 소리 */
            interactionAudio.clip = BasicUI_Click; // 1. 오디오소스에 플레이하고 싶은 소리 클립을 넣는다. 
            interactionAudio.Play(); // 2. 재생한다.

            if (noahPushObject == null)
            {
                if (PlayerScripts.playerscripts.currentObject != null)
                {
                    noahBiteObject = PlayerScripts.playerscripts.currentObject;
                    /* 취소할 때 참고하기 위해 저장 */
                    equipment.biteObjectName = noahBiteObject.name;

                    equipment.cancelBitePos = noahBiteObject.transform.position;
                    equipment.cancelBiteRot = noahBiteObject.transform.eulerAngles;
                    equipment.cancelBiteScale = noahBiteObject.transform.localScale;

                    biteData = noahBiteObject.GetComponent<ObjData>();
                    biteData.objectDATA.IsBite = true;



                    /* 현재 물고 있는 오브젝트 이름 띄움 */
                    objectText.text = "Noah N.113 - " + biteData.ObjectName;

                    Invoke("ChangeBiteTrue", 0.5f);
                    Invoke("PlayerPickUp", 0.7f);
                    Invoke("ChangeBiteFalse", 1);
                }
            }
        }

    }

    void ChangeBiteTrue()
    {
        noahAnim.SetBool("IsBiting", true);
    }

    void PlayerPickUp()
    {
        noahBiteObject.GetComponent<Rigidbody>().isKinematic = true;   //makes the rigidbody not be acted upon by forces
        noahBiteObject.GetComponent<Rigidbody>().useGravity = false;

        noahBiteObject.transform.SetParent(myMouth.transform, true);

        noahBiteObject.transform.localPosition = biteData.BitePos; // sets the position of the object to your mouth position
        noahBiteObject.transform.localEulerAngles = biteData.BiteRot; // sets the position of the object to your mouth position      
    }

    void ChangeBiteFalse()
    {
        noahAnim.SetBool("IsBiting", false);
    }

    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    /* 물기 취소 */
    public void CancelBite()
    {
        noahBiteObject = GameObject.Find(equipment.biteObjectName).gameObject;

        if (noahBiteObject!=null)
        {
            biteData = noahBiteObject.GetComponent<ObjData>();
            biteData.objectDATA.IsBite = false;
            equipment.biteObjectName = "";
            noahAnim.SetBool("IsPutDowning", true);
            Invoke("CancelBitingAnimation", 1f);
            Invoke("PutDownObject", 0.3f);

        }
    }
    void CancelBitingAnimation()
    {
        noahAnim.SetBool("IsPutDowning", false);
    }
    void PutDownObject()
    {
        noahBiteObject.GetComponent<Rigidbody>().isKinematic = false;
        noahBiteObject.transform.parent = null;

        noahBiteObject.transform.localScale = equipment.cancelBiteScale;
        noahBiteObject.transform.position = new Vector3(noahBiteObject.transform.position.x, equipment.cancelBitePos.y, noahBiteObject.transform.position.z);
        noahBiteObject.transform.eulerAngles = equipment.cancelBiteRot;
        
        noahBiteObject.transform.parent = portableObjects.transform;

        noahBiteObject = null;
        biteData = null;
    }

    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
    /* 파괴하기 */

    public void PlayerSmash1()
    {
        /* 스팀 업적 카운트 */
        if (achieveData.destroyCount < 50)
        {
            achieveData.destroyCount += 1;
        }

        /* 버튼 누르는 소리 */
        interactionAudio.clip = BasicUI_Click; // 1. 오디오소스에 플레이하고 싶은 소리 클립을 넣는다. 
        interactionAudio.Play(); // 2. 재생한다.

        noahSmashObject = PlayerScripts.playerscripts.currentObject;
        objData = noahSmashObject.GetComponent<ObjData>();
        objData.objectDATA.IsSmash =  true;

        Invoke("ChangeDestroyTrue", 1f);
    }

    public void PlayerSmash2()
    {
        Invoke("ChangeDestroyFalse", 3f);
    }

    void ChangeDestroyTrue()
    {
        noahAnim.SetBool("IsDestroying", true);
    }

    void ChangeDestroyFalse()
    {

        noahAnim.SetBool("IsDestroying", false);
    }


    public void PlayerCanNotSmash()
    {
        objData = noahSmashObject.GetComponent<ObjData>();
        objData.objectDATA.IsSmash = false;
        StartCoroutine(CanNotSmashText());
    }

    IEnumerator CanNotSmashText()
    {
        statPanel.SetActive(true);
        statText.text = " 너무 딱딱해서 파괴할 수 없습니다. ";
        yield return new WaitForSeconds(3f);
        statPanel.SetActive(false);
    }

    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    /* 냄새 맡기 */
    public void playerSniff()
    {
        /* 스팀 업적 카운트 */
        if (achieveData.smellCount < 50)
        {
            achieveData.smellCount += 1;
        }

        /* 버튼 누르는 소리 */
        interactionAudio.clip = BasicUI_Click; // 1. 오디오소스에 플레이하고 싶은 소리 클립을 넣는다. 
        interactionAudio.Play(); // 2. 재생한다.

        noahSniffObject = PlayerScripts.playerscripts.currentObject;
        objData = noahSniffObject.GetComponent<ObjData>();
        objData.objectDATA.IsSniff = true;

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
        /* 스팀 업적 카운트 */
        if (achieveData.observeCount < 50)
        {
            achieveData.observeCount += 1;
        }

        /* 버튼 누르는 소리 */
        interactionAudio.clip = BasicUI_Click; // 1. 오디오소스에 플레이하고 싶은 소리 클립을 넣는다. 
        interactionAudio.Play(); // 2. 재생한다.

        StartCoroutine(ObserveAnimAndChangeView());
    }

    public IEnumerator ObserveAnimAndChangeView()
    {
        CameraController.cameraController.SavePosition();
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
    //public void PlayerRise1()
    //{
    //    /* 스팀 업적 카운트 */
    //    if (achieveData.upCount < 50)
    //    {
    //        achieveData.upCount += 1;
    //    }

    //    /* 버튼 누르는 소리 */
    //    interactionAudio.clip = BasicUI_Click; // 1. 오디오소스에 플레이하고 싶은 소리 클립을 넣는다. 
    //    interactionAudio.Play(); // 2. 재생한다.

    //    noahUpDownObject = PlayerScripts.playerscripts.currentObject;
    //    upDownData = noahUpDownObject.GetComponent<ObjData>();
    //    upDownData.objectDATA.IsUpDown = true;

    //    if (playerAgent.enabled) // 오르기 동작은 NabMeshAgent을 사용하면서 원래 플레이어가 이동 가능했던 영역을 벗어나는 것이므로, navmeshagent를 잠시 끔
    //    {
    //        playerAgent.updatePosition = false;
    //        playerAgent.updateRotation = false;
    //        playerAgent.isStopped = true;
    //        StartCoroutine(RiseAnim1());
    //    }
    //}

    //public void PlayerRise2()
    //{
    //    StartCoroutine(RiseAnim2());
    //    playerAgent.isStopped = false;
    //}

    //IEnumerator RiseAnim1()
    //{
    //    yield return new WaitForSeconds(0.5f);
    //    noahAnim.SetBool("IsRising", true);
    //    yield return new WaitForSeconds(0.4f);
    //    noahAnim.SetBool("IsRising2", true);
    //}

    //IEnumerator RiseAnim2()
    //{
    //    yield return new WaitForSeconds(1f);
    //    noahPlayer.transform.position = risePosition; // 동작 실행중에 플레이어의 위치를 바꿈
    //    yield return new WaitForSeconds(0.000001f);
    //    noahAnim.SetBool("IsRising3", true);
    //    yield return new WaitForSeconds(0.000001f);
    //    noahAnim.SetBool("IsRising4", true);
    //    yield return new WaitForSeconds(0.000001f);
    //    noahAnim.SetBool("IsRising5", true);
    //    yield return new WaitForSeconds(0.000001f);
    //    noahAnim.SetBool("IsRising", false);
    //}

    public void PlayerRise1()
    {
        camerapos = new Vector3(Mathf.Clamp(noahPlayer.transform.position.x, -262f, -251f), mainCamera.transform.position.y, Mathf.Clamp(noahPlayer.transform.position.z, 672f, 688f));
        if (cameraFollow!=null)
        {
            cameraFollow.enabled = false;
        }
        /* 스팀 업적 카운트 */
        if (achieveData.upCount < 50)
        {
            achieveData.upCount += 1;
        }

        /* 버튼 누르는 소리 */
        interactionAudio.clip = BasicUI_Click; // 1. 오디오소스에 플레이하고 싶은 소리 클립을 넣는다. 
        interactionAudio.Play(); // 2. 재생한다.

        noahUpDownObject = PlayerScripts.playerscripts.currentObject;
        upDownData = noahUpDownObject.GetComponent<ObjData>();
        upDownData.objectDATA.IsUpDown = true;

        if (playerAgent.enabled) // 오르기 동작은 NabMeshAgent을 사용하면서 원래 플레이어가 이동 가능했던 영역을 벗어나는 것이므로, navmeshagent를 잠시 끔
        {
            playerAgent.updatePosition = false;
            playerAgent.updateRotation = false;
            playerAgent.isStopped = true;
            noahAnim.SetBool("Jump", true);
            //StartCoroutine(RiseAnim1());
        }
    }

    IEnumerator RiseAnim1()
    {
        //noahPlayer.transform.position = risePosition; // 동작 실행중에 플레이어의 위치를 바꿈
        yield return new WaitForSeconds(0.025f);
        noahAnim.SetBool("Jump2", true);
        //yield return null;

    }
    IEnumerator RiseAnim2()
    {
        float i = 0;
        while (i<1f)
        {
            noahPlayer.transform.position = Vector3.Lerp(noahPlayer.transform.position, risePosition, (i/1));
            Debug.Log("올라김");
            i += Time.deltaTime;
            yield return null;
        }
        //noahPlayer.transform.position = risePosition; // 동작 실행중에 플레이어의 위치를 바꿈
        //yield return new WaitForSeconds(0.025f);
        noahAnim.SetBool("Jump", false);
    }

    public void PlayerRise2()
    {
        StartCoroutine(RiseAnim1());
        StartCoroutine(RiseAnim2());
        noahAnim.SetBool("Jump2", false);
        playerAgent.isStopped = false;
    }

    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    /* 내려가기 */

    //public void PlayerFall1()
    //{
    //    upDownData = noahUpDownObject.GetComponent<ObjData>();
    //    if (upDownData.objectDATA.IsUpDown)
    //    {
    //        if (playerAgent.enabled) // 오르기 동작은 NabMeshAgent을 사용하면서 원래 플레이어가 이동 가능했던 영역을 벗어나는 것이므로, navmeshagent를 잠시 끔
    //        {
    //            Vector3 fallrot = noahPlayer.transform.eulerAngles;
    //            noahPlayer.transform.eulerAngles = new Vector3(fallrot.x, fallrot.y - 180, fallrot.z);

                
    //            //playerAgent.updatePosition = true;
    //            //playerAgent.updateRotation = true;
    //            playerAgent.isStopped = true;
    //            Invoke("ChangeFallTrue1", 0.5f);
    //            Invoke("ChangeFallTrue2", 1.1f);
    //            Invoke("ChangeFallTrue3", 1.5f);
    //            //Invoke("ChangeFallTrue4", 2.5f);
    //            Invoke("ChangeFallFalse1", 2.5f);
    //            //Invoke("TurnOnNav", 4f);
    //        }
    //        upDownData.objectDATA.IsUpDown = false;

    //        noahUpDownObject = null;
    //        upDownData = null;
    //    }

    //}

    //void ChangeFallTrue1()
    //{
    //    noahAnim.SetBool("Falling1", true);
    //}

    //void ChangeFallTrue2()
    //{
    //    //noahPlayer.transform.position = new Vector3(noahUpDownObject.transform.localPosition.x + 3, 0.8883325f, noahUpDownObject.transform.localPosition.z) + transform.forward;
    //    noahAnim.SetBool("Falling2", true);

    //}
    //void ChangeFallTrue3()
    //{
    //    noahAnim.SetBool("Falling3", true);
    //    noahAnim.SetBool("Falling4", true);
    //    noahPlayer.transform.position = new Vector3(noahPlayer.transform.position.x, 0.8883325f, noahPlayer.transform.position.z+1);
    //}
    //void ChangeFallTrue4()
    //{

    //    //upDownData = noahUpDownObject.GetComponent<ObjData>();
    //    //Vector3 fallPosition = upDownData.DownPos.position;

    //    //noahPlayer.transform.position = fallPosition;


    //}
    //void ChangeFallFalse1()
    //{
 
    //    playerAgent.isStopped = false;


    //    playerAgent.updatePosition = true;
    //    playerAgent.updateRotation = true;
    //    noahAnim.SetBool("Falling1", false);

    //}

    public void PlayerFall1()
    {
        upDownData = noahUpDownObject.GetComponent<ObjData>();
        if (upDownData.objectDATA.IsUpDown)
        {
            if (playerAgent.enabled) // 오르기 동작은 NabMeshAgent을 사용하면서 원래 플레이어가 이동 가능했던 영역을 벗어나는 것이므로, navmeshagent를 잠시 끔
            {
                Vector3 fallrot = noahPlayer.transform.eulerAngles;
                noahPlayer.transform.eulerAngles = new Vector3(fallrot.x, fallrot.y - 180, fallrot.z);


                //playerAgent.updatePosition = true;
                //playerAgent.updateRotation = true;
                playerAgent.isStopped = true;
                noahAnim.SetBool("Down", true);
                StartCoroutine(Down2());
                noahAnim.SetBool("Down2", false);
            }
            upDownData.objectDATA.IsUpDown = false;

            noahUpDownObject = null;
            upDownData = null;
            //if (cameraFollow != null)
            //{
            //    StartCoroutine(StartCameraFollow());
            //}
        }
    }

    IEnumerator Down2()
    {
        yield return new WaitForSeconds(0.025f);
        noahAnim.SetBool("Down2", true); 
        yield return new WaitForSeconds(0.05f);
        noahAnim.SetBool("Down", false);
        playerAgent.updatePosition = true;
        playerAgent.updateRotation = true;
        playerAgent.isStopped = false;
        if (cameraFollow != null)
        {
            float elapsedTime = 0;
            
            while (elapsedTime < 1.5f)
            {
                mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, camerapos, (elapsedTime / 1.5f));
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            cameraFollow.enabled = true;
        }

    }
    


    IEnumerator StartCameraFollow()
    {
        float elapsedTime = 0;
        Vector3 camerapos = new Vector3(Mathf.Clamp(noahPlayer.transform.position.x, -262f, -251f), mainCamera.transform.position.y, Mathf.Clamp(noahPlayer.transform.position.z, 672f, 688f));
        while (elapsedTime <1.5f)
        {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, camerapos, (elapsedTime / 1.5f));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        cameraFollow.enabled = true;
    }


    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    /* 누르기 - 상자 등을 밀기 */
    public void playerPush() 
    {
        /* 스팀 업적 카운트 */
        if (achieveData.pressCount < 50)
        {
            achieveData.pressCount += 1;
        }

        if (equipment.biteObjectName == "" && equipment.pushObjectName == "")
        {
            /* 버튼 누르는 소리 */
            interactionAudio.clip = BasicUI_Click; // 1. 오디오소스에 플레이하고 싶은 소리 클립을 넣는다. 
            interactionAudio.Play(); // 2. 재생한다.);

            if (noahBiteObject == null)
            {
                noahPushObject = PlayerScripts.playerscripts.currentObject;
                if (noahPushObject != null)
                {
                    // 스크립터블오브젝트 변수에 저장
                    equipment.pushObjectName = noahPushObject.name;

                    equipment.cancelPushPos = noahPushObject.transform.position;
                    equipment.cancelPushRot = noahPushObject.transform.eulerAngles;
                    equipment.cancelPushScale = noahPushObject.transform.localScale;

                    Invoke("ChangePushTrue1", 0.5f);
                    Invoke("ChangePushTrue2", 1f);



                    pushData = noahPushObject.GetComponent<ObjData>();
                    objectText.text = "Noah N.113 - " + pushData.ObjectName;
                    pushData.objectDATA.IsPushOrPress = true;

                    Invoke("AddPushObject", 1f);
                }
            }
        }
    }

    void AddPushObject()
    {
        noahPushObject.GetComponent<Rigidbody>().isKinematic = true;   //makes the rigidbody not be acted upon by forces
        noahPushObject.GetComponent<Rigidbody>().useGravity = false;

        noahPushObject.transform.parent = myMouth.transform; //makes the object become a child of the parent so that it moves with the mouth

        noahPushObject.transform.localPosition = pushData.PushPos; // sets the position of the object to your mouth position
        noahPushObject.transform.localEulerAngles = pushData.PushRot; // sets the position of the object to yo
    }

    void ChangePushTrue1()
    {
        noahAnim.SetBool("IsPushing", true);
    }
    void ChangePushTrue2()
    {
        noahAnim.SetBool("IsPushing2", true);
    }

    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
    /* 밀기 취소 */

    public void CancelPush()
    {
        noahPushObject = GameObject.Find(equipment.pushObjectName).gameObject;
        equipment.pushObjectName = "";
        pushData = noahPushObject.GetComponent<ObjData>();
        pushData.objectDATA.IsPushOrPress = false;

        noahAnim.SetBool("IsPushing", false);

        interactionAudio.clip = DropBox;
        interactionAudio.Play();

        noahPushObject.transform.SetParent(null, true);

        noahPushObject.transform.localScale = equipment.cancelPushScale;
        noahPushObject.transform.position = new Vector3(noahPushObject.transform.position.x, equipment.cancelPushPos.y, noahPushObject.transform.position.z);
        noahPushObject.transform.eulerAngles = equipment.cancelPushRot;

    
        noahPushObject.transform.parent = portableObjects.transform;

        noahPushObject = null;
        pushData = null;
    }

    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
    public void playerPressHand()
    {
        /* 스팀 업적 카운트 */
        if (achieveData.pressCount < 50)
        {
            achieveData.pressCount += 1;
        }

        /* 버튼 누르는 소리 */
        interactionAudio.clip = BasicUI_Click; // 1. 오디오소스에 플레이하고 싶은 소리 클립을 넣는다. 
        interactionAudio.Play(); // 2. 재생한다.

        noahPressObject = PlayerScripts.playerscripts.currentObject;
        pressData = noahPressObject.GetComponent<ObjData>();
        pressData.objectDATA.IsPushOrPress = true;
        StartCoroutine(HandPressAnim());
    }

    IEnumerator HandPressAnim()
    {
        yield return new WaitForSeconds(0.5f);
        noahAnim.SetBool("IsHandPressing", true);
        yield return new WaitForSeconds(0.5f);
        noahAnim.SetBool("IsHandPressing", false);
        yield return new WaitForSeconds(2f);
        pressData.objectDATA.IsPushOrPress = false;
    }

    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    public void playerPressHead()
    {
        /* 스팀 업적 카운트 */
        if (achieveData.pressCount < 50)
        {
            achieveData.pressCount += 1;
        }

        /* 버튼 누르는 소리 */
        interactionAudio.clip = BasicUI_Click; // 1. 오디오소스에 플레이하고 싶은 소리 클립을 넣는다. 
        interactionAudio.Play(); // 2. 재생한다.

        noahPressObject = PlayerScripts.playerscripts.currentObject;
        pressData = noahPressObject.GetComponent<ObjData>();
        pressData.objectDATA.IsPushOrPress = true;
        StartCoroutine(HeadPressAnim());
    }
    IEnumerator HeadPressAnim()
    {
        yield return new WaitForSeconds(0.5f);
        noahAnim.SetBool("IsHeadPressing", true);
        yield return new WaitForSeconds(0.5f);
        noahAnim.SetBool("IsHeadPressing", false);
        yield return new WaitForSeconds(2f);
        pressData.objectDATA.IsPushOrPress = false;
    }

    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    /* 먹기 */
    public void playerEat()
    {
        /* 스팀 업적 카운트 */
        if(achieveData.eatCount<50)
        {
            achieveData.eatCount += 1;
        }

        /* 버튼 누르는 소리 */
        interactionAudio.clip = BasicUI_Click; // 1. 오디오소스에 플레이하고 싶은 소리 클립을 넣는다. 
        interactionAudio.Play(); // 2. 재생한다.

        noahEatObject = PlayerScripts.playerscripts.currentObject;

        objData = noahEatObject.GetComponent<ObjData>();
        objData.objectDATA.IsEaten = true;

        StartCoroutine(EatAnim());
    }

    IEnumerator EatAnim()
    {
        yield return new WaitForSeconds(1f);
        noahAnim.SetBool("IsEating1", true);
        yield return new WaitForSeconds(1f);
        noahAnim.SetBool("IsEating2", true);
        yield return new WaitForSeconds(1f);

        /* 먹는 소리 */
        interactionAudio.clip = Noah_Eat; // 1. 오디오소스에 플레이하고 싶은 소리 클립을 넣는다. 
        interactionAudio.Play(); // 2. 재생한다.

        noahAnim.SetBool("IsEating3", true);
        yield return new WaitForSeconds(0.1f);
        Destroy(noahEatObject);
        yield return new WaitForSeconds(0.9f);
        noahAnim.SetBool("IsEating1", false);
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
        // 버튼 누르는 소리 넣어주세요
        /* 버튼 누르는 소리 */
        interactionAudio.clip = BasicUI_Click; // 1. 오디오소스에 플레이하고 싶은 소리 클립을 넣는다. 
        interactionAudio.Play(); // 2. 재생한다.

        //noahPlayer.transform.position = PlayerScripts.playerscripts.currentInsertObj.transform.position + insertPosOffset;
        //noahPlayer.transform.eulerAngles = PlayerScripts.playerscripts.currentInsertObj.transform.eulerAngles + insertRotOffset;
        StartCoroutine(InsertAnim());
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

    public void PlayerSleep()
    {
        StartCoroutine(Sleeping());
    }

    IEnumerator Sleeping()
    {
        noahAnim.SetBool("IsSleep1", true);
        yield return new WaitForSeconds(1f);
        noahAnim.SetBool("IsSleep2", true);
        yield return new WaitForSeconds(10f);
        noahAnim.SetBool("IsSleep3", true);
        yield return new WaitForSeconds(1f);
        noahAnim.SetBool("IsSleep4", true);
        yield return new WaitForSeconds(1f);
        noahAnim.SetBool("IsSleep5", true);
        yield return new WaitForSeconds(1f);
        noahAnim.SetBool("IsSleep1", false);
        noahAnim.SetBool("IsSleep2", false);
        noahAnim.SetBool("IsSleep3", false);
        noahAnim.SetBool("IsSleep4", false);
    }
    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
    public void PlayerDie()
    {
        noahAnim.SetBool("Die1", true);
    }
}
