using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GoogleSheetManager : MonoBehaviour
{
    public static GoogleSheetManager googleSheetManager { get; private set; }
    const string URL = "https://docs.google.com/spreadsheets/d/1kNqPr-xpTnZC0C7S844Pl_0zkn4ehTulPxtj8KtFX1M/export?format=tsv"; //export format = tsv : ���̳� ���ͷ� ����

    public Dictionary<int, string[]> AIDialogueDic = new Dictionary<int, string[]>(); // ���߿� Ű�� string ���� �ٲٱ�
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

   

}


