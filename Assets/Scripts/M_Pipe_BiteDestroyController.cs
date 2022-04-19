using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class M_Pipe_BiteDestroyController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public Button barkButton_m_Pipe, pressButton_m_Pipe, sniffButton_m_Pipe, noCenterButton_m_Pipe;

    public GameObject biteDestroyButton_m_Pipe;
    Sprite biteButtonImage, biteButtonMouseOver, biteButtonClicked, destroyButtonMouseOver;
    GameObject myMouth;
    TMPro.TextMeshProUGUI biteText;
    Animator playerAnimation;

    [HideInInspector]
    public Vector3 biteObjectFallPosition, biteObjectFallRotation;
    


    bool isPointerDown = false;
    [SerializeField] float requiredHoldTime = 1f;
    [SerializeField] float requiredChangeTime = 0.5f;
    float pointerDownTimer = 0;

    ObjData pipeData_m;
    public GameObject pipe_M;

    // public Button biteDestroyButton; // PlayerScripts - MovePlayer ���� ��ư �̹��� BiteButtonImage �� �ٲ�

    GameObject noahBiteObject, noahDestroyObject;

    void Start()
    {
        biteButtonImage = BiteDestroyButtonController.biteDestroyButtonController.biteButtonImage;
        biteButtonMouseOver = BiteDestroyButtonController.biteDestroyButtonController.biteButtonMouseOver;
        biteButtonClicked = BiteDestroyButtonController.biteDestroyButtonController.biteButtonClicked;
        destroyButtonMouseOver = BiteDestroyButtonController.biteDestroyButtonController.destroyButtonMouseOver;

        playerAnimation = BiteDestroyButtonController.biteDestroyButtonController.playerAnimation;
        myMouth = BiteDestroyButtonController.biteDestroyButtonController.myMouth;
        biteText = BiteDestroyButtonController.biteDestroyButtonController.biteObjectText;

        isPointerDown = false;
        noahBiteObject = null;
        pipeData_m = pipe_M.GetComponent<ObjData>();
    }


    /* ��ȣ�ۿ� ��ư ���� �Լ� */
    void DiableButton()
    {
        barkButton_m_Pipe.transform.gameObject.SetActive(false);
        biteDestroyButton_m_Pipe.transform.gameObject.SetActive(false);
        pressButton_m_Pipe.transform.gameObject.SetActive(false);
        sniffButton_m_Pipe.transform.gameObject.SetActive(false);
        noCenterButton_m_Pipe.transform.gameObject.SetActive(false);
    }

    /* ���콺������ ���콺�����̹����� ���� */
    public void OnPointerEnter(PointerEventData eventData)
    {
        biteDestroyButton_m_Pipe.GetComponent<Image>().sprite = biteButtonMouseOver;
    }

    /* ���콺 ������ ������ �⺻�̹����� ���� */
    public void OnPointerExit(PointerEventData eventData)
    {
        biteDestroyButton_m_Pipe.GetComponent<Image>().sprite = biteButtonImage;
    }

    /* ���콺 Ŭ�� �� ���� ��ȣ�ۿ� ��ư ��Ȱ��ȭ, �չ�ư Ÿ�̸�  & IsPointerDown ���� */
    public void OnPointerUp(PointerEventData eventData)
    {
        DiableButton();
        Reset();
    }

    private void Reset()
    {
        isPointerDown = false;
        pointerDownTimer = 0;
    }




    public void OnPointerDown(PointerEventData eventData)
    {
        noahBiteObject = PlayerScripts.playerscripts.currentObject;

        if (noahBiteObject != null)
        {
            PlayerScripts.playerscripts.currentObserveObj = noahBiteObject;

            biteObjectFallPosition = noahBiteObject.transform.position;
            biteObjectFallRotation = noahBiteObject.transform.eulerAngles;

            ObjData noahBiteData = noahBiteObject.GetComponent<ObjData>();
            biteText.text = "Noah N.113 - " + noahBiteData.ObjectName;
            noahBiteData.IsBite = true;
            isPointerDown = true;
            biteDestroyButton_m_Pipe.GetComponent<Image>().sprite = biteButtonClicked;
            Invoke("ChangeBiteTrue", 0.5f);
            Invoke("PlayerPickUp", 0.7f);
            Invoke("ChangeBiteFalse", 1);
        }
    }

    void ChangeBiteTrue()
    {
        playerAnimation.SetBool("IsBiting", true);
    }

    void ChangeBiteFalse()
    {
        playerAnimation.SetBool("IsBiting", false);
    }

    void PlayerPickUp()
    {
        noahBiteObject.GetComponent<Rigidbody>().isKinematic = true;   //makes the rigidbody not be acted upon by forces
        noahBiteObject.GetComponent<Rigidbody>().useGravity = false;
        noahBiteObject.transform.parent = myMouth.transform; //makes the object become a child of the parent so that it moves with the mouth
        noahBiteObject.transform.localPosition = new Vector3(0, 0, 0); // sets the position of the object to your mouth position
        noahBiteObject.transform.localEulerAngles = new Vector3(0, 0, 0); // sets the position of the object to your mouth position
    }

    void Update()
    {
        if (isPointerDown)
        {
            noahBiteObject = PlayerScripts.playerscripts.currentObject;
            ObjData noahBiteData = noahBiteObject.GetComponent<ObjData>();
            pointerDownTimer += Time.deltaTime;
            if (pointerDownTimer >= requiredChangeTime)
            {
                ChangeBiteToDestroyButton();
                noahBiteData.IsDestroy = true;
                Invoke("ChangeDestroyTrue", 1f);
                

                Invoke("ChangeDestroyFalse", 3f);
                
                Reset();
            }
        }
    }

    void ChangeBiteToDestroyButton()
    {
        biteDestroyButton_m_Pipe.GetComponent<Image>().sprite = destroyButtonMouseOver;

        noahDestroyObject = PlayerScripts.playerscripts.currentObject;
        if (noahDestroyObject != null)
        {
            ObjData noahBiteDestroyData = noahBiteObject.GetComponent<ObjData>();
            noahBiteDestroyData.IsDestroy = true;
        }
    }

    void ChangeDestroyTrue()
    {
        playerAnimation.SetBool("IsDestroying", true);
    }

    void ChangeDestroyFalse()
    {
        playerAnimation.SetBool("IsDestroying", false);
        DiableButton();
    }


    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    noahBiteObject = PlayerScripts.playerscripts.currentObject;

    //    if (noahBiteObject != null)
    //    {
    //        /* ���� ����� �� ����ϱ� ���� ���� */
    //        PlayerScripts.playerscripts.currentBiteObj = noahBiteObject;

    //        biteObjectFallPosition = noahBiteObject.transform.position;
    //        biteObjectFallRotation = noahBiteObject.transform.eulerAngles;

    //        ObjData noahBiteData = noahBiteObject.GetComponent<ObjData>();
    //        noahBiteData.IsBite = true;

    //        biteText.text = "Noah N.113 - " + noahBiteData.ObjectName;


    //        biteDestroyButton_m_Pipe.GetComponent<Image>().sprite = biteButtonClickeds;
    //        isPointerDown = true;

    //        StartCoroutine(BiteAnim());

    //        biteDestroyButton_m_Pipe.GetComponent<Image>().sprite = biteButtonClickeds;
    //    }
    //}
    //IEnumerator BiteAnim()
    //{
    //    yield return new WaitForSeconds(0.5f);
    //    playerAnimation.SetBool("IsBiting", true);

    //    yield return new WaitForSeconds(0.7f);
    //    noahBiteObject.GetComponent<Rigidbody>().isKinematic = true;   //makes the rigidbody not be acted upon by forces
    //    noahBiteObject.GetComponent<Rigidbody>().useGravity = false;
    //    noahBiteObject.transform.parent = myMouth.transform; //makes the object become a child of the parent so that it moves with the mouth
    //    noahBiteObject.transform.localPosition = new Vector3(0, 0, 0); // sets the position of the object to your mouth position
    //    noahBiteObject.transform.localEulerAngles = new Vector3(0, 0, 0); // sets the position of the object to your mouth position

    //    yield return new WaitForSeconds(2f);
    //    playerAnimation.SetBool("IsBiting", false);
    //    yield return null;
    //}
    //void Update()
    //{
    //    if (isPointerDown)
    //    {
    //        noahBiteObject = PlayerScripts.playerscripts.currentObject;
    //        ObjData noahBiteData = noahBiteObject.GetComponent<ObjData>();

    //        pointerDownTimer += Time.deltaTime;
    //        if (pointerDownTimer >= requiredChangeTime)
    //        {

    //            noahBiteData.IsDestroy = true;

    //            biteDestroyButton_m_Pipe.GetComponent<Image>().sprite = destroyButtonMouseOver;

    //            StartCoroutine(DestroyAnim());

    //            Reset();
    //        }
    //    }
    //}



    //IEnumerator DestroyAnim()
    //{
    //    yield return new WaitForSeconds(1f);
    //    playerAnimation.SetBool("IsDestroying", true);
    //    DiableButton();
    //    yield return new WaitForSeconds(3f);
    //    playerAnimation.SetBool("IsDestroying", false);
    //}
}
