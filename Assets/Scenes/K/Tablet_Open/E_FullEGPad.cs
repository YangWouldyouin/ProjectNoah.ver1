using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class E_FullEGPad : MonoBehaviour, IInteraction
{
    private Button barkButton, sniffButton, biteButton,
pushButton, smashButton, NoCenterButton;

    ObjData FullEGPad_E;

    /* ��ȣ�ۿ� ������Ʈ */
    public GameObject Tablet_C;
    ObjData TabletData_C;

    private float Charge; // �º� - �����е� �Ÿ� ���

    void Start()
    {
        FullEGPad_E = GetComponent<ObjData>();
        TabletData_C = Tablet_C.GetComponent<ObjData>();


        barkButton = FullEGPad_E.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = FullEGPad_E.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = FullEGPad_E.BiteButton; // ���Ⱑ �Ǵ� ������Ʈ

        //smashButton_M_Box = boxData_M.SmashButton;
        //smashButton_M_Box.onClick.AddListener(OnSmash);

        pushButton = FullEGPad_E.PushOrPressButton;
        pushButton.onClick.AddListener(OnPushOrPress);

        // ��Ȱ��ȭ ��ư�� ��ư�� �������⸸ �Ѵ�. 
        NoCenterButton = FullEGPad_E.CenterButton1;
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





    public void OnBark()
    {
        FullEGPad_E.IsBark = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnBite()
    {
        // throw new System.NotImplementedException();

        Charge = Vector3.Distance(Tablet_C.transform.position, FullEGPad_E.transform.position);

        if (Charge <= 1f) // �º��� ����O�е� ���̰� 1f ���� �� ��
        {
            FullEgTablet = true; // �º� ���� ��

            if (TabletData_C.IsObserve) // �º� �����ϱ�
            {
                //if UIȭ�� Ȯ��信�� �˸��� ��й�ȣ�� Ŭ������ ��
                {
                    OpenTablet = true;
                }
            }

        }
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
    public void OnPushOrPress()
    {
    }
    public void OnSmash()
    {
    }
    public void OnSniff()
    {
    }
    public void OnUp()
    {
    }
}
