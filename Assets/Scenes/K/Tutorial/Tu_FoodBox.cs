using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tu_FoodBox : MonoBehaviour, IInteraction
{
    private Button barkButton, sniffButton, biteButton,
pushButton, DisableButton, smashButton;

    ObjData FoodBox_Tu;

    /* ��ȣ�ۿ� ������Ʈ */
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
        // "����"�� �ȵǴ� ������Ʈ�� �Ʒ������� �״�� ����

        // �ı��ϱⰡ �Ǵ� ������Ʈ�̸� �ı��ϱ� ��ư ������ �߰��Ѵ�.
        smashButton = FoodBox_Tu.SmashButton;
        smashButton.onClick.AddListener(OnSmash);

        pushButton = FoodBox_Tu.PushOrPressButton;
        pushButton.onClick.AddListener(OnPushOrPress);

        // ��Ȱ��ȭ ��ư�� ��ư�� �������⸸ �Ѵ�. 
        DisableButton = FoodBox_Tu.CenterButton1;

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
        /* �б� & ������ �߿� "������"�� ��!!! */

        FoodBox_Tu.IsPushOrPress = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerPressHand(); // ������ ������ �ִϸ��̼�

        StartCoroutine(ChangePressFalse()); // 2�� �ڿ� IsPushOrPress �� false �� �ٲ�
    }
    IEnumerator ChangePressFalse() // 2�� �ڿ� ������ ������ false �� �ٲٴ� �ڷ�ƾ
    {
        yield return new WaitForSeconds(2f);
        FoodBox_Tu.IsPushOrPress = false;
    }


    public void OnSmash() // �ı��ϱ�
    {
        FoodBox_Tu.IsSmash = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.PlayerSmash1();

        /* �ı��ϱ� ���� ���� (2�� �����̰� �ִϸ��̼��� �ڿ�������) */
        Invoke(" SmashInteraction", 2f);

        /* ������Ʈ ���� �ִϸ��̼� ���� */
        InteractionButtonController.interactionButtonController.PlayerSmash2();
    }

    void SmashInteraction()
    {
        FoodBox_Box_Tu.SetActive(false);
        FoodBox_Door_Tu.SetActive(false);
        DogFood_Tu.SetActive(true);
    }


    public void OnSniff() // �����ñ�
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
