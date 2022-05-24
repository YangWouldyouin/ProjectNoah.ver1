using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public Button aiButton;

    // Start is called before the first frame update
    void Start()
    {
        dialogManager = dialog.GetComponent<DialogManager>();

        GameManager.gameManager._gameData.IsBasicTuto = false;
        GameManager.gameManager._gameData.IsEndTuto = false;
        GameManager.gameManager._gameData.afterFirstTalk = false;
        GameManager.gameManager._gameData.afterNewsTalk = false;

        cardData.IsBite = false;
        cardData.IsNotInteractable = false;
        timerData.IsTimerStarted = false;

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

    }


    //�ӹ� �Ϸ� �� Ī���ϰ� AI �θ��� ����ũ
    IEnumerator CallingAI()
    {
        yield return new WaitForSeconds(4f);

        while (true)
        {
            if (dialogManager.IsSubtitleStarted)
            {
                yield return new WaitForSeconds(1f);
            }

            else
            {
                dialogManager.StartCoroutine(dialogManager.PrintSubtitles(24));
                StartCoroutine(Comment());

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
            if (dialogManager.IsSubtitleStarted)
            {
                yield return new WaitForSeconds(1f);
            }

            else
            {
                Debug.Log("����ũ�� AI ƼŰŸī ����");

                //dialogManager.StartCoroutine(dialogManager.PrintSubtitles(24));
                Color aiTurnColor = aiButton.GetComponent<Image>().color;
                aiTurnColor.a = 1.0f;
                aiButton.GetComponent<Image>().color = aiTurnColor;
                aiButton.interactable = true;
                dialogManager.StartCoroutine(dialogManager.PrintAIDialog(63));
                dialogManager.StartCoroutine(dialogManager.PrintSubtitles(25));
                //Invoke("Mike", 0.2f);

                StartCoroutine(NewsTalk());

                break;
            }
        }


    }

    public void Mike()
    {
        dialogManager.StartCoroutine(dialogManager.PrintSubtitles(25));
        StartCoroutine(NewsTalk());
    }


    //�½� �˾�â �߰� ���� ��ȭ
    IEnumerator NewsTalk()
    {
        yield return new WaitForSeconds(3f);

        while (true)
        {
            if(dialogManager.IsSubtitleStarted)
            {
                yield return new WaitForSeconds(1f);
            }

            else
            {
                newsUI.SetActive(true);

                Debug.Log("������ȭ ����");

                GameManager.gameManager._gameData.afterFirstTalk = true;
                dialogManager.StartCoroutine(dialogManager.PrintSubtitles(25));
                StartCoroutine(TuTalkEnd());

                break;
            }
        }
    }


    IEnumerator TuTalkEnd()
    {
        yield return new WaitForSeconds(3f);

        while (true)
        {
            if(dialogManager.IsSubtitleStarted)
            {
                yield return new WaitForSeconds(1f);
            }

            else
            {
                Debug.Log("������ ��ȭ ����");

                GameManager.gameManager._gameData.afterNewsTalk = true;

                dialogManager.StartCoroutine(dialogManager.PrintAIDialog(64));
                Invoke("MikeLast", 0.1f);

                break;
            }
        }
    }

    void MikeLast()
    {
        //GameManager.gameManager._gameData.IsTutorialClear = true;
        //SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        dialogManager.StartCoroutine(dialogManager.PrintSubtitles(26));
        StartCoroutine(AILastTalk());

    }


    IEnumerator AILastTalk()
    {
        yield return new WaitForSeconds(2f);
        
        while (true)
        {
            if(dialogManager.IsSubtitleStarted)
            {
                yield return new WaitForSeconds(1f);
            }

            else
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

        Invoke("TutoBye", 3f);

        //Ʃ�丮�� ������ ���� üũ
        //ȭ�� ����
        //Ʃ�� �� ���� ���� ���������� ����
    }

    void StartPassing()
    {
        PassAnim.SetActive(true);
        Destroy(PassAnim, 4f);
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
        GameManager.gameManager._gameData.statNum = 10;
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
