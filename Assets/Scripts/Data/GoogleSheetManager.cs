using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GoogleSheetManager : MonoBehaviour
{
    public static GoogleSheetManager googleSheetManager { get; private set; }
    const string dialogURL = "https://docs.google.com/spreadsheets/d/1kNqPr-xpTnZC0C7S844Pl_0zkn4ehTulPxtj8KtFX1M/export?format=tsv"; //export format = tsv : 탭이나 엔터로 구분
    const string subtitleURL = "https://docs.google.com/spreadsheets/d/1kNqPr-xpTnZC0C7S844Pl_0zkn4ehTulPxtj8KtFX1M/export?format=tsv&gid=1023122798"; //export format = tsv : 탭이나 엔터로 구분

    public Dictionary<int, string[]> AIDialogueDic = new Dictionary<int, string[]>(); // 나중에 키값 string 으로 바꾸기
    Dictionary<int, List<string>> AIDic = new Dictionary<int, List<string>>();

    public Dictionary<int, string[]> subtitleDic = new Dictionary<int, string[]>(); // 나중에 키값 string 으로 바꾸기
    Dictionary<int, List<string>> subDic = new Dictionary<int, List<string>>();

    public Dictionary<int, string[]> nameDic = new Dictionary<int, string[]>(); // 나중에 키값 string 으로 바꾸기

    int dialogKey = 1;
    List<string> tempString = new List<string>();

    int subtitleKey = 1;
    List<string> subtitleString = new List<string>();
    List<string> nameString = new List<string>();

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

        string[] data = googleData.Split('\n'); // 스프레드시트를 행으로 나눠서 data 배열에 담음

        for (int i = 2; i < data.Length; i++)
        {
            string[] row = data[i].Split('\t'); // 스프레드 시트 행 하나를 열로 나눔

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

        string[] subData = googlesubTitleData.Split('\n'); // 스프레드시트를 행으로 나눠서 data 배열에 담음

        for (int k = 2; k < subData.Length; k++)
        {
            string[] subRow = subData[k].Split('\t'); // 스프레드 시트 행 하나를 열로 나눔

            if (subtitleNumber != subRow[3])
            {
                string[] nameTemp = nameString.ToArray();
                string[] subtemp = subtitleString.ToArray();
                nameDic[subtitleKey] = nameTemp;
                subtitleDic[subtitleKey] = subtemp;
                subtitleKey++;
                nameString = new List<string>();
                subtitleString = new List<string>();
            }
            nameString.Add(subRow[4]);
            subtitleString.Add(subRow[5]);

            subtitleNumber = subRow[3];
        }
    }

}


