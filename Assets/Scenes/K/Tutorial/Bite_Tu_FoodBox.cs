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


    /* ��ȣ�ۿ� ������Ʈ */
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
        // "����"�� �ȵǴ� ������Ʈ�� �Ʒ������� �״�� ����

        // �ı��ϱⰡ �Ǵ� ������Ʈ�̸� �ı��ϱ� ��ư ������ �߰��Ѵ�.
        smashButton = FoodBoxData_Tu.SmashButton;
        smashButton.onClick.AddListener(OnSmash);

        pushButton = FoodBoxData_Tu.PushOrPressButton;
        //pushButton.onClick.AddListener(OnPushOrPress);

        // ��Ȱ��ȭ ��ư�� ��ư�� �������⸸ �Ѵ�. 
        DisableButton = FoodBoxData_Tu.CenterButton1;

/*        FoodBox_Tu.SetActive(true);
        DogFood_Tu.SetActive(false);*/

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
        /* �б� & ������ �߿� "������"�� ��!!! */

        FoodBoxData_Tu.IsPushOrPress = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerPressHand(); // ������ ������ �ִϸ��̼�

        StartCoroutine(ChangePressFalse()); // 2�� �ڿ� IsPushOrPress �� false �� �ٲ�
    }
    IEnumerator ChangePressFalse() // 2�� �ڿ� ������ ������ false �� �ٲٴ� �ڷ�ƾ
    {
        yield return new WaitForSeconds(2f);
        FoodBoxData_Tu.IsPushOrPress = false;
    }


    public void OnSmash() // �ı��ϱ�
    {
        DiableButton();
        InteractionButtonController.interactionButtonController.PlayerSmash1();

        /* �ı��ϱ� ���� ���� (2�� �����̰� �ִϸ��̼��� �ڿ�������) */
        Invoke("SmashInteraction", 2f);
        // SmashInteraction();

        /* ������Ʈ ���� �ִϸ��̼� ���� */
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


    public void OnSniff() // �����ñ�
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
