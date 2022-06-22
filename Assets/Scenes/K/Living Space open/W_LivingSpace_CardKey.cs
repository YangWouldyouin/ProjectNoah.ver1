using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class W_LivingSpace_CardKey : MonoBehaviour, IInteraction
{
    private Button barkButton_W_LS_CardKey, sniffButton_W_LS_CardKey, biteButton_W_LS_CardKey,
pushButton_W_LS_CardKey, upButton_W_LS_CardKey, upDisableButton_W_LS_CardKey, smashButton_W_LS_CardKey, centerButton_W_LS_CardKey;

    ObjData LS_CardKeyData_W; // 해당 오브젝트의 ObjData 변수
    public ObjectData LS_CardKey_W;



    void Start()
    {
        /* 해당 오브젝트의 ObjData를 가져온다. */
        LS_CardKeyData_W = GetComponent<ObjData>();

        barkButton_W_LS_CardKey = LS_CardKeyData_W.BarkButton;  // ObjData 로부터 상호작용 버튼을 가져온다.
        barkButton_W_LS_CardKey.onClick.AddListener(OnBark); // 버튼에 함수를 넣어준다.

        sniffButton_W_LS_CardKey = LS_CardKeyData_W.SniffButton;
        sniffButton_W_LS_CardKey.onClick.AddListener(OnSniff);

        biteButton_W_LS_CardKey = LS_CardKeyData_W.BiteButton; // 물기

        smashButton_W_LS_CardKey = LS_CardKeyData_W.SmashButton; // 파괴하기가 되는 오브젝트이면 파괴하기 버튼 변수를 추가한다.
        smashButton_W_LS_CardKey.onClick.AddListener(OnSmash);

        pushButton_W_LS_CardKey = LS_CardKeyData_W.PushOrPressButton;
        pushButton_W_LS_CardKey.onClick.AddListener(OnPushOrPress);

        centerButton_W_LS_CardKey = LS_CardKeyData_W.CenterButton1;

        LS_CardKey_W.IsCenterButtonChanged = false;
    }

    /* 상호작용 버튼을 끄는 함수 */
    void DiableButton() // 비활성화 버튼까지 포함하여 위에서 만든 모든 버튼 변수를 끈다.
    {   // ex. 누르기 버튼, 가운데 버튼이 오르기 버튼인데 처음에 비활성화
        barkButton_W_LS_CardKey.transform.gameObject.SetActive(false);
        sniffButton_W_LS_CardKey.transform.gameObject.SetActive(false);
        biteButton_W_LS_CardKey.transform.gameObject.SetActive(false);
        smashButton_W_LS_CardKey.transform.gameObject.SetActive(false);
        pushButton_W_LS_CardKey.transform.gameObject.SetActive(false);
        centerButton_W_LS_CardKey.transform.gameObject.SetActive(false);

    }

    void Update()
    {
    }

    public void OnBark()
    {
        LS_CardKeyData_W.IsBark = true; // 오브젝트의 짖기 변수 true로 바꿈
        DiableButton(); // 상호작용 버튼을 끔
        InteractionButtonController.interactionButtonController.playerBark(); //애니메이션 보여줌
    }

    public void OnBite()
    {
        //throw new System.NotImplementedException();

    }

    public void OnInsert()  // 끼우기
    {
        LS_CardKeyData_W.IsInsert = true;
        DiableButton();

        /* "끼우기" 시 이동할 위치와 각도 넣기 */
        InteractionButtonController.interactionButtonController.insertPosOffset = new Vector3(1, 0, 1);
        InteractionButtonController.interactionButtonController.insertRotOffset = new Vector3(0, 0, 0);

        /* 끼우기 애니메이션 & 이동 */
        InteractionButtonController.interactionButtonController.PlayerInsert1();
    }

    /* 밀기 & 누르기 중에 "밀기"일 때!!! */
    public void OnPushOrPress()
    {
        LS_CardKeyData_W.IsPushOrPress = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerPressHand();
    }

    public void OnSniff()
    {
        LS_CardKeyData_W.IsSniff = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }



    public void OnObserve()
    {
    }
    public void OnEat()
    {
    }
    public void OnUp()
    {
    }
    public void OnSmash()
    {
    }
}
