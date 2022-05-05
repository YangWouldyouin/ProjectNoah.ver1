using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_CylinderAnswer : MonoBehaviour, IInteraction
{
    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_M_CylinderAnswer, sniffButton_M_CylinderAnswer, biteButton_M_CylinderAnswer,
        pressButton_M_CylinderAnswer, noCenterButton_M_CylinderAnswer;

    /*ObjData*/
    ObjData CylinderAnswerData_M;

    void Start()
    {
        /*ObjData*/
        CylinderAnswerData_M = GetComponent<ObjData>();

        barkButton_M_CylinderAnswer = CylinderAnswerData_M.BarkButton;
        barkButton_M_CylinderAnswer.onClick.AddListener(OnBark);

        sniffButton_M_CylinderAnswer = CylinderAnswerData_M.SniffButton;
        sniffButton_M_CylinderAnswer.onClick.AddListener(OnSniff);

        biteButton_M_CylinderAnswer = CylinderAnswerData_M.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_M_CylinderAnswer = CylinderAnswerData_M.PushOrPressButton;
        pressButton_M_CylinderAnswer.onClick.AddListener(OnPushOrPress);

        noCenterButton_M_CylinderAnswer = CylinderAnswerData_M.CenterButton1;

    }

    void DisableButton()
    {
        barkButton_M_CylinderAnswer.transform.gameObject.SetActive(false);
        sniffButton_M_CylinderAnswer.transform.gameObject.SetActive(false);
        biteButton_M_CylinderAnswer.transform.gameObject.SetActive(false);
        pressButton_M_CylinderAnswer.transform.gameObject.SetActive(false);
        noCenterButton_M_CylinderAnswer.transform.gameObject.SetActive(false);
    }

    public void OnBark()
    {
        //CylinderAnswerData_M.IsBark = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnPushOrPress()
    {
        //CylinderAnswerData_M.IsPushOrPress = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHead();

        //StartCoroutine(ChangePressFalse());
    }


/*    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        CylinderAnswerData_M.IsPushOrPress = false;
    }*/

    public void OnSniff()
    {
        //CylinderAnswerData_M.IsSniff = true;

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
