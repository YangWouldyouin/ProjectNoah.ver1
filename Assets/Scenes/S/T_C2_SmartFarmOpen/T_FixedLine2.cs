using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_FixedLine2 : MonoBehaviour, IInteraction
{
    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_T_FixedLine2, sniffButton_T_FixedLine2, biteButton_T_FixedLine2,
        pressButton_T_FixedLine2, noCenterButton_T_FixedLine2;

    ObjData fixedLine2Data_T;


    void Start()
    {
        fixedLine2Data_T = GetComponent<ObjData>();


        barkButton_T_FixedLine2 = fixedLine2Data_T.BarkButton;
        barkButton_T_FixedLine2.onClick.AddListener(OnBark);

        sniffButton_T_FixedLine2 = fixedLine2Data_T.SniffButton;
        sniffButton_T_FixedLine2.onClick.AddListener(OnSniff);

        biteButton_T_FixedLine2 = fixedLine2Data_T.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_T_FixedLine2 = fixedLine2Data_T.PushOrPressButton;
        pressButton_T_FixedLine2.onClick.AddListener(OnPushOrPress);

        noCenterButton_T_FixedLine2 = fixedLine2Data_T.CenterButton1;
    }

    void DisableButton()
    {
        barkButton_T_FixedLine2.transform.gameObject.SetActive(false);
        sniffButton_T_FixedLine2.transform.gameObject.SetActive(false);
        biteButton_T_FixedLine2.transform.gameObject.SetActive(false);
        pressButton_T_FixedLine2.transform.gameObject.SetActive(false);
        noCenterButton_T_FixedLine2.transform.gameObject.SetActive(false);
    }

    public void OnBark()
    {
        fixedLine2Data_T.IsBark = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }


    public void OnPushOrPress()
    {
        fixedLine2Data_T.IsPushOrPress = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();

        StartCoroutine(ChangePressFalse());
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        fixedLine2Data_T.IsPushOrPress = false;
    }


    public void OnSniff()
    {
        fixedLine2Data_T.IsSniff = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnSmash()
    {

    }

    public void OnUp()
    {
        
    }

    public void OnBite()
    {

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

}
