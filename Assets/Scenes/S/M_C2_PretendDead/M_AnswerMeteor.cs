using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_AnswerMeteor : MonoBehaviour, IInteraction
{
    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_M_AnswerMeteor, sniffButton_M_AnswerMeteor, biteButton_M_AnswerMeteor,
        pressButton_M_AnswerMeteor, noCenterButton_M_AnswerMeteor;

    /*ObjData*/
    ObjData AnswerMeteorData_T;

    void Start()
    {
        /*ObjData*/
        AnswerMeteorData_T = GetComponent<ObjData>();

        barkButton_M_AnswerMeteor = AnswerMeteorData_T.BarkButton;
        barkButton_M_AnswerMeteor.onClick.AddListener(OnBark);

        sniffButton_M_AnswerMeteor = AnswerMeteorData_T.SniffButton;
        sniffButton_M_AnswerMeteor.onClick.AddListener(OnSniff);

        biteButton_M_AnswerMeteor = AnswerMeteorData_T.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_M_AnswerMeteor = AnswerMeteorData_T.PushOrPressButton;
        pressButton_M_AnswerMeteor.onClick.AddListener(OnPushOrPress);

        noCenterButton_M_AnswerMeteor = AnswerMeteorData_T.CenterButton1;

    }

    void DisableButton()
    {
        barkButton_M_AnswerMeteor.transform.gameObject.SetActive(false);
        sniffButton_M_AnswerMeteor.transform.gameObject.SetActive(false);
        biteButton_M_AnswerMeteor.transform.gameObject.SetActive(false);
        pressButton_M_AnswerMeteor.transform.gameObject.SetActive(false);
        noCenterButton_M_AnswerMeteor.transform.gameObject.SetActive(false);
    }


    public void OnBark()
    {
        //AnswerMeteorData_T.IsBark = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnPushOrPress()
    {
        //AnswerMeteorData_T.IsPushOrPress = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();

        //StartCoroutine(ChangePressFalse());
    }

/*    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        AnswerMeteorData_T.IsPushOrPress = false;
    }*/

    public void OnSniff()
    {
        //AnswerMeteorData_T.IsSniff = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
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
