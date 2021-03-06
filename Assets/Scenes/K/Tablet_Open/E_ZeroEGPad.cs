using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class E_ZeroEGPad : MonoBehaviour, IInteraction
{
    private Button barkButton, sniffButton, biteButton,
pushButton, smashButton, NoCenterButton;

    ObjData ZeroEGPad_E;

    /* 상호작용 오브젝트 */
    public GameObject Tablet_C;
    ObjData TabletData_C;

    private float Charge; // 태블릿 - 충전패드 거리 계산

    void Start()
    {
        ZeroEGPad_E = GetComponent<ObjData>();
        TabletData_C = Tablet_C.GetComponent<ObjData>();


        barkButton = ZeroEGPad_E.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = ZeroEGPad_E.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = ZeroEGPad_E.BiteButton; // 물기가 되는 오브젝트

        //smashButton_M_Box = boxData_M.SmashButton;
        //smashButton_M_Box.onClick.AddListener(OnSmash);

        pushButton = ZeroEGPad_E.PushOrPressButton;
        pushButton.onClick.AddListener(OnPushOrPress);

        // 비활성화 버튼은 버튼을 가져오기만 한다. 
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
        InteractionButtonController.interactionButtonController.playerPressHand(); // 손으로 누르는 애니메이션
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
