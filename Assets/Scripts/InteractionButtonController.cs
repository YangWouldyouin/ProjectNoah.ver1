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

    void Awake()
    {
        interactionButtonController = this;
    }

    private void Start()
    {
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


    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    /* 짖기 */
    public void playerBark() // 이 함수가 실행되었다는 것은 현재 플레이어가 어떤 오브젝트에 "맡기" 버튼을 클릭했다는 뜻이다.
    {
        noahBarkObject = PlayerScripts.playerscripts.currentObject;
        objData = noahBarkObject.GetComponent<ObjData>();
        objData.objectDATA.IsBark = true;

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
        if(noahPushObject==null)
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
        equipment.biteObjectName = "";
        noahBiteObject.transform.parent = portableObjects.transform;

        noahBiteObject = null;
        biteData = null;
    }

    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
    /* 파괴하기 */

    public void PlayerSmash1()
    {
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

    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    /* 냄새 맡기 */
    public void playerSniff()
    {
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
    public void PlayerRise1()
    {
        noahUpDownObject = PlayerScripts.playerscripts.currentObject;
        upDownData = noahUpDownObject.GetComponent<ObjData>();
        upDownData.objectDATA.IsUpDown = true;

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

    /* 내려가기 */

    public void PlayerFall1()
    {
        upDownData = noahUpDownObject.GetComponent<ObjData>();
        if (upDownData.objectDATA.IsUpDown)
        {
            if (playerAgent.enabled) // 오르기 동작은 NabMeshAgent을 사용하면서 원래 플레이어가 이동 가능했던 영역을 벗어나는 것이므로, navmeshagent를 잠시 끔
            {
                Vector3 fallrot = noahPlayer.transform.eulerAngles;
                noahPlayer.transform.eulerAngles = new Vector3(fallrot.x, fallrot.y - 180, fallrot.z);

                noahPlayer.transform.position = new Vector3(noahUpDownObject.transform.localPosition.x, 33.78f, noahUpDownObject.transform.localPosition.z) + transform.forward;
                playerAgent.updatePosition = true;
                playerAgent.updateRotation = true;
                playerAgent.isStopped = false;
                //Invoke("ChangeFallTrue1", 0.5f);
                //Invoke("ChangeFallTrue2", 1.1f);
                //Invoke("ChangeFallTrue3", 1.5f);
                //Invoke("ChangeFallTrue4", 2.5f);
                //Invoke("ChangeFallFalse1", 4.5f);
            }
            upDownData.IsUpDown = false;

            noahUpDownObject = null;
            upDownData = null;
        }

    }

    void ChangeFallTrue1()
    {
        noahAnim.SetBool("Falling1", true);
    }

    void ChangeFallTrue2()
    {
        noahAnim.SetBool("Falling2", true);
    }
    void ChangeFallTrue3()
    {
        noahAnim.SetBool("Falling3", true);
    }
    void ChangeFallTrue4()
    {
        noahAnim.SetBool("Falling4", true);
        upDownData = noahUpDownObject.GetComponent<ObjData>();
        Vector3 fallPosition = upDownData.DownPos.position;
        //noahPlayer.transform.position = new Vector3(fallPosition.x - 2, 35.78f, fallPosition.z);
        noahPlayer.transform.position = fallPosition;


    }
    void ChangeFallFalse1()
    {
        noahAnim.SetBool("Falling1", false);

        playerAgent.isStopped = false;


        playerAgent.updatePosition = true;
        playerAgent.updateRotation = true;
    }

    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    /* 누르기 - 상자 등을 밀기 */
    public void playerPush() 
    {
        if(noahBiteObject==null)
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

        pushData = noahPushObject.GetComponent<ObjData>();
        pushData.objectDATA.IsPushOrPress = false;

        noahAnim.SetBool("IsPushing", false);

        noahPushObject.transform.SetParent(null, true);

        noahPushObject.transform.localScale = equipment.cancelPushScale;
        noahPushObject.transform.position = new Vector3(noahPushObject.transform.position.x, equipment.cancelPushPos.y, noahPushObject.transform.position.z);
        noahPushObject.transform.eulerAngles = equipment.cancelPushRot;

        equipment.pushObjectName = "";
        noahPushObject.transform.parent = portableObjects.transform;

        noahPushObject = null;
        pushData = null;
    }

    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
    public void playerPressHand()
    {
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
        noahPlayer.transform.position = PlayerScripts.playerscripts.currentInsertObj.transform.position + insertPosOffset;
        noahPlayer.transform.eulerAngles = PlayerScripts.playerscripts.currentInsertObj.transform.eulerAngles + insertRotOffset;
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
}
