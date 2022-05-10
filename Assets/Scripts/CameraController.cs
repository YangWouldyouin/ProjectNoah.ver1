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

    ObjData currentObserveObjectData;
    ObjectData currentObjectData;
    Outline currentObjectOutline;

    GameObject objectNameTag;

    private void Awake()
    {
        cameraController = this;
    }

    private void Start()
    {
        objectNameTag = BaseCanvas._baseCanvas.objectNameTag;
        noah = BaseCanvas._baseCanvas.noahFBX;
        playerAnimation = BaseCanvas._baseCanvas.noahPlayer.GetComponent<Animator>();

        cameraFollow = GetComponent<CameraFollow>();
        engineRoomController = GetComponent<HorizontalCameraController>();
        livingRoomController = GetComponent<LivingRoomCameraController>();
    }
    public void SavePosition()
    {
        originPosition = transform.position;
        originRotation = transform.rotation.eulerAngles;
    }
    public void ObserveButtonClick()
    {
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

        noah.transform.gameObject.SetActive(false);

        ChangeView(currentView);
    }

    public void CancelObserve()
    {
        objectNameTag.SetActive(true);
        noah.transform.gameObject.SetActive(true);

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
        currentObserveObject = PlayerScripts.playerscripts.currentObserveObj;

        currentObjectOutline = currentObserveObject.GetComponent<Outline>();
        currentObjectOutline.OutlineWidth = 8;

        currentObjectData = currentObserveObjectData.objectDATA;
        currentObjectData.IsNotInteractable = false;
        currentObjectData.IsObserve = false;

        ComeBackView(originPosition, originRotation);

        Invoke("CancelObserving2Animation", 0.5f);
        Invoke("CancelObservingAnimation", 0.5f);
    }

    /* 전환 효과 없는 카메라 전환 메서드 */
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
    void CancelObserving2Animation()
    {
        playerAnimation.SetBool("IsObserving2", false);
    }

    void CancelObservingAnimation()
    {
        playerAnimation.SetBool("IsObserving", false);
    }
}
