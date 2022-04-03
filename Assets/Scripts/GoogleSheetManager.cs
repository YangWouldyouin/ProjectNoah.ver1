using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GoogleSheetManager : MonoBehaviour
{
    const string URL = "https://docs.google.com/spreadsheets/d/1kNqPr-xpTnZC0C7S844Pl_0zkn4ehTulPxtj8KtFX1M/export?format=tsv"; //export format = tsv : ���̳� ���ͷ� ����
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
        //printAI();
        
    }

    IEnumerator GetGoogleSpreadSheet()
    {

        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();
        string googleData = www.downloadHandler.text;

        string[] data = googleData.Split('\n'); // ���������Ʈ�� ������ ������ dialogueData �迭�� ����

        for (int i = 2; i < data.Length;)
        {
            string[] row = data[i].Split('\t'); // ���������Ʈ�� ���� ����

            //Dialogue dialogue = new Dialogue();
            //dialogue.ID = int.Parse(row[4]);
            //print(dialogue.ID); // ID ���
            //List<string> contextList = new List<string>(); // ��� ����Ʈ ����



            
            /* ���� ID �� ��� ��� ��� */
            do // 1���� ������ ���� (ID)
            {
                
                //contextList.Add(row[5]);
                //print(row[5]); // ��� 1�� ���
                if (++i < data.Length)
                {
                    row = data[i].Split('\t');
                    tempString.Add(row[5]);
                    dialogNum++;
                }
                else
                {
                    break;
                }
            } while (row[4].ToString() == ""); // �� ID �� ��簡 ���� ������ ����
            
            
            //dialogKey++;
            //dialogNum = 0;
            //dialogue.contexts = contextList.ToArray(); // ����Ʈ�� �迭�� ġȯ

            //dialogueList.Add(dialogue);
        }
        string[] temp = tempString.ToArray();
        AIDialogueDic.Add(dialogKey, temp);
        //googleDialogues = dialogueList.ToArray();
    }

    void printAI()
    {
        //for(int k =0; k < ; k++)
        //{
        //    print(temp[k]);
        //    //print(AIDialogueDic[num][k]);
        //}
    }
}


