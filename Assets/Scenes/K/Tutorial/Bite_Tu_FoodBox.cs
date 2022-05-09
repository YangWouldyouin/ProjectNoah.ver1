using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bite_Tu_FoodBox : MonoBehaviour, IInteraction
{
    private Button barkButton, sniffButton, biteButton,
pushButton, DisableButton, smashButton;

    public ObjectData FoodBoxData_Bite;
    ObjData FoodBoxData_Tu;
    public GameObject FoodBox_Tu;
    public Outline FoodBoxOutline_Tu;


    /* 상호작용 오브젝트 */
    public GameObject FoodBox_Box_Tu;
    public GameObject FoodBox_Door_Tu;
    public GameObject DogFood_Tu;
    ObjData DogFoodData_Tu;
    public Outline DogFoodOutline_Tu;

    BoxCollider FoodBox_Collider;

    public GameObject dialog;
    DialogManager dialogManager;

    public bool isBited;

    void Start()
    {
        dialogManager = dialog.GetComponent<DialogManager>();

        FoodBox_Collider = GetComponent<BoxCollider>();

        FoodBoxData_Tu = GetComponent<ObjData>();
        DogFoodData_Tu = DogFood_Tu.GetComponent<ObjData>();

        barkButton = FoodBoxData_Tu.BarkButton;
        //barkButton.onClick.AddListener(OnBark);

        sniffButton = FoodBoxData_Tu.SniffButton;
        //sniffButton.onClick.AddListener(OnSniff);

        biteButton = FoodBoxData_Tu.BiteButton;
        biteButton.onClick.AddListener(OnBite);
        // "물기"가 안되는 오브젝트는 아래문장을 그대로 쓰고

        // 파괴하기가 되는 오브젝트이면 파괴하기 버튼 변수를 추가한다.
        smashButton = FoodBoxData_Tu.SmashButton;
        smashButton.onClick.AddListener(OnSmash);

        pushButton = FoodBoxData_Tu.PushOrPressButton;
        //pushButton.onClick.AddListener(OnPushOrPress);

        // 비활성화 버튼은 버튼을 가져오기만 한다. 
        DisableButton = FoodBoxData_Tu.CenterButton1;

/*        FoodBox_Tu.SetActive(true);
        DogFood_Tu.SetActive(false);*/

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
        if (FoodBoxData_Bite.IsClicked && !isBited)
        {
            dialogManager.StartCoroutine(dialogManager.PrintSubtitles(12));

            FoodBoxData_Bite.IsClicked = false;
        }

        if (FoodBoxData_Bite.IsClicked && isBited)
        {
            dialogManager.StartCoroutine(dialogManager.PrintSubtitles(13));

            FoodBoxData_Bite.IsClicked = false;
        }
    }



    public void OnBark()
    {
        FoodBoxData_Tu.IsBark = true;
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

        FoodBoxData_Tu.IsPushOrPress = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerPressHand(); // 손으로 누르는 애니메이션

        StartCoroutine(ChangePressFalse()); // 2초 뒤에 IsPushOrPress 를 false 로 바꿈
    }
    IEnumerator ChangePressFalse() // 2초 뒤에 누르기 변수를 false 로 바꾸는 코루틴
    {
        yield return new WaitForSeconds(2f);
        FoodBoxData_Tu.IsPushOrPress = false;
    }


    public void OnSmash() // 파괴하기
    {
        DiableButton();
        InteractionButtonController.interactionButtonController.PlayerSmash1();

        /* 파괴하기 내용 쓰기 (2초 딜레이가 애니메이션이 자연스러움) */
        Invoke("SmashInteraction", 2f);
        // SmashInteraction();

        /* 오브젝트 흔드는 애니메이션 끝냄 */
        InteractionButtonController.interactionButtonController.PlayerSmash2();
    }

    void SmashInteraction()
    {
        // Destroy(FoodBoxData_Tu);
        //FoodBox_Box_Tu.SetActive(false);
        //FoodBox_Door_Tu.SetActive(false);
        FoodBox_Tu.SetActive(false);
        FoodBox_Collider.enabled = false;


        //DogFood_Tu.SetActive(true);

        /*        FoodBox_Tu.SetActive(false);
                FoodBoxOutline_Tu.gameObject.SetActive(false);

                DogFood_Tu.SetActive(true);
                DogFoodOutline_Tu.gameObject.SetActive(true);*/

    }


    public void OnSniff() // 냄새맡기
    {
        FoodBoxData_Tu.IsSniff = true;
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
