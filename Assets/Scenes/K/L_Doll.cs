using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class L_Doll : MonoBehaviour, IInteraction

{
    /* ������Ʈ�� ��ȣ�ۿ� ��ư�� */
    private Button barkButton_L_Doll, sniffButton_L_Doll, biteButton_L_Doll,
pushButton_L_Doll, upButton_L_Doll, upDisableButton_L_Doll, smashButton_L_Doll;

    /* �ش� ������Ʈ�� ObjData ���� */
    ObjData DollData_L;

    public GameObject AllDoll_L;
    public GameObject HalfDoll_L;
    public GameObject DestroyDoll_L;

    ObjData AllDollData_L;
    ObjData HalfDollData_L;
    ObjData DestroyDollData_L;


    void Start()
    {
        /* �ش� ������Ʈ�� ObjData�� �����´�. */
        DollData_L = GetComponent<ObjData>();

        barkButton_L_Doll = DollData_L.BarkButton; // ObjData �κ��� ��ȣ�ۿ� ��ư�� �����´�.
        barkButton_L_Doll.onClick.AddListener(OnBark); // ��ư�� �Լ��� �־��ش�.

        sniffButton_L_Doll = DollData_L.SniffButton;
        sniffButton_L_Doll.onClick.AddListener(OnSniff);

        biteButton_L_Doll = DollData_L.BiteButton; // ����

        smashButton_L_Doll = DollData_L.SmashButton; // �ı��ϱⰡ �Ǵ� ������Ʈ�̸� �ı��ϱ� ��ư ������ �߰��Ѵ�.
        smashButton_L_Doll.onClick.AddListener(OnSmash);

        pushButton_L_Doll = DollData_L.PushOrPressButton;
        pushButton_L_Doll.onClick.AddListener(OnPushOrPress);
    }

    /* ��ȣ�ۿ� ��ư�� ���� �Լ� */
    void DiableButton() // ��Ȱ��ȭ ��ư���� �����Ͽ� ������ ���� ��� ��ư ������ ����.
    {   // ex. ������ ��ư, ��� ��ư�� ������ ��ư�ε� ó���� ��Ȱ��ȭ
        barkButton_L_Doll.transform.gameObject.SetActive(false);
        sniffButton_L_Doll.transform.gameObject.SetActive(false);
        biteButton_L_Doll.transform.gameObject.SetActive(false);
        smashButton_L_Doll.transform.gameObject.SetActive(false);
        pushButton_L_Doll.transform.gameObject.SetActive(false);
    }


    void Update()
    {
    }


    /* ��ȣ�ۿ� �Լ� �ۼ� */
    // �ش� ������Ʈ���� ������ ���̴� �͵鸸 �Լ� ������ ä��� �ȴ�.
    public void OnBark() // ¢��
    {
        DollData_L.IsBark = true; // ������Ʈ�� ¢�� ���� true�� �ٲ�
        DiableButton(); // ��ȣ�ۿ� ��ư�� ��
        InteractionButtonController.interactionButtonController.playerBark(); //�ִϸ��̼� ������
    }

    public void OnSmash() // �ı��ϱ�
    {
        /* ������Ʈ�� �ı��ϱ� ���� true�� �ٲ� */
        DollData_L.IsSmash = true;
        /* ��ȣ�ۿ� ��ư�� �� */
        DiableButton();

        /* ������Ʈ ���� �ִϸ��̼� ����*/
        InteractionButtonController.interactionButtonController.PlayerSmash1();

        /* �ı��ϱ� ���� ���� (2�� �����̰� �ִϸ��̼��� �ڿ�������) */
        Invoke(" SmashInteraction", 2f);

        /* ������Ʈ ���� �ִϸ��̼� ���� */
        InteractionButtonController.interactionButtonController.PlayerSmash2();
    }

    void SmashInteraction() // �ı��ϱ⸦ ���� �� �����ְų� ������ �͵��� ���´� 
    {
        AllDoll_L.SetActive(false);
        DestroyDoll_L.SetActive(true);
    }

    public void OnPushOrPress() // �б�, ������
    {
        /* �б� & ������ �߿� "������"�� ��!!! */

        DollData_L.IsPushOrPress = true;// ������Ʈ�� ���� ���� true�� �ٲ�
        DiableButton(); // ��ȣ�ۿ� ��ư�� ��

        /* �ִϸ��̼� ������ */
        InteractionButtonController.interactionButtonController.playerPressHand(); // ������ ������ �ִϸ��̼�
        StartCoroutine(ChangePressFalse()); // 2�� �ڿ� IsPushOrPress �� false �� �ٲ�
    }
    /* 2�� �ڿ� ������ ������ false �� �ٲٴ� �ڷ�ƾ */
    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        DollData_L.IsPushOrPress = false;
    }

    public void OnSniff() // �����ñ�
    {
        DollData_L.IsSniff = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }




    public void OnObserve() // �����ϱ�
    {
    }
    public void OnInsert() // �����
    {
    }
    public void OnUp() // ������
    {
    }
    public void OnEat() // �Ա�
    {
    }

    public void OnBite()
    {
        throw new System.NotImplementedException();
    }
}
