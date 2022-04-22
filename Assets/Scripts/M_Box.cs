using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_Box : MonoBehaviour, IInteraction
{
    Button barkButton_M_Box, sniffButton_M_Box, biteButton_M_Box, pushButton_M_Box, upButton_M_Box;
    ObjData boxData_M;

    public Vector3 pushPos, pushRot;

    public Vector3 boxRisePos;

    void Start()
    {
        boxData_M = GetComponent<ObjData>();

        /* 각 상호작용 버튼에 함수를 넣는다 */
        barkButton_M_Box = boxData_M.BarkButton;
        barkButton_M_Box.onClick.AddListener(OnBark);

        sniffButton_M_Box = boxData_M.SniffButton;
        sniffButton_M_Box.onClick.AddListener(OnSniff);

        biteButton_M_Box = boxData_M.BiteDestroyButton;
        biteButton_M_Box.onClick.AddListener(OnBiteDestroy);

        pushButton_M_Box = boxData_M.PushOrPressButton;
        pushButton_M_Box.onClick.AddListener(OnPushOrPress);

        upButton_M_Box = boxData_M.CenterButton1;
        upButton_M_Box.onClick.AddListener(OnUp);
    }

    void DiableButton()
    {
        barkButton_M_Box.transform.gameObject.SetActive(false);
        sniffButton_M_Box.transform.gameObject.SetActive(false);
        biteButton_M_Box.transform.gameObject.SetActive(false);
        pushButton_M_Box.transform.gameObject.SetActive(false);
        upButton_M_Box.transform.gameObject.SetActive(false);
    }

    public void OnBark()
    {
        InteractionButtonController.interactionButtonController.playerBark();
        DiableButton();
    }

    public void OnBiteDestroy()
    {
        /* 상호작용 버튼을 끔 */
        DiableButton();
        /*  물기만 하는 애니메이션 & 물 수 없는 오브젝트임을 알림 */
        InteractionButtonController.interactionButtonController.PlayerBite();
    }

    public void OnPushOrPress()
    {
        /* 상호작용 버튼을 끔 */
        DiableButton();

        InteractionButtonController.interactionButtonController.playerPush1();

        InteractionButtonController.interactionButtonController.pushPos = new Vector3(0, 0, 0);
        InteractionButtonController.interactionButtonController.pushRot = new Vector3(0, 0, 0);
        
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

    public void OnBite()
    {
        throw new System.NotImplementedException();
    }

    public void OnDestruct()
    {
        throw new System.NotImplementedException();
    }
}
