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
    public  Sprite biteButtonImages, biteButtonMouseOvers, biteButtonClickeds, destroyButtonMouseOvers;
    GameObject Mouth;
    TMPro.TextMeshProUGUI biteText;
    Animator playerAnimatio;

    [HideInInspector]
    public Vector3 biteObjectFallPosition, biteObjectFallRotation;
    


    bool isPointerDown = false;
    [SerializeField] float requiredHoldTime = 1f;
    [SerializeField] float requiredChangeTime = 0.5f;
    float pointerDownTimer = 0;

    ObjData pipeData_m;
    public GameObject pipe_M;

    // public Button biteDestroyButton; // PlayerScripts - MovePlayer 에서 버튼 이미지 BiteButtonImage 로 바꿈
    public GameObject noahBiteObject, noahDestroyObject;

    void Start()
    {
        biteButtonImages = BiteDestroyButtonController.biteDestroyButtonController.biteButtonImage;
        biteButtonMouseOvers = BiteDestroyButtonController.biteDestroyButtonController.biteButtonMouseOver;
        biteButtonClickeds = BiteDestroyButtonController.biteDestroyButtonController.biteButtonClicked;
        destroyButtonMouseOvers = BiteDestroyButtonController.biteDestroyButtonController.destroyButtonMouseOver;

        playerAnimatio = BiteDestroyButtonController.biteDestroyButtonController.playerAnimation;
        Mouth = BiteDestroyButtonController.biteDestroyButtonController.myMouth;
        biteText = BiteDestroyButtonController.biteDestroyButtonController.biteObjectText;

        isPointerDown = false;
        noahBiteObject = null;
        pipeData_m = pipe_M.GetComponent<ObjData>();
    }


    /* 상호작용 버튼 끄는 함수 */
    void DiableButton()
    {
        barkButton_m_Pipe.transform.gameObject.SetActive(false);
        biteDestroyButton_m_Pipe.transform.gameObject.SetActive(false);
        pressButton_m_Pipe.transform.gameObject.SetActive(false);
        sniffButton_m_Pipe.transform.gameObject.SetActive(false);
        noCenterButton_m_Pipe.transform.gameObject.SetActive(false);
    }

    /* 마우스오버시 마우스오버이미지로 변경 */
    public void OnPointerEnter(PointerEventData eventData)
    {
        biteDestroyButton_m_Pipe.GetComponent<Image>().sprite = biteButtonMouseOvers;
    }

    /* 마우스 밖으로 나가면 기본이미지로 변경 */
    public void OnPointerExit(PointerEventData eventData)
    {
        biteDestroyButton_m_Pipe.GetComponent<Image>().sprite = biteButtonImages;
    }

    /* 마우스 클릭 후 떼면 상호작용 버튼 비활성화, 롱버튼 타이머  & IsPointerDown 리셋 */
    public void OnPointerUp(PointerEventData eventData)
    {
        DiableButton();
        //Reset();
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
            /* 물기 취소할 때 사용하기 위해 저장 */
            PlayerScripts.playerscripts.currentBiteObj = noahBiteObject;

            biteObjectFallPosition = noahBiteObject.transform.position;
            biteObjectFallRotation = noahBiteObject.transform.eulerAngles;

            ObjData noahBiteData = noahBiteObject.GetComponent<ObjData>();
            noahBiteData.IsBite = true;

            biteText.text = "Noah N.113 - " + noahBiteData.ObjectName;


            biteDestroyButton_m_Pipe.GetComponent<Image>().sprite = biteButtonClickeds;
            isPointerDown = true;

            StartCoroutine(BiteAnim());

            biteDestroyButton_m_Pipe.GetComponent<Image>().sprite = biteButtonClickeds;
        }
    }

    IEnumerator BiteAnim()
    {
        yield return new WaitForSeconds(0.5f);
        playerAnimatio.SetBool("IsBiting", true);

        yield return new WaitForSeconds(0.7f);
        noahBiteObject.GetComponent<Rigidbody>().isKinematic = true;   //makes the rigidbody not be acted upon by forces
        noahBiteObject.GetComponent<Rigidbody>().useGravity = false;
        noahBiteObject.transform.parent = Mouth.transform; //makes the object become a child of the parent so that it moves with the mouth
        noahBiteObject.transform.localPosition = new Vector3(0, 0, 0); // sets the position of the object to your mouth position
        noahBiteObject.transform.localEulerAngles = new Vector3(0, 0, 0); // sets the position of the object to your mouth position

        yield return new WaitForSeconds(2f);
        playerAnimatio.SetBool("IsBiting", false);
        yield return null;
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

                noahBiteData.IsDestroy = true;

                biteDestroyButton_m_Pipe.GetComponent<Image>().sprite = destroyButtonMouseOvers;

                StartCoroutine(DestroyAnim());

                Reset();
            }
        }
    }



    IEnumerator DestroyAnim()
    {
        yield return new WaitForSeconds(1f);
        playerAnimatio.SetBool("IsDestroying", true);
        DiableButton();
        yield return new WaitForSeconds(3f);
        playerAnimatio.SetBool("IsDestroying", false);
    }
}
