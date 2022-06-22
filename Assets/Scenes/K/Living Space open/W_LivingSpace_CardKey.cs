using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class W_LivingSpace_CardKey : MonoBehaviour, IInteraction
{
    private Button barkButton_W_LS_CardKey, sniffButton_W_LS_CardKey, biteButton_W_LS_CardKey,
pushButton_W_LS_CardKey, upButton_W_LS_CardKey, upDisableButton_W_LS_CardKey, smashButton_W_LS_CardKey, centerButton_W_LS_CardKey;

    ObjData LS_CardKeyData_W; // �ش� ������Ʈ�� ObjData ����
    public ObjectData LS_CardKey_W;



    void Start()
    {
        /* �ش� ������Ʈ�� ObjData�� �����´�. */
        LS_CardKeyData_W = GetComponent<ObjData>();

        barkButton_W_LS_CardKey = LS_CardKeyData_W.BarkButton;  // ObjData �κ��� ��ȣ�ۿ� ��ư�� �����´�.
        barkButton_W_LS_CardKey.onClick.AddListener(OnBark); // ��ư�� �Լ��� �־��ش�.

        sniffButton_W_LS_CardKey = LS_CardKeyData_W.SniffButton;
        sniffButton_W_LS_CardKey.onClick.AddListener(OnSniff);

        biteButton_W_LS_CardKey = LS_CardKeyData_W.BiteButton; // ����

        smashButton_W_LS_CardKey = LS_CardKeyData_W.SmashButton; // �ı��ϱⰡ �Ǵ� ������Ʈ�̸� �ı��ϱ� ��ư ������ �߰��Ѵ�.
        smashButton_W_LS_CardKey.onClick.AddListener(OnSmash);

        pushButton_W_LS_CardKey = LS_CardKeyData_W.PushOrPressButton;
        pushButton_W_LS_CardKey.onClick.AddListener(OnPushOrPress);

        centerButton_W_LS_CardKey = LS_CardKeyData_W.CenterButton1;

        LS_CardKey_W.IsCenterButtonChanged = false;
    }

    /* ��ȣ�ۿ� ��ư�� ���� �Լ� */
    void DiableButton() // ��Ȱ��ȭ ��ư���� �����Ͽ� ������ ���� ��� ��ư ������ ����.
    {   // ex. ������ ��ư, ��� ��ư�� ������ ��ư�ε� ó���� ��Ȱ��ȭ
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
        LS_CardKeyData_W.IsBark = true; // ������Ʈ�� ¢�� ���� true�� �ٲ�
        DiableButton(); // ��ȣ�ۿ� ��ư�� ��
        InteractionButtonController.interactionButtonController.playerBark(); //�ִϸ��̼� ������
    }

    public void OnBite()
    {
        //throw new System.NotImplementedException();

    }

    public void OnInsert()  // �����
    {
        LS_CardKeyData_W.IsInsert = true;
        DiableButton();

        /* "�����" �� �̵��� ��ġ�� ���� �ֱ� */
        InteractionButtonController.interactionButtonController.insertPosOffset = new Vector3(1, 0, 1);
        InteractionButtonController.interactionButtonController.insertRotOffset = new Vector3(0, 0, 0);

        /* ����� �ִϸ��̼� & �̵� */
        InteractionButtonController.interactionButtonController.PlayerInsert1();
    }

    /* �б� & ������ �߿� "�б�"�� ��!!! */
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
