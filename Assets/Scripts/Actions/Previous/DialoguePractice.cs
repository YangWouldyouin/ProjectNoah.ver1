//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class GameManager : MonoBehaviour
//{
//    public DialogManager dialogManager;
//    public TMPro.TextMeshProUGUI dialogText;

//    public GameObject scanObject;
//    public bool isAction;
//    public int talkIndex;

//    private void Start()
//    {
//        Talk(1000);
//    }

//    public void Action(GameObject scanObj)
//    {
//        if(isAction)
//        {
//            isAction = false;
//        }
//        else
//        {
//            isAction = true;
//            scanObject = scanObj;
//            ObjData objData = scanObject.GetComponent<ObjData>();
//            Talk(objData.id);
            
//        }
//    }

//    void Talk(int id)
//    {
//        string talkData = dialogManager.GetTalk(id, talkIndex);
//        if (talkData == null)
//        {
//            isAction = false;
//            return;
//        }
//        dialogText.text = talkData;
//        isAction = true;

//        Invoke("IncreaseTalkIndex", 1f);
//    }

//    void IncreaseTalkIndex()
//    {
//        talkIndex++;
//    }
//}
