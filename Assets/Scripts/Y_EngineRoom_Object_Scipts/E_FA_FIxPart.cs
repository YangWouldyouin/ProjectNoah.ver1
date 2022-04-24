using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class E_FA_FIxPart : MonoBehaviour, IInteraction
{
    private Button barkButton_E_FA_FIxPart, sniffButton_E_FA_FIxPart, biteButton_E_FA_FIxPart, pushButton_E_FA_FIxPart, noCenterButton_E_FA_FIxPart;

    ObjData FA_FIxPartData_E;

    // Start is called before the first frame update
    void Start()
    {
        FA_FIxPartData_E = GetComponent<ObjData>();

        /* ObjData �κ��� ��ȣ�ۿ� ��ư�� �����´�. */
        barkButton_E_FA_FIxPart = FA_FIxPartData_E.BarkButton;

        barkButton_E_FA_FIxPart.onClick.AddListener(OnBark);

        sniffButton_E_FA_FIxPart = FA_FIxPartData_E.SniffButton;
        sniffButton_E_FA_FIxPart.onClick.AddListener(OnSniff);

        biteButton_E_FA_FIxPart = FA_FIxPartData_E.BiteButton;

        pushButton_E_FA_FIxPart = FA_FIxPartData_E.PushOrPressButton;
        pushButton_E_FA_FIxPart.onClick.AddListener(OnPushOrPress);

        // ��Ȱ��ȭ ��ư�� ��ư�� �������⸸ �Ѵ�. 
        noCenterButton_E_FA_FIxPart = FA_FIxPartData_E.CenterButton1;
    }

    void DiableButton()
    {
        // ��Ȱ��ȭ ��ư���� �����Ͽ� ������ ���� ��� ��ư ������ ����.

        // ex. ������ ��ư, ��� ��ư�� ������ ��ư�ε� ó���� ��Ȱ��ȭ
        barkButton_E_FA_FIxPart.transform.gameObject.SetActive(false);
        sniffButton_E_FA_FIxPart.transform.gameObject.SetActive(false);
        biteButton_E_FA_FIxPart.transform.gameObject.SetActive(false);
        pushButton_E_FA_FIxPart.transform.gameObject.SetActive(false);
        noCenterButton_E_FA_FIxPart.transform.gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    /* 2�� �ڿ� ������ ������ false �� �ٲٴ� �ڷ�ƾ */
    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        FA_FIxPartData_E.IsPushOrPress = false;
    }

    public void OnBark()
    {
        FA_FIxPartData_E.IsBark = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnPushOrPress()
    {
        FA_FIxPartData_E.IsPushOrPress = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerPressHead();
        StartCoroutine(ChangePressFalse());
    }

    public void OnSniff()
    {
        FA_FIxPartData_E.IsSniff = true;
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
