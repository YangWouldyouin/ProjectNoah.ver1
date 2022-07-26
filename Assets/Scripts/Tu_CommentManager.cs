using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Kino;

public class Tu_CommentManager : MonoBehaviour
{
    public DialogManager dialog;
    DialogManager dialogManager;

    public GameObject newsUI;

    public ObjectData cardData;
    public InGameTime timerData;

    public bool check01;
    public bool check02;

    public GameObject StartAnim;
    public GameObject PassAnim;
    public GameObject EndAnim;

    public GameObject LoadingAnim;

    public GameObject condition;
    public GameObject smell;

    public GameObject console;
    BoxCollider console_collider;

    public Button aiButton;

    private Camera mainCamera;
    AnalogGlitch analogEffect;

    public InGameTime inGameTime;
    public GameObject skipText;


    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        analogEffect = mainCamera.GetComponent<AnalogGlitch>();

        dialogManager = dialog.GetComponent<DialogManager>();

        GameManager.gameManager._gameData.IsBasicTuto = false;
        GameManager.gameManager._gameData.IsEndTuto = false;
        GameManager.gameManager._gameData.afterFirstTalk = false;
        GameManager.gameManager._gameData.afterNewsTalk = false;

        cardData.IsBite = false;
        cardData.IsNotInteractable = false;
        timerData.IsTimerStarted = false;

        console_collider = console.GetComponent<BoxCollider>();

        StartCoroutine(Dalay1());

        Invoke("ShowCon", 30f);

        //Invoke("TutoBye", 5f);


