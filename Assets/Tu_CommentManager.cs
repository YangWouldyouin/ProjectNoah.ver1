using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tu_CommentManager : MonoBehaviour
{
    public DialogManager dialog;
    DialogManager dialogManager;

    public GameObject newsUI;

    public ObjectData cardData;

    public bool check01;
    public bool check02;

    public GameObject StartAnim;
    public GameObject PassAnim;
    public GameObject EndAnim;

    public GameObject LoadingAnim;

    // Start is called before the first frame update
    void Start()
    {
        dialogManager = dialog.GetComponent<DialogManager>();

        GameManager.gameManager._gameData.IsEndTuto = false;
        GameManager.gameManager._gameData.afterFirstTalk = false;
        GameManager.gameManager._gameData.afterNewsTalk = false;

        cardData.IsBite = false;
        cardData.IsNotInteractable = false;

        StartCoroutine(Dalay1());

        //Invoke("Dalay", 16f);


        //GameManager.gameManager._gameData.afterFirstTalk = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameManager._gameData.IsEndTuto &&  !GameManager.gameManager._gameData.afterFirstTalk && !check01)
        {
            Invoke("NewsTalk", 73f);
            check01 = true;
        }

        if (GameManager.gameManager._gameData.afterFirstTalk && !GameManager.gameManager._gameData.afterNewsTalk && !check02)
        {
            Invoke("TuTalkEnd", 39f);
            //Invoke("TuTalkEnd", 5f);
            check02 = true;
        }
    }

    void NewsTalk()
    {
        //뉴스창 팝업 지현아 도와죠~!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        newsUI.SetActive(true);

        Debug.Log("뉴스대화 시작");

        GameManager.gameManager._gameData.afterFirstTalk = true;
        Invoke("MikeNews", 4f);
        
    }

    void TuTalkEnd()
    {
        Debug.Log("마지막 대화 시작");

        GameManager.gameManager._gameData.afterNewsTalk = true;
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(64));
        Invoke("MikeLast", 0.1f);

        Invoke("StartPassing", 27f);
        Invoke("TuEnd", 47f);
    }

    void TuEnd()
    {
        EndAnim.SetActive(true);
        GameManager.gameManager._gameData.IsDisqualifiedEnd = true;

        //튜토리얼 찐으로 끝남 체크
        //화면 연출
        //튜토 씬 끄고 게임 본격적으로 시작
    }

    void StartPassing()
    {
        PassAnim.SetActive(true);
        Destroy(PassAnim, 2f);
    }

    void MikeNews()
    {
        dialogManager.StartCoroutine(dialogManager.PrintSubtitles(25));
    }

    void MikeLast()
    {
        dialogManager.StartCoroutine(dialogManager.PrintSubtitles(26));

        GameManager.gameManager._gameData.IsTutorialClear = true;
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
}
