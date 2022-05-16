using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tu_DogFood : MonoBehaviour, IInteraction
{
    /*다음 퍼즐 오브젝트*/
    public GameObject IsIDConsole;
    public GameObject IsIDCard;

    BoxCollider IsIDConsole_Collider;
    BoxCollider IsIDCard_Collider;

    private Button barkButton, sniffButton, biteButton,
pushButton, smashButton, eatButton;

    ObjData DogFood_Tu;

    public ObjectData dogFoodData;

    public DialogManager dialog;
    DialogManager dialogManager;

    public GameObject box;

    public GameObject stat;
    public GameObject smellUI;
    public GameObject conditionUI;


    void Start()
    {
        /*다음 퍼즐 오브젝트*/
        IsIDConsole_Collider = IsIDConsole.GetComponent<BoxCollider>();
        IsIDCard_Collider = IsIDCard.GetComponent<BoxCollider>();

        dialogManager = dialog.GetComponent<DialogManager>();

        DogFood_Tu = GetComponent<ObjData>();

        barkButton = DogFood_Tu.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = DogFood_Tu.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = DogFood_Tu.BiteButton;

        pushButton = DogFood_Tu.PushOrPressButton;
        pushButton.onClick.AddListener(OnPushOrPress);

        smashButton = DogFood_Tu.PushOrPressButton;
        smashButton.onClick.AddListener(OnSmash);

        eatButton = DogFood_Tu.CenterButton1;
        eatButton.onClick.AddListener(OnEat);

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
        eatButton.transform.gameObject.SetActive(false);
    }


    void Update()
    {
        if (dogFoodData.IsClicked)
        {
            Debug.Log("먹어바");

            dialogManager.StartCoroutine(dialogManager.PrintSubtitles(14));

            dogFoodData.IsClicked = false; 
        }
    }



    public void OnBark()
    {
        DogFood_Tu.IsBark = true;
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

        DogFood_Tu.IsPushOrPress = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerPressHand(); // 손으로 누르는 애니메이션

        StartCoroutine(ChangePressFalse()); // 2초 뒤에 IsPushOrPress 를 false 로 바꿈
    }
    IEnumerator ChangePressFalse() // 2초 뒤에 누르기 변수를 false 로 바꾸는 코루틴
    {
        yield return new WaitForSeconds(2f);
        DogFood_Tu.IsPushOrPress = false;
    }

    public void OnEat()
    {
        //다음 퍼즐 이어하기
        IsIDConsole_Collider.enabled = true;
        IsIDCard_Collider.enabled = true;

        Debug.Log("다음 퍼즐을 이어할게요");
        //S-1 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
        //S-1 대사 대신 타이머가 켜지는 대사 출력함
        //dialogManager.StartCoroutine(dialogManager.PrintSubtitles(15));
        //Invoke(" StartTimer", 5f);
        //StartCoroutine(StartTimer1());

        GameManager.gameManager._gameData.IsBasicTuto = true;

        box.GetComponent<BoxCollider>().enabled = true;

        DogFood_Tu.IsEaten = true;
        DiableButton();
        GameManager.gameManager._gameData.IsTutorialClear = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        InteractionButtonController.interactionButtonController.playerEat();


        //GameManager.gameManager._gameData.GoodFoodEat[4] = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        //스탯 상승
        //NoahStatController.noahStatController.IncreaseStatBar();
        Invoke("StatUp", 3f);


        //Invoke("NextPuzzle", 2f);

        //SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }

    /*    IEnumerator StartTimer1() // 2초 뒤에 누르기 변수를 false 로 바꾸는 코루틴
        {
            yield return new WaitForSeconds(5f);
            TimerManager.timerManager.TimerStart(60);
        }

        void StartTimer()
        {
            TimerManager.timerManager.TimerStart(60);
        }*/



    public void OnSniff() // 냄새맡기
    {
        DogFood_Tu.IsSniff = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerSniff();

        smellUI.SetActive(true);
        Invoke("NoSmellUI", 3f);
    }


    public void OnSmash() // 파괴하기
    {
    }
    public void OnObserve()
    {
    }
    public void OnInsert()
    {
    }

    public void OnUp()
    {
    }

    public void StatUp()
    {
        stat.SetActive(true);
        conditionUI.SetActive(true);

        Invoke("NoSmellUI", 3f);
    }

    public void NoSmellUI()
    {
        smellUI.SetActive(false);
        conditionUI.SetActive(false);
    }
}