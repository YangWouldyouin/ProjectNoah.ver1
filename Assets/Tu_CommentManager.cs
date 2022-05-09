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
        /*if (/*ä���� Ʃ�丮�� ���� �Ϸ� üũ &&  !GameManager.gameManager._gameData.afterFirstTalk)
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
        //����â �˾� ������ ������~!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        Debug.Log("������ȭ ����");

        GameManager.gameManager._gameData.afterFirstTalk = true;
        dialogManager.StartCoroutine(dialogManager.PrintSubtitles(25));
    }

    void TuTalkEnd()
    {
        Debug.Log("������ ��ȭ ����");

        GameManager.gameManager._gameData.afterNewsTalk = true;
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(64));
        dialogManager.StartCoroutine(dialogManager.PrintSubtitles(26));

        Invoke("TuEnd", 2f);
    }

    void TuEnd()
    {

        GameManager.gameManager._gameData.IsDisqualifiedEnd = true;

        //Ʃ�丮�� ������ ���� üũ
        //ȭ�� ����
        //Ʃ�� �� ���� ���� ���������� ����
    }
}
