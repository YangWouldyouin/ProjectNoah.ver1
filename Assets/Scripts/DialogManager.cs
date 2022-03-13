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

    public Image fadeImage;
    public GameObject fade;
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
        StartCoroutine(FadeCoroutine());
        if (SceneManager.GetActiveScene().name == "new workroom")
        {
            AI.SetActive(true);
            Color color = aiIcon.GetComponent<Image>().color;
            color.a = 1f;
            aiIcon.GetComponent<Image>().color = color;

        }
        
    }
    IEnumerator FadeCoroutine()
    {
        Color color = aiIcon.GetComponent<Image>().color;
        color.a = 0f;
        aiIcon.GetComponent<Image>().color = color;

        Color fadeColor = fadeImage.GetComponent<Image>().color;
        fadeColor.a = 1f;
        while (fadeColor.a>=0)
        {
            fadeColor.a -= 0.01f;
            fadeImage.GetComponent<Image>().color = fadeColor;
            yield return new WaitForSeconds(0.00001f);
        }
        fade.SetActive(false);
    }

    void GenerateData()
    {
        talkData.Add(1000, new string[] { "AI 시스템 재부팅 완료",
            "매뉴얼 데이터 재로드", "우주선 시스템 재연결", "…", 
            "우주선 꼴이 말이 아니군요.", "다시 인사 드립니다, 플레이어.", "지시대로 AI를 최우선으로 복구한 것은 잘하셨습니다.",
        "추후 상부 보고 때 가산점이 있을 것입니다.", "플레이어, 앞으로도 제 말을 잘 따라 주시길 바랍니다.", "저는 당신이 유능해지도록 도울 수는 있지만",
        "당신의 무능을 막을 수는 없기 때문입니다." });
        // AI 아이콘이 밝게 빛남

        talkData.Add(1001, new string[] { "항해 임무 매뉴얼이 로드 되었습니다.", "현재 최우선 목표인 항해 임무를 수행하기 위해",
        "업무 공간으로 향하길 바랍니다."});

        // 문을 열려하지만 열리지 않음
        talkData.Add(1002, new string[] { "플레이어, 사소한 것 하나하나 제가 지시해드릴 순 없습니다.", "다시 말씀드립니다.",
        "업무 공간으로 향하길 바랍니다."});
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

}