        //GameManager.gameManager._gameData.afterFirstTalk = true;

    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.gameManager._gameData.IsEndTuto && !check01)
        {
            StartCoroutine(CallingAI());
            check01 = true;
        }

        if(GameManager.gameManager._gameData.afterFirstMission && !check02)
        {
            StartCoroutine(NewsTalk());
            check02 = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TuEnd();
            skipText.SetActive(false);
        }
    }


    //�ӹ� �Ϸ� �� Ī���ϰ� AI �θ��� ����ũ
    IEnumerator CallingAI()
    {
        yield return new WaitForSeconds(4f);

        while (true)
        {
            if (dialogManager.IsTalking)
            {
                yield return new WaitForSeconds(1f);
            }

            else
            {
                dialogManager.StartCoroutine(dialogManager.PrintSubtitles(24));
                StartCoroutine(Comment());
                StartCoroutine(Comment_Mike());

                break;
            }
        }
    }
    
    //�ӹ� �Ϸ� ��� (AI�� ����ũ�� ƼŰŸī)
    IEnumerator Comment()
    {

        yield return new WaitForSeconds(1.5f);

        while (true)
        {
            if (dialogManager.IsTalking)
            {
                yield return new WaitForSeconds(0.5f);
            }

            else if (!dialogManager.IsTalking)
            {
                Color aiTurnColor = aiButton.GetComponent<Image>().color;
                aiTurnColor.a = 1.0f;
                aiButton.GetComponent<Image>().color = aiTurnColor;
                aiButton.interactable = true;
                //mission.SetActive(true);
                dialogManager.StartCoroutine(dialogManager.PrintAIDialog(67));

                break;
            }

        }


    }

    IEnumerator Comment_Mike()
    {

        yield return new WaitForSeconds(6f);

        while (true)
        {
            if (dialogManager.IsTalking)
            {
                yield return new WaitForSeconds(2f);
            }

            else
            {
                Debug.Log("����ũ�� AI ƼŰŸī ����");

                dialogManager.StartCoroutine(dialogManager.PrintSubtitles(29));
                StartCoroutine(AngryAI());

                break;
            }
        }


    }

    IEnumerator AngryAI()
    {
        yield return new WaitForSeconds(0.5f);

        while (true)
        {
            if (dialogManager.IsTalking)
            {
                yield return new WaitForSeconds(0.5f);
            }

            else if (!dialogManager.IsTalking)
            {
                dialogManager.StartCoroutine(dialogManager.PrintAIDialog(68));
                StartCoroutine(YesMike());

                break;
            }
        }
    }

    IEnumerator YesMike()
    {
        yield return new WaitForSeconds(0.5f);

        while (true)
        {
            if (dialogManager.IsDialogStarted)
            {
                yield return new WaitForSeconds(0.5f);
            }

            else if (!dialogManager.IsDialogStarted)
            {
                dialogManager.StartCoroutine(dialogManager.PrintSubtitles(30));
                StartCoroutine(LoadingAI());

                break;
            }
        }
    }

    IEnumerator LoadingAI()
    {
        yield return new WaitForSeconds(1f);

        while (true)
        {
            if (dialogManager.IsTalking)
            {
                yield return new WaitForSeconds(1f);
            }

            else if (!dialogManager.IsTalking)
            {
                dialogManager.StartCoroutine(dialogManager.PrintAIDialog(69));
                StartCoroutine(FirstMission());

                break;
            }
        }
    }

    IEnumerator FirstMission()
    {
        yield return new WaitForSeconds(1f);

        while (true)
        {
            if (dialogManager.IsDialogStarted)
            {
                yield return new WaitForSeconds(1f);
            }

            else
            {
                dialogManager.StartCoroutine(dialogManager.PrintAIDialog(72));

                //GameManager.gameManager._gameData.ActiveMissionList[31] = true;
                //SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
                //MissionGenerator.missionGenerator.ActivateMissionList();
                MissionGenerator.missionGenerator.AddNewMission(31);

                console_collider.enabled = true;

                break;
            }
        }
    }

    /*public void Mike()
    {
        dialogManager.StartCoroutine(dialogManager.PrintSubtitles(25));
        StartCoroutine(NewsTalk());
    }*/


    //���� �˾�â �߰� ���� ��ȭ
    IEnumerator NewsTalk()
    {
        yield return new WaitForSeconds(10f);

        while (true)
        {
            if(dialogManager.IsTalking)
            {
                yield return new WaitForSeconds(6f);
            }

            else
            {
                newsUI.SetActive(true);

                Debug.Log("������ȭ ����");

                GameManager.gameManager._gameData.afterFirstTalk = true;
                dialogManager.StartCoroutine(dialogManager.PrintSubtitles(26));
                StartCoroutine(TuTalkEnd());
                StartCoroutine(TuTalkEnd_Mike());

                break;
            }
        }
    }


    IEnumerator TuTalkEnd()
    {
        yield return new WaitForSeconds(3f);

        while (true)
        {
            if(dialogManager.IsTalking)
            {
                yield return new WaitForSeconds(6f);
            }

            else if(!dialogManager.IsTalking)
            {
                Debug.Log("������ ��ȭ ����");

                GameManager.gameManager._gameData.afterNewsTalk = true;

                dialogManager.StartCoroutine(dialogManager.PrintAIDialog(64));
                StartCoroutine(AILastTalk());

                break;
            }

        }
    }

    IEnumerator TuTalkEnd_Mike()
    {
        yield return new WaitForSeconds(3.2f);

        while (true)
        {
            if (dialogManager.IsTalking)
            {
                yield return new WaitForSeconds(8f);
            }

            else
            {
                dialogManager.StartCoroutine(dialogManager.PrintSubtitles(27));

                break;
            }
        }


    }


    IEnumerator AILastTalk()
    {
        yield return new WaitForSeconds(5f);
        
        while (true)
        {
            if(dialogManager.IsTalking)
            {
                yield return new WaitForSeconds(1f);
            }

            else if(!dialogManager.IsTalking)
            {
                dialogManager.StartCoroutine(dialogManager.PrintAIDialog(66));

                Invoke("StartPassing", 4f);
                Invoke("TuEnd", 14f);

                break;
            }
        }
    }

    void TuEnd()
    {
        EndAnim.SetActive(true);
        GameManager.gameManager._gameData.IsTutorialClear = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        /* �������� : �μ��ΰ� �Ϸ� */
        SteamStatManager.steamAchieve1Time.Invoke(0, "END_TUTORIAL_CLEAR");

        Invoke("TutoBye", 3f);

        //Ʃ�丮�� ������ ���� üũ
        //ȭ�� ����
        //Ʃ�� �� ���� ���� ���������� ����
    }

    void StartPassing()
    {
        StartCoroutine(GlitchEffect());
        StartCoroutine(EndEffect());
        PassAnim.SetActive(true);

        Destroy(PassAnim, 4f);
    }
    IEnumerator GlitchEffect()
    {
        float i = 0;
        while (i <= 0.5f)
        {
            yield return new WaitForSeconds(1f);
            i += 0.1f;
            analogEffect.scanLineJitter = i;
            analogEffect.horizontalShake = i;
        }
    }

    IEnumerator EndEffect()
    {
        yield return new WaitForSeconds(5f);
        float k= 0.5f;
        while (k >=0.1f)
        {
            yield return new WaitForSeconds(1f);
            k-= 0.1f;
            analogEffect.scanLineJitter = k;
            analogEffect.horizontalShake = k;
        }
    }


    /*    void Delay()
        {
            StartAnim.SetActive(true);
            Destroy(StartAnim, 4f);
            Destroy(LoadingAnim, 3f);
        }*/

    IEnumerator Dalay1()
    {
        yield return new WaitForSeconds(16f);
        StartAnim.SetActive(true);
        Destroy(StartAnim, 4f);
        Destroy(LoadingAnim, 3f);

    }

    void TutoBye()
    {
        inGameTime.statNum = 10;
        GameManager.gameManager._gameData.ActiveMissionList[31] = false;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        timerData.days = 0;
        timerData.hours = 0;
        timerData.timer = 0;


        //slManagerload();
        SceneManager.LoadScene("new cockpit");
    }

    void ShowCon()
    {
        condition.SetActive(false);
    }


}
