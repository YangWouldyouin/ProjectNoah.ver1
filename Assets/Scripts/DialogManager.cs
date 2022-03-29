using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{
    public static DialogManager dialogManager { get; private set; }
    Dictionary<int, string[]> talkData;
    public TMPro.TextMeshProUGUI dialogText;
    public GameObject AI;


    private int i = 0;

    public Image aiIcon;

    void Awake()
    {
        dialogManager = this;
        talkData = new Dictionary<int, string[]>(); // int : 각 오브젝트의 ID
        GenerateData();
    }

    // Start is called before the first frame update
    void Start()
    {
        

        if (SceneManager.GetActiveScene().name == "new workroom")
        {
            AI.SetActive(true);
            Color color = aiIcon.GetComponent<Image>().color;
            color.a = 1f;
            aiIcon.GetComponent<Image>().color = color;

        }
        
    }


    void GenerateData()
    {
        /* 조종실 - AI 해금 */
        talkData.Add(1000, new string[] { "AI 시스템 재부팅 완료",
            "매뉴얼 데이터 재로드", "우주선 시스템 재연결", "…", 
            "우주선 꼴이 말이 아니군요.", "다시 인사 드립니다, 플레이어.", "지시대로 AI를 최우선으로 복구한 것은 잘하셨습니다.",
        "추후 상부 보고 때 가산점이 있을 것입니다.", "플레이어, 앞으로도 제 말을 잘 따라 주시길 바랍니다.", "저는 당신이 유능해지도록 도울 수는 있지만",
        "당신의 무능을 막을 수는 없기 때문입니다." }); // 조종실 - AI 해금
       

        /* 조종실 - 문 해금 (AI 아이콘이 밝게 빛난 후) */ 
        talkData.Add(1001, new string[] { "항해 임무 매뉴얼이 로드 되었습니다.", "현재 최우선 목표인 항해 임무를 수행하기 위해",
        "업무 공간으로 향하길 바랍니다."});// 조종실 - 문 해금1
        talkData.Add(1002, new string[] { "플레이어, 사소한 것 하나하나 제가 지시해드릴 순 없습니다.", "다시 말씀드립니다.",
        "업무 공간으로 향하길 바랍니다."}); // 조종실 - 문 해금2 : 문을 열려하지만 열리지 않을 때


        /* 업무공간 - 생체기계 수리 */
        talkData.Add(1003, new string[] { "플레이어, 블랙홀 통과의 충격으로 인해 선내 여러 시설들이 불안정한 상태입니다.",
            "원활한 임무 수행을 위해 수리가 필요합니다.", "우선 상부에 노아 n.113의 생체 데이터를 보고해야 합니다.", // 
            "생체 데이터 수집을 위해 상태 체크 기계를 최우선 수리하기 바랍니다." }); // 업무공간 - 생체기계 수리 인트로
        // 스마트팜 관리기계 관찰시 처럼, 생체기계를 플레이어가 클릭했을 때 나와도 될 것 같기도 하고.... 약간 쿠킹덤 퀘스트 페이지가 없어서 스마트팜이랑 동시에 진행할 때 꼬일 것 같기도 함
        // 만약에 플레이어가 처음 들어와서 생체기계 클릭하면 -> 생체기계 먼저 시작하고, 스마트팜 클릭시 -> 스마트팜 먼저 시작 ?? 스마트팜은 일정시간 지난 후, 힌트가 있는지??
        talkData.Add(1004, new string[] { "상태 체크 기계는 업무 공간 중앙에 위치해 있습니다.", 
            "노아 n.113의 능력을 적극 활용하길 바랍니다.", "개의 후각 능력은 인간의 1만배 달합니다."}); // 업무공간 - 생체기계 수리 힌트, 뭔가 "후각" 글씨 색을 다르게 한다든지, 기울이든지 하고싶음


        /* 업무공간 - 스마트팜 수리 */
        talkData.Add(1005, new string[] { "스마트 팜 관리기계를 찾으셨군요.", 
            "스마트 팜을 사용하기 위해선 관리기계를 수리해야 합니다.", "아무래도 기기 스피커가 파손된 모양입니다."}); // 업무공간 - 스마트팜 관리기계 관찰하기 시
        talkData.Add(1006, new string[] { "스마트 팜은 소리를 인식해 문이 개폐됩니다." }); // 업무공간 - 스피커 수리 후
        talkData.Add(1007, new string[] { "이제 스마트 팜을 사용하실 수 있습니다.", "우주 공간 내 식물 성장을 연구하기 위해 마련된 시설입니다.",
            "스마트 팜에서 노아 n.113이 섭취할 식량을 재배할 수 있습니다.", "하지만 어디까지나 본 쓰임은 연구임을 잊지 마십시오." }); // 업무공간 - 스마트 팜 오픈
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }

    IEnumerator PrintAIDialog(int DialogNum)
    {

        for (int i = 0; i < talkData[DialogNum].Length; i++)
        {
            string talkData = GetTalk(DialogNum, i);

            dialogText.text = talkData;

            yield return new WaitForSeconds(1f);
        }
    }

    public void ResetSystem()
    {
        StartCoroutine(ResetSystemDialog());
    }

    IEnumerator ResetSystemDialog()
    {
        yield return new WaitForSeconds(2f);
        AI.SetActive(true);

        Color color = aiIcon.GetComponent<Image>().color;
        for (int i = 0; i < 3; i++)
        {
            color.a = 0f;
            aiIcon.GetComponent<Image>().color = color;
            yield return new WaitForSeconds(0.1f);
            color.a = 1f;
            aiIcon.GetComponent<Image>().color = color;
            yield return new WaitForSeconds(0.1f);
        }

        for (int i = 0; i < 11; i++)
        {
            string talkData = GetTalk(1000, i);

            dialogText.text = talkData;

            yield return new WaitForSeconds(1f);
        }

        AI.SetActive(false);
        color.a = 0f;
        aiIcon.GetComponent<Image>().color = color;

        yield return new WaitForSeconds(1f);

        for (int i = 0; i < 3; i++)
        {
            color.a = 0f;
            aiIcon.GetComponent<Image>().color = color;
            yield return new WaitForSeconds(0.05f);
            color.a = 1f;
            aiIcon.GetComponent<Image>().color = color;
            yield return new WaitForSeconds(0.05f);
        }

        AI.SetActive(true);

        for (int i = 0; i < 3; i++)
        {
            string talkData = GetTalk(1001, i);

            dialogText.text = talkData;

            yield return new WaitForSeconds(1f);
        }
    }

    public void DoorLock()
    {
        StartCoroutine(PrintAIDialog(1002));
    }

    public void HealthMachineRepairIntro()
    {
        StartCoroutine(PrintAIDialog(1003));
    }
    public void HealthMachineRepairHint()
    {
        StartCoroutine(PrintAIDialog(1004));
    }


}
