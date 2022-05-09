using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_BoxForTuto : MonoBehaviour, IInteraction
{
    Button barkButton_M_BoxForTuto, sniffButton_M_BoxForTuto, biteButton_M_BoxForTuto, 
        pushButton_M_BoxForTuto, upButton_M_BoxForTuto;
    ObjData boxForTutoData_M;

    public ObjectData boxForTutoData;

    public Vector3 pushPos, pushRot;

    public Vector3 boxRisePos;

    public GameObject dialog;
    DialogManager dialogManager;

    /*타이머*/
    public InGameTime inGameTime;

    void Start()
    {
        boxForTutoData_M = GetComponent<ObjData>();

        /* 각 상호작용 버튼에 함수를 넣는다 */
        barkButton_M_BoxForTuto = boxForTutoData_M.BarkButton;
        barkButton_M_BoxForTuto.onClick.AddListener(OnBark);

        sniffButton_M_BoxForTuto = boxForTutoData_M.SniffButton;
        sniffButton_M_BoxForTuto.onClick.AddListener(OnSniff);

        biteButton_M_BoxForTuto = boxForTutoData_M.BiteButton;
        biteButton_M_BoxForTuto.onClick.AddListener(OnBiteDestroy);

        pushButton_M_BoxForTuto = boxForTutoData_M.PushOrPressButton;
        pushButton_M_BoxForTuto.onClick.AddListener(OnPushOrPress);

        upButton_M_BoxForTuto = boxForTutoData_M.CenterButton1;
        upButton_M_BoxForTuto.onClick.AddListener(OnUp);
    }

    void Update()
    {
        if (!GameManager.gameManager._gameData.IsMiddleTuto)
        {
            if (inGameTime.missionTimer == 0)
            {
                GameManager.gameManager._gameData.IsDisqualifiedEnd = true;
                Debug.Log("튜토리얼 실패 엔딩");
            }
        }
    }
    void DiableButton()
    {
        barkButton_M_BoxForTuto.transform.gameObject.SetActive(false);
        sniffButton_M_BoxForTuto.transform.gameObject.SetActive(false);
        biteButton_M_BoxForTuto.transform.gameObject.SetActive(false);
        pushButton_M_BoxForTuto.transform.gameObject.SetActive(false);
        upButton_M_BoxForTuto.transform.gameObject.SetActive(false);
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
        InteractionButtonController.interactionButtonController.PlayerCanNotBite();
    }

    public void OnSniff()
    {
        InteractionButtonController.interactionButtonController.playerSniff();
        DiableButton();
    }

    public void OnPushOrPress()
    {
        /* 상호작용 버튼을 끔 */
        DiableButton();

        /* 애니메이션 실행 */
        InteractionButtonController.interactionButtonController.playerPush();
    }

    //InteractionButtonController.interactionButtonController.pushPos = new Vector3(-0.011f, -0.384f, -0.229f);
    //InteractionButtonController.interactionButtonController.pushRot = new Vector3(0, 0, 0);

    //InteractionButtonController.interactionButtonController.PlayerPush2();

    public void OnUp()
    {
        DiableButton();
        if (!boxForTutoData.IsUpDown)
        {
            PlayerScripts.playerscripts.currentUpObj = this.gameObject;
            boxForTutoData.IsUpDown = true;

            boxRisePos.x = boxForTutoData_M.UpPos.position.x;
            //boxRisePos.y = transform.position.y;
            boxRisePos.z = boxForTutoData_M.UpPos.position.z;

            InteractionButtonController.interactionButtonController.PlayerRise1();
            InteractionButtonController.interactionButtonController.risePosition = boxRisePos;
            InteractionButtonController.interactionButtonController.PlayerRise2();

            //S-2 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
            dialogManager.StartCoroutine(dialogManager.PrintSubtitles(18));
            TimerManager.timerManager.TimerStart(60);
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

    public void OnSmash()
    {
        throw new System.NotImplementedException();
    }
}
