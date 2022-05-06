using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/* 클래스 이름 스크립트 이름이랑 똑같이
BiteDestroyController + 오브젝트 이름으로 바꾼다. */

public class BiteDestroyController_Conduction : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public ObjectData biteRubberData_M;
    public ObjectData biteConductionData_M;

    /* 상호작용 버튼 변수 */
    // 이름 짓기 규칙 : biteButton + 오브젝트 이름
    public Button biteButtonConduction, smashButtonConduction, barkButtonConduction, sniffButtonConduction, pushOrPressButtonConduction;
    [Header("추가 상호작용 버튼")]
    public Button centerButton1_Conduction;
    public Button centerDisableButton1_Conduction;
    public Button centerButton2_Conduction;
    public Button centerDisableButton2_Conduction;

    // 여기서부터 아래까지 복붙

    /* 물기 버튼을 계속 누르고 있으면 파괴하기 버튼으로 바꾸기 위한 변수 */
    // Private 변수라 이름 그대로 써도됨

    // 물기 버튼이 눌렸는지 체크
    private bool isPointerDown = false;
    // 얼마나 오래 누르고 있어야 하는지
    private float requiredChangeTime = 0.5f;
    // 누르고 있는 시간 재기 위한 변수 
    private float pointerDownTimer = 0;

    void Update()
    {
        // 위에서 정한 파괴하기버튼, 물기 버튼 변수를 넣는다. 
        ChangeButton(smashButtonConduction, biteButtonConduction);
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
        smashButtonConduction.transform.gameObject.SetActive(false);
        biteButtonConduction.transform.gameObject.SetActive(false);
        barkButtonConduction.transform.gameObject.SetActive(false);
        sniffButtonConduction.transform.gameObject.SetActive(false);
        pushOrPressButtonConduction.transform.gameObject.SetActive(false);
        centerButton1_Conduction.transform.gameObject.SetActive(false);

        if (centerDisableButton1_Conduction != null)
        {
            centerDisableButton1_Conduction.transform.gameObject.SetActive(false);
        }
        if (centerDisableButton2_Conduction != null)
        {
            centerDisableButton2_Conduction.transform.gameObject.SetActive(false);
        }
        if (centerButton2_Conduction != null)
        {
            centerButton2_Conduction.transform.gameObject.SetActive(false);
        }
    }

    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@



    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    /* 물기 함수 */
    /* 예시) 처음에는 그냥 물기만 하다가 특정 조건 만족하면 물기 + 다른 행동을 할 때 */
    public void OnPointerDown(PointerEventData eventData)
    {
        // 물기 버튼이 눌러짐
        isPointerDown = true;

        if (biteRubberData_M.IsBite /*&& biteConductionData_M.IsBite*/)
        {
            Debug.Log("안전합니다.");
            InteractionButtonController.interactionButtonController.PlayerBite();
        }

        else /*if (biteConductionData_M.IsBite)*/
        {
            Debug.Log("감전엔딩");
            InteractionButtonController.interactionButtonController.PlayerBite();
        }


/*        if (boxData.IsUpDown) // 특정 조건을 만족하면
        {
            // 물고나서 나올 상호작용들을 적는다.
            CameraController.cameraController.CancelObserve();

            // 1.5초 후 물기 애니메이션 + IsBite 변수 참으로 바꿈
            Invoke("DelayBiteAnim", 1.5f);
        }
        else // 평소에는 
        {
            // 물기 애니메이션 + IsBite 변수 참으로 바꿈
            InteractionButtonController.interactionButtonController.PlayerBite();
        }*/
    

/*    void DelayBiteAnim()
    {
        InteractionButtonController.interactionButtonController.PlayerBite();
    }*/

    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
}
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