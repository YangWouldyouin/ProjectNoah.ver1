using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DialogManager : MonoBehaviour
{
    public static DialogManager dialogManager { get; private set; }
    GoogleSheetManager googleSheetManager;

    public TMPro.TextMeshProUGUI dialogText;

    [SerializeField] C_ControlWorkDoor c_ControlWorkDoor;

    //public gameobject ai;
    //public image aiicon;

    void awake()
    {
        dialogManager = this;
    }
    private void Start()
    {
        googleSheetManager = GetComponent<GoogleSheetManager>();

        c_ControlWorkDoor.Printed += PrintDialog;
    }

    public string getTalk(int id, int talkIndex)
    {
        if (talkIndex == googleSheetManager.AIDialogueDic[id].Length)
            return null;
        else
            return googleSheetManager.AIDialogueDic[id][talkIndex];
    }

    public IEnumerator PrintAIDialog(int dialogNum)
    {
        int num = dialogNum;

        if (num != dialogNum)
        {
            num = dialogNum;
        }

        else
        {
            for (int i = 0; i < googleSheetManager.AIDialogueDic[num].Length; i++)
            {
                string talkdata = getTalk(num, i);

                dialogText.text = talkdata;

                yield return new WaitForSeconds(1f);
            }
        }
    }

    public void PrintDialog(int q)
    {
        StartCoroutine(PrintAIDialog(q));
    }

    //// start is called before the first frame update
    //void start()
    //{
    //    if (scenemanager.getactivescene().name == "new workroom")
    //    {
    //        ai.setactive(true);
    //        color color = aiicon.getcomponent<image>().color;
    //        color.a = 1f;
    //        aiicon.getcomponent<image>().color = color;
    //    }      
    //}


    //public dialogue[] getdialogue(int _startnum, int _endnum)
    //{
    //    list<dialogue> dialoguelist = new list<dialogue>();

    //    for(int i =0; i<= _endnum-_startnum; i++)
    //    {
    //        dialoguelist.add(dialoguedic[_startnum + i]);
    //    }
    //    return dialoguelist.toarray();
    //}

    //void generatedata()
    //{
    //    /* ������ - ai �ر� */
    //    dialoguedic.add(1000, new string[] { "ai �ý��� ����� �Ϸ�",
    //        "�Ŵ��� ������ ��ε�", "���ּ� �ý��� �翬��", "��", 
    //        "���ּ� ���� ���� �ƴϱ���.", "�ٽ� �λ� �帳�ϴ�, �÷��̾�.", "���ô��", "ai�� �ֿ켱���� ������ ���� ���ϼ̽��ϴ�.",
    //    "���� ��� ���� �� �������� ���� ���Դϴ�.", "�÷��̾�,", "�����ε� �� ���� �� ���� �ֽñ� �ٶ��ϴ�.", "���� ����� ������������ ���� ���� ������",
    //    "����� ������ ���� ���� ���� �����Դϴ�." }); // ������ - ai �ر�


    //    /* ������ - �� �ر� (ai �������� ��� ���� ��) */ 
    //    dialoguedic.add(1001, new string[] { "���� �ӹ� �Ŵ����� �ε� �Ǿ����ϴ�.", "���� �ֿ켱 ��ǥ�� ���� �ӹ��� �����ϱ� ����",
    //    "���� �������� ���ϱ� �ٶ��ϴ�."});// ������ - �� �ر�1

    //}

    //ienumerator resetsystemdialog()
    //{
    //    yield return new waitforseconds(2f);
    //    ai.setactive(true);

    //    color color = aiicon.getcomponent<image>().color;
    //    for (int i = 0; i < 3; i++)
    //    {
    //        color.a = 0f;
    //        aiicon.getcomponent<image>().color = color;
    //        yield return new waitforseconds(0.1f);
    //        color.a = 1f;
    //        aiicon.getcomponent<image>().color = color;
    //        yield return new waitforseconds(0.1f);
    //    }

    //    for (int i = 0; i < 11; i++)
    //    {
    //        string talkdata = gettalk(1000, i);

    //        dialogtext.text = talkdata;

    //        yield return new waitforseconds(1f);
    //    }

    //    ai.setactive(false);
    //    color.a = 0f;
    //    aiicon.getcomponent<image>().color = color;

    //    yield return new waitforseconds(1f);

    //    for (int i = 0; i < 3; i++)
    //    {
    //        color.a = 0f;
    //        aiicon.getcomponent<image>().color = color;
    //        yield return new waitforseconds(0.05f);
    //        color.a = 1f;
    //        aiicon.getcomponent<image>().color = color;
    //        yield return new waitforseconds(0.05f);
    //    }

    //    ai.setactive(true);

    //    for (int i = 0; i < 3; i++)
    //    {
    //        string talkdata = gettalk(1001, i);

    //        dialogtext.text = talkdata;

    //        yield return new waitforseconds(1f);
    //    }
    //}
}
