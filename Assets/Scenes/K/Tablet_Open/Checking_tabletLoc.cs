using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checking_tabletLoc : MonoBehaviour
{
    private float timer = 0f; // 태블릿 감지 타이머
    public float DestroyTime = 10.0f; // 태블릿을 AI가 감지하기까지 걸리는 시간

    public GameObject TabletHideZone_E;
    ObjData TabletHideZone_Data_E;

    public GameObject Tablet_E;
    ObjData TabletData_E;
    public GameObject noahPlayer;
    ObjData noahPlayerData_E;

    public GameObject dialog;
    DialogManager dialogManager;

    void Start()
    {
        dialogManager = dialog.GetComponent<DialogManager>();

        // TabletHideZone_Data_E = TabletHideZone_E.GetComponent<ObjData>();
        TabletData_E = Tablet_E.GetComponent<ObjData>();
        noahPlayerData_E = noahPlayer.GetComponent<ObjData>();
    }

    private void Update()
    {
        GetOutAIZone(); // 태블릿이 AI전파감지범위 벗어나는가 안벗어나는가
    }

    public void GetOutAIZone() // AI전파감지범위 벗어나기
    {
        Vector3 TabletPos = Tablet_E.transform.position; // 태블릿 실시간 위치값

        if (TabletPos.x > 1 && TabletPos.x < 10 && TabletPos.z < -8 && TabletPos.z > -16) // 타블렛이 안전 영역 안에 있으면
        {
            Debug.Log("타이머 리셋");
            timer = 0f; // 5초 안에 안전 영역으로 다시 돌아오면 타이머를 다시 0으로 돌림
        }
        else // 타블렛이 안전 영역 밖에 있으면
        {
            timer += Time.deltaTime; // 타이머 시작 
            float seconds = Mathf.FloorToInt((timer % 3600) % 60); // 초 단위 체크
            Debug.Log(seconds);
            if (seconds >= DestroyTime) // 5초가 지나면
            {
                Debug.Log("타블렛 파괴");
                // AI: 이상 전파가 감지되었습니다. 해당 기기를 폐기합니다
                dialogManager.StartCoroutine(dialogManager.PrintAIDialog(39));

                Tablet_E.SetActive(false);
                //Destroy(Tablet_E); // 타블렛 파괴
                GameManager.gameManager._gameData.IsTabletDestory = true; // 반복문에서 빠져나옴
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "noahPlayer")
        {
            if (!GameManager.gameManager._gameData.IsFirstExitTablet)
            {
                dialogManager.StartCoroutine(dialogManager.PrintAIDialog(40));
                GameManager.gameManager._gameData.IsFirstExitTablet = true;
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            }
            
            if (GameManager.gameManager._gameData.IsFirstExitTablet)
            {
                dialogManager.StartCoroutine(dialogManager.PrintAIDialog(41));
            }
        }
    }

    //public void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.name == "noahPlayer" && tabletData.IsBite)
    //    {
    //        GameManager.gameManager._gameData.IsTabletMoved = false;
    //        Debug.Log("타블렛 안에 있음");
    //    }

    //    /*if (other.tag == "chip")
    //     {
    //         if(GameManager.gameManager._gameData.IsHide)
    //         {
    //             Debug.Log("안전함");
    //         }

    //         else
    //         {
    //             Debug.Log("님 지금 머하시는????");
    //             //AI가 경계하는 대사 출력

    //             GameManager.gameManager._gameData.IsAlert = true;
    //             SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    //         }

    //     }*/
    //}

    //public void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.name == "noahPlayer" && tabletData.IsBite) // && TabletData_E.IsBite
    //    {
    //        GameManager.gameManager._gameData.IsCanConnect_C_MS = true;
    //        Debug.Log("타블렛 나감");

    //        if (GameManager.gameManager._gameData.IsAIDown)
    //        {
    //            Debug.Log("타블렛 옮기고 다녀도 안전함");
    //        }

    //        else
    //        {
    //            Debug.Log("AI가 타블렛 파괴"); // AI가 타블렛 파괴함
    //            // Destroy(Tablet_E);
    //            Tablet_E.SetActive(false);

    //            /* ♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥ P-1대사 삽입 ♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥ */
    //        }
    //    }


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


