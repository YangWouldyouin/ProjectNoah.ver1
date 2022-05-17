using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
// PointerEnterHandler, IPointerExitHandler, IPointerDownHandler, 
public class BiteDestroyController_W_CardKey : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public Button biteButton_W_CardKey, smashButton_W_CardKey, barkButton_W_CardKey, sniffButton_W_CardKey, pushOrPressButton_W_CardKey;
    [Header("추가 상호작용 버튼")]
    public Button centerButton1_W_CardKey;

    private bool isPointerDown = false;
    private float requiredChangeTime = 0.5f;
    private float pointerDownTimer = 0;

    public GameObject cardKey_W;
    ObjData cardKeyData;

    private void Start()
    {
        cardKeyData = cardKey_W.GetComponent<ObjData>();
    }
    /* 상호작용 버튼 끄는 함수 */
    void DiableButton()
    {
        smashButton_W_CardKey.transform.gameObject.SetActive(false);
        biteButton_W_CardKey.transform.gameObject.SetActive(false);
        barkButton_W_CardKey.transform.gameObject.SetActive(false);
        sniffButton_W_CardKey.transform.gameObject.SetActive(false);
        pushOrPressButton_W_CardKey.transform.gameObject.SetActive(false);
        centerButton1_W_CardKey.transform.gameObject.SetActive(false);
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
                /* 0.5초 이상 클릭시 물기 버튼 비활성화, 파괴하기 버튼 활성화 */
                smashButton.transform.gameObject.SetActive(true);
                biteButton.transform.gameObject.SetActive(false);

                Reset();
            }
        }
    }

    /* 마우스 클릭 후 떼면 상호작용 버튼 비활성화, 롱버튼 타이머  & IsPointerDown 리셋 */
    public void OnPointerUp(PointerEventData eventData)
    {
        DiableButton();
        Reset();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPointerDown = true;

        Debug.Log("bite1");
        if(cardKeyData.IsInsert==false)
        {
            CameraController.cameraController.CancelObserve();
            Invoke("Delay15seconds", 1.5f);
            cardKeyData.IsInsert = true;
        }
        else
        {
            InteractionButtonController.interactionButtonController.PlayerBite();
        }
        
        Debug.Log("bite2");
        //StartCoroutine(Delay15seconds());
        
    }

    
    void Delay15seconds()
    {
        
        Debug.Log("bite4");
        InteractionButtonController.interactionButtonController.PlayerBite();

        Debug.Log("bite5");
        /* ♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥ 퍼즐 끝 ♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥ */
    }

    void Update()
    {
        ChangeButton(smashButton_W_CardKey, biteButton_W_CardKey);
    }






    ////void Update()
    ////{
    ////    if (isPointerDown)
    ////    {
    ////        pointerDownTimer += Time.deltaTime;
    ////        if (pointerDownTimer >= requiredChangeTime)
    ////        {
    ////            /* 0.5초 이상 클릭시 물기 버튼 비활성화, 파괴하기 버튼 활성화 */
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
    //        /* 물기 취소할 때 사용하기 위해 저장 */
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


    ///* 마우스오버시 마우스오버이미지로 변경 */
    //public void OnPointerEnter(PointerEventData eventData)
    //{
    //    biteDestroyButton.GetComponent<Image>().sprite = biteButtonMouseOver;
    //}

    ///* 마우스 밖으로 나가면 기본이미지로 변경 */
    //public void OnPointerExit(PointerEventData eventData)
    //{
    //    biteDestroyButton.GetComponent<Image>().sprite = biteButtonImage;
    //}


}

