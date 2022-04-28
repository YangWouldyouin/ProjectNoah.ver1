using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class L_Doll : MonoBehaviour, IInteraction

{
    /* 오브젝트의 상호작용 버튼들 */
    private Button barkButton_L_Doll, sniffButton_L_Doll, biteButton_L_Doll,
pushButton_L_Doll, upButton_L_Doll, upDisableButton_L_Doll, smashButton_L_Doll;

    /* 해당 오브젝트의 ObjData 변수 */
    ObjData DollData_L;

    public GameObject AllDoll_L;
    public GameObject HalfDoll_L;
    public GameObject DestroyDoll_L;

    ObjData AllDollData_L;
    ObjData HalfDollData_L;
    ObjData DestroyDollData_L;


    void Start()
    {
        /* 해당 오브젝트의 ObjData를 가져온다. */
        DollData_L = GetComponent<ObjData>();

        barkButton_L_Doll = DollData_L.BarkButton; // ObjData 로부터 상호작용 버튼을 가져온다.
        barkButton_L_Doll.onClick.AddListener(OnBark); // 버튼에 함수를 넣어준다.

        sniffButton_L_Doll = DollData_L.SniffButton;
        sniffButton_L_Doll.onClick.AddListener(OnSniff);

        biteButton_L_Doll = DollData_L.BiteButton; // 물기

        smashButton_L_Doll = DollData_L.SmashButton; // 파괴하기가 되는 오브젝트이면 파괴하기 버튼 변수를 추가한다.
        smashButton_L_Doll.onClick.AddListener(OnSmash);

        pushButton_L_Doll = DollData_L.PushOrPressButton;
        pushButton_L_Doll.onClick.AddListener(OnPushOrPress);
    }

    /* 상호작용 버튼을 끄는 함수 */
    void DiableButton() // 비활성화 버튼까지 포함하여 위에서 만든 모든 버튼 변수를 끈다.
    {   // ex. 누르기 버튼, 가운데 버튼이 오르기 버튼인데 처음에 비활성화
        barkButton_L_Doll.transform.gameObject.SetActive(false);
        sniffButton_L_Doll.transform.gameObject.SetActive(false);
        biteButton_L_Doll.transform.gameObject.SetActive(false);
        smashButton_L_Doll.transform.gameObject.SetActive(false);
        pushButton_L_Doll.transform.gameObject.SetActive(false);
    }


    void Update()
    {
    }


    /* 상호작용 함수 작성 */
    // 해당 오브젝트에서 실제로 쓰이는 것들만 함수 내용을 채우면 된다.
    public void OnBark() // 짖기
    {
        DollData_L.IsBark = true; // 오브젝트의 짖기 변수 true로 바꿈
        DiableButton(); // 상호작용 버튼을 끔
        InteractionButtonController.interactionButtonController.playerBark(); //애니메이션 보여줌
    }

    public void OnSmash() // 파괴하기
    {
        /* 오브젝트의 파괴하기 변수 true로 바꿈 */
        DollData_L.IsSmash = true;
        /* 상호작용 버튼을 끔 */
        DiableButton();

        /* 오브젝트 흔드는 애니메이션 시작*/
        InteractionButtonController.interactionButtonController.PlayerSmash1();

        /* 파괴하기 내용 쓰기 (2초 딜레이가 애니메이션이 자연스러움) */
        Invoke(" SmashInteraction", 2f);

        /* 오브젝트 흔드는 애니메이션 끝냄 */
        InteractionButtonController.interactionButtonController.PlayerSmash2();
    }

    void SmashInteraction() // 파괴하기를 했을 때 보여주거나 변경할 것들을 적는다 
    {
        AllDoll_L.SetActive(false);
        DestroyDoll_L.SetActive(true);
    }

    public void OnPushOrPress() // 밀기, 누르기
    {
        /* 밀기 & 누르기 중에 "누르기"일 때!!! */

        DollData_L.IsPushOrPress = true;// 오브젝트의 관찰 변수 true로 바꿈
        DiableButton(); // 상호작용 버튼을 끔

        /* 애니메이션 보여줌 */
        InteractionButtonController.interactionButtonController.playerPressHand(); // 손으로 누르는 애니메이션
        StartCoroutine(ChangePressFalse()); // 2초 뒤에 IsPushOrPress 를 false 로 바꿈
    }
    /* 2초 뒤에 누르기 변수를 false 로 바꾸는 코루틴 */
    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        DollData_L.IsPushOrPress = false;
    }

    public void OnSniff() // 냄새맡기
    {
        DollData_L.IsSniff = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }




    public void OnObserve() // 관찰하기
    {
    }
    public void OnInsert() // 끼우기
    {
    }
    public void OnUp() // 오르기
    {
    }
    public void OnEat() // 먹기
    {
    }

    public void OnBite()
    {
        throw new System.NotImplementedException();
    }
}
