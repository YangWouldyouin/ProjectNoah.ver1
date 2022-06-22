using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public static DialogManager dialogManager { get; private set; }
    public InGameTime inGameTime;
    public Animator AIPanelAnim;
    Animator subtitleAnim;

    public TMPro.TextMeshProUGUI dialogText;

    public TMPro.TextMeshProUGUI talkText;
    public TMPro.TextMeshProUGUI nameText;

    public GameObject AIPanel;
    public GameObject subtitlePanel;
    private Image talkPanelImage;

    public bool IsDialogStarted = false;
    public bool IsTalking = false;

    [Header("타이핑 시간 간격")]
    public float typingSpeed = 0.02f;
    [Header("문장 시간 간격")]
    public float aiSentenceDelay = 1.8f;
    public float delayAmount = 3.6f;

    int aiDialogNumber;

    IEnumerator printAIDialogs;

    AudioSource dialogSource;
    public AudioClip aiAudio;

    GoogleSheetManager googleSheetManager;



    void awake()
    {
        dialogManager = this;
    }
    private void Start()
    {
        subtitlePanel.SetActive(false);
        googleSheetManager = GetComponent<GoogleSheetManager>();
        talkPanelImage = subtitlePanel.GetComponent<Image>();
        dialogSource = GetComponent<AudioSource>();
        dialogSource.clip = aiAudio;
        subtitleAnim = subtitlePanel.GetComponent<Animator>();

    }

    public string GetAI(int id, int talkIndex)
    {
        if (talkIndex == googleSheetManager.AIDialogueDic[id].Length)
            return null;
        else
            return googleSheetManager.AIDialogueDic[id][talkIndex];
    }
    public IEnumerator PrintAIDialog(int dialogNum)
    {
        if(inGameTime.IsAIAwake)
        {
            if (printAIDialogs != null)
            {
                StopCoroutine(printAIDialogs);
                printAIDialogs = AIDialogPrinting(dialogNum);
                StartCoroutine(printAIDialogs);
            }
            else
            {
                printAIDialogs = AIDialogPrinting(dialogNum);
                StartCoroutine(printAIDialogs);
            }
            yield return null;
        }
    }
    /* AI 는 여기 */
    IEnumerator AIDialogPrinting(int AIIndex)
    {
        IsDialogStarted = true;
        aiDialogNumber = AIIndex;
        AIPanel.SetActive(true);

        AIPanelAnim.SetBool("IsAIClose", false);

        AIPanelAnim.SetBool("IsAIPanelActive", true);

        AIPanelAnim.SetBool("IsAIOpen", true);

        yield return new WaitForSeconds(1f);

        for (int i = 0; i < googleSheetManager.AIDialogueDic[aiDialogNumber].Length; i++)
        {
            string talkdata = GetAI(aiDialogNumber, i);
            dialogSource.Play();
            StartCoroutine(_typingAI(talkdata));

            yield return new WaitForSeconds(talkdata.Length * typingSpeed + aiSentenceDelay);

        }
        // 3초 후 대화 패널 비활성화
        yield return new WaitForSeconds(0.02f);

        AIPanelAnim.SetBool("IsAIClose", true);
        AIPanelAnim.SetBool("IsAIOpen", false);
        AIPanelAnim.SetBool("IsAIPanelActive", false);
        // 여기에 넣으면 끝날때 
        Invoke("EndPanelAnim", 1.2f);
    }
    void EndPanelAnim()
    {
        AIPanel.SetActive(false);
        IsDialogStarted = false;
    }
    void StartPanelAnim()
    {
        AIPanelAnim.SetBool("IsAIPanelActive", true);
    }
    IEnumerator _typingAI(string data)
    {
        //yield return new WaitForSeconds(2f);
        for (int i = 0; i <= data.Length; i++)
        {
          //dialogSource.Play(); // 플레이 
            dialogText.text = data.Substring(0, i);

            yield return new WaitForSeconds(typingSpeed);

        }
        dialogSource.Stop();
    }

    //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    // 코루틴을 중간에 멈추려면 변수를 만들어서 담아서 실행해야 한다고 해서 만든 변수
    IEnumerator _printSubtitles;
    IEnumerator _talkOne;
    IEnumerator _typing;

    int talkingIndex;

    string talkData;
    string nameData;

    /* 스킵 관련 변수 */
    bool IsSkiped;
    int k;

    /* 대화 스킵 */
    public void SkipTalking()
    {
        // 대사가 나오는 중이면 타이핑 코루틴을 중단하고 한 문장을 한번에 출력
        if (_typing != null)
        {
            StopCoroutine(_typing);
            _typing = null;
            talkText.text = talkData;
        }
        else // 대사가 나오는 중이 아니면 (한문장이 이미 나왔고, 다음 문장이 나오기 전까지 읽을 텀중인데 스킵하려고하면)
        {
            IsSkiped = true; // 다음 문장나오기 전까지의 대기 반복문을 끝냄
        }
    }

    /* 대화  */
    // 하는 일 
    // - 대화를 불러와야 하는 시점에 이 메서드를 실행하여 대화번호만 가지고 원하는 대사를 불러옴
    // - 대화가 나오는 중인지 아닌지 체크하여 대화가 나오는 중에 다른 대화를 실행시키면 기존 대화를 끝내고 다음 대화 시작

    public IEnumerator PrintSubtitles(int talkingIndex) // talkingIndex : 대화 딕셔너리의 키
    {
        if (_printSubtitles!=null) // 이미 대사가 나오는 중이면
        {
            // 현재 대사를 출력하는 코루틴 중단
            StopCoroutine(_printSubtitles); 

            _printSubtitles = _talking(talkingIndex); 
            StartCoroutine(_printSubtitles); // 새 대사를 출력하는 코루틴 시작
        }
        else // 아무 대사도 나오지 않는 상황이었으면
        {
            _printSubtitles = _talking(talkingIndex);
            StartCoroutine(_printSubtitles); // 대사 코루틴 시작
        }
        yield return null;
    }

    /* 대화 출력 */
    // 하는 일 : 실질적으로 대화를 출력하는 역할
    // 한 대화의 모든 문장 개수만큼 반복문을 돌려서 문장 출력 & 한 문장이 끝나면 잠깐 기다림, 대화창을 켜고 끔
    IEnumerator _talking(int index)
    {
        talkingIndex = index;
        IsTalking = true;
        StartCoroutine(_turnOnPanel()); // 대화창을 켬



        yield return new WaitForSeconds(0.5f);


        // 한 대화의 문장 개수만큼 반복
        for (int i = 0; i < googleSheetManager.subtitleDic[talkingIndex].Length; i++)
        {
            k = 0;
            IsSkiped = false;

            _talkOne = _talkOneSentence(i); // 한 문장을 타이핑 효과로 출력
            StartCoroutine(_talkOne);

            // 한 문장이 모두 출력된 후 다음 문장이 나오기 전에 잠시 대기
            for (k = 0; k <= talkData.Length + delayAmount; k++) // 한 문장 길이 + 일정시간만큼
            {  
                if (IsSkiped)
                {
                    yield return null;
                    break;
                }
                else
                {
                    yield return new WaitForSeconds(typingSpeed);
                }
            }
        }
        yield return new WaitForSeconds(0.5f); 
        StartCoroutine(_turnOffPanel());  // 대화창을 끔
    }

    /* 한 문장 출력 */
    // 하는일 : 한 문장만 출력
    IEnumerator _talkOneSentence(int sentenceIndex)
    {
        // 등장인물 이름은 타이핑 효과없이 바로 출력
        nameData = GetName(talkingIndex, sentenceIndex);
        nameText.text = nameData;

        // 대사는 타이핑 효과를 줌
        talkData = GetTalk(talkingIndex, sentenceIndex);
        _typing = _typingEffect(talkData);
        StartCoroutine(_typing);

        yield return null;
    }

    /* 대사와 등장인물을 가져옴 */
    string GetTalk(int talkIndex, int sentenceIndex) // talkIndex : 대화 번호, sentenceIndex : 한 대화 안의 문장 번호
    {
        if (sentenceIndex == googleSheetManager.subtitleDic[talkIndex].Length) // 문장 번호 == 대화의 길이 -> 현재 대화의 마지막 문장이다
            return null;
        else
            return googleSheetManager.subtitleDic[talkIndex][sentenceIndex];
    }

    string GetName(int talkIndex, int sentenceIndex)
    {
        if (sentenceIndex == googleSheetManager.nameDic[talkIndex].Length)
            return null;
        else
            return googleSheetManager.nameDic[talkIndex][sentenceIndex];
    }

    /* 1글자씩 타이핑 */
    IEnumerator _typingEffect(string talkdata)
    {
        for (int j = 0; j <= talkdata.Length; j++)
        {
            talkText.text = talkdata.Substring(0, j);

            yield return new WaitForSeconds(typingSpeed);
        }
    }

    /* 대화 패널 활성화 & 비활성화 */
    IEnumerator _turnOnPanel()
    {
        subtitlePanel.SetActive(true);
        talkPanelImage.enabled = true;

        Color fadeInColor = talkPanelImage.color;
        while (fadeInColor.a <=0.6f)
        {
            fadeInColor.a += 0.02f;
            talkPanelImage.GetComponent<Image>().color = fadeInColor;
            yield return new WaitForSeconds(0.00001f);
        }
    }

    IEnumerator _turnOffPanel()
    {
        Color fadeOutColor = talkPanelImage.color;
        fadeOutColor.a = 0.6f;
        while (fadeOutColor.a >= 0)
        {
            fadeOutColor.a -= 0.02f;
            talkPanelImage.GetComponent<Image>().color = fadeOutColor;
            yield return new WaitForSeconds(0.00001f);
        }
        IsTalking = false;
        talkPanelImage.enabled = false;
        subtitlePanel.SetActive(false);
    }
}
