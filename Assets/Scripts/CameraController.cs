using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController cameraController { get; private set; }

    //private Transform camObserveView, camObserveBoxView;
    [SerializeField] Transform mainView;



    public GameObject objectExtraDescription;



    public Transform currentView;

    [SerializeField] GameObject noah;

    public GameObject aiPanel, ui;

    private GameObject currentObserveObject;

    private Transform observeView;
    private Transform observePlusView;

    private void Awake()
    {
        cameraController = this;
    }

    public void ObserveButtonClick()
    {
        currentObserveObject = PlayerScripts.playerscripts.currentObject;
        ObjData currentObserveObjectData = currentObserveObject.GetComponent<ObjData>();

        //camObserveView = PlayerScripts.playerscripts.PlayerobserveView;
        //camObserveBoxView = PlayerScripts.playerscripts.PlayerobserveBoxView;
        noah.transform.gameObject.SetActive(false);
        aiPanel.SetActive(false);
        ui.SetActive(false);
        //if()
        //{
        //    currentView = currentObserveObjectData.ObserveView;
        //}
        //else
        //{

        //}
        if(currentObserveObjectData.IsExtraDescriptionActive)
        {
            objectExtraDescription = PlayerScripts.playerscripts.PlayerExtraDescription;
            objectExtraDescription.SetActive(true);
        }
        ChangeView(currentView);

    }

    public void CancelObserve()
    {
        aiPanel.SetActive(true);
        ui.SetActive(true);
        noah.transform.gameObject.SetActive(true);
        objectExtraDescription.SetActive(false);
        ChangeView(mainView);
    }

    /* ��ȯ ȿ�� ���� ī�޶� ��ȯ �޼��� */
    void ChangeView(Transform view)
    {
        transform.position = view.position;
        transform.rotation = view.rotation;
        //mainCamera.transform.position = view.position;
        //mainCamera.transform.rotation = view.rotation;
    }
}


// public float transitionSpeed;
// public Transform currentVieww;

/* ��ȯ ȿ�� �ִ� ī�޶� ��ȯ 
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
/* �����ϱ� ��Ȱ��ȭ 
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

