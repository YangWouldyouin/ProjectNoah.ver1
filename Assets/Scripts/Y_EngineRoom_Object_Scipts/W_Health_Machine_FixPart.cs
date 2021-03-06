using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class W_Health_Machine_FixPart : MonoBehaviour, IInteraction
{
    private Button barkButton_W_Health_Machine_FixPart, sniffButton_W_Health_Machine_FixPart, biteButton_W_Health_Machine_FixPart, pushButton_W_Health_Machine_FixPart, noCenterButton_W_Health_Machine_FixPart;

    public ObjectData Health_Machine_FixPartData;

    ObjData HM_FIxPartData_W;

    // Start is called before the first frame update
    void Start()
    {
        HM_FIxPartData_W = GetComponent<ObjData>();

        /* ObjData 로부터 상호작용 버튼을 가져온다. */
        barkButton_W_Health_Machine_FixPart = HM_FIxPartData_W.BarkButton;

        barkButton_W_Health_Machine_FixPart.onClick.AddListener(OnBark);

        sniffButton_W_Health_Machine_FixPart = HM_FIxPartData_W.SniffButton;
        sniffButton_W_Health_Machine_FixPart.onClick.AddListener(OnSniff);

        biteButton_W_Health_Machine_FixPart = HM_FIxPartData_W.BiteButton;

        pushButton_W_Health_Machine_FixPart = HM_FIxPartData_W.PushOrPressButton;
        pushButton_W_Health_Machine_FixPart.onClick.AddListener(OnPushOrPress);

        // 비활성화 버튼은 버튼을 가져오기만 한다. 
        noCenterButton_W_Health_Machine_FixPart = HM_FIxPartData_W.CenterButton1;
    }

    void DiableButton()
    {
        // 비활성화 버튼까지 포함하여 위에서 만든 모든 버튼 변수를 끈다.

        // ex. 누르기 버튼, 가운데 버튼이 오르기 버튼인데 처음에 비활성화
        barkButton_W_Health_Machine_FixPart.transform.gameObject.SetActive(false);
        sniffButton_W_Health_Machine_FixPart.transform.gameObject.SetActive(false);
        biteButton_W_Health_Machine_FixPart.transform.gameObject.SetActive(false);
        pushButton_W_Health_Machine_FixPart.transform.gameObject.SetActive(false);
        noCenterButton_W_Health_Machine_FixPart.transform.gameObject.SetActive(false);
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
