using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class L_TDBT_FixPart : MonoBehaviour, IInteraction
{
    private Button barkButton_L_TDBT_FixPart, sniffButton_L_TDBT_FixPart, biteButton_L_TDBT_FixPart, pushButton_L_TDBT_FixPart, noCenterButton_L_TDBT_FixPart;

    ObjData TDBT_FIxPartData_L;
    ObjectData fixData;

    void Start()
    {
        TDBT_FIxPartData_L = GetComponent<ObjData>();
        fixData = TDBT_FIxPartData_L.objectDATA;
        fixData.IsNotInteractable = false;
        /* ObjData 로부터 상호작용 버튼을 가져온다. */
        barkButton_L_TDBT_FixPart = TDBT_FIxPartData_L.BarkButton;
        barkButton_L_TDBT_FixPart.onClick.AddListener(OnBark);

        sniffButton_L_TDBT_FixPart = TDBT_FIxPartData_L.SniffButton;
        sniffButton_L_TDBT_FixPart.onClick.AddListener(OnSniff);

        biteButton_L_TDBT_FixPart = TDBT_FIxPartData_L.BiteButton;

        pushButton_L_TDBT_FixPart = TDBT_FIxPartData_L.PushOrPressButton;
        pushButton_L_TDBT_FixPart.onClick.AddListener(OnPushOrPress);

        // 비활성화 버튼은 버튼을 가져오기만 한다. 
        noCenterButton_L_TDBT_FixPart = TDBT_FIxPartData_L.CenterButton1;
    }

    void DiableButton()
    {
        // 비활성화 버튼까지 포함하여 위에서 만든 모든 버튼 변수를 끈다.

        // ex. 누르기 버튼, 가운데 버튼이 오르기 버튼인데 처음에 비활성화
        barkButton_L_TDBT_FixPart.transform.gameObject.SetActive(false);
        sniffButton_L_TDBT_FixPart.transform.gameObject.SetActive(false);
        biteButton_L_TDBT_FixPart.transform.gameObject.SetActive(false);
        pushButton_L_TDBT_FixPart.transform.gameObject.SetActive(false);
        noCenterButton_L_TDBT_FixPart.transform.gameObject.SetActive(false);
    }

    public void OnBark()
    {
        DiableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnPushOrPress()
    {
        DiableButton();
        InteractionButtonController.interactionButtonController.playerPressHand();
        InteractionButtonController.interactionButtonController.PlayerCanNotPush();
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

