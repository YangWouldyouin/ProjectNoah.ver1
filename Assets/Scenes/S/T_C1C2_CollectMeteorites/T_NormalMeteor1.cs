using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_NormalMeteor1 : MonoBehaviour, IInteraction
{
    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_T_NormalMeteor1, sniffButton_T_NormalMeteor1, biteButton_T_NormalMeteor1,
        pressButton_T_NormalMeteor1, noCenterButton_T_NormalMeteor1;

    ObjData normalMeteor1Data_T;

    // Start is called before the first frame update
    void Start()
    {
        normalMeteor1Data_T = GetComponent<ObjData>();


        barkButton_T_NormalMeteor1 = normalMeteor1Data_T.BarkButton;
        barkButton_T_NormalMeteor1.onClick.AddListener(OnBark);

        sniffButton_T_NormalMeteor1 = normalMeteor1Data_T.SniffButton;
        sniffButton_T_NormalMeteor1.onClick.AddListener(OnSniff);

        biteButton_T_NormalMeteor1 = normalMeteor1Data_T.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_T_NormalMeteor1 = normalMeteor1Data_T.PushOrPressButton;
        pressButton_T_NormalMeteor1.onClick.AddListener(OnPushOrPress);

        noCenterButton_T_NormalMeteor1 = normalMeteor1Data_T.CenterButton1;
    }

    void DisableButton()
    {
        barkButton_T_NormalMeteor1.transform.gameObject.SetActive(false);
        sniffButton_T_NormalMeteor1.transform.gameObject.SetActive(false);
        biteButton_T_NormalMeteor1.transform.gameObject.SetActive(false);
        pressButton_T_NormalMeteor1.transform.gameObject.SetActive(false);
        noCenterButton_T_NormalMeteor1.transform.gameObject.SetActive(false);
    }

    public void OnBark()
    {
        //normalMeteor1Data_T.IsBark = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnPushOrPress()
    {
       // normalMeteor1Data_T.IsPushOrPress = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();

        //StartCoroutine(ChangePressFalse());
    }

/*    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        normalMeteor1Data_T.IsPushOrPress = false;
    }*/


    public void OnSniff()
    {
        //normalMeteor1Data_T.IsSniff = true;

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
