using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GoogleSheetManager : MonoBehaviour
{
    const string URL = "https://docs.google.com/spreadsheets/d/1kNqPr-xpTnZC0C7S844Pl_0zkn4ehTulPxtj8KtFX1M/export?format=tsv"; //export format = tsv : 탭이나 엔터로 구분
                                                                                                                                // Start is called before the first frame update


    IEnumerator Start()
    {
        List<Dialogue> dialogueList = new List<Dialogue>();
        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();
        string data = www.downloadHandler.text;

        string[] dialogueData = data.Split('\n'); // 스프레드시트를 행으로 나눠서 dialogueData 배열에 담음

        for (int i = 2; i < dialogueData.Length;)
        {
            string[] row = dialogueData[i].Split('\t'); // 스프레드시트를 열로 나눔




            //Dialogue dialogue = new Dialogue();

            List<string> contextList = new List<string>();

            do // 1번은 무조건 실행 (ID)
            {
                contextList.Add(row[1]);
                print(contextList[i]);
                //print(row[1]);
                if (++i < dialogueData.Length)
                {
                    ;
                }
            } while (row[0].ToString() == ""); // 한 ID 의 대사가 끝날 때까지 실행


            if (++i < dialogueData.Length)
            {
                ;
            }
        }
        //return dialogueList.ToArray();

    }
}
