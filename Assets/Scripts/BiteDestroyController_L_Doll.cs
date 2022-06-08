using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
// PointerEnterHandler, IPointerExitHandler, IPointerDownHandler, 
public class BiteDestroyController_L_Doll : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public Button biteButton, smashButton, barkButton, sniffButton, pushOrPressButton;
    [Header("추가 상호작용 버튼")]
    public Button centerButton1;
    public Button centerDisableButton1;
    public Button centerButton2;
    public Button centerDisableButton2;

    private bool isPointerDown = false;
    private  float requiredChangeTime = 0.5f;
    private float pointerDownTimer = 0;

    [Header("애니메이션")]
    public Animator LivingDoorAni_L; // 생활공간 문 완전히 열리기

    [Header("오디오")]
    AudioSource LivingDoor_open_sound;
    public AudioClip LivingDoor_open;

    void Start()
    {
        LivingDoor_open_sound = GetComponent<AudioSource>();
    }

        /* 상호작용 버튼 끄는 함수 */
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
                /* 0.5초 이상 클릭시 물기 버튼 비활성화, 파괴하기 버튼 활성화 */
                smashButton.transform.gameObject.SetActive(true);
                biteButton.transform.gameObject.SetActive(false);

                Reset();
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //StartCoroutine(LivingDoorOpen());// 문 완전히 열리는 애니메이션 실행
        // 물기 버튼이 눌러짐
        isPointerDown = true;
        InteractionButtonController.interactionButtonController.PlayerBite();

        // 물고나서 나올 상호작용들을 적는다.
        GameManager.gameManager._gameData.IsLivingRoomDollOut = true; // 생활공간 문에 끼어있던 인형 꺼냄
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        Debug.Log("인형 빼기");

        // LivingDoorOpen();
       Invoke("LivingDoorOpen", 2f); 

        LivingDoor_open_sound.clip = LivingDoor_open;
        LivingDoor_open_sound.Play();

        GameManager.gameManager._gameData.IsCompleteOpenLivingRoom = true; // 생활공간 문 완전 오픈 완료
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        Debug.Log("문 완전히 열리기");
    }
    void LivingDoorOpen() // 문 열리는 애니메이션
    {

        LivingDoorAni_L.SetBool("LivingOpen", true); // 생활공간 문 완전히 열리기
        LivingDoorAni_L.SetBool("LivingEnd", true);
    }


    void DelayBiteAnim()
    {
        InteractionButtonController.interactionButtonController.PlayerBite();
    }

    /* 마우스 클릭 후 떼면 상호작용 버튼 비활성화, 롱버튼 타이머  & IsPointerDown 리셋 */
    public void OnPointerUp(PointerEventData eventData)
    {
        DiableButton();
        Reset();
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
