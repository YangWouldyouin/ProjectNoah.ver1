using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_SuperDrug : MonoBehaviour, IInteraction
{
    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_T_SuperDrug, sniffButton_T_SuperDrug, biteButton_T_SuperDrug,
        pressButton_T_SuperDrug, eatButton_T_SuperDrug; // eatDisableButton_T_SuperDrug;


    /*ObjData*/
    ObjData SuperDrugData_T;

    void Start()
    {
        /*ObjData*/
        SuperDrugData_T = GetComponent<ObjData>();

        barkButton_T_SuperDrug = SuperDrugData_T.BarkButton;
        barkButton_T_SuperDrug.onClick.AddListener(OnBark);

        sniffButton_T_SuperDrug = SuperDrugData_T.SniffButton;
        sniffButton_T_SuperDrug.onClick.AddListener(OnSniff);

        biteButton_T_SuperDrug = SuperDrugData_T.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_T_SuperDrug = SuperDrugData_T.PushOrPressButton;
        pressButton_T_SuperDrug.onClick.AddListener(OnPushOrPress);

        eatButton_T_SuperDrug = SuperDrugData_T.CenterButton1;
        eatButton_T_SuperDrug.onClick.AddListener(OnEat);

        //eatDisableButton_T_SuperDrug = SuperDrugData_T.CenterDisableButton1;
    }

    void DisableButton()
    {
        barkButton_T_SuperDrug.transform.gameObject.SetActive(false);
        sniffButton_T_SuperDrug.transform.gameObject.SetActive(false);
        biteButton_T_SuperDrug.transform.gameObject.SetActive(false);
        pressButton_T_SuperDrug.transform.gameObject.SetActive(false);
        eatButton_T_SuperDrug.transform.gameObject.SetActive(false);
        //eatDisableButton_T_SuperDrug.transform.gameObject.SetActive(false);
    }


    public void OnBark()
    {
        //SuperDrugData_T.IsBark = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnEat()
    {
        //SuperDrugData_T.IsEaten = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerEat();

        Debug.Log("슈퍼성장약 섭취 엔딩");
    }

    public void OnSniff()
    {
        //SuperDrugData_T.IsSniff = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnPushOrPress()
    {
        //SuperDrugData_T.IsPushOrPress = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHead();

        //StartCoroutine(ChangePressFalse());
    }


/*    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        SuperDrugData_T.IsPushOrPress = false;
    }*/

    public void OnBite()
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
