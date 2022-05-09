using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tu_CommentManager : MonoBehaviour
{
    public DialogManager dialog;
    DialogManager dialogManager;

    public GameObject newsUI;

    // Start is called before the first frame update
    void Start()
    {
        dialogManager = dialog.GetComponent<DialogManager>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (/*채현이 튜토리얼 퍼즐 완료 체크 &&  !GameManager.gameManager._gameData.afterFirstTalk)
        {
            Invoke("NewsTalk", 2f);
        }*/

        if (GameManager.gameManager._gameData.afterFirstTalk && !GameManager.gameManager._gameData.afterNewsTalk)
        {
            Invoke("TuTalkEnd", 2f);
        }
    }

    void NewsTalk()
    {
        //뉴스창 팝업 지현아 도와죠~!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        Debug.Log("뉴스대화 시작");

        GameManager.gameManager._gameData.afterFirstTalk = true;
        dialogManager.StartCoroutine(dialogManager.PrintSubtitles(25));
    }

    void TuTalkEnd()
    {
        Debug.Log("마지막 대화 시작");

        GameManager.gameManager._gameData.afterNewsTalk = true;
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(64));
        dialogManager.StartCoroutine(dialogManager.PrintSubtitles(26));

        Invoke("TuEnd", 2f);
    }

    void TuEnd()
    {

        GameManager.gameManager._gameData.IsDisqualifiedEnd = true;

        //튜토리얼 찐으로 끝남 체크
        //화면 연출
        //튜토 씬 끄고 게임 본격적으로 시작
    }
}
