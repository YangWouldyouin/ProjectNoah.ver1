using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/* 클래스 이름 스크립트 이름이랑 똑같이
BiteDestroyController + 오브젝트 이름으로 바꾼다. */

public class BiteDestroyController_IronPlateDoor : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{

    /*연관있는 오브젝트*/
    public GameObject T_DoIronPlateDoor;

    public ObjectData DoIronPlateDoorData_T;

    Outline DoIronPlateDoorOutline_T;

    BoxCollider ironPlateCollider_T;

    /* 상호작용 버튼 변수 */
    // 이름 짓기 규칙 : biteButton + 오브젝트 이름
    public Button biteButtonIronPlateDoor, smashButtonIronPlateDoor, 
        barkButtonIronPlateDoor, sniffButtonIronPlateDoor, pushOrPressButtonIronPlateDoor;
    [Header("추가 상호작용 버튼")]
    public Button centerButton1_IronPlateDoor;
    public Button centerDisableButton1_IronPlateDoor;
    public Button centerButton2_IronPlateDoor;
    public Button centerDisableButton2_IronPlateDoor;

    // 여기서부터 아래까지 복붙

    /* 물기 버튼을 계속 누르고 있으면 파괴하기 버튼으로 바꾸기 위한 변수 */
    // Private 변수라 이름 그대로 써도됨

    // 물기 버튼이 눌렸는지 체크
    private bool isPointerDown = false;
    // 얼마나 오래 누르고 있어야 하는지
    private float requiredChangeTime = 0.5f;
    // 누르고 있는 시간 재기 위한 변수 
    private float pointerDownTimer = 0;

    void Start()
    {
        DoIronPlateDoorOutline_T = T_DoIronPlateDoor.GetComponent<Outline>();
        ironPlateCollider_T = T_DoIronPlateDoor.GetComponent<BoxCollider>();
    }

    void Update()
    {
        // 위에서 정한 파괴하기버튼, 물기 버튼 변수를 넣는다. 
        ChangeButton(smashButtonIronPlateDoor, biteButtonIronPlateDoor);
    }

    /* 버튼을 누르고 있는 시간을 재서 0.5초 이상 눌렀으면 파괴하기 버튼으로 바꾸는 함수 */
    void ChangeButton(Button smashButton, Button biteButton)
    {
        // 물기 버튼을 누르면 
        if (isPointerDown)
        {
            // 누르고 있는 시간을 잰다 
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

    /* 상호작용 버튼 끄는 함수 */
    void DiableButton()
    {
        smashButtonIronPlateDoor.transform.gameObject.SetActive(false);
        biteButtonIronPlateDoor.transform.gameObject.SetActive(false);
        barkButtonIronPlateDoor.transform.gameObject.SetActive(false);
        sniffButtonIronPlateDoor.transform.gameObject.SetActive(false);
        pushOrPressButtonIronPlateDoor.transform.gameObject.SetActive(false);
        centerButton1_IronPlateDoor.transform.gameObject.SetActive(false);

        if (centerDisableButton1_IronPlateDoor != null)
        {
            centerDisableButton1_IronPlateDoor.transform.gameObject.SetActive(false);
        }
        if (centerDisableButton2_IronPlateDoor != null)
        {
            centerDisableButton2_IronPlateDoor.transform.gameObject.SetActive(false);
        }
        if (centerButton2_IronPlateDoor != null)
        {
            centerButton2_IronPlateDoor.transform.gameObject.SetActive(false);
        }
    }
    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    /* 물기 함수 */
    /* 예시) 물기 버튼을 클릭하면 - 물기 이후 다른 행동을 해야 할 때 / 
연속적으로 일어나는 행위일때 물기 한 번만하면 관찰하기 까지 해제되는 연결 행위 */
    public void OnPointerDown(PointerEventData eventData)
    {
        // 물기 버튼이 눌러짐
        isPointerDown = true;

        // 물고나서 나올 상호작용들을 적는다.
        CameraController.cameraController.CancelObserve();
        // ( ex. 관찰 취소 : 현재 관찰하기를 취소하면 앉았다 일어나는 애니메이션이 있어서 
        // 1.5초 정도 딜레이를 주어야 함 )

        // 1.5초 후 물기 애니메이션 + IsBite 변수 참으로 바꿈
        Invoke("DelayBiteAnim", 1f);

        Invoke("IronPlateOpen", 1.7f);
    }

    void DelayBiteAnim()
    {
        InteractionButtonController.interactionButtonController.PlayerBite();
    }

    void IronPlateOpen()
    {
        // 부모 자식 관계를 해제한다.
        T_DoIronPlateDoor.GetComponent<Rigidbody>().isKinematic = false;
        T_DoIronPlateDoor.transform.parent = null;

        // 해당 위치, 각도, 크기로 바꾸겠다.
        T_DoIronPlateDoor.transform.position = new Vector3(-258.15f, 538.619f, 670.1605f); //위치 고정
        T_DoIronPlateDoor.transform.rotation = Quaternion.Euler(7.034f, 90, 90); //각도 고정
        T_DoIronPlateDoor.transform.localScale = new Vector3(-2.882732f, -115.34f, -93.69196f); // 크기 고정

        // 합판 더 이상 상호작용 불가
        DoIronPlateDoorData_T.IsNotInteractable = true;
        DoIronPlateDoorOutline_T.OutlineWidth = 0;

        //콜라이더도 끈다.
        ironPlateCollider_T.enabled = false;
        GameManager.gameManager._gameData.IsIronDisappear_T_C2 = true;
    }


    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    /* 물기 버튼 클릭 후 떼면 */
    public void OnPointerUp(PointerEventData eventData)
    {
        /* 상호작용 버튼 비활성화 */
        DiableButton();
        /* 롱버튼 타이머  & IsPointerDown 원래대로 리셋 */
        Reset();
    }

    private void Reset()
    {
        isPointerDown = false;
        pointerDownTimer = 0;
    }


}

