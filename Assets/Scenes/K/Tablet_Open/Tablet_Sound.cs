using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablet_Sound : MonoBehaviour
{
    // public float TabletSoundRange = 30f; // 태블릿 소리 나는 주기 = 30초
    public float speed; // 노아가 돌아보는 속도

    public GameObject TabletSoundArea; // 소리 들을 수 있는 영역
    ObjData TabletSoundArea_Data;

    public GameObject Player_Noah; // 노아 플레이어

    public GameObject Tablet; // 태블릿
    ObjData Tablet_Data;

    public bool IsTabletSoundListen = false; // 태블릿 소리를 들었는가?

    /* 상태창 관련 오브젝트 */
    public GameObject samplePanel; // 상태창
    public TMPro.TextMeshProUGUI sampleText; // 상태창 텍스트

    public GameObject dialog;
    DialogManager dialogManager;

    public bool firstCheck;

    void Start()
    {
        dialogManager = dialog.GetComponent<DialogManager>();

        Tablet_Data = Tablet.GetComponent<ObjData>();
    }

    void Update()
    {
    }

    public void TabletSoundLoop() // 태블릿에서 소리 들리기
    {
        IsTabletSoundListen = true;
        Debug.Log("이상한 소리");
    }

    /* ♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥ 퍼즐 시작 ♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥ */
    /* ♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥ 퍼즐 끝 ♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥ */
    public void OnTriggerEnter(Collider other)
    {
        if(GameManager.gameManager._gameData.IsNoBoxes == false)
        {
            TabletSoundArea.SetActive(true);

            if (other.gameObject == Player_Noah)
            {
                Debug.Log("태블릿 소리 영역 진입");
                TabletSoundLoop();
                // TabletSoundArea.SetActive(true);
                dialogManager.StartCoroutine(dialogManager.PrintAIDialog(38));
            }
        }
        else
        {
            TabletSoundArea.SetActive(false);
            Debug.Log("상자없다");
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject == Player_Noah && IsTabletSoundListen == true)
        {
            Invoke("FollowTablet", 2f);
            Debug.Log("태블릿 소리 감지");
            PrintSomething(); // 상태창에 "[소리] 이상한 기계음

            
        }
    }


    void PrintSomething()
    {
        samplePanel.SetActive(true); // 상태창을 활성화한다. 
        sampleText.text = "[소리] 이상한 기계음";
    }



    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player_Noah)
        {
            sampleText.text = "";
            samplePanel.SetActive(false); // 상태창을 활성화한다. 
            CancelInvoke("FollowTablet");

            // TabletSoundArea.SetActive(false);
            Debug.Log("태블릿 소리 감지 종료");
        }
    }

    public void FollowTablet() // 노아가 태블릿 쪽을 바라봄
    {
        // TabletSoundArea_Data.IsNotInteractable = true;
        Debug.Log("태블릿 바라봐");

        Vector3 dir = Tablet.transform.position - Player_Noah.transform.position;
        Player_Noah.transform.rotation = Quaternion.Lerp(Player_Noah.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * speed);
    }
}
