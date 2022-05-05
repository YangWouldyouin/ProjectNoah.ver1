using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class E_FA : MonoBehaviour, IInteraction
{
    private Button barkButton_E_FuelAbsorber, sniffButton_E_FuelAbsorber, biteButton_E_FuelAbsorber, pushButton_E_FuelAbsorber, noCenterButton_E_FuelAbsorber, smashButton_E_FuelAbsorber;

    ObjData FuelAbsorber_E;

    void Start()
    {
        FuelAbsorber_E = GetComponent<ObjData>();


        /* ObjData �κ��� ��ȣ�ۿ� ��ư�� �����´�. */
        barkButton_E_FuelAbsorber = FuelAbsorber_E.BarkButton;

        barkButton_E_FuelAbsorber.onClick.AddListener(OnBark);

        sniffButton_E_FuelAbsorber = FuelAbsorber_E.SniffButton;
        sniffButton_E_FuelAbsorber.onClick.AddListener(OnSniff);

        biteButton_E_FuelAbsorber = FuelAbsorber_E.BiteButton;

        pushButton_E_FuelAbsorber = FuelAbsorber_E.PushOrPressButton;
        pushButton_E_FuelAbsorber.onClick.AddListener(OnPushOrPress);

        noCenterButton_E_FuelAbsorber = FuelAbsorber_E.CenterButton1;
    }

    void DiableButton()
    {
        // ��Ȱ��ȭ ��ư���� �����Ͽ� ������ ���� ��� ��ư ������ ����.

        // ex. ������ ��ư, ��� ��ư�� ������ ��ư�ε� ó���� ��Ȱ��ȭ
        barkButton_E_FuelAbsorber.transform.gameObject.SetActive(false);
        sniffButton_E_FuelAbsorber.transform.gameObject.SetActive(false);
        biteButton_E_FuelAbsorber.transform.gameObject.SetActive(false);
        smashButton_E_FuelAbsorber.transform.gameObject.SetActive(false);
        pushButton_E_FuelAbsorber.transform.gameObject.SetActive(false);
        noCenterButton_E_FuelAbsorber.transform.gameObject.SetActive(false);
    }

    public void OnBark()
    {
        DiableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnPushOrPress()
    {
        DiableButton();
        InteractionButtonController.interactionButtonController.playerPressHead();
    }

    public void OnSniff()
    {
        DiableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnEat()
    {
        //throw new System.NotImplementedException();
    }

    public void OnInsert()
    {
        //throw new System.NotImplementedException();
    }

    public void OnObserve()
    {
        //throw new System.NotImplementedException();
    }

    public void OnUp()
    {
        //throw new System.NotImplementedException();
    }

    public void OnBite()
    {
        //throw new System.NotImplementedException();
    }

    public void OnSmash()
    {
        //throw new System.NotImplementedException();
    }
}
