using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/* 클래스 이름 스크립트 이름이랑 똑같이
BiteDestroyController + 오브젝트 이름으로 바꾼다. */

public class BiteDestroyController_CollectMeteorites : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public GameObject canMeteorCollectMachine;

    public ObjectData canMeteorCollectMachineData;
    public ObjectData canNormalMeteor1Data;
    public ObjectData canImportantMeteorData;

    public GameObject canNormalMeteor1;
    public GameObject canImportantMeteor;

    /*Animator*/
    public Animator meteorBoxAnim;

    /*Collider*/
    BoxCollider IsNormalMeteor1Collider;
    BoxCollider IsImportantMeteorCollider;

    /*Outline*/
    Outline canMeteorCollectMachineOutline;

    /* 상호작용 버튼 변수 */
    // 이름 짓기 규칙 : biteButton + 오브젝트 이름
    public Button biteButtonCollectMeteorites, smashButtonCollectMeteorites, barkButtonCollectMeteorites, sniffButtonCollectMeteorites, pushOrPressButtonCollectMeteorites;
    [Header("추가 상호작용 버튼")]
    public Button centerButton1_CollectMeteorites;
    public Button centerDisableButton1_CollectMeteorites;
    public Button centerButton2_CollectMeteorites;
    public Button centerDisableButton2_CollectMeteorites;

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
        /*Collider*/
        IsNormalMeteor1Collider = canNormalMeteor1.GetComponent<BoxCollider>();
        IsImportantMeteorCollider = canImportantMeteor.GetComponent<BoxCollider>();

        canMeteorCollectMachineOutline = canMeteorCollectMachine.GetComponent<Outline>();
    }

    void Update()
    {
        // 위에서 정한 파괴하기버튼, 물기 버튼 변수를 넣는다. 
        ChangeButton(smashButtonCollectMeteorites, biteButtonCollectMeteorites);
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
        smashButtonCollectMeteorites.transform.gameObject.SetActive(false);
        biteButtonCollectMeteorites.transform.gameObject.SetActive(false);
        barkButtonCollectMeteorites.transform.gameObject.SetActive(false);
        sniffButtonCollectMeteorites.transform.gameObject.SetActive(false);
        pushOrPressButtonCollectMeteorites.transform.gameObject.SetActive(false);
        centerButton1_CollectMeteorites.transform.gameObject.SetActive(false);

        if (centerDisableButton1_CollectMeteorites != null)
        {
            centerDisableButton1_CollectMeteorites.transform.gameObject.SetActive(false);
        }
        if (centerDisableButton2_CollectMeteorites != null)
        {
            centerDisableButton2_CollectMeteorites.transform.gameObject.SetActive(false);
        }
        if (centerButton2_CollectMeteorites != null)
        {
            centerButton2_CollectMeteorites.transform.gameObject.SetActive(false);
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
        canNormalMeteor1Data.IsBite = true;

        // 물고나서 나올 상호작용들을 적는다.
         CameraController.cameraController.CancelObserve();
        // ( ex. 관찰 취소 : 현재 관찰하기를 취소하면 앉았다 일어나는 애니메이션이 있어서 
        // 1.5초 정도 딜레이를 주어야 함 )

        // 1.5초 후 물기 애니메이션 + IsBite 변수 참으로 바꿈
        //Invoke("DelayBiteAnim", 1.1f);
        StartCoroutine(Hello());

        // 2초 후 물기 애니메이션 + IsBite 변수 참으로 바꿈
        //Invoke("DoorClose", 1.1f);


    }

    IEnumerator Hello()
    {

        yield return new WaitForSeconds(2f);
        Debug.Log("물고 싶어요");
        InteractionButtonController.interactionButtonController.PlayerBite();

        //C-3 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆

    }

    void DelayBiteAnim()
    {
        Debug.Log("물고 싶어요");
        InteractionButtonController.interactionButtonController.PlayerBite();
    }

    void DoorClose()
    {
        meteorBoxAnim.SetBool("isMeteorBoxOpen", false);
        meteorBoxAnim.SetBool("isMeteorBoxOpenEnd", false);
        meteorBoxAnim.SetBool("isMeteorBoxClose", true);
        meteorBoxAnim.SetBool("isMeteorBoxCloseEnd", true);

        canMeteorCollectMachineData.IsNotInteractable = true; // 상호작용 불가능하게
        canMeteorCollectMachineOutline.OutlineWidth = 0;

        IsNormalMeteor1Collider.enabled = false; //운석에 상호작용 불가능하게
        IsImportantMeteorCollider.enabled = false;

        GameManager.gameManager._gameData.IsMeteorCollectOpen = false;
        GameManager.gameManager._gameData.IsMeteorCollectClose = true;

        //meteorCollectanimOpen_T = false; // 다시 반복할 수 있게
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