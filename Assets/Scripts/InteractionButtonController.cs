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

    public Animator noahAnim;
    public Button barkButton, pushButton, pressButton, sniffButton, biteButton, upDownButton, insertButton, noCenterButton, observeButton;
    [SerializeField] GameObject noah, noahPlayer;





  
    public bool isBark = false;



    public Rigidbody playerRigidbody;
    public NavMeshAgent playerAgent;
    private Vector3 risePosition;


    
    public GameObject noahPushOrPressObject;
    public GameObject noahSniffObject;
    public GameObject noahBarkObject;

    public GameObject noahUpDownObject;
    public GameObject noahInsertObject;
    public GameObject noahObserveObject;





    public GameObject goToWork;
    public GameObject noahPushObject;
    public static GameObject noahpushobject;
    public static bool ISPUSH = false;
    public bool ispush = false;
    public static string pushObjectName;

    public GameObject InsertArea, DoorLocked, DoorUnLocked;

    private void Start()
    {
        StartCoroutine("NoahWalking");
    }


    void Awake()
    {
        interactionButtonController = this;

        noahAnim.SetBool("IsSleeping", true);

        barkButton.onClick.AddListener(playerBark);
        sniffButton.onClick.AddListener(playerSniff);
        observeButton.onClick.AddListener(playerObserve);
        upDownButton.onClick.AddListener(playerRising);
        insertButton.onClick.AddListener(playerInserting);
        pushButton.onClick.AddListener(playerPush);
        pressButton.onClick.AddListener(playerPress);
    }


    IEnumerator NoahWalking()
    {
        yield return new WaitForSeconds(0.0001f);
        noahAnim.SetBool("IsWaking", true);
        noahAnim.SetBool("IsWaking2", true);
        noahAnim.SetBool("IsSleeping", false);
    }

    private void Update()
    {

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

    void playerPush()
    {
        noahPushObject = PlayerScripts.playerscripts.currentObject;

        noahpushobject = noahPushObject;
        pushObjectName = noahPushObject.name;
        //PlayerManager.playermanager.ISPUSH = true;
        ispush = true;
        ISPUSH = true;
        TurnOffInteractionButton();
        Invoke("ChangePushTrue", 0.5f);
        Invoke("ChangePush2True", 0.5f);
        noahPushObject.transform.parent = noah.transform;
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

    void playerPress()
    {
        noahPushOrPressObject = PlayerScripts.playerscripts.currentObject;
        ObjData noahPushOrPressData = noahPushOrPressObject.GetComponent<ObjData>();
        TurnOffInteractionButton();
        if (noahPushOrPressData.ISPushOrPressActive)
        {
            noahPushOrPressData.IsPushOrPress = true;

            

            Invoke("ChangePressTrue", 0.5f);
            Invoke("ChangePressFalse", 2f);
        }
        else
        {
            Invoke("JustPlayPushAnimationTrue", 0.5f);
            Invoke("JustPlayPushAnimationFalse", 2f);
        }




        //if (noahPushObject.name == "Console_Left_UnLockButton")
        //{
        //    // ���� ���ȴ� ������
        //    DoorController.doorController.isDoorOpen = true;
        //    //Invoke("IsDoorOpenTrue", 2.5f);
        //    Invoke("IsDoorOpenFalse", 1f);
        //}
    }
    void ChangePressTrue()
    {
        noahAnim.SetBool("IsPressing", true);
    }
    void ChangePressFalse()
    {
        noahAnim.SetBool("IsPressing", false);
    }

    void JustPlayPushAnimationTrue()
    {
        noahAnim.SetBool("IsNonePushing", true);
    }

    void JustPlayPushAnimationFalse()
    {
        noahAnim.SetBool("IsNonePushing", false);
    }


    //void IsDoorOpentTrue()
    //{
    //    DoorController.doorController.isDoorOpen = true;
    //}
    //void IsDoorOpenFalse()
    //{
    //    DoorController.doorController.isDoorOpen = false;
    //}

    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    void playerInserting()
    {
        noahInsertObject = PlayerScripts.playerscripts.currentObject;
        ObjData noahInsertData = noahInsertObject.GetComponent<ObjData>();
        

        TurnOffInteractionButton();
        Invoke("ChangeInsertTrue", 0.5f);
        //InsertArea.SetActive(true);
        if (noahInsertData.IsInsert == false)
        {
            noahInsertData.IsInsert = true;
            if (playerAgent.enabled)
            {
                // set the agents target to where you are before the jump
                // this stops her before she jumps. Alternatively, you could
                // cache this value, and set it again once the jump is complete
                // to continue the original move
                //Playeragent.SetDestination(transform.position);
                // disable the agent
                playerAgent.updatePosition = false;
                playerAgent.updateRotation = false;
                playerAgent.isStopped = true;
            }
        }

        noahPlayer.transform.position = new Vector3(21.5f, 34.03531f, -1.002877f);
        noahPlayer.transform.rotation = Quaternion.Euler(0, 0, 0);

        //NoahPlayer.transform.Rotate(0, 0, 0);
        //Playeragent.isStopped = false;

        DoorController.doorController.isDoorOpen = true;
        noahInsertData.IsInsert = false;
        Invoke("ChangeInsertFalse", 0.05f);
        goToWork.SetActive(true);
        if (playerAgent.enabled)
        {
            playerAgent.updatePosition = true;
            playerAgent.updateRotation = true;
            playerAgent.isStopped = false;
        }

        //DoorLocked.SetActive(false);
        //DoorUnLocked.SetActive(true);
    }

    void ChangeInsertTrue()
    {
        noahAnim.SetBool("IsInserting", true);
    }

    public void ChangeInsertfalse()
    {
        noahAnim.SetBool("IsInserting", false);
    }

    public void TurnOffInsertArea()
    {
        InsertArea.SetActive(false);
    }

    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    public void TurnOffInteractionButton()
    {
        barkButton.transform.gameObject.SetActive(false);
        pushButton.transform.gameObject.SetActive(false);
        pressButton.transform.gameObject.SetActive(false);
        noCenterButton.transform.gameObject.SetActive(false);
        upDownButton.transform.gameObject.SetActive(false);
        insertButton.transform.gameObject.SetActive(false);
        observeButton.transform.gameObject.SetActive(false);
        sniffButton.transform.gameObject.SetActive(false);
        biteButton.transform.gameObject.SetActive(false);
    }

    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&   

    void playerBark()
    {
        noahBarkObject = PlayerScripts.playerscripts.currentObject;
        ObjData noahBarkData = noahBarkObject.GetComponent<ObjData>();
        noahBarkData.IsBark = true;

        GameManager.gameManager.isBark = true; // 나중에 수정 필요 */
        TurnOffInteractionButton();
        Invoke("ChangeBarkTrue", 0.5f);
        Invoke("ChangeBarkFalse", 2);
    }

    void ChangeBarkTrue()
    {
        noahAnim.SetBool("IsBarking", true);
    }

    void ChangeBarkFalse()
    {
        noahAnim.SetBool("IsBarking", false);
    }

    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    void playerSniff()
    {
        noahSniffObject = PlayerScripts.playerscripts.currentObject;
        ObjData noahSniffData = noahSniffObject.GetComponent<ObjData>();
        noahSniffData.IsSniff = true;
        TurnOffInteractionButton();
        Invoke("ChangeSniffTrue", 0.5f);
        Invoke("ChangeSniffFalse", 2);
        Invoke("TurnOnTheSmellPanel", 2);
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
        DialogSystem.Instance.Smell();
    }

    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    void playerObserve()
    {
        noahObserveObject = PlayerScripts.playerscripts.currentObject;
        ObjData noahObserveData = noahObserveObject.GetComponent<ObjData>();
        noahObserveData.IsObserve = true;

        TurnOffInteractionButton();
        Invoke("ChangeObserveTrue", 0.5f);
        Invoke("ChangeObserve2True", 1f);

        //Invoke("ChangeObserveFalse", 2);
        Invoke("ChangeCameraView", 2);
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
        CameraController.cameraController.ObserveButtonClick();
        //noah.transform.gameObject.SetActive(false);
    }

    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
    void playerRising()
    {
        noahUpDownObject = PlayerScripts.playerscripts.currentObject;
        ObjData noahUpDownData = noahUpDownObject.GetComponent<ObjData>();
        risePosition = noahUpDownObject.transform.localPosition;
        TurnOffInteractionButton();

        if (noahUpDownData.IsUpDown == false)
        {
            noahUpDownData.IsUpDown = true;
            if (playerAgent.enabled)
            {
                playerAgent.updatePosition = false;
                playerAgent.updateRotation = false;
                playerAgent.isStopped = true;
            }
            Invoke("ChangeRiseTrue", 0.5f);
            Invoke("ChangeRise2True", 0.5f);
            Invoke("ChangeRise3True", 0.5f);
            Invoke("ChangeRise4True", 0.5f);
            Invoke("ChangeRise5True", 0.5f);
            Invoke("noahJump", 1f);
            Invoke("ChangeRiseFalse", 2);

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
        noahPlayer.transform.position = new Vector3(risePosition.x-1f, 34.69f, risePosition.z);
    }

}
