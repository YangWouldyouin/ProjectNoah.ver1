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


        /* ObjData 로부터 상호작용 버튼을 가져온다. */
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
        // 비활성화 버튼까지 포함하여 위에서 만든 모든 버튼 변수를 끈다.

        // ex. 누르기 버튼, 가운데 버튼이 오르기 버튼인데 처음에 비활성화
        barkButton_E_FuelAbsorber.transform.gameObject.SetActive(false);
        sniffButton_E_FuelAbsorber.transform.gameObject.SetActive(false);
        biteButton_E_FuelAbsorber.transform.gameObject.SetActive(false);
        smashButton_E_FuelAbsorber.transform.gameObject.SetActive(false);
        pushButton_E_FuelAbsorber.transform.gameObject.SetActive(false);
        noCenterButton_E_FuelAbsorber.transform.gameObject.SetActive(false);
    }

    /* 2초 뒤에 누르기 변수를 false 로 바꾸는 코루틴 */
    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        FuelAbsorber_E.IsPushOrPress = false;
    }

    public void OnBark()
    {
        FuelAbsorber_E.IsBark = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnPushOrPress()
    {
        FuelAbsorber_E.IsPushOrPress = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerPressHead();
        StartCoroutine(ChangePressFalse());

    }

    public void OnSniff()
    {
        FuelAbsorber_E.IsSniff = true;
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
