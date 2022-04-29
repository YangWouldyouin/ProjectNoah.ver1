using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class T_IronPlateDoor : MonoBehaviour, IInteraction
{
    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_T_IronPlateDoor, sniffButton_T_IronPlateDoor, biteButton_T_IronPlateDoor,
        pressButton_T_IronPlateDoor, noCenterButton_T_IronPlateDoor;

    ObjData ironPlateDoorData_T;


    void Start()
    {
        ironPlateDoorData_T = GetComponent<ObjData>();


        barkButton_T_IronPlateDoor = ironPlateDoorData_T.BarkButton;
        barkButton_T_IronPlateDoor.onClick.AddListener(OnBark);

        sniffButton_T_IronPlateDoor = ironPlateDoorData_T.SniffButton;
        sniffButton_T_IronPlateDoor.onClick.AddListener(OnSniff);

        biteButton_T_IronPlateDoor = ironPlateDoorData_T.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_T_IronPlateDoor = ironPlateDoorData_T.PushOrPressButton;
        pressButton_T_IronPlateDoor.onClick.AddListener(OnPushOrPress);

        noCenterButton_T_IronPlateDoor = ironPlateDoorData_T.CenterButton1;
    }

    void DisableButton()
    {
        barkButton_T_IronPlateDoor.transform.gameObject.SetActive(false);
        sniffButton_T_IronPlateDoor.transform.gameObject.SetActive(false);
        biteButton_T_IronPlateDoor.transform.gameObject.SetActive(false);
        pressButton_T_IronPlateDoor.transform.gameObject.SetActive(false);
        noCenterButton_T_IronPlateDoor.transform.gameObject.SetActive(false);
    }

    public void OnBark()
    {
        ironPlateDoorData_T.IsBark = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnPushOrPress()
    {
        ironPlateDoorData_T.IsPushOrPress = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();

        StartCoroutine(ChangePressFalse());
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        ironPlateDoorData_T.IsPushOrPress = false;
    }

    public void OnSniff()
    {
        ironPlateDoorData_T.IsSniff = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }


    public void OnSmash()
    {
       
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

    public void OnUp()
    {
      
    }
}
