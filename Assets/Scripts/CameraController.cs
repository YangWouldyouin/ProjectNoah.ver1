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

    GameObject nameTag, noahStat, clock;

    private GameObject currentObserveObject;

    CameraFollow cameraFollow;

    ObjData currentObserveObjectData;
    Outline currentObjectOutline;

    private void Awake()
    {
        cameraController = this;
    }

    private void Start()
    {
        clock = BaseCanvas._baseCanvas.clock;
        noahStat = BaseCanvas._baseCanvas.statPanel;
        nameTag = BaseCanvas._baseCanvas.objectNameTag;
        noah = BaseCanvas._baseCanvas.noahFBX;
        playerAnimation = BaseCanvas._baseCanvas.noahPlayer.GetComponent<Animator>();

        cameraFollow = GetComponent<CameraFollow>();
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
        currentObserveObjectData.IsNotInteractable = true;

        if (cameraFollow!=null)
        {
            cameraFollow.enabled = false;
        }
        
        //camObserveView = PlayerScripts.playerscripts.PlayerobserveView;
        //camObserveBoxView = PlayerScripts.playerscripts.PlayerobserveBoxView;
        noah.transform.gameObject.SetActive(false);
        //aiPanel.SetActive(false);
        clock.SetActive(false);
        nameTag.SetActive(false);
        noahStat.SetActive(false);
        ChangeView(currentView);

    }

    public void CancelObserve()
    {
        //aiPanel.SetActive(true);
        clock.SetActive(true);
        nameTag.SetActive(true);
        noahStat.SetActive(true);
        noah.transform.gameObject.SetActive(true);

        if (cameraFollow != null)
        {
            cameraFollow.enabled = true;
        }

        currentObserveObject = PlayerScripts.playerscripts.currentObserveObj;

        currentObjectOutline = currentObserveObject.GetComponent<Outline>();
        currentObjectOutline.OutlineWidth = 8;
  
        currentObserveObjectData.IsNotInteractable = false;
        currentObserveObjectData.IsObserve = false;

        ComeBackView(originPosition, originRotation);

        Invoke("CancelObserving2Animation", 0.5f);
        Invoke("CancelObservingAnimation", 0.5f);
    }

    /* 전환 효과 없는 카메라 전환 메서드 */
    void ChangeView(Transform view)
    {
        transform.position = view.position;
        transform.rotation = view.rotation;
        //mainCamera.transform.position = view.position;
        //mainCamera.transform.rotation = view.rotation;
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


// public float transitionSpeed;
// public Transform currentVieww;

/* 전환 효과 있는 카메라 전환 
void LateUpdate()
{
    transform.position = 

    transform.position = Vector3.Lerp(transform.position, currentVieww.position, Time.deltaTime*transitionSpeed);

    Vector3 currentAngle = new Vector3(
        Mathf.LerpAngle(transform.rotation.eulerAngles.x, currentVieww.transform.rotation.eulerAngles.x, Time.deltaTime*transitionSpeed),
        Mathf.LerpAngle(transform.rotation.eulerAngles.y, currentVieww.transform.rotation.eulerAngles.y, Time.deltaTime*transitionSpeed),
        Mathf.LerpAngle(transform.rotation.eulerAngles.z, currentVieww.transform.rotation.eulerAngles.z, Time.deltaTime*transitionSpeed));

    transform.eulerAngles = currentAngle;
} */

/*
if(Input.GetButtonDown("Observe"))
{
changeView(views[0]);
}

if(Input.GetKeyDown("space"))
{
//currentVieww = views[0];
changeView(views[0]);
}
/* 관찰하기 비활성화 
if(Input.GetKeyDown("space"))
{
// currentVieww = views[1];
changeView(views[1]);
}    
*/


//if (Input.GetMouseButtonDown(1))
//{
//    //gameObject.GetComponent<SceneCameraControl>().enabled = true;

//}

