using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tu_FoodBox : MonoBehaviour, IInteraction
{
    private Button barkButton, sniffButton, biteButton,
pushButton, DisableButton, smashButton;

    ObjData FoodBox_Tu;

    /* 상호작용 오브젝트 */
    public GameObject FoodBox_Box_Tu;
    public GameObject FoodBox_Door_Tu;
    public GameObject DogFood_Tu;


    void Start()
    {
        FoodBox_Tu = GetComponent<ObjData>();

        barkButton = FoodBox_Tu.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = FoodBox_Tu.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = FoodBox_Tu.BiteButton;
        // "물기"가 안되는 오브젝트는 아래문장을 그대로 쓰고

        // 파괴하기가 되는 오브젝트이면 파괴하기 버튼 변수를 추가한다.
        smashButton = FoodBox_Tu.SmashButton;
        smashButton.onClick.AddListener(OnSmash);

        pushButton = FoodBox_Tu.PushOrPressButton;
        pushButton.onClick.AddListener(OnPushOrPress);

        // 비활성화 버튼은 버튼을 가져오기만 한다. 
        DisableButton = FoodBox_Tu.CenterButton1;

    }
    void DiableButton()
    {
        // 비활성화 버튼까지 포함하여 위에서 만든 모든 버튼 변수를 끈다.

        // ex. 누르기 버튼, 가운데 버튼이 오르기 버튼인데 처음에 비활성화
        barkButton.transform.gameObject.SetActive(false);
        sniffButton.transform.gameObject.SetActive(false);
        biteButton.transform.gameObject.SetActive(false);
        // 파괴하기가 되는 오브젝트이면 파괴하기 버튼 추가
        smashButton.transform.gameObject.SetActive(false);
        pushButton.transform.gameObject.SetActive(false);
        DisableButton.transform.gameObject.SetActive(false);
    }


    void Update()
    {

    }



    public void OnBark()
    {
        FoodBox_Tu.IsBark = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }
    public void OnBite()
    {
        // throw new System.NotImplementedException();
    }
    public void OnPushOrPress()
    {
        /* 밀기 & 누르기 중에 "누르기"일 때!!! */

        FoodBox_Tu.IsPushOrPress = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerPressHand(); // 손으로 누르는 애니메이션

        StartCoroutine(ChangePressFalse()); // 2초 뒤에 IsPushOrPress 를 false 로 바꿈
    }
    IEnumerator ChangePressFalse() // 2초 뒤에 누르기 변수를 false 로 바꾸는 코루틴
    {
        yield return new WaitForSeconds(2f);
        FoodBox_Tu.IsPushOrPress = false;
    }


    public void OnSmash() // 파괴하기
    {
        FoodBox_Tu.IsSmash = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.PlayerSmash1();

        /* 파괴하기 내용 쓰기 (2초 딜레이가 애니메이션이 자연스러움) */
        Invoke(" SmashInteraction", 2f);

        /* 오브젝트 흔드는 애니메이션 끝냄 */
        InteractionButtonController.interactionButtonController.PlayerSmash2();
    }

    void SmashInteraction()
    {
        FoodBox_Box_Tu.SetActive(false);
        FoodBox_Door_Tu.SetActive(false);
        DogFood_Tu.SetActive(true);
    }


    public void OnSniff() // 냄새맡기
    {
        FoodBox_Tu.IsSniff = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }


    public void OnObserve()
    {
    }
    public void OnInsert()
    {
    }
    public void OnEat()
    {
    }
    public void OnUp()
    {
    }
}
