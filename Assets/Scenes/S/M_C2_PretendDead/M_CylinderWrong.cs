using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_CylinderWrong : MonoBehaviour, IInteraction
{
    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_M_CylinderWrong, sniffButton_M_CylinderWrong, biteButton_M_CylinderWrong,
        pressButton_M_CylinderWrong, noCenterButton_M_CylinderWrong;

    /*ObjData*/
    ObjData CylinderWrongData_M;

    void Start()
    {
        /*ObjData*/
        CylinderWrongData_M = GetComponent<ObjData>();

        barkButton_M_CylinderWrong = CylinderWrongData_M.BarkButton;
        barkButton_M_CylinderWrong.onClick.AddListener(OnBark);

        sniffButton_M_CylinderWrong = CylinderWrongData_M.SniffButton;
        sniffButton_M_CylinderWrong.onClick.AddListener(OnSniff);

        biteButton_M_CylinderWrong = CylinderWrongData_M.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_M_CylinderWrong = CylinderWrongData_M.PushOrPressButton;
        pressButton_M_CylinderWrong.onClick.AddListener(OnPushOrPress);

        noCenterButton_M_CylinderWrong = CylinderWrongData_M.CenterButton1;

    }

    void DisableButton()
    {
        barkButton_M_CylinderWrong.transform.gameObject.SetActive(false);
        sniffButton_M_CylinderWrong.transform.gameObject.SetActive(false);
        biteButton_M_CylinderWrong.transform.gameObject.SetActive(false);
        pressButton_M_CylinderWrong.transform.gameObject.SetActive(false);
        noCenterButton_M_CylinderWrong.transform.gameObject.SetActive(false);
    }

    public void OnBark()
    {
        CylinderWrongData_M.IsBark = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnPushOrPress()
    {
        CylinderWrongData_M.IsPushOrPress = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHead();

        StartCoroutine(ChangePressFalse());
    }


    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        CylinderWrongData_M.IsPushOrPress = false;
    }

    public void OnSniff()
    {
        CylinderWrongData_M.IsSniff = true;

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
