using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class C_New_Consoles_Center: MonoBehaviour
{
    /* 게임이 종료되어도 저장될 설정 변수들 */

    /* 이 오브젝트와 상호작용 하는 변수들 */
    public GameObject box_M_C1;
    public GameObject envirPipe_M_C1;
    public GameObject consoleAIResetButton_M_C1;
    public GameObject consoleUnLockButton_M_C1;
    public GameObject consoleCenter_M_C1;

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
    public Animator cockpitDoorAnim_M_C1;
    public Animator noahAnim_M_C1;

    public Image fadeImage_M_C1;
    public GameObject fade_M_C1;
    public Image aiIcon_M_C1;

    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(!GameManager.gameManager.IsAI_M_C1)
        {
            // 플로우차트 처음 시작 때 넣고 싶은 연출들을 넣는다.  
            noahAnim_M_C1.SetBool("IsSleeping", true);
            StartCoroutine(NoahWakeUp()); // 잠들어 있던 노아가 깨어난다
            StartCoroutine(FadeCoroutine()); //화면이 밝아진다
        }


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


    IEnumerator NoahWakeUp()
    {
        yield return new WaitForSeconds(2f);
        noahAnim_M_C1.SetBool("IsWaking", true);
        yield return new WaitForSeconds(1f);
        noahAnim_M_C1.SetBool("IsWaking2", true);
        yield return new WaitForSeconds(1f);
        noahAnim_M_C1.SetBool("IsSleeping", false);
    }

    IEnumerator FadeCoroutine()
    {
        Color color = aiIcon_M_C1.GetComponent<Image>().color;
        color.a = 0f;
        aiIcon_M_C1.GetComponent<Image>().color = color;

        Color fadeColor = fadeImage_M_C1.GetComponent<Image>().color;
        fadeColor.a = 1f;
        while (fadeColor.a >= 0)
        {
            fadeColor.a -= 0.01f;
            fadeImage_M_C1.GetComponent<Image>().color = fadeColor;
            yield return new WaitForSeconds(0.00001f);
        }
        fade_M_C1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (consoleCenteData_M_C1.IsObserve)
        {
            if(boxData_M_C1.IsUpDown)
            {
                CameraController.cameraController.currentView = consoleCenteData_M_C1.ObservePlusView; //관찰 뷰 : < 시스템 재가동 버튼> 이 보이는 위치

                timer += Time.deltaTime;
                float seconds = Mathf.FloorToInt((timer % 3600) % 60);
                if(seconds>=2f) // 관찰하기 애니메이션 후 관찰화면으로 넘어가는데 2초 정도 걸리므로 2초 후 버튼 설명 띄움
                {
                    consoleDescription.SetActive(true);
                    consoleUnLockButtonData_M_C1.IsNotInteractable = false;
                    consoleUnLockButtonOutline.OutlineWidth = 10;
                }

                if (consoleUnLockButtonData_M_C1.IsPushOrPress)
                {
                    CameraController.cameraController.CancelObserve();

                    Invoke("OpenCockpitDoor", 1f); // 문 열렸다가 닫히는 애니메이션 
                    Invoke("CloseCockpitDoor", 3f);
                }

                if (envirPipeData_M_C1.IsBite) // <파이프> "물기" true 이면
                {
                    consoleAIResetButtonData_M_C1.IsNotInteractable = false; // AI 리셋 버튼 활성화
                    consoleAIResetButtonOutline.OutlineWidth = 8;

                    if (consoleAIResetButtonData_M_C1.IsPushOrPress)
                    {
                        CameraController.cameraController.CancelObserve();

                        consoleUnLockButtonData_M_C1.IsNotInteractable = true;
                        consoleUnLockButtonOutline.OutlineWidth = 0;

                        consoleAIResetButtonData_M_C1.IsNotInteractable = true; // AI 리셋 버튼 비활성화 (앞으로 누를 일 없음)
                        consoleAIResetButtonOutline.OutlineWidth = 0;

                        DialogManager.dialogManager.ResetSystem(); // AI 1 번째 대사 묶음 출력

                        GameManager.gameManager.IsAI_M_C1 = true; // return true; // 엔딩 수집 페이지 갱신, 게임 세이브 분기점
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

                consoleUnLockButtonData_M_C1.IsNotInteractable = true;
                consoleUnLockButtonOutline.OutlineWidth = 0;

                consoleAIResetButtonData_M_C1.IsNotInteractable = true; // AI 리셋 버튼 비활성화
                consoleAIResetButtonOutline.OutlineWidth = 0;
            }
        }
        else
        {
            timer = 0; // 관찰시간 텀 타이머 리셋
            consoleDescription.SetActive(false);

            consoleUnLockButtonData_M_C1.IsNotInteractable = true;
            consoleUnLockButtonOutline.OutlineWidth = 0;

            consoleAIResetButtonData_M_C1.IsNotInteractable = true; // AI 리셋 버튼 비활성화
            consoleAIResetButtonOutline.OutlineWidth = 0;
        }
    }

    void OpenCockpitDoor()
    {
        cockpitDoorAnim_M_C1.SetBool("IsDoorOpenStart", true);
        cockpitDoorAnim_M_C1.SetBool("IsDoorOpened", true);
    }
    void CloseCockpitDoor()
    {
        cockpitDoorAnim_M_C1.SetBool("IsDoorOpened", false);
        cockpitDoorAnim_M_C1.SetBool("IsDoorOpenStart", false);
    }
}
