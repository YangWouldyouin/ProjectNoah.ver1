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
    //    /* 조종실 - ai 해금 */
    //    dialoguedic.add(1000, new string[] { "ai 시스템 재부팅 완료",
    //        "매뉴얼 데이터 재로드", "우주선 시스템 재연결", "…", 
    //        "우주선 꼴이 말이 아니군요.", "다시 인사 드립니다, 플레이어.", "지시대로", "ai를 최우선으로 복구한 것은 잘하셨습니다.",
    //    "추후 상부 보고 때 가산점이 있을 것입니다.", "플레이어,", "앞으로도 제 말을 잘 따라 주시길 바랍니다.", "저는 당신이 유능해지도록 도울 수는 있지만",
    //    "당신의 무능을 막을 수는 없기 때문입니다." }); // 조종실 - ai 해금


    //    /* 조종실 - 문 해금 (ai 아이콘이 밝게 빛난 후) */ 
    //    dialoguedic.add(1001, new string[] { "항해 임무 매뉴얼이 로드 되었습니다.", "현재 최우선 목표인 항해 임무를 수행하기 위해",
    //    "업무 공간으로 향하길 바랍니다."});// 조종실 - 문 해금1

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
