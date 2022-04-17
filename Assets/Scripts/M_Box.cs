using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_Box : MonoBehaviour, IInteraction
{
    public Button bb1, bb2, bb3, bb4, bb5;
    ObjData boxData_M;

    public Vector3 pushPos, pushRot;

    public Vector3 boxRisePos;

    void Start()
    {
        boxData_M = GetComponent<ObjData>();
    }

    void DiableButton()
    {
        bb1.transform.gameObject.SetActive(false);
        bb2.transform.gameObject.SetActive(false);
        bb3.transform.gameObject.SetActive(false);
        bb4.transform.gameObject.SetActive(false);
        bb5.transform.gameObject.SetActive(false);
    }

    public void OnBark()
    {
        InteractionButtonController.interactionButtonController.playerBark();
        DiableButton();
    }

    public void OnBiteDestroy()
    {

    }

    public void OnPushOrPress()
    {
        PlayerScripts.playerscripts.currentPushOrPressObj = this.gameObject;
        InteractionButtonController.interactionButtonController.playerPush1();
        this.transform.localPosition = pushPos; // sets the position of the object to your mouth position
        this.transform.localEulerAngles = pushRot; // sets the position of the object to your mouth position
        InteractionButtonController.interactionButtonController.PlayerPush2();
    }

    public void OnSniff()
    {
        InteractionButtonController.interactionButtonController.playerSniff();
        DiableButton();
    }

    public void OnUp()
    {
        if(!boxData_M.IsUpDown)
        {
            boxRisePos.x = this.transform.position.x;
            boxRisePos.y = this.transform.position.y;
            boxRisePos.z = this.transform.position.z;
            PlayerScripts.playerscripts.currentUpObj = this.gameObject;           
            boxData_M.IsUpDown = true;
            InteractionButtonController.interactionButtonController.PlayerRise1();
            InteractionButtonController.interactionButtonController.risePosition = boxRisePos;
            InteractionButtonController.interactionButtonController.PlayerRise2();
        }
    }

    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    public void OnEat()
    {
        //throw new System.NotImplementedException();
    }

    public void OnInsert()
    {
        //throw new System.NotImplementedException();
    }

    public void OnObserve()
    {
        //throw new System.NotImplementedException();
    }
}
