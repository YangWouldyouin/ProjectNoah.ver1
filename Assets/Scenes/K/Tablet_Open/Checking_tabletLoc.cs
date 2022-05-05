using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checking_tabletLoc : MonoBehaviour
{

    public GameObject tablet;


    public void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.name == "Tablet")
        {
            GameManager.gameManager._gameData.IsTabletMoved = false;
            Debug.Log("타블렛 돌아옴");
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
        if (other.gameObject.name == "Tablet")
        {
            GameManager.gameManager._gameData.IsCanConnect_C_MS = true;
            Debug.Log("타블렛 나감");

            if (GameManager.gameManager._gameData.IsAIDown)
            {
                Debug.Log("타블렛 옮기고 다녀도 안전함");
            }

            else
            {
                Debug.Log("AI가 타블렛 파괴"); // AI가 타블렛 파괴함
                Destroy(tablet);
            }
        }
    }

}
