using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController cameraController { get; private set; }

    //public GameObject objectExtraDescription;
    [HideInInspector]
    public Vector3 originPosition, originRotation;
    [HideInInspector]
    public Transform currentView;

    GameObject noah;
    Animator playerAnimation;

    GameObject currentObserveObject;

    CameraFollow cameraFollow;
    HorizontalCameraController engineRoomController;
    LivingRoomCameraController livingRoomController;
    ControlCameraController controlRoomController;

    ObjData currentObserveObjectData;
    ObjectData currentObjectData;
    Outline currentObjectOutline;

    GameObject objectNameTag;

    TMPro.TextMeshProUGUI cameraNumText;
    public bool IsObserve;
    private void Awake()
    {
        cameraController = this;
    }
    private void Update()
    {
        if(currentObjectData!=null)
        {
            if (currentObjectData.IsObserve)
            {
                PlayerScripts.playerscripts.boringTime = 0;
            }
        }

    }
    private void Start()
    {
        objectNameTag = BaseCanvas._baseCanvas.objectNameTag;
        noah = BaseCanvas._baseCanvas.noahFBX;
        playerAnimation = BaseCanvas._baseCanvas.noahPlayer.GetComponent<Animator>();

        cameraNumText = BaseCanvas._baseCanvas.CameraNumText;

        cameraFollow = GetComponent<CameraFollow>();
        engineRoomController = GetComponent<HorizontalCameraController>();
        livingRoomController = GetComponent<LivingRoomCameraController>();
        controlRoomController = GetComponent<ControlCameraController>();
    }
    public void SavePosition()
    {
        originPosition = transform.position;
        originRotation = transform.rotation.eulerAngles;
    }
    public void ObserveButtonClick()
    {
        IsObserve = true;
        currentObserveObject = PlayerScripts.playerscripts.currentObserveObj;

        currentObjectOutline = currentObserveObject.GetComponent<Outline>();
        currentObjectOutline.OutlineWidth = 0;

        currentObserveObjectData = currentObserveObject.GetComponent<ObjData>();
        currentObjectData = currentObserveObjectData.objectDATA;
        currentObjectData.IsObserve = true;
        currentObjectData.IsNotInteractable = true;
        objectNameTag.SetActive(false);
        if (cameraFollow!=null)
        {
            cameraFollow.enabled = false;
        }

        if(engineRoomController!=null)
        {
            engineRoomController.enabled = false;
        }
        
        if(livingRoomController!=null)
        {
            livingRoomController.enabled = false;
        }
        if(controlRoomController!=null)
        {
            controlRoomController.enabled = false;
        }

        noah.transform.gameObject.SetActive(false);

        ChangeView(currentView);
    }

    public void CancelObserve()
    {
        IsObserve = false;
        objectNameTag.SetActive(true);
        noah.transform.gameObject.SetActive(true);
        objectNameTag.SetActive(false);
        if (cameraFollow != null)
        {
            cameraFollow.enabled = true;
        }

        if (engineRoomController != null)
        {
            engineRoomController.enabled = true;
        }

        if (livingRoomController != null)
        {
            livingRoomController.enabled = true;
        }

        if (controlRoomController != null)
        {
            controlRoomController.enabled = true;
        }
        currentObserveObject = PlayerScripts.playerscripts.currentObserveObj;

        currentObjectOutline = currentObserveObject.GetComponent<Outline>();
        currentObjectOutline.OutlineWidth = 8;

        currentObjectData = currentObserveObjectData.objectDATA;
        currentObjectData.IsNotInteractable = false;
        currentObjectData.IsObserve = false;

        ComeBackView(originPosition, originRotation);
        StartCoroutine(CancelObserving2Animation());

        if (GameManager.gameManager._gameData.currentRoom == 1)
        {
            cameraNumText.text = "60fps" + "\n" + "Camera_1; control_room";
        }
        else if (GameManager.gameManager._gameData.currentRoom == 2)
        {
            cameraNumText.text = "60fps" + "\n" + "Camera_2; work_room";
        }
        else if (GameManager.gameManager._gameData.currentRoom == 3)
        {
            cameraNumText.text = "60fps" + "\n" + "Camera_3; living_room";
        }
        else if (GameManager.gameManager._gameData.currentRoom == 4)
        {
            cameraNumText.text = "60fps" + "\n" + "Camera_4; engine_room";
        }
    }

    /* ???? ???? ???? ?????? ???? ?????? */
    void ChangeView(Transform view)
    {
        transform.position = view.position;
        transform.rotation = view.rotation;
    }

    void ComeBackView(Vector3 originPos, Vector3 originRot)
    {
        transform.position = originPos;
        transform.rotation = Quaternion.Euler(originRot);
    }
    IEnumerator CancelObserving2Animation()
    {
        yield return new WaitForSeconds(0.5f);
        playerAnimation.SetBool("IsObserving2", false);
        yield return new WaitForSeconds(0.5f);
        playerAnimation.SetBool("IsObserving", false);
    }

    void CancelObservingAnimation()
    {
        playerAnimation.SetBool("IsObserving", false);
    }
}
