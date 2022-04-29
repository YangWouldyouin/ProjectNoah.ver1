using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_Rubber : MonoBehaviour, IInteraction
{
     /*오브젝트의 상호작용 버튼들*/
     private Button barkButton_M_Rubber, sniffButton_M_Rubber, biteButton_M_Rubber, pressButton_M_Rubber, noCenterButton_M_Rubber;

    ObjData rubberData_M;

    // Start is called before the first frame update
    void Start()
    {
        rubberData_M = GetComponent<ObjData>();


        barkButton_M_Rubber = rubberData_M.BarkButton;
        barkButton_M_Rubber.onClick.AddListener(OnBark);

        sniffButton_M_Rubber = rubberData_M.SniffButton;
        sniffButton_M_Rubber.onClick.AddListener(OnSniff);

        biteButton_M_Rubber = rubberData_M.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_M_Rubber = rubberData_M.PushOrPressButton;
        pressButton_M_Rubber.onClick.AddListener(OnPushOrPress);

        noCenterButton_M_Rubber = rubberData_M.CenterButton1;
    }

    void DisableButton()
    {
        barkButton_M_Rubber.transform.gameObject.SetActive(false);
        sniffButton_M_Rubber.transform.gameObject.SetActive(false);
        biteButton_M_Rubber.transform.gameObject.SetActive(false);
        pressButton_M_Rubber.transform.gameObject.SetActive(false);
        noCenterButton_M_Rubber.transform.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnBark()
    {
        rubberData_M.IsBark = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();

    }


    public void OnPushOrPress()
    {
        rubberData_M.IsPushOrPress = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();

        StartCoroutine(ChangePressFalse());
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        rubberData_M.IsPushOrPress = false;
    }

    public void OnSniff()
    {
        rubberData_M.IsSniff = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }





    public void OnUp()
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

    public void OnBite()
    {
        
    }

    public void OnSmash()
    {
        
    }
}
