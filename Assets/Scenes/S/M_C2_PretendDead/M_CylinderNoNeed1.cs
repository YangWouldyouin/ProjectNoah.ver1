using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_CylinderNoNeed1 : MonoBehaviour, IInteraction
{
    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_M_CylinderNoNeed1, sniffButton_M_CylinderNoNeed1, biteButton_M_CylinderNoNeed1,
        pressButton_M_CylinderNoNeed1, noCenterButton_M_CylinderNoNeed1;

    /*ObjData*/
    ObjData CylinderNoNeed1Data_M;

    void Start()
    {
        /*ObjData*/
        CylinderNoNeed1Data_M = GetComponent<ObjData>();

        barkButton_M_CylinderNoNeed1 = CylinderNoNeed1Data_M.BarkButton;
        barkButton_M_CylinderNoNeed1.onClick.AddListener(OnBark);

        sniffButton_M_CylinderNoNeed1 = CylinderNoNeed1Data_M.SniffButton;
        sniffButton_M_CylinderNoNeed1.onClick.AddListener(OnSniff);

        biteButton_M_CylinderNoNeed1 = CylinderNoNeed1Data_M.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_M_CylinderNoNeed1 = CylinderNoNeed1Data_M.PushOrPressButton;
        pressButton_M_CylinderNoNeed1.onClick.AddListener(OnPushOrPress);

        noCenterButton_M_CylinderNoNeed1 = CylinderNoNeed1Data_M.CenterButton1;

    }

    void DisableButton()
    {
        barkButton_M_CylinderNoNeed1.transform.gameObject.SetActive(false);
        sniffButton_M_CylinderNoNeed1.transform.gameObject.SetActive(false);
        biteButton_M_CylinderNoNeed1.transform.gameObject.SetActive(false);
        pressButton_M_CylinderNoNeed1.transform.gameObject.SetActive(false);
        noCenterButton_M_CylinderNoNeed1.transform.gameObject.SetActive(false);
    }

    public void OnBark()
    {
        //CylinderNoNeed1Data_M.IsBark = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnPushOrPress()
    {
        //CylinderNoNeed1Data_M.IsPushOrPress = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHead();

        //StartCoroutine(ChangePressFalse());
    }


/*    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        CylinderNoNeed1Data_M.IsPushOrPress = false;
    }*/

    public void OnSniff()
    {
        //CylinderNoNeed1Data_M.IsSniff = true;

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
