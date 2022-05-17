using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{
    public static DialogManager dialogManager { get; private set; }

    GoogleSheetManager googleSheetManager;

    public Animator AIPanelAnim;

    public TMPro.TextMeshProUGUI dialogText;

    public TMPro.TextMeshProUGUI subtitleText;
    public TMPro.TextMeshProUGUI nameText;

    public GameObject AIPanel;
    public GameObject subtitlePanel;
    private Image subtitlePanelImage;

    bool IsDialogStarted = false;
    bool IsSubtitleStarted = false;

    [Header("Ÿ���� �ð� ����")]
    public float typingSpeed = 0.02f;
    [Header("���� �ð� ����")]
    public float aiSentenceDelay = 1.8f;
    public float subtitleSentenceDelay = 1.5f;

    int aiDialogNumber;
    int subtitleNumber;

    string subData;
    string nameData;

    IEnumerator typingSubtitle;
    IEnumerator printSubtitles;

    IEnumerator printAIDialogs;

    AudioSource dialogSource;
    public AudioClip aiClip;
    public AudioClip aiClip2;

    void awake()
    {
        dialogManager = this;
    }
    private void Start()
    {
        googleSheetManager = GetComponent<GoogleSheetManager>();
        subtitlePanelImage = subtitlePanel.GetComponent<Image>();
        dialogSource = GetComponent<AudioSource>();
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
        if(printAIDialogs!=null)
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

    /* AI �� ���� */
    // �÷����غ��鼭 �ְ� �����ڸ��� �������������
    IEnumerator AIDialogPrinting(int AIIndex)
    {
        dialogSource.clip = aiClip2; // �Ҹ� ����
        dialogSource.Play(); // �÷���
        // ���⿡ ������ ���� ����
        aiDialogNumber = AIIndex;
        AIPanel.SetActive(true);

        AIPanelAnim.SetBool("IsAIClose", false);

        AIPanelAnim.SetBool("IsAIPanelActive", true);

        AIPanelAnim.SetBool("IsAIOpen", true);



        yield return new WaitForSeconds(1f);

        for (int i = 0; i < googleSheetManager.AIDialogueDic[aiDialogNumber].Length; i++)
        {
            // 1���� �����Ҷ�
            dialogSource.clip = aiClip; // �Ҹ� �ٲ㳢��
            dialogSource.Play(); // �÷���
            string talkdata = getTalk(aiDialogNumber, i);
            StartCoroutine(_typing(talkdata));
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
    }
    void StartPanelAnim()
    {
        AIPanelAnim.SetBool("IsAIPanelActive", true);
    }

    /* 1���ھ� Ÿ������ ���� */
    // ��������� Ÿ���μӵ��� ������ ����� �߾ȵ�
    IEnumerator _typing(string data)
    {
        //yield return new WaitForSeconds(2f);
        for (int i = 0; i <= data.Length; i++)
        {
/*            dialogSource.Play(); // �÷��� 
            dialogText.text = data.Substring(0, i);*/

            yield return new WaitForSeconds(typingSpeed);

        }      
    }

    //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    public string GetName(int subID, int subIndex)
    {
        if (subIndex == googleSheetManager.nameDic[subID].Length)
            return null;
        else
            return googleSheetManager.nameDic[subID][subIndex];
    }

    public string GetSubtitleTalk(int subID, int subIndex)
    {
        if (subIndex == googleSheetManager.subtitleDic[subID].Length)
            return null;
        else
            return googleSheetManager.subtitleDic[subID][subIndex];
    }


    /* ��ȭ ��ŵ�� ���� */
    public void OnSkipButtonClicked()
    {
        // ���� Ÿ���� �ڷ�ƾ ������, ���� ���� ���� ���

        if(typingSubtitle!=null)
        {
            StopCoroutine(typingSubtitle);
            subtitleText.text = subData;
        }
    }




    public IEnumerator PrintSubtitles(int subtitleNum)
    {
        if(printSubtitles!=null)
        {
            StopCoroutine(printSubtitles);
            printSubtitles = SubtitlePrinting(subtitleNum);
            StartCoroutine(printSubtitles);
        }
        else
        {
            printSubtitles = SubtitlePrinting(subtitleNum);
            StartCoroutine(printSubtitles);
        }
        yield return null;
    }


    /* ��ȭ�� ���� */
    // �÷����غ��鼭 �ְ� �����ڸ��� �������������
    IEnumerator SubtitlePrinting(int index)
    {
        subtitleNumber = index;
        // ��ȭâ ��Ÿ���� ����
        StartCoroutine(FadeInCoroutine());
        yield return new WaitForSeconds(0.5f);

        for (int subtitleCentenceNum = 0; subtitleCentenceNum < googleSheetManager.subtitleDic[subtitleNumber].Length; subtitleCentenceNum++)
        {
            // 1���徿
            nameData = GetName(subtitleNumber, subtitleCentenceNum);
            nameText.text = nameData;

            subData = GetSubtitleTalk(subtitleNumber, subtitleCentenceNum);
            typingSubtitle = _typingSubtitle(subData);
            StartCoroutine(typingSubtitle);

            yield return new WaitForSeconds(subData.Length * typingSpeed + subtitleSentenceDelay); // ���� ���� ġ�µ� �ɸ��� �ð� + �д� �ð�

        }
        // ��ȭ �г� ��Ȱ��ȭ
        // ������
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(FadeOutCoroutine());
    }

    /* 1���ھ� Ÿ������  ���� */
    IEnumerator _typingSubtitle(string subdata)
    {
        //yield return new WaitForSeconds(2f);
        for (int i = 0; i <= subdata.Length; i++)
        {
            subtitleText.text = subdata.Substring(0, i);

            yield return new WaitForSeconds(typingSpeed);
        }
    }

    IEnumerator FadeInCoroutine()
    {
        subtitlePanelImage.enabled = true;

        Color fadeInColor = subtitlePanelImage.color;
        while (fadeInColor.a <=0.6f)
        {
            fadeInColor.a += 0.02f;
            subtitlePanelImage.GetComponent<Image>().color = fadeInColor;
            yield return new WaitForSeconds(0.00001f);
        }
    }

    IEnumerator FadeOutCoroutine()
    {
        Color fadeOutColor = subtitlePanelImage.color;
        fadeOutColor.a = 0.6f;
        while (fadeOutColor.a >= 0)
        {
            fadeOutColor.a -= 0.02f;
            subtitlePanelImage.GetComponent<Image>().color = fadeOutColor;
            yield return new WaitForSeconds(0.00001f);
        }
        subtitlePanelImage.enabled = false;
    }
}
