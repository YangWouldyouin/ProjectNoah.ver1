using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_New_Consoles_Center: MonoBehaviour
{
    /* 게임이 종료되어도 저장될 설정 변수들 */
    public static bool IsAI_M_C1 = false;

    /* 이 오브젝트와 상호작용 하는 변수들 */
    public GameObject box_M_C1;
    public GameObject envirPipe_M_C1;
    public GameObject consoleAIResetButton_M_C1;
    public GameObject consoleUnLockButton_M_C1;
    public GameObject consoleCenter_M_C1;
    //public GameObject cockpitDoor_M_C1;

    /* 이 오브젝트와 상호작용 하는 변수들의 데이터 */
    ObjData consoleCenteData_M_C1;
    ObjData boxData_M_C1;
    ObjData envirPipeData_M_C1;
    ObjData consoleAIResetButtonData_M_C1;
    ObjData consoleUnLockButtonData_M_C1;

    /* 기타 필요한 변수들 */
    Outline consoleAIResetButtonOutline;
    Outline consoleUnLockButtonOutline;
    public GameObject consoleDescription;

    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        consoleCenteData_M_C1 = consoleCenter_M_C1.GetComponent<ObjData>();
        boxData_M_C1 = box_M_C1.GetComponent<ObjData>();
        envirPipeData_M_C1 = envirPipe_M_C1.GetComponent<ObjData>();
        consoleAIResetButtonData_M_C1 = consoleAIResetButton_M_C1.GetComponent<ObjData>();
        consoleUnLockButtonData_M_C1 = consoleUnLockButton_M_C1.GetComponent<ObjData>();

        consoleAIResetButtonOutline = consoleAIResetButton_M_C1.GetComponent<Outline>();
        consoleAIResetButtonOutline.OutlineWidth = 0;

        consoleUnLockButtonOutline = consoleUnLockButton_M_C1.GetComponent<Outline>();
        consoleUnLockButtonOutline.OutlineWidth = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (consoleCenteData_M_C1.IsObserve) // <박스> "오르기" && <조종석> "관찰하기" true 이면
        {
            if(boxData_M_C1.IsUpDown)
            {
                CameraController.cameraController.currentView = consoleCenteData_M_C1.ObservePlusView; //관찰 뷰 : < 시스템 재가동 버튼> 이 보이는 위치
                timer += Time.deltaTime;
                float seconds = Mathf.FloorToInt((timer % 3600) % 60);
                if(seconds>=2f)
                {
                    consoleDescription.SetActive(true);
                    consoleUnLockButtonData_M_C1.IsNotInteractable = false;
                    consoleUnLockButtonOutline.OutlineWidth = 10;
                    timer = 0;
                }
                
                //Invoke("TurnOnConsoleDescription", 2f);
                //consoleDescription.SetActive(true);

                //consoleCenteData_M_C1.IsExtraDescriptionActive = true; // 버튼 추가 설명을 활성화한다. 


                if (consoleUnLockButtonData_M_C1.IsPushOrPress)
                {
                    CameraController.cameraController.CancelObserve();
                    //consoleDescription.SetActive(false); // 버틀 설명 비활성화
                    // 문 열렸다가 닫히는 애니메이션 
                    consoleCenteData_M_C1.IsObserve = false; // 임의로 관찰하기 취소하였으므로 수동으로 거짓으로 변경
                }

                if (envirPipeData_M_C1.IsBite) // <파이프> "물기" true 이면
                {
                    consoleAIResetButtonData_M_C1.IsNotInteractable = false; // AI 리셋 버튼 활성화
                    consoleAIResetButtonOutline.OutlineWidth = 8;

                    if (consoleAIResetButtonData_M_C1.IsPushOrPress)
                    {
                        CameraController.cameraController.CancelObserve();
                        //consoleDescription.SetActive(false);

                        consoleUnLockButtonData_M_C1.IsNotInteractable = true;
                        consoleUnLockButtonOutline.OutlineWidth = 0;

                        consoleAIResetButtonData_M_C1.IsNotInteractable = true; // AI 리셋 버튼 비활성화 (앞으로 누를 일 없음)
                        consoleAIResetButtonOutline.OutlineWidth = 0;

                        DialogManager.dialogManager.ResetSystem(); // AI 1 번째 대사 묶음 출력

                        //CameraController.cameraController.currentView = consoleCenteData_M_C1.ObserveView; // 앞으로 볼 일 없으므로 초기화
                        IsAI_M_C1 = true; // return true; // 엔딩 수집 페이지 갱신, 게임 세이브 분기점
                        consoleCenteData_M_C1.IsObserve = false; // 임의로 관찰하기 취소하였으므로 수동으로 거짓으로 변경

                    }

                }
                else
                {
                    consoleAIResetButtonData_M_C1.IsNotInteractable = true; // AI 리셋 버튼 비활성화
                    consoleAIResetButtonOutline.OutlineWidth = 0;
                }

            }
            else // 박스 없이 그냥 <조종석> 을 "관찰하기"
            {
                CameraController.cameraController.currentView = consoleCenteData_M_C1.ObserveView; // 관찰 뷰 : 안 보이는 위치
                //consoleDescription.SetActive(false);

                consoleUnLockButtonData_M_C1.IsNotInteractable = true;
                consoleUnLockButtonOutline.OutlineWidth = 0;

                consoleAIResetButtonData_M_C1.IsNotInteractable = true; // AI 리셋 버튼 비활성화
                consoleAIResetButtonOutline.OutlineWidth = 0;
            }
        }
        else
        {
            timer = 0;
            consoleDescription.SetActive(false);
            consoleUnLockButtonData_M_C1.IsNotInteractable = true;
            consoleUnLockButtonOutline.OutlineWidth = 0;

            consoleAIResetButtonData_M_C1.IsNotInteractable = true; // AI 리셋 버튼 비활성화
            consoleAIResetButtonOutline.OutlineWidth = 0;
        }
    }

    void TurnOnConsoleDescription()
    {
        consoleDescription.SetActive(true);
    }
}
