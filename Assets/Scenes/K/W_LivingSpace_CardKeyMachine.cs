using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class W_LivingSpace_CardKeyMachine : MonoBehaviour, IInteraction
{
    /* 오브젝트의 상호작용 버튼들 */
    private Button barkButton_W_LS_CardKeyMachine, sniffButton_W_LS_CardKeyMachine, biteButton_W_LS_CardKeyMachine,
pushButton_W_LS_CardKeyMachine, upButton_W_LS_CardKeyMachine, upDisableButton_W_LS_CardKeyMachine, smashButton_W_LS_CardKeyMachine;

    /* 해당 오브젝트의 ObjData 변수 */
    ObjData LivingSpace_CardKeyMachine_W;

    /* 이 오브젝트와 상호작용 하는 변수들 + 데이터 */
    public GameObject box_WL;
    public GameObject Card_WL;

    ObjData boxData_WL;
    ObjData CardData_WL;



    void Start()
    {
        /* 해당 오브젝트의 ObjData를 가져온다. */
        LivingSpace_CardKeyMachine_W = GetComponent<ObjData>();


        /* ObjData 로부터 상호작용 버튼을 가져온다. */
        barkButton_W_LS_CardKeyMachine = LivingSpace_CardKeyMachine_W.BarkButton;
        barkButton_W_LS_CardKeyMachine.onClick.AddListener(OnBark);

        sniffButton_W_LS_CardKeyMachine = LivingSpace_CardKeyMachine_W.SniffButton;
        sniffButton_W_LS_CardKeyMachine.onClick.AddListener(OnSniff);

        biteButton_W_LS_CardKeyMachine = LivingSpace_CardKeyMachine_W.BiteButton;
        biteButton_W_LS_CardKeyMachine.onClick.AddListener(OnBite); // "물기"가 안되는 오브젝트

        pushButton_W_LS_CardKeyMachine = LivingSpace_CardKeyMachine_W.PushOrPressButton;
        pushButton_W_LS_CardKeyMachine.onClick.AddListener(OnPushOrPress);
    }

    /* 상호작용 버튼을 끄는 함수 */
    void DiableButton() // 비활성화 버튼까지 포함하여 위에서 만든 모든 버튼 변수를 끈다.
    {   
        barkButton_W_LS_CardKeyMachine.transform.gameObject.SetActive(false);
        sniffButton_W_LS_CardKeyMachine.transform.gameObject.SetActive(false);
        biteButton_W_LS_CardKeyMachine.transform.gameObject.SetActive(false);
        pushButton_W_LS_CardKeyMachine.transform.gameObject.SetActive(false);
    }



    void Update()
    { 
    }

    public void OnBark()
    {
        LivingSpace_CardKeyMachine_W.IsBark = true; // 오브젝트의 짖기 변수 true로 바꿈
        DiableButton(); // 상호작용 버튼을 끔
        InteractionButtonController.interactionButtonController.playerBark(); //애니메이션 보여줌
    }

    public void OnInsert()
    {
        LivingSpace_CardKeyMachine_W.IsInsert = true;
        DiableButton();

        /* "끼우기" 시 이동할 위치와 각도 넣기 */
        InteractionButtonController.interactionButtonController.insertPosOffset = new Vector3(1, 0, 1);
        InteractionButtonController.interactionButtonController.insertRotOffset = new Vector3(0, 0, 0);

        /* 끼우기 애니메이션 & 이동 */
        InteractionButtonController.interactionButtonController.PlayerInsert1();
    }

    public void OnObserve()
    {
        LivingSpace_CardKeyMachine_W.IsObserve = true;
        DiableButton();
        PlayerScripts.playerscripts.currentObserveObj = this.gameObject; // 취소할 때 참고할 오브젝트 저장

        if (boxData_WL.IsUpDown) // 상자에 올라갔을 때
        {
            /* 카메라 컨트롤러에 뷰 전달 */
            CameraController.cameraController.currentView = LivingSpace_CardKeyMachine_W.ObservePlusView; // 관찰 뷰 : 위쪽
            /* 관찰 애니메이션 & 카메라 전환 */
            InteractionButtonController.interactionButtonController.playerObserve();
            
            if (CardData_WL.IsBite) // 카드를 물었을 때
            { 
                // 끼우기 버튼 활성화
            }

            else // 카드를 물지 않았을 때
            { 
                // 끼우기 버튼 비활성화
            }
        }
        
        else // 상자에 안올라갔을 때
        {
            /* 카메라 컨트롤러에 뷰 전달 */
            CameraController.cameraController.currentView = LivingSpace_CardKeyMachine_W.ObserveView; // 관찰 뷰 : 아래쪽
            /* 관찰 애니메이션 & 카메라 전환 */
            InteractionButtonController.interactionButtonController.playerObserve();
        }

    }

    public void OnPushOrPress()
    {
        /* 밀기 & 누르기 중에 "누르기"일 때!!! */

        LivingSpace_CardKeyMachine_W.IsPushOrPress = true;// 오브젝트의 관찰 변수 true로 바꿈
        DiableButton(); // 상호작용 버튼을 끔

        /* 애니메이션 보여줌 */
        InteractionButtonController.interactionButtonController.playerPressHand(); // 손으로 누르는 애니메이션
        StartCoroutine(ChangePressFalse()); // 2초 뒤에 IsPushOrPress 를 false 로 바꿈
    }
    /* 2초 뒤에 누르기 변수를 false 로 바꾸는 코루틴 */
    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        LivingSpace_CardKeyMachine_W.IsPushOrPress = false;
    }

    public void OnSniff()
    {
        LivingSpace_CardKeyMachine_W.IsSniff = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }




    public void OnEat()
    {
    }
    public void OnUp()
    {
    }

    public void OnBite()
    {
    }

    public void OnSmash()
    {
    }
}
