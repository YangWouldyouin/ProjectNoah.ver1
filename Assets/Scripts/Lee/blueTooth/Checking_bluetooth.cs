using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checking_bluetooth : MonoBehaviour
{
    // Start is called before the first frame update

    //public GameObject dialogManager_CCB;
    //DialogManager dialogManager;
    
    //public GameObject canConnect;

    public GameObject tablet;
    public GameObject RChip01;
    public GameObject WChip01;

    ObjData tabletData;
    ObjData RChip01Data;
    ObjData WChip01Data;

    //public static bool IsCanConnect;

    //public GameObject tablet;

    void Start()
    {
        tabletData = tablet.GetComponent<ObjData>();
        RChip01Data = RChip01.GetComponent<ObjData>();
        WChip01Data = WChip01.GetComponent<ObjData>();
        //dialogManager = dialogManager_CCB.GetComponent<DialogManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "noahPlayer")
        {
            /*if (tabletData.IsBite)
            {
                GameManager.gameManager._gameData.IsCanConnect_C_MS = true;
            }*/

            if (RChip01Data.IsBite && GameManager.gameManager._gameData.IsHide)
            {
                Debug.Log("이상한 칩 감지");
                GameManager.gameManager._gameData.IsAlert = true;
                Invoke("NoRChip", 0f);
            }

            if (WChip01Data.IsBite && GameManager.gameManager._gameData.IsHide)
            {
                Debug.Log("이상한 칩 감지");
                GameManager.gameManager._gameData.IsAlert = true;
                Invoke("NoWChip", 0f);
            }
        }

       /*if (other.tag == "chip")
        {
            if(GameManager.gameManager._gameData.IsHide)
            {
                Debug.Log("������");
            }

            else
            {
                Debug.Log("�� ���� ���Ͻô�????");
                //AI�� ����ϴ� ��� ���

                GameManager.gameManager._gameData.IsAlert = true;
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            }

        }*/
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "noahPlayer")
        {
            if (tabletData.IsBite)
            {
                GameManager.gameManager._gameData.IsCanConnect_C_MS = false;
            }

            if (RChip01Data.IsBite || WChip01Data.IsBite)
            {
                Debug.Log("이상한 칩 나감");
                GameManager.gameManager._gameData.IsAlert = false;
            }
        }
    }

    public void NoRChip()
    {
        Destroy(RChip01, 3f);
        GameManager.gameManager._gameData.IsAlert = false;
    }

    public void NoWChip()
    {
        Destroy(WChip01, 3f);
        GameManager.gameManager._gameData.IsAlert = false;
    }
}
