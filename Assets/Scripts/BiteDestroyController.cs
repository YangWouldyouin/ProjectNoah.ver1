using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
// PointerEnterHandler, IPointerExitHandler, IPointerDownHandler, 
public class BiteDestroyController : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public Button biteButton, smashButton, barkButton, sniffButton, pushOrPressButton;
    [Header("�߰� ��ȣ�ۿ� ��ư")]
    public Button centerButton1;
    public Button centerDisableButton1;
    public Button centerButton2;
    public Button centerDisableButton2;

    private bool isPointerDown = false;
    private  float requiredChangeTime = 0.5f;
    private float pointerDownTimer = 0;

    /* ��ȣ�ۿ� ��ư ���� �Լ� */
    void DiableButton()
    {
        smashButton.transform.gameObject.SetActive(false);
        biteButton.transform.gameObject.SetActive(false);
        barkButton.transform.gameObject.SetActive(false);
        sniffButton.transform.gameObject.SetActive(false);
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

    private void Reset()
    {
        isPointerDown = false;
        pointerDownTimer = 0;
    }

    void ChangeButton(Button smashButton, Button biteButton)
    {
        if (isPointerDown)
        {
            pointerDownTimer += Time.deltaTime;
            if (pointerDownTimer >= requiredChangeTime)
            {
                /* 0.5�� �̻� Ŭ���� ���� ��ư ��Ȱ��ȭ, �ı��ϱ� ��ư Ȱ��ȭ */
                smashButton.transform.gameObject.SetActive(true);
                biteButton.transform.gameObject.SetActive(false);

                Reset();
            }
        }
    }

    /* ���콺 Ŭ�� �� ���� ��ȣ�ۿ� ��ư ��Ȱ��ȭ, �չ�ư Ÿ�̸�  & IsPointerDown ���� */
    public void OnPointerUp(PointerEventData eventData)
    {
        DiableButton();
        Reset();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPointerDown = true;
        InteractionButtonController.interactionButtonController.PlayerBite();
    }

    void Update()
    {
        ChangeButton(smashButton, biteButton);
    }






    ////void Update()
    ////{
    ////    if (isPointerDown)
    ////    {
    ////        pointerDownTimer += Time.deltaTime;
    ////        if (pointerDownTimer >= requiredChangeTime)
    ////        {
    ////            /* 0.5�� �̻� Ŭ���� ���� ��ư ��Ȱ��ȭ, �ı��ϱ� ��ư Ȱ��ȭ */
    ////            smashButton.transform.gameObject.SetActive(true);
    ////            biteButton.transform.gameObject.SetActive(false);
    ////            //ChangeBiteToDestroyButton();
    ////            //Invoke("ChangeDestroyTrue", 1f);
    ////            // Invoke("DeleteObject", 2f);
    ////            //Invoke("ChangeDestroyFalse", 3f);
    ////            //noahBiteData.IsDestroy = true;

    ////            Reset();
    ////        }
    ////    }
    ////}

    // void PlayerPickUp(GameObject biteObject)
    //{
    //    noahBiteObject.GetComponent<Rigidbody>().isKinematic = true;   //makes the rigidbody not be acted upon by forces
    //    noahBiteObject.GetComponent<Rigidbody>().useGravity = false;

    //    noahBiteObject.transform.SetParent(myMouth.transform, true);
    //    noahBiteObject.transform.localPosition = mouthPos; // sets the position of the object to your mouth position
    //    noahBiteObject.transform.localEulerAngles = mouthRot; // sets the position of the object to your mouth position      
    //}


    //void ChangeBiteToDestroyButton()
    //{
    //    biteDestroyButton.GetComponent<Image>().sprite = destroyButtonMouseOver;

    //    noahDestroyObject = PlayerScripts.playerscripts.currentObject;
    //    if (noahDestroyObject != null)
    //    {
    //        smashbutton.transform.gameObject.SetActive(true);
    //        bitebutton.transform.gameObject.SetActive(false);
    //        ObjData noahBiteDestroyData = noahBiteObject.GetComponent<ObjData>();
    //        noahBiteDestroyData.IsSmash = true;
    //    }
    //}

    //void ChangeDestroyTrue()
    //{
    //    playerAnimation.SetBool("IsDestroying", true);
    //}

    //void DeleteObject()
    //{
    //    noahDestroyObject.SetActive(false);
    //}
    //void ChangeDestroyFalse()
    //{

    //    playerAnimation.SetBool("IsDestroying", false);
    //    DiableButton();
    //}






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


    ///* ���콺������ ���콺�����̹����� ���� */
    //public void OnPointerEnter(PointerEventData eventData)
    //{
    //    biteDestroyButton.GetComponent<Image>().sprite = biteButtonMouseOver;
    //}

    ///* ���콺 ������ ������ �⺻�̹����� ���� */
    //public void OnPointerExit(PointerEventData eventData)
    //{
    //    biteDestroyButton.GetComponent<Image>().sprite = biteButtonImage;
    //}


}
