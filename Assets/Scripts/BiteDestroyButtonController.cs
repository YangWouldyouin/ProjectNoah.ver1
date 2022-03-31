using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BiteDestroyButtonController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{ 
    public static BiteDestroyButtonController biteDestroyButtonController { get; private set; }

    void Awake()
    {
        biteDestroyButtonController = this;
    }

    public Animator playerAnimation;

    bool isPointerDown = false;
    [SerializeField] float requiredHoldTime = 1f;
    [SerializeField] float requiredChangeTime = 0.5f;
    float pointerDownTimer = 0;

    public Button biteDestroyButton; // PlayerScripts - MovePlayer 에서 버튼 이미지 BiteButtonImage 로 바꿈
    public Sprite biteButtonImage, biteButtonMouseOver, biteButtonClicked, destroyButtonMouseOver;

    public GameObject noahBiteObject;
    public GameObject noahDestroyObject;
    public GameObject myMouth;
    public Vector3 biteObjectFallPosition, biteObjectFallRotation;

    public TMPro.TextMeshProUGUI biteObjectText;

    void Start()
    {
        isPointerDown = false;
        noahBiteObject = null; // 처음 시작할 때 noahBiteObject 를 null 로 초기화했는데도 발생하고 있습니다.
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
                InteractionButtonController.interactionButtonController.TurnOffInteractionButton();

                Invoke("ChangeDestroyFalse", 3f);

                Reset();
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        biteDestroyButton.GetComponent<Image>().sprite = biteButtonMouseOver;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        biteDestroyButton.GetComponent<Image>().sprite = biteButtonImage;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        InteractionButtonController.interactionButtonController.TurnOffInteractionButton();
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

        biteObjectFallPosition = noahBiteObject.transform.position;
        biteObjectFallRotation = noahBiteObject.transform.eulerAngles;
        if (noahBiteObject!=null)
        {
            ObjData noahBiteData = noahBiteObject.GetComponent<ObjData>();
            biteObjectText.text = "Noah N.113 - " + noahBiteData.ObjectName;
            if (noahBiteData.ISBiteActive)
            {
                noahBiteData.IsBite = true;
                biteDestroyButton.GetComponent<Image>().sprite = biteButtonClicked;
                isPointerDown = true;

                Invoke("ChangeBiteTrue", 0.5f);
                Invoke("PlayerPickUp", 0.7f);
                Invoke("ChangeBiteFalse", 1);
            }
            else
            {
                biteDestroyButton.GetComponent<Image>().sprite = biteButtonClicked;
            }
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
        noahBiteObject.transform.localPosition = new Vector3(0,0,0); // sets the position of the object to your mouth position
        noahBiteObject.transform.localEulerAngles = new Vector3(0, 0, 0); // sets the position of the object to your mouth position
    }

    void ChangeBiteToDestroyButton()
    {
        biteDestroyButton.GetComponent<Image>().sprite = destroyButtonMouseOver;

        noahDestroyObject = PlayerScripts.playerscripts.currentObject;
        if (noahDestroyObject != null)
        {
            ObjData noahBiteDestroyData = noahBiteObject.GetComponent<ObjData>();
            if (noahBiteDestroyData.ISBiteActive)
            {
                noahBiteDestroyData.IsDestroy = true;
            }
        }
    }

    void ChangeDestroyTrue()
    {
        playerAnimation.SetBool("IsDestroying", true);
    }

    void ChangeDestroyFalse()
    {
        playerAnimation.SetBool("IsDestroying", false);
    }

}
