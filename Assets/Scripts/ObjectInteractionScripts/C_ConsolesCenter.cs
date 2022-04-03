using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class C_ConsolesCenter : MonoBehaviour
{
    /* 이 오브젝트와 상호작용 하는 변수들 */
    public GameObject box_CC;
    public GameObject envirPipe_CC;
    public GameObject consoleAIResetButton_CC;
    public GameObject consoleUnLockButton_CC;
    public GameObject consoleCenter_CC;

    /* 이 오브젝트와 상호작용 하는 변수들의 데이터 */
    ObjData consoleCenterData_CC;
    ObjData boxData_CC;
    ObjData envirPipeData_CC;
    ObjData consoleAIResetButtonData_CC;
    ObjData consoleUnLockButtonData_CC;

    /* 기타 필요한 변수들 */
    Outline consoleAIResetButtonOutline_CC;
    Outline consoleUnLockButtonOutline_CC;
    public GameObject consoleDescription_CC;
    public Animator cockpitDoorAnim_CC;
    public Animator noahAnim_CC;

    public Image fadeImage_CC;
    public GameObject fade_CC;
    public Image aiIcon_CC;

    float timer_CC = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (!GameManager.gameManager.IsAI_M_C1)
        {
            // 플로우차트 처음 시작 때 넣고 싶은 연출들을 넣는다.  
            noahAnim_CC.SetBool("IsSleeping", true);
            StartCoroutine(NoahWakeUp()); // 잠들어 있던 노아가 깨어난다
            StartCoroutine(FadeCoroutine()); //화면이 밝아진다
        }


        consoleCenterData_CC = consoleCenter_CC.GetComponent<ObjData>();
        boxData_CC = box_CC.GetComponent<ObjData>();
        envirPipeData_CC = envirPipe_CC.GetComponent<ObjData>();
        consoleAIResetButtonData_CC = consoleAIResetButton_CC.GetComponent<ObjData>();
        consoleUnLockButtonData_CC = consoleUnLockButton_CC.GetComponent<ObjData>();

        consoleAIResetButtonOutline_CC = consoleAIResetButton_CC.GetComponent<Outline>();
        consoleAIResetButtonOutline_CC.OutlineWidth = 0;

        consoleUnLockButtonOutline_CC = consoleUnLockButton_CC.GetComponent<Outline>();
        consoleUnLockButtonOutline_CC.OutlineWidth = 0;
    }


    IEnumerator NoahWakeUp()
    {
        yield return new WaitForSeconds(2f);
        noahAnim_CC.SetBool("IsWaking", true);
        yield return new WaitForSeconds(1f);
        noahAnim_CC.SetBool("IsWaking2", true);
        yield return new WaitForSeconds(1f);
        noahAnim_CC.SetBool("IsSleeping", false);
    }

    IEnumerator FadeCoroutine()
    {
        Color color = aiIcon_CC.GetComponent<Image>().color;
        color.a = 0f;
        aiIcon_CC.GetComponent<Image>().color = color;

        Color fadeColor = fadeImage_CC.GetComponent<Image>().color;
        fadeColor.a = 1f;
        while (fadeColor.a >= 0)
        {
            fadeColor.a -= 0.01f;
            fadeImage_CC.GetComponent<Image>().color = fadeColor;
            yield return new WaitForSeconds(0.00001f);
        }
        fade_CC.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (consoleCenterData_CC.IsObserve)
        {
            if (boxData_CC.IsUpDown)
            {
                CameraController.cameraController.currentView = consoleCenterData_CC.ObservePlusView; //관찰 뷰 : < 시스템 재가동 버튼> 이 보이는 위치

                timer_CC += Time.deltaTime;
                float seconds = Mathf.FloorToInt((timer_CC % 3600) % 60);
                if (seconds >= 2f) // 관찰하기 애니메이션 후 관찰화면으로 넘어가는데 2초 정도 걸리므로 2초 후 버튼 설명 띄움
                {
                    consoleDescription_CC.SetActive(true);
                    consoleUnLockButtonData_CC.IsNotInteractable = false;
                    consoleUnLockButtonOutline_CC.OutlineWidth = 10;
                }

                if (consoleUnLockButtonData_CC.IsPushOrPress)
                {
                    CameraController.cameraController.CancelObserve();

                    Invoke("OpenCockpitDoor", 1f); // 문 열렸다가 닫히는 애니메이션 
                    Invoke("CloseCockpitDoor", 3f);
                }

                if (envirPipeData_CC.IsBite) // <파이프> "물기" true 이면
                {
                    consoleAIResetButtonData_CC.IsNotInteractable = false; // AI 리셋 버튼 활성화
                    consoleAIResetButtonOutline_CC.OutlineWidth = 8;

                    if (consoleAIResetButtonData_CC.IsPushOrPress)
                    {
                        CameraController.cameraController.CancelObserve();

                        consoleUnLockButtonData_CC.IsNotInteractable = true;
                        consoleUnLockButtonOutline_CC.OutlineWidth = 0;

                        consoleAIResetButtonData_CC.IsNotInteractable = true; // AI 리셋 버튼 비활성화 (앞으로 누를 일 없음)
                        consoleAIResetButtonOutline_CC.OutlineWidth = 0;

                        //DialogManager.dialogManager.ResetSystem(); // AI 1 번째 대사 묶음 출력

                        GameManager.gameManager.IsAI_M_C1 = true; // return true; // 엔딩 수집 페이지 갱신, 게임 세이브 분기점
                    }

                }
                else
                {
                    consoleAIResetButtonData_CC.IsNotInteractable = true; // AI 리셋 버튼 비활성화
                    consoleAIResetButtonOutline_CC.OutlineWidth = 0;
                }

            }
            else // 박스 없이 그냥 <조종석> 을 "관찰하기"
            {
                CameraController.cameraController.currentView = consoleCenterData_CC.ObserveView; // 관찰 뷰 : 안 보이는 위치

                consoleUnLockButtonData_CC.IsNotInteractable = true;
                consoleUnLockButtonOutline_CC.OutlineWidth = 0;

                consoleAIResetButtonData_CC.IsNotInteractable = true; // AI 리셋 버튼 비활성화
                consoleAIResetButtonOutline_CC.OutlineWidth = 0;
            }
        }
        else
        {
            timer_CC = 0; // 관찰시간 텀 타이머 리셋
            consoleDescription_CC.SetActive(false);

            consoleUnLockButtonData_CC.IsNotInteractable = true;
            consoleUnLockButtonOutline_CC.OutlineWidth = 0;

            consoleAIResetButtonData_CC.IsNotInteractable = true; // AI 리셋 버튼 비활성화
            consoleAIResetButtonOutline_CC.OutlineWidth = 0;
        }
    }

    void OpenCockpitDoor()
    {
        cockpitDoorAnim_CC.SetBool("IsDoorOpenStart", true);
        cockpitDoorAnim_CC.SetBool("IsDoorOpened", true);
    }
    void CloseCockpitDoor()
    {
        cockpitDoorAnim_CC.SetBool("IsDoorOpened", false);
        cockpitDoorAnim_CC.SetBool("IsDoorOpenStart", false);
    }
}
