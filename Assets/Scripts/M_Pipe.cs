using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_Pipe : MonoBehaviour, IInteraction
{
    private ObjData pipeData_M;

    private Button barkButton_M_Pipe, biteButton_M_Pipe, smashButton_M_Pipe, 
        pressButton_M_Pipe, sniffButton_M_Pipe, noCenterButton_M_Pipe;

    void Start()
    {
        pipeData_M = GetComponent<ObjData>();
        
        /* 각 상호작용 버튼에 함수를 넣는다 */
        barkButton_M_Pipe = pipeData_M.BarkButton;
        barkButton_M_Pipe.onClick.AddListener(OnBark);

        biteButton_M_Pipe = pipeData_M.BiteButton;

        smashButton_M_Pipe = pipeData_M.SmashButton;
        smashButton_M_Pipe.onClick.AddListener(OnSmash);

        sniffButton_M_Pipe = pipeData_M.SniffButton;
        sniffButton_M_Pipe.onClick.AddListener(OnSniff);

        pressButton_M_Pipe = pipeData_M.PushOrPressButton;
        pressButton_M_Pipe.onClick.AddListener(OnPushOrPress);

        noCenterButton_M_Pipe = pipeData_M.CenterButton1;
    }

    /* 상호작용 버튼 끄는 함수 */
    void DiableButton()
    {
        biteButton_M_Pipe.transform.gameObject.SetActive(false);
        smashButton_M_Pipe.transform.gameObject.SetActive(false);
        barkButton_M_Pipe.transform.gameObject.SetActive(false);
        pressButton_M_Pipe.transform.gameObject.SetActive(false);
        sniffButton_M_Pipe.transform.gameObject.SetActive(false);
        noCenterButton_M_Pipe.transform.gameObject.SetActive(false);
    }

    public void OnSmash()
    {
        /* 상호작용 버튼을 끔 */
        DiableButton();

        /* 오브젝트 흔드는 애니메이션 시작*/
        InteractionButtonController.interactionButtonController.PlayerSmash1();

        /* 파괴하기 내용 쓰기 (2초 정도가 애니메이션이 자연스러움) */
        Invoke(" SmashInteraction", 2f);

        /* 오브젝트 흔드는 애니메이션 끝냄 */
        InteractionButtonController.interactionButtonController.PlayerSmash2();
    }

    void SmashInteraction()
    {
        // 부모 비활성화, 자식 활성화 등등 각 오브젝트에 맞춰서 필요한 것들 쓰기
    }

    public void OnBark()
    {
        /* 상호작용 버튼을 끔 */
        DiableButton();
        /* 애니메이션 보여줌 */
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnSniff()
    {
        /* 상호작용 버튼을 끔 */
        DiableButton();
        /* 애니메이션 보여주고 냄새 텍스트 띄움 */
        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnPushOrPress()
    {
        /* 상호작용 버튼을 끔 */
        DiableButton();

        /* 애니메이션 보여줌 */
        InteractionButtonController.interactionButtonController.playerPressHand(); // 손으로 누르는 애니메이션

        ///* 임무 리스트에 "AI 깨우기" 미션 추가 */
        //GameManager.gameManager._gameData.ActiveMissionList[1] = true;
        //SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        //MissionGenerator.missionGenerator.IsOn = false;
        //MissionGenerator.missionGenerator.ShowMissionList();
    }

    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    public void OnEat()
    {
        throw new System.NotImplementedException();
    }

    public void OnObserve()
    {
        throw new System.NotImplementedException();
    }

    public void OnUp()
    {
        throw new System.NotImplementedException();
    }

    public void OnInsert()
    {
        throw new System.NotImplementedException();
    }

    public void OnBite()
    {
        // 진짜 "물기" 가 되는 오브젝트는 비워둠
    }

}
