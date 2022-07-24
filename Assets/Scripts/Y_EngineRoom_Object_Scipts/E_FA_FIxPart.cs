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

        /* ObjData 로부터 상호작용 버튼을 가져온다. */
        barkButton = FA_FIxPartData_E.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = FA_FIxPartData_E.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = FA_FIxPartData_E.BiteButton;

        pushButton = FA_FIxPartData_E.PushOrPressButton;
        pushButton.onClick.AddListener(OnPushOrPress);

        // 비활성화 버튼은 버튼을 가져오기만 한다. 
        noCenterButton = FA_FIxPartData_E.CenterButton1;
    }

    void DiableButton()
    {
        // 비활성화 버튼까지 포함하여 위에서 만든 모든 버튼 변수를 끈다.

        // ex. 누르기 버튼, 가운데 버튼이 오르기 버튼인데 처음에 비활성화
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
