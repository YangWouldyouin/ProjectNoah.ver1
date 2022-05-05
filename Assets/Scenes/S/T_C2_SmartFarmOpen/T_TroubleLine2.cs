using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_TroubleLine2 : MonoBehaviour, IInteraction
{
    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_T_TroubleLine2, sniffButton_T_TroubleLine2, biteButton_T_TroubleLine2,
        pressButton_T_TroubleLine2, noCenterButton_T_TroubleLine2;

    ObjData troubleLine2Data_T;


    void Start()
    {
        troubleLine2Data_T = GetComponent<ObjData>();


        barkButton_T_TroubleLine2 = troubleLine2Data_T.BarkButton;
        barkButton_T_TroubleLine2.onClick.AddListener(OnBark);

        sniffButton_T_TroubleLine2 = troubleLine2Data_T.SniffButton;
        sniffButton_T_TroubleLine2.onClick.AddListener(OnSniff);

        biteButton_T_TroubleLine2 = troubleLine2Data_T.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_T_TroubleLine2 = troubleLine2Data_T.PushOrPressButton;
        pressButton_T_TroubleLine2.onClick.AddListener(OnPushOrPress);

        noCenterButton_T_TroubleLine2 = troubleLine2Data_T.CenterButton1;
    }

    void DisableButton()
    {
        barkButton_T_TroubleLine2.transform.gameObject.SetActive(false);
        sniffButton_T_TroubleLine2.transform.gameObject.SetActive(false);
        biteButton_T_TroubleLine2.transform.gameObject.SetActive(false);
        pressButton_T_TroubleLine2.transform.gameObject.SetActive(false);
        noCenterButton_T_TroubleLine2.transform.gameObject.SetActive(false);
    }

    public void OnSniff()
    {

        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnBark()
    {


        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }


    public void OnPushOrPress()
    {


        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();


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

    public void OnSmash()
    {
      
    }

    public void OnUp()
    {
        
    }
}
