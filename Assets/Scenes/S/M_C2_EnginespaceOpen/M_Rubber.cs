using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_Rubber : MonoBehaviour, IInteraction
{
     /*오브젝트의 상호작용 버튼들*/
     private Button barkButton_M_Rubber, sniffButton_M_Rubber, biteButton_M_Rubber, pressButton_M_Rubber, noCenterButton_M_Rubber;

    /*ObjData*/
    ObjData rubberObjData_M;
    public ObjectData rubberData_M;

    /*Collider*/
    BoxCollider rubber_Collider;

    // Start is called before the first frame update
    void Start()
    {
        rubberObjData_M = GetComponent<ObjData>();
        rubber_Collider = GetComponent<BoxCollider>();

        barkButton_M_Rubber = rubberObjData_M.BarkButton;
        barkButton_M_Rubber.onClick.AddListener(OnBark);

        sniffButton_M_Rubber = rubberObjData_M.SniffButton;
        sniffButton_M_Rubber.onClick.AddListener(OnSniff);

        biteButton_M_Rubber = rubberObjData_M.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_M_Rubber = rubberObjData_M.PushOrPressButton;
        pressButton_M_Rubber.onClick.AddListener(OnPushOrPress);

        noCenterButton_M_Rubber = rubberObjData_M.CenterButton1;
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
        if(rubberData_M.IsBite) // 콜라이더 겹치는 거 방지 물면 콜라이더 꺼주는 거
        {
            rubber_Collider.enabled = false;
        }
        else
        {
            rubber_Collider.enabled = true;
        }

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

    public void OnSniff()
    {

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
