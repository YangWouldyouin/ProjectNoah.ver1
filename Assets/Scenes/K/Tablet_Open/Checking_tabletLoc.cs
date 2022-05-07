using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checking_tabletLoc : MonoBehaviour
{
    public GameObject TabletHideZone_E;
    ObjData TabletHideZone_Data_E;

    public GameObject Tablet_E;
    ObjData TabletData_E;

    public GameObject noahPlayer;
    ObjData noahPlayerData_E;

    void Start()
    {
        // TabletHideZone_Data_E = TabletHideZone_E.GetComponent<ObjData>();
        TabletData_E = Tablet_E.GetComponent<ObjData>();
        noahPlayerData_E = noahPlayer.GetComponent<ObjData>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "noahPlayer" && TabletData_E.IsBite)
        {
            GameManager.gameManager._gameData.IsTabletMoved = false;
            Debug.Log("타블렛 안에 있음");
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
        if (other.gameObject.name == "noahPlayer" && TabletData_E.IsBite) // && TabletData_E.IsBite
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
                // Destroy(Tablet_E);
                Tablet_E.SetActive(false);

                /* ♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥ P-1대사 삽입 ♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥ */
            }
        }


        /*if (other.gameObject.name == "Tablet_E")
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
                Destroy(Tablet_E);
            }
        }*/
    }

}
