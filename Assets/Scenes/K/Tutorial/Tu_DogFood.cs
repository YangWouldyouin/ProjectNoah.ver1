using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tu_DogFood : MonoBehaviour, IInteraction
{
    private Button barkButton, sniffButton, biteButton,
pushButton, smashButton, eatButton;

    ObjData DogFood_Tu;



    void Start()
    {
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
        DogFood_Tu.IsEaten = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerEat();
    }

    public void OnSniff() // �����ñ�
    {
        DogFood_Tu.IsSniff = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
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
}