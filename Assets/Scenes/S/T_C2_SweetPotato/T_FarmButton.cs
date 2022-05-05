using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_FarmButton : MonoBehaviour, IInteraction
{
    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_T_FarmButton, sniffButton_T_FarmButton, biteButton_T_FarmButton, pressButton_T_FarmButton, noCenterButton_T_FarmButton;

    /*ObjData*/
    ObjData FarmButtonData_T;

    void Start()
    {
        FarmButtonData_T = GetComponent<ObjData>();

        barkButton_T_FarmButton = FarmButtonData_T.BarkButton;
        barkButton_T_FarmButton.onClick.AddListener(OnBark);

        sniffButton_T_FarmButton = FarmButtonData_T.SniffButton;
        sniffButton_T_FarmButton.onClick.AddListener(OnSniff);

        biteButton_T_FarmButton = FarmButtonData_T.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_T_FarmButton = FarmButtonData_T.PushOrPressButton;
        pressButton_T_FarmButton.onClick.AddListener(OnPushOrPress);

        noCenterButton_T_FarmButton = FarmButtonData_T.CenterButton1;
    }

    void DisableButton()
    {
        barkButton_T_FarmButton.transform.gameObject.SetActive(false);
        sniffButton_T_FarmButton.transform.gameObject.SetActive(false);
        biteButton_T_FarmButton.transform.gameObject.SetActive(false);
        pressButton_T_FarmButton.transform.gameObject.SetActive(false);
        noCenterButton_T_FarmButton.transform.gameObject.SetActive(false);
    }


    public void OnBark()
    {
        //FarmButtonData_T.IsBark = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnSniff()
    {
        //FarmButtonData_T.IsSniff = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnPushOrPress()
    {
        //FarmButtonData_T.IsPushOrPress = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();

        //StartCoroutine(ChangePressFalse());
    }


/*    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        FarmButtonData_T.IsPushOrPress = false;
    }*/

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
