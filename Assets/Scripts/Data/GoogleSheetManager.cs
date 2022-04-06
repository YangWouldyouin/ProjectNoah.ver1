using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GoogleSheetManager : MonoBehaviour
{
    public static GoogleSheetManager googleSheetManager { get; private set; }
    const string URL = "https://docs.google.com/spreadsheets/d/1kNqPr-xpTnZC0C7S844Pl_0zkn4ehTulPxtj8KtFX1M/export?format=tsv"; //export format = tsv : 탭이나 엔터로 구분

    public Dictionary<int, string[]> AIDialogueDic = new Dictionary<int, string[]>(); // 나중에 키값 string 으로 바꾸기
    Dictionary<int, List<string>> AIDic = new Dictionary<int, List<string>>();

    int dialogKey = 1;
    List<string> tempString = new List<string>();

    string dialognumber = "1";

    private void Awake()
    {
        if(googleSheetManager!=null)
        {
            googleSheetManager = this;
        }

        StartCoroutine("GetGoogleSpreadSheet");
    }

    void Start()
    {
        
    }

    IEnumerator GetGoogleSpreadSheet()
    {
        UnityWebRequest www = UnityWebRequest.Get(URL);
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

   

}


