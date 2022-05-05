using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_CylinderNoNeed2 : MonoBehaviour, IInteraction
{
    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_M_CylinderNoNeed2, sniffButton_M_CylinderNoNeed2, biteButton_M_CylinderNoNeed2,
        pressButton_M_CylinderNoNeed2, noCenterButton_M_CylinderNoNeed2;

    /*ObjData*/
    ObjData CylinderNoNeed2Data_M;

    void Start()
    {
        /*ObjData*/
        CylinderNoNeed2Data_M = GetComponent<ObjData>();

        barkButton_M_CylinderNoNeed2 = CylinderNoNeed2Data_M.BarkButton;
        barkButton_M_CylinderNoNeed2.onClick.AddListener(OnBark);

        sniffButton_M_CylinderNoNeed2 = CylinderNoNeed2Data_M.SniffButton;
        sniffButton_M_CylinderNoNeed2.onClick.AddListener(OnSniff);

        biteButton_M_CylinderNoNeed2 = CylinderNoNeed2Data_M.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_M_CylinderNoNeed2 = CylinderNoNeed2Data_M.PushOrPressButton;
        pressButton_M_CylinderNoNeed2.onClick.AddListener(OnPushOrPress);

        noCenterButton_M_CylinderNoNeed2 = CylinderNoNeed2Data_M.CenterButton1;

    }

    void DisableButton()
    {
        barkButton_M_CylinderNoNeed2.transform.gameObject.SetActive(false);
        sniffButton_M_CylinderNoNeed2.transform.gameObject.SetActive(false);
        biteButton_M_CylinderNoNeed2.transform.gameObject.SetActive(false);
        pressButton_M_CylinderNoNeed2.transform.gameObject.SetActive(false);
        noCenterButton_M_CylinderNoNeed2.transform.gameObject.SetActive(false);
    }

    public void OnBark()
    {
        //CylinderNoNeed2Data_M.IsBark = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnPushOrPress()
    {
        //CylinderNoNeed2Data_M.IsPushOrPress = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHead();

        //StartCoroutine(ChangePressFalse());
    }


/*    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        CylinderNoNeed2Data_M.IsPushOrPress = false;
    }*/

    public void OnSniff()
    {
        //CylinderNoNeed2Data_M.IsSniff = true;

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
