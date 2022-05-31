using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_BoxForTuto : MonoBehaviour, IInteraction
{
    public bool noMoreTimer = false;
    public bool OnlyOneTimer = false;

    public GameObject S_TimerBarFilled;
    public GameObject S_TimerBackground;
    public GameObject S_TimerText;

    Button barkButton_M_BoxForTuto, sniffButton_M_BoxForTuto, biteButton_M_BoxForTuto, 
        pushButton_M_BoxForTuto, upButton_M_BoxForTuto;
    ObjData boxForTutoData_M;

    public ObjectData boxForTutoData;

    public Vector3 pushPos, pushRot;

    public Vector3 boxRisePos;

    public DialogManager dialog;
    DialogManager dialogManager;

    /*Ÿ�̸�*/
    public InGameTime inGameTime;

    public ObjectData IDCardData;

    public bool FailTuto = false;

    public bool IsTutoFail = false;


    void Start()
    {
        boxForTutoData.IsUpDown = false;

         boxForTutoData_M = GetComponent<ObjData>();

        /* �� ��ȣ�ۿ� ��ư�� �Լ��� �ִ´� */
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
        dialogManager = dialog.GetComponent<DialogManager>();
    }

    void Update()
    {
        /*Ʃ�丮�� ����*/

        if (IsTutoFail == true && FailTuto == false && !GameManager.gameManager._gameData.IsRealMiddleTuto)
        {
            GameManager.gameManager._gameData.IsDisqualifiedEnd = true;
            Debug.Log("Ʃ�丮�� ���� ����");
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            FailTuto = true;
        }

/*        if (!GameManager.gameManager._gameData.IsRealMiddleTuto && FailTuto == false)
        {
          
        }*/

        /*Ÿ�� ���� ������*/
        if(GameManager.gameManager._gameData.IsMiddleTuto)
        {
            inGameTime.IsTimerStarted = false;

            S_TimerBarFilled.SetActive(false);
            S_TimerBackground.SetActive(false);
            S_TimerText.SetActive(false);

            Debug.Log("��¥ Ʃ�丮�� �Ϸ�");
            GameManager.gameManager._gameData.IsMiddleTuto = false;
            GameManager.gameManager._gameData.IsRealMiddleTuto = true; //��¥ Ʃ�丮�� �߰� ����
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
        /* ��ȣ�ۿ� ��ư�� �� */
        DiableButton();
        /*  ���⸸ �ϴ� �ִϸ��̼� & �� �� ���� ������Ʈ���� �˸� */
        InteractionButtonController.interactionButtonController.PlayerCanNotBite();
    }

    public void OnSniff()
    {
        InteractionButtonController.interactionButtonController.playerSniff();
        DiableButton();
    }

    public void OnPushOrPress()
    {
        /* ��ȣ�ۿ� ��ư�� �� */
        DiableButton();

        /* �ִϸ��̼� ���� */
        InteractionButtonController.interactionButtonController.playerPush();

        dialogManager.StartCoroutine(dialogManager.PrintSubtitles(28));
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

            // �ڽ� ��ġ�� �°� �����⸦ �ߴٸ� Ÿ�̸� ��ŸƮ
            if(GameManager.gameManager._gameData.BoxZoneCheck == true && OnlyOneTimer == false)
            {
                TimerManager.timerManager.TimerStart(120);
                Invoke("TutoFailCheck", 120f);

                OnlyOneTimer = true;
            }


            if (!IDCardData.IsBite && noMoreTimer == false)
            {
                dialogManager.StartCoroutine(dialogManager.PrintSubtitles(18));

                noMoreTimer = true;
            }

            //S-2 ��� ��� �١١١١١١١١١١١١١١١١١١١١١١١١١١١١١١١١١١�

        }
       
    }

    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    void TutoFailCheck()
    {
        IsTutoFail = true;
    }

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
        //throw new System.NotImplementedException();
    }

    public void OnSmash()
    {
        //throw new System.NotImplementedException();
    }
}
