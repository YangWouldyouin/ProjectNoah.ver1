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

    [Header("Ÿ���� �ð� ����")]
    public float typingSpeed = 0.02f;
    [Header("���� �ð� ����")]
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
    /* AI �� ���� */
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
        // 3�� �� ��ȭ �г� ��Ȱ��ȭ
        yield return new WaitForSeconds(0.02f);

        AIPanelAnim.SetBool("IsAIClose", true);
        AIPanelAnim.SetBool("IsAIOpen", false);
        AIPanelAnim.SetBool("IsAIPanelActive", false);
        // ���⿡ ������ ������ 
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
          //dialogSource.Play(); // �÷��� 
            dialogText.text = data.Substring(0, i);

            yield return new WaitForSeconds(typingSpeed);

        }
        dialogSource.Stop();
    }

    //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    // �ڷ�ƾ�� �߰��� ���߷��� ������ ���� ��Ƽ� �����ؾ� �Ѵٰ� �ؼ� ���� ����
    IEnumerator _printSubtitles;
    IEnumerator _talkOne;
    IEnumerator _typing;

    int talkingIndex;

    string talkData;
    string nameData;

    /* ��ŵ ���� ���� */
    bool IsSkiped;
    int k;

    /* ��ȭ ��ŵ */
    public void SkipTalking()
    {
        // ��簡 ������ ���̸� Ÿ���� �ڷ�ƾ�� �ߴ��ϰ� �� ������ �ѹ��� ���
        if (_typing != null)
        {
            StopCoroutine(_typing);
            _typing = null;
            talkText.text = talkData;
        }
        else // ��簡 ������ ���� �ƴϸ� (�ѹ����� �̹� ���԰�, ���� ������ ������ ������ ���� �����ε� ��ŵ�Ϸ����ϸ�)
        {
            IsSkiped = true; // ���� ���峪���� �������� ��� �ݺ����� ����
        }
    }

    /* ��ȭ  */
    // �ϴ� �� 
    // - ��ȭ�� �ҷ��;� �ϴ� ������ �� �޼��带 �����Ͽ� ��ȭ��ȣ�� ������ ���ϴ� ��縦 �ҷ���
    // - ��ȭ�� ������ ������ �ƴ��� üũ�Ͽ� ��ȭ�� ������ �߿� �ٸ� ��ȭ�� �����Ű�� ���� ��ȭ�� ������ ���� ��ȭ ����

    public IEnumerator PrintSubtitles(int talkingIndex) // talkingIndex : ��ȭ ��ųʸ��� Ű
    {
        if (_printSubtitles!=null) // �̹� ��簡 ������ ���̸�
        {
            // ���� ��縦 ����ϴ� �ڷ�ƾ �ߴ�
            StopCoroutine(_printSubtitles); 

            _printSubtitles = _talking(talkingIndex); 
            StartCoroutine(_printSubtitles); // �� ��縦 ����ϴ� �ڷ�ƾ ����
        }
        else // �ƹ� ��絵 ������ �ʴ� ��Ȳ�̾�����
        {
            _printSubtitles = _talking(talkingIndex);
            StartCoroutine(_printSubtitles); // ��� �ڷ�ƾ ����
        }
        yield return null;
    }

    /* ��ȭ ��� */
    // �ϴ� �� : ���������� ��ȭ�� ����ϴ� ����
    // �� ��ȭ�� ��� ���� ������ŭ �ݺ����� ������ ���� ��� & �� ������ ������ ��� ��ٸ�, ��ȭâ�� �Ѱ� ��
    IEnumerator _talking(int index)
    {
        talkingIndex = index;
        IsTalking = true;
        StartCoroutine(_turnOnPanel()); // ��ȭâ�� ��



        yield return new WaitForSeconds(0.5f);


        // �� ��ȭ�� ���� ������ŭ �ݺ�
        for (int i = 0; i < googleSheetManager.subtitleDic[talkingIndex].Length; i++)
        {
            k = 0;
            IsSkiped = false;

            _talkOne = _talkOneSentence(i); // �� ������ Ÿ���� ȿ���� ���
            StartCoroutine(_talkOne);

            // �� ������ ��� ��µ� �� ���� ������ ������ ���� ��� ���
            for (k = 0; k <= talkData.Length + delayAmount; k++) // �� ���� ���� + �����ð���ŭ
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
        StartCoroutine(_turnOffPanel());  // ��ȭâ�� ��
    }

    /* �� ���� ��� */
    // �ϴ��� : �� ���常 ���
    IEnumerator _talkOneSentence(int sentenceIndex)
    {
        // �����ι� �̸��� Ÿ���� ȿ������ �ٷ� ���
        nameData = GetName(talkingIndex, sentenceIndex);
        nameText.text = nameData;

        // ���� Ÿ���� ȿ���� ��
        talkData = GetTalk(talkingIndex, sentenceIndex);
        _typing = _typingEffect(talkData);
        StartCoroutine(_typing);

        yield return null;
    }

    /* ���� �����ι��� ������ */
    string GetTalk(int talkIndex, int sentenceIndex) // talkIndex : ��ȭ ��ȣ, sentenceIndex : �� ��ȭ ���� ���� ��ȣ
    {
        if (sentenceIndex == googleSheetManager.subtitleDic[talkIndex].Length) // ���� ��ȣ == ��ȭ�� ���� -> ���� ��ȭ�� ������ �����̴�
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

    /* 1���ھ� Ÿ���� */
    IEnumerator _typingEffect(string talkdata)
    {
        for (int j = 0; j <= talkdata.Length; j++)
        {
            talkText.text = talkdata.Substring(0, j);

            yield return new WaitForSeconds(typingSpeed);
        }
    }

    /* ��ȭ �г� Ȱ��ȭ & ��Ȱ��ȭ */
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
