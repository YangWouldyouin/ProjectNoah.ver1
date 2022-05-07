using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/* 클래스 이름 스크립트 이름이랑 똑같이
BiteDestroyController + 오브젝트 이름으로 바꾼다. */

public class BiteDestroyController_FoodBox : MonoBehaviour, IPointerUpHandler
{
    /* 상호작용 버튼 변수 */
    // 이름 짓기 규칙 : biteButton + FoodBox
    public Button biteButton, smashButton, barkButton, sniffButton, pushOrPressButton;
    [Header("추가 상호작용 버튼")]
    public Button centerButton1;
    public Button centerDisableButton1;
    public Button centerButton2;
    public Button centerDisableButton2;

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
        ChangeButton(smashButton, biteButton);
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
