using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class L_TDBT_FixPart : MonoBehaviour, IInteraction
{
    private Button barkButton_L_TDBT_FixPart, sniffButton_L_TDBT_FixPart, biteButton_L_TDBT_FixPart, pushButton_L_TDBT_FixPart, noCenterButton_L_TDBT_FixPart;

    ObjData TDBT_FIxPartData_L;

    // Start is called before the first frame update
    void Start()
    {
        TDBT_FIxPartData_L = GetComponent<ObjData>();

        /* ObjData �κ��� ��ȣ�ۿ� ��ư�� �����´�. */
        barkButton_L_TDBT_FixPart = TDBT_FIxPartData_L.BarkButton;

        barkButton_L_TDBT_FixPart.onClick.AddListener(OnBark);

        sniffButton_L_TDBT_FixPart = TDBT_FIxPartData_L.SniffButton;
        sniffButton_L_TDBT_FixPart.onClick.AddListener(OnSniff);

        biteButton_L_TDBT_FixPart = TDBT_FIxPartData_L.BiteButton;

        pushButton_L_TDBT_FixPart = TDBT_FIxPartData_L.PushOrPressButton;
        pushButton_L_TDBT_FixPart.onClick.AddListener(OnPushOrPress);

        // ��Ȱ��ȭ ��ư�� ��ư�� �������⸸ �Ѵ�. 
        noCenterButton_L_TDBT_FixPart = TDBT_FIxPartData_L.CenterButton1;
    }

    void DiableButton()
    {
        // ��Ȱ��ȭ ��ư���� �����Ͽ� ������ ���� ��� ��ư ������ ����.

        // ex. ������ ��ư, ��� ��ư�� ������ ��ư�ε� ó���� ��Ȱ��ȭ
        barkButton_L_TDBT_FixPart.transform.gameObject.SetActive(false);
        sniffButton_L_TDBT_FixPart.transform.gameObject.SetActive(false);
        biteButton_L_TDBT_FixPart.transform.gameObject.SetActive(false);
        pushButton_L_TDBT_FixPart.transform.gameObject.SetActive(false);
        noCenterButton_L_TDBT_FixPart.transform.gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {

    }

    /* 2�� �ڿ� ������ ������ false �� �ٲٴ� �ڷ�ƾ */
    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        TDBT_FIxPartData_L.IsPushOrPress = false;
    }

    public void OnBark()
    {
        TDBT_FIxPartData_L.IsBark = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnPushOrPress()
    {
        TDBT_FIxPartData_L.IsPushOrPress = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerPressHead();
        StartCoroutine(ChangePressFalse());
    }

    public void OnSniff()
    {
        TDBT_FIxPartData_L.IsSniff = true;
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

