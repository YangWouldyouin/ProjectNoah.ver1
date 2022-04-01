using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GoogleSheetManager : MonoBehaviour
{
    const string URL = "https://docs.google.com/spreadsheets/d/1kNqPr-xpTnZC0C7S844Pl_0zkn4ehTulPxtj8KtFX1M/export?format=tsv"; //export format = tsv : ���̳� ���ͷ� ����
                                                                                                                                // Start is called before the first frame update


    IEnumerator Start()
    {
        List<Dialogue> dialogueList = new List<Dialogue>();
        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();
        string data = www.downloadHandler.text;

        string[] dialogueData = data.Split('\n'); // ���������Ʈ�� ������ ������ dialogueData �迭�� ����

        for (int i = 2; i < dialogueData.Length;)
        {
            string[] row = dialogueData[i].Split('\t'); // ���������Ʈ�� ���� ����




            //Dialogue dialogue = new Dialogue();

            List<string> contextList = new List<string>();

            do // 1���� ������ ���� (ID)
            {
                contextList.Add(row[1]);
                print(contextList[i]);
                //print(row[1]);
                if (++i < dialogueData.Length)
                {
                    ;
                }
            } while (row[0].ToString() == ""); // �� ID �� ��簡 ���� ������ ����


            if (++i < dialogueData.Length)
            {
                ;
            }
        }
        //return dialogueList.ToArray();

    }
}
