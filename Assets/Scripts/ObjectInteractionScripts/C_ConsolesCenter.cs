using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class C_ConsolesCenter : MonoBehaviour
{
    /* �� ������Ʈ�� ��ȣ�ۿ� �ϴ� ������ */
    public GameObject box_CC;
    public GameObject envirPipe_CC;
    public GameObject consoleAIResetButton_CC;
    public GameObject consoleUnLockButton_CC;
    public GameObject consoleCenter_CC;

    /* �� ������Ʈ�� ��ȣ�ۿ� �ϴ� �������� ������ */
    ObjData consoleCenterData_CC;
    ObjData boxData_CC;
    ObjData envirPipeData_CC;
    ObjData consoleAIResetButtonData_CC;
    ObjData consoleUnLockButtonData_CC;

    /* ��Ÿ �ʿ��� ������ */
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
            // �÷ο���Ʈ ó�� ���� �� �ְ� ���� ������� �ִ´�.  
            noahAnim_CC.SetBool("IsSleeping", true);
            StartCoroutine(NoahWakeUp()); // ���� �ִ� ��ư� �����
            StartCoroutine(FadeCoroutine()); //ȭ���� �������
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
                CameraController.cameraController.currentView = consoleCenterData_CC.ObservePlusView; //���� �� : < �ý��� �簡�� ��ư> �� ���̴� ��ġ

                timer_CC += Time.deltaTime;
                float seconds = Mathf.FloorToInt((timer_CC % 3600) % 60);
                if (seconds >= 2f) // �����ϱ� �ִϸ��̼� �� ����ȭ������ �Ѿ�µ� 2�� ���� �ɸ��Ƿ� 2�� �� ��ư ���� ���
                {
                    consoleDescription_CC.SetActive(true);
                    consoleUnLockButtonData_CC.IsNotInteractable = false;
                    consoleUnLockButtonOutline_CC.OutlineWidth = 10;
                }

                if (consoleUnLockButtonData_CC.IsPushOrPress)
                {
                    CameraController.cameraController.CancelObserve();

                    Invoke("OpenCockpitDoor", 1f); // �� ���ȴٰ� ������ �ִϸ��̼� 
                    Invoke("CloseCockpitDoor", 3f);
                }

                if (envirPipeData_CC.IsBite) // <������> "����" true �̸�
                {
                    consoleAIResetButtonData_CC.IsNotInteractable = false; // AI ���� ��ư Ȱ��ȭ
                    consoleAIResetButtonOutline_CC.OutlineWidth = 8;

                    if (consoleAIResetButtonData_CC.IsPushOrPress)
                    {
                        CameraController.cameraController.CancelObserve();

                        consoleUnLockButtonData_CC.IsNotInteractable = true;
                        consoleUnLockButtonOutline_CC.OutlineWidth = 0;

                        consoleAIResetButtonData_CC.IsNotInteractable = true; // AI ���� ��ư ��Ȱ��ȭ (������ ���� �� ����)
                        consoleAIResetButtonOutline_CC.OutlineWidth = 0;

                        //DialogManager.dialogManager.ResetSystem(); // AI 1 ��° ��� ���� ���

                        GameManager.gameManager.IsAI_M_C1 = true; // return true; // ���� ���� ������ ����, ���� ���̺� �б���
                    }

                }
                else
                {
                    consoleAIResetButtonData_CC.IsNotInteractable = true; // AI ���� ��ư ��Ȱ��ȭ
                    consoleAIResetButtonOutline_CC.OutlineWidth = 0;
                }

            }
            else // �ڽ� ���� �׳� <������> �� "�����ϱ�"
            {
                CameraController.cameraController.currentView = consoleCenterData_CC.ObserveView; // ���� �� : �� ���̴� ��ġ

                consoleUnLockButtonData_CC.IsNotInteractable = true;
                consoleUnLockButtonOutline_CC.OutlineWidth = 0;

                consoleAIResetButtonData_CC.IsNotInteractable = true; // AI ���� ��ư ��Ȱ��ȭ
                consoleAIResetButtonOutline_CC.OutlineWidth = 0;
            }
        }
        else
        {
            timer_CC = 0; // �����ð� �� Ÿ�̸� ����
            consoleDescription_CC.SetActive(false);

            consoleUnLockButtonData_CC.IsNotInteractable = true;
            consoleUnLockButtonOutline_CC.OutlineWidth = 0;

            consoleAIResetButtonData_CC.IsNotInteractable = true; // AI ���� ��ư ��Ȱ��ȭ
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
