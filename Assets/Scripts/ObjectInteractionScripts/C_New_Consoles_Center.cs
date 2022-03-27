using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class C_New_Consoles_Center: MonoBehaviour
{
    /* ������ ����Ǿ ����� ���� ������ */

    /* �� ������Ʈ�� ��ȣ�ۿ� �ϴ� ������ */
    public GameObject box_M_C1;
    public GameObject envirPipe_M_C1;
    public GameObject consoleAIResetButton_M_C1;
    public GameObject consoleUnLockButton_M_C1;
    public GameObject consoleCenter_M_C1;

    /* �� ������Ʈ�� ��ȣ�ۿ� �ϴ� �������� ������ */
    ObjData consoleCenteData_M_C1;
    ObjData boxData_M_C1;
    ObjData envirPipeData_M_C1;
    ObjData consoleAIResetButtonData_M_C1;
    ObjData consoleUnLockButtonData_M_C1;

    /* ��Ÿ �ʿ��� ������ */
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
            // �÷ο���Ʈ ó�� ���� �� �ְ� ���� ������� �ִ´�.  
            noahAnim_M_C1.SetBool("IsSleeping", true);
            StartCoroutine(NoahWakeUp()); // ���� �ִ� ��ư� �����
            StartCoroutine(FadeCoroutine()); //ȭ���� �������
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
                CameraController.cameraController.currentView = consoleCenteData_M_C1.ObservePlusView; //���� �� : < �ý��� �簡�� ��ư> �� ���̴� ��ġ

                timer += Time.deltaTime;
                float seconds = Mathf.FloorToInt((timer % 3600) % 60);
                if(seconds>=2f) // �����ϱ� �ִϸ��̼� �� ����ȭ������ �Ѿ�µ� 2�� ���� �ɸ��Ƿ� 2�� �� ��ư ���� ���
                {
                    consoleDescription.SetActive(true);
                    consoleUnLockButtonData_M_C1.IsNotInteractable = false;
                    consoleUnLockButtonOutline.OutlineWidth = 10;
                }

                if (consoleUnLockButtonData_M_C1.IsPushOrPress)
                {
                    CameraController.cameraController.CancelObserve();

                    Invoke("OpenCockpitDoor", 1f); // �� ���ȴٰ� ������ �ִϸ��̼� 
                    Invoke("CloseCockpitDoor", 3f);
                }

                if (envirPipeData_M_C1.IsBite) // <������> "����" true �̸�
                {
                    consoleAIResetButtonData_M_C1.IsNotInteractable = false; // AI ���� ��ư Ȱ��ȭ
                    consoleAIResetButtonOutline.OutlineWidth = 8;

                    if (consoleAIResetButtonData_M_C1.IsPushOrPress)
                    {
                        CameraController.cameraController.CancelObserve();

                        consoleUnLockButtonData_M_C1.IsNotInteractable = true;
                        consoleUnLockButtonOutline.OutlineWidth = 0;

                        consoleAIResetButtonData_M_C1.IsNotInteractable = true; // AI ���� ��ư ��Ȱ��ȭ (������ ���� �� ����)
                        consoleAIResetButtonOutline.OutlineWidth = 0;

                        DialogManager.dialogManager.ResetSystem(); // AI 1 ��° ��� ���� ���

                        GameManager.gameManager.IsAI_M_C1 = true; // return true; // ���� ���� ������ ����, ���� ���̺� �б���
                    }

                }
                else
                {
                    consoleAIResetButtonData_M_C1.IsNotInteractable = true; // AI ���� ��ư ��Ȱ��ȭ
                    consoleAIResetButtonOutline.OutlineWidth = 0;
                }

            }
            else // �ڽ� ���� �׳� <������> �� "�����ϱ�"
            {
                CameraController.cameraController.currentView = consoleCenteData_M_C1.ObserveView; // ���� �� : �� ���̴� ��ġ

                consoleUnLockButtonData_M_C1.IsNotInteractable = true;
                consoleUnLockButtonOutline.OutlineWidth = 0;

                consoleAIResetButtonData_M_C1.IsNotInteractable = true; // AI ���� ��ư ��Ȱ��ȭ
                consoleAIResetButtonOutline.OutlineWidth = 0;
            }
        }
        else
        {
            timer = 0; // �����ð� �� Ÿ�̸� ����
            consoleDescription.SetActive(false);

            consoleUnLockButtonData_M_C1.IsNotInteractable = true;
            consoleUnLockButtonOutline.OutlineWidth = 0;

            consoleAIResetButtonData_M_C1.IsNotInteractable = true; // AI ���� ��ư ��Ȱ��ȭ
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
