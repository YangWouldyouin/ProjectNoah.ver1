using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class E_ZeroEGPad : MonoBehaviour, IInteraction
{
    private Button barkButton, sniffButton, biteButton,
pushButton, smashButton, NoCenterButton;

    ObjData ZeroEGPad_E;

    /* ��ȣ�ۿ� ������Ʈ */
    public GameObject Tablet_C;
    ObjData TabletData_C;

    private float Charge; // �º� - �����е� �Ÿ� ���

    void Start()
    {
        ZeroEGPad_E = GetComponent<ObjData>();
        TabletData_C = Tablet_C.GetComponent<ObjData>();


        barkButton = ZeroEGPad_E.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = ZeroEGPad_E.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = ZeroEGPad_E.BiteButton; // ���Ⱑ �Ǵ� ������Ʈ

        //smashButton_M_Box = boxData_M.SmashButton;
        //smashButton_M_Box.onClick.AddListener(OnSmash);

        pushButton = ZeroEGPad_E.PushOrPressButton;
        pushButton.onClick.AddListener(OnPushOrPress);

        // ��Ȱ��ȭ ��ư�� ��ư�� �������⸸ �Ѵ�. 
        NoCenterButton = ZeroEGPad_E.CenterButton1;
    }
    void DiableButton()
    {
        barkButton.transform.gameObject.SetActive(false);
        sniffButton.transform.gameObject.SetActive(false);
        biteButton.transform.gameObject.SetActive(false);
        pushButton.transform.gameObject.SetActive(false);
        NoCenterButton.transform.gameObject.SetActive(false);
    }

    void Update()
    {
    }

    public void OnSniff()
    {
        ZeroEGPad_E.IsSniff = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnPushOrPress()
    {
        ZeroEGPad_E.IsSniff = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerPressHand(); // ������ ������ �ִϸ��̼�
    }

    public void OnBark()
    {
        ZeroEGPad_E.IsBark = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnBite()
    {
        // throw new System.NotImplementedException();
    }


    public void OnEat()
    {
    }
    public void OnInsert()
    {
    }
    public void OnObserve()
    {
    }
    public void OnSmash()
    {
    }
    public void OnUp()
    {
    }
}
