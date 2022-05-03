using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checking_bluetooth : MonoBehaviour
{
    // Start is called before the first frame update

    //public GameObject dialogManager_CCB;
    //DialogManager dialogManager;
    
    //public GameObject canConnect;

    //public static bool IsCanConnect;

    //public GameObject tablet;

    void Start()
    {
        //dialogManager = dialogManager_CCB.GetComponent<DialogManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.name == "tablet")
        {
            GameManager.gameManager._gameData.IsCanConnect_C_MS = true;
            Debug.Log("연결이 가능합니다");
        }

       /*if (other.tag == "chip")
        {
            if(GameManager.gameManager._gameData.IsHide)
            {
                Debug.Log("안전함");
            }

            else
            {
                Debug.Log("님 지금 머하시는????");
                //AI가 경계하는 대사 출력

                GameManager.gameManager._gameData.IsAlert = true;
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            }

        }*/
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "tablet")
        {
            GameManager.gameManager._gameData.IsCanConnect_C_MS = false;
            Debug.Log("연결이 불가능합니당 ㅠㅠ");
        }
    }

}
