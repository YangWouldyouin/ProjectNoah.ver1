using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GoogleSheetManager : MonoBehaviour
{
    const string URL = "https://docs.google.com/spreadsheets/d/1kNqPr-xpTnZC0C7S844Pl_0zkn4ehTulPxtj8KtFX1M/export?format=tsv"; //export format = tsv : 탭이나 엔터로 구분
    public Dialogue[] googleDialogues;
    List<Dialogue> dialogueList = new List<Dialogue>();

    Dictionary<int, string[]> AIDialogueDic = new Dictionary<int, string[]>();
    int dialogKey = 0;
    int dialogNum = 0;
    List<string> tempString = new List<string>();
    string[] temp;
    void Start()
    {
        StartCoroutine("GetGoogleSpreadSheet");
        printAI(0);
        
    }

    IEnumerator GetGoogleSpreadSheet()
    {

        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();
        string googleData = www.downloadHandler.text;

        string[] data = googleData.Split('\n'); // 스프레드시트를 행으로 나눠서 dialogueData 배열에 담음

        for (int i = 2; i < data.Length;)
        {
            string[] row = data[i].Split('\t'); // 스프레드시트를 열로 나눔

            //Dialogue dialogue = new Dialogue();
            //dialogue.ID = int.Parse(row[4]);
            //print(dialogue.ID); // ID 출력
            //List<string> contextList = new List<string>(); // 대사 리스트 생성



            
            /* 같은 ID 의 대사 모두 출력 */
            do // 1번은 무조건 실행 (ID)
            {
                tempString.Add(row[5]);
                //contextList.Add(row[5]);
                //print(row[5]); // 대사 1개 출력
                if (++i < data.Length)
                {
                    row = data[i].Split('\t');
                    
                }
                else
                {
                    break;
                }
            } while (row[4].ToString() == ""); // 한 ID 의 대사가 끝날 때까지 실행
            
            
            //dialogKey++;
            //dialogNum = 0;
            //dialogue.contexts = contextList.ToArray(); // 리스트를 배열로 치환

            //dialogueList.Add(dialogue);
        }
        string[] temp = tempString.ToArray();
        AIDialogueDic.Add(dialogKey, temp);

        //googleDialogues = dialogueList.ToArray();
        for (int k = 0; k < AIDialogueDic[0].Length; k++)
        {
            print(AIDialogueDic[0][k]);
        }


    }

    void printAI(int n)
    {
        for(int k =0; k <=AIDialogueDic[n].Length; k++)
        {
            print(AIDialogueDic[n][k]);
        }
    }
}


