using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BiteDestroyController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public GameObject biteDestroyButton;
    public Button barkButton, sniffButton, pushOrPressButton, centerButton1, centerDisableButton1, centerButton2, centerDisableButton2;


    public Vector3 mouthPos, mouthRot = new Vector3(0, 0, 0);
    private Sprite biteButtonImage, biteButtonMouseOver, biteButtonClicked, destroyButtonMouseOver;
    private GameObject myMouth;
    private TMPro.TextMeshProUGUI biteText;
    private Animator playerAnimation;

    private bool isPointerDown = false;
    private  float requiredChangeTime = 0.5f;
    private float pointerDownTimer = 0;


    int i = 0;
    // public Button biteDestroyButton; // PlayerScripts - MovePlayer ���� ��ư �̹��� BiteButtonImage �� �ٲ�
    GameObject noahBiteObject, noahDestroyObject;
    

    void Start()
    {
        biteButtonImage = BaseCanvas._baseCanvas.biteButtonImage;
        biteButtonMouseOver = BaseCanvas._baseCanvas.biteButtonMouseOver;
        biteButtonClicked = BaseCanvas._baseCanvas.biteButtonClicked;
        destroyButtonMouseOver = BaseCanvas._baseCanvas.destroyButtonMouseOver;

        playerAnimation = BaseCanvas._baseCanvas.playerAnimation;
        myMouth = BaseCanvas._baseCanvas.myMouth;
        biteText = BaseCanvas._baseCanvas.biteObjectText;
 
    }


    /* ��ȣ�ۿ� ��ư ���� �Լ� */
    public void DiableButton()
    {

        barkButton.transform.gameObject.SetActive(false);
        sniffButton.transform.gameObject.SetActive(false);
        biteDestroyButton.transform.gameObject.SetActive(false);
        pushOrPressButton.transform.gameObject.SetActive(false);
        centerButton1.transform.gameObject.SetActive(false);

        if (centerDisableButton1 != null)
        {
            centerDisableButton1.transform.gameObject.SetActive(false);
        }
        if (centerDisableButton2 != null)
        {
            centerDisableButton2.transform.gameObject.SetActive(false);
        }
        if (centerButton2 != null)
        {
            centerButton2.transform.gameObject.SetActive(false);
        }
    }

    /* ���콺������ ���콺�����̹����� ���� */
    public void OnPointerEnter(PointerEventData eventData)
    {
        biteDestroyButton.GetComponent<Image>().sprite = biteButtonMouseOver;
    }

    /* ���콺 ������ ������ �⺻�̹����� ���� */
    public void OnPointerExit(PointerEventData eventData)
    {
        biteDestroyButton.GetComponent<Image>().sprite = biteButtonImage;
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
            PlayerScripts.playerscripts.currentBiteObj = noahBiteObject;

            PlayerScripts.playerscripts.biteFallPos = noahBiteObject.transform.position;
            PlayerScripts.playerscripts.biteFallRot = noahBiteObject.transform.eulerAngles;
            PlayerScripts.playerscripts.biteOriginScale = noahBiteObject.transform.localScale;

            ObjData noahBiteData = noahBiteObject.GetComponent<ObjData>();
            biteText.text = "Noah N.113 - " + noahBiteData.ObjectName;
            noahBiteData.IsBite = true;

            isPointerDown = true;
            biteDestroyButton.GetComponent<Image>().sprite = biteButtonClicked;
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

    public void PlayerPickUp()
    {
        noahBiteObject.GetComponent<Rigidbody>().isKinematic = true;   //makes the rigidbody not be acted upon by forces
        noahBiteObject.GetComponent<Rigidbody>().useGravity = false;

        //noahBiteObject.transform.parent = myMouth.transform; //makes the object become a child of the parent so that it moves with the mouth
        noahBiteObject.transform.SetParent(myMouth.transform, true);
        noahBiteObject.transform.localPosition = mouthPos; // sets the position of the object to your mouth position
        noahBiteObject.transform.localEulerAngles = mouthRot; // sets the position of the object to your mouth position
        
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

                Invoke("DeleteObject", 2f);
                Invoke("ChangeDestroyFalse", 3f);
                
                Reset();
            }
        }
    }

    void ChangeBiteToDestroyButton()
    {
        biteDestroyButton.GetComponent<Image>().sprite = destroyButtonMouseOver;

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

    void DeleteObject()
    {
        noahDestroyObject.SetActive(false);
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