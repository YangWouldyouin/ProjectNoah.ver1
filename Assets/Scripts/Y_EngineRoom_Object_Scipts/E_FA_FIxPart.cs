using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class E_FA_FIxPart : MonoBehaviour, IInteraction
{
    private Button barkButton, sniffButton, biteButton, pushButton, noCenterButton;

    public ObjectData fuelabsorberFixPartData;

    ObjData FA_FIxPartData_E;

    // Start is called before the first frame update
    void Start()
    {
        FA_FIxPartData_E = GetComponent<ObjData>();

        /* ObjData �κ��� ��ȣ�ۿ� ��ư�� �����´�. */
        barkButton = FA_FIxPartData_E.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = FA_FIxPartData_E.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = FA_FIxPartData_E.BiteButton;

        pushButton = FA_FIxPartData_E.PushOrPressButton;
        pushButton.onClick.AddListener(OnPushOrPress);

        // ��Ȱ��ȭ ��ư�� ��ư�� �������⸸ �Ѵ�. 
        noCenterButton = FA_FIxPartData_E.CenterButton1;
    }

    void DiableButton()
    {
        // ��Ȱ��ȭ ��ư���� �����Ͽ� ������ ���� ��� ��ư ������ ����.

        // ex. ������ ��ư, ��� ��ư�� ������ ��ư�ε� ó���� ��Ȱ��ȭ
        barkButton.transform.gameObject.SetActive(false);
        sniffButton.transform.gameObject.SetActive(false);
        biteButton.transform.gameObject.SetActive(false);
        pushButton.transform.gameObject.SetActive(false);
        noCenterButton.transform.gameObject.SetActive(false);
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
        //InteractionButtonController.interactionButtonController.PlayerCanNotPush();
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
