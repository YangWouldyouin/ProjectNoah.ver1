using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GoogleSheetManager : MonoBehaviour
{
    public static GoogleSheetManager googleSheetManager { get; private set; }
    const string dialogURL = "https://docs.google.com/spreadsheets/d/1kNqPr-xpTnZC0C7S844Pl_0zkn4ehTulPxtj8KtFX1M/export?format=tsv"; //export format = tsv : ���̳� ���ͷ� ����
    const string subtitleURL = "https://docs.google.com/spreadsheets/d/1kNqPr-xpTnZC0C7S844Pl_0zkn4ehTulPxtj8KtFX1M/export?format=tsv&gid=1023122798"; //export format = tsv : ���̳� ���ͷ� ����

    public Dictionary<int, string[]> AIDialogueDic = new Dictionary<int, string[]>(); // ���߿� Ű�� string ���� �ٲٱ�
    Dictionary<int, List<string>> AIDic = new Dictionary<int, List<string>>();

    public Dictionary<int, string[]> subtitleDic = new Dictionary<int, string[]>(); // ���߿� Ű�� string ���� �ٲٱ�
    Dictionary<int, List<string>> subDic = new Dictionary<int, List<string>>();

    int dialogKey = 1;
    List<string> tempString = new List<string>();

    int subtitleKey = 1;
    List<string> subtitleString = new List<string>();

    string dialognumber = "1";
    string subtitleNumber = "1";

    private void Awake()
    {
        if(googleSheetManager!=null)
        {
            googleSheetManager = this;
        }

        StartCoroutine("GetGoogleSpreadSheet");
        StartCoroutine("GetSubtitleSheet");

    }

    IEnumerator GetGoogleSpreadSheet()
    {
        UnityWebRequest www = UnityWebRequest.Get(dialogURL);
        yield return www.SendWebRequest();
        string googleData = www.downloadHandler.text;

        string[] data = googleData.Split('\n'); // ���������Ʈ�� ������ ������ data �迭�� ����

        for (int i = 2; i < data.Length; i++)
        {
            string[] row = data[i].Split('\t'); // �������� ��Ʈ �� �ϳ��� ���� ����

            if (dialognumber!=row[4])
            {
                string[] temp = tempString.ToArray();
                AIDialogueDic[dialogKey] = temp;
                dialogKey++;
                tempString = new List<string>();
            }
            tempString.Add(row[5]);

            dialognumber = row[4];
        }
    }

    IEnumerator GetSubtitleSheet()
    {
        UnityWebRequest wwwsub = UnityWebRequest.Get(subtitleURL);
        yield return wwwsub.SendWebRequest();
        string googlesubTitleData = wwwsub.downloadHandler.text;

        string[] subData = googlesubTitleData.Split('\n'); // ���������Ʈ�� ������ ������ data �迭�� ����

        for (int k = 2; k < subData.Length; k++)
        {
            string[] subRow = subData[k].Split('\t'); // �������� ��Ʈ �� �ϳ��� ���� ����

            if (subtitleNumber != subRow[4])
            {
                string[] subtemp = subtitleString.ToArray();
                subtitleDic[subtitleKey] = subtemp;
                subtitleKey++;
                subtitleString = new List<string>();
            }
            subtitleString.Add(subRow[5]);

            subtitleNumber = subRow[4];
        }
    }

}


