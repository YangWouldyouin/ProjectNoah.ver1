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
    //public Image dialogPanel;
    public GameObject dialogPanel;

    bool IsDialogStarted = false;
    //public gameobject ai;
    //public image aiicon;

    [Header("Ÿ���� �ð� ����")]
    public float typingSpeed = 0.05f;
    [Header("���� �ð� ����")]
    public float sentenceSpeed = 1.8f;

    public Animator AIPanelAnim;

    void awake()
    {
        dialogManager = this;
    }
    private void Start()
    {
        googleSheetManager = GetComponent<GoogleSheetManager>();
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
        if(!IsDialogStarted)
        {
            IsDialogStarted = true;

            dialogPanel.SetActive(true);
            AIPanelAnim.SetBool("IsAIPanelActive", true);
            AIPanelAnim.SetBool("IsAIOpen", true);
            yield return new WaitForSeconds(1f);
            for (int i = 0; i < googleSheetManager.AIDialogueDic[dialogNum].Length; i++)
            {             
                string talkdata = getTalk(dialogNum, i);

                //dialogText.text = talkdata;
                StartCoroutine(_typing(talkdata));
                yield return new WaitForSeconds(sentenceSpeed);
            }

            // 3�� �� ��ȭ �г� ��Ȱ��ȭ
            yield return new WaitForSeconds(3f);

            AIPanelAnim.SetBool("IsAIClose", true);
            AIPanelAnim.SetBool("IsAIOpen", false);
            AIPanelAnim.SetBool("IsAIPanelActive", false);
            Invoke("EndPanelAnim", 1f);
            //dialogPanel.SetActive(false);
            IsDialogStarted = false;
        }
        else
        { // ��ø�Ǽ� ��� ��ġ�� �� ����
            yield break;
        }     
    }

    void EndPanelAnim()
    {
        dialogPanel.SetActive(false);
    }
    void StartPanelAnim()
    {
        AIPanelAnim.SetBool("IsAIPanelActive", true);
    }

    IEnumerator _typing(string data)
    {
        //yield return new WaitForSeconds(2f);
        for (int i = 0; i <= data.Length; i++)
        {
            dialogText.text = data.Substring(0, i);
            yield return new WaitForSeconds(typingSpeed);
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
