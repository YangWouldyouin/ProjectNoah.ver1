using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tu_DogFood : MonoBehaviour, IInteraction
{
    /*���� ���� ������Ʈ*/
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
        /*���� ���� ������Ʈ*/
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
        // ��Ȱ��ȭ ��ư���� �����Ͽ� ������ ���� ��� ��ư ������ ����.

        // ex. ������ ��ư, ��� ��ư�� ������ ��ư�ε� ó���� ��Ȱ��ȭ
        barkButton.transform.gameObject.SetActive(false);
        sniffButton.transform.gameObject.SetActive(false);
        biteButton.transform.gameObject.SetActive(false);
        // �ı��ϱⰡ �Ǵ� ������Ʈ�̸� �ı��ϱ� ��ư �߰�
        smashButton.transform.gameObject.SetActive(false);
        pushButton.transform.gameObject.SetActive(false);
        eatButton.transform.gameObject.SetActive(false);
    }


    void Update()
    {
        if (dogFoodData.IsClicked)
        {
            Debug.Log("�Ծ��");

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
        /* �б� & ������ �߿� "������"�� ��!!! */

        DogFood_Tu.IsPushOrPress = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerPressHand(); // ������ ������ �ִϸ��̼�

        StartCoroutine(ChangePressFalse()); // 2�� �ڿ� IsPushOrPress �� false �� �ٲ�
    }
    IEnumerator ChangePressFalse() // 2�� �ڿ� ������ ������ false �� �ٲٴ� �ڷ�ƾ
    {
        yield return new WaitForSeconds(2f);
        DogFood_Tu.IsPushOrPress = false;
    }

    public void OnEat()
    {
        //���� ���� �̾��ϱ�
        IsIDConsole_Collider.enabled = true;
        IsIDCard_Collider.enabled = true;

        Debug.Log("���� ������ �̾��ҰԿ�");
        //S-1 ��� ��� �١١١١١١١١١١١١١١١١١١١١١١١١١١١١١١١١١١�
        //S-1 ��� ��� Ÿ�̸Ӱ� ������ ��� �����
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

        //���� ���
        //NoahStatController.noahStatController.IncreaseStatBar();
        Invoke("StatUp", 3f);


        //Invoke("NextPuzzle", 2f);

        //SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }

    /*    IEnumerator StartTimer1() // 2�� �ڿ� ������ ������ false �� �ٲٴ� �ڷ�ƾ
        {
            yield return new WaitForSeconds(5f);
            TimerManager.timerManager.TimerStart(60);
        }

        void StartTimer()
        {
            TimerManager.timerManager.TimerStart(60);
        }*/



    public void OnSniff() // �����ñ�
    {
        DogFood_Tu.IsSniff = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerSniff();

        smellUI.SetActive(true);
        Invoke("NoSmellUI", 3f);
    }


    public void OnSmash() // �ı��ϱ�
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