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
    public GameObject consoleCenter_CC;

    /* �� ������Ʈ�� ��ȣ�ۿ� �ϴ� �������� ������ */
    ObjData consoleCenterData_CC;
    ObjData boxData_CC;
    ObjData envirPipeData_CC;
    ObjData consoleAIResetButtonData_CC;

    /* ��Ÿ �ʿ��� ������ */
    Outline consoleAIResetButtonOutline_CC;
    public GameObject consoleDescription_CC;
    public Animator noahAnim_CC;

    public Image fadeImage_CC;
    public GameObject fade_CC;
    public Image aiIcon_CC;

    public GameObject dialogManager_CC;
    DialogManager dialogManager;

    float timer_CC = 0;

    // Start is called before the first frame update
    void Start()
    {
        dialogManager = dialogManager_CC.GetComponent<DialogManager>();

        if (!GameManager.gameManager._gameData.IsAIAwake_M_C1)
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

        consoleAIResetButtonOutline_CC = consoleAIResetButton_CC.GetComponent<Outline>();
        consoleAIResetButtonOutline_CC.OutlineWidth = 0;
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

            consoleCenterData_CC.IsNotInteractable = true;
            if (boxData_CC.IsUpDown)
            {
                CameraController.cameraController.currentView = consoleCenterData_CC.ObservePlusView; //���� �� : < �ý��� �簡�� ��ư> �� ���̴� ��ġ

                timer_CC += Time.deltaTime;
                float seconds = Mathf.FloorToInt((timer_CC % 3600) % 60);
                if (seconds >= 2f) // �����ϱ� �ִϸ��̼� �� ����ȭ������ �Ѿ�µ� 2�� ���� �ɸ��Ƿ� 2�� �� ��ư ���� ���
                {
                    consoleDescription_CC.SetActive(true);
                }


                if (envirPipeData_CC.IsBite) // <������> "����" true �̸�
                {
                    consoleAIResetButtonData_CC.IsNotInteractable = false; // AI ���� ��ư Ȱ��ȭ
                    consoleAIResetButtonOutline_CC.OutlineWidth = 8;

                    if (consoleAIResetButtonData_CC.IsPushOrPress)
                    {
                        CameraController.cameraController.CancelObserve();


                        consoleAIResetButtonData_CC.IsNotInteractable = true; // AI ���� ��ư ��Ȱ��ȭ (������ ���� �� ����)
                        consoleAIResetButtonOutline_CC.OutlineWidth = 0;
                        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(1));

                        GameManager.gameManager._gameData.IsAIAwake_M_C1 = true;
                        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
                        //GameManager.gameManager.IsAI_M_C1 = true; // ���� ���̺� �б���
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


                consoleAIResetButtonData_CC.IsNotInteractable = true; // AI ���� ��ư ��Ȱ��ȭ
                consoleAIResetButtonOutline_CC.OutlineWidth = 0;
            }
        }
        else
        {
            consoleCenterData_CC.IsNotInteractable = false;
            timer_CC = 0; // �����ð� �� Ÿ�̸� ����
            consoleDescription_CC.SetActive(false);

            consoleAIResetButtonData_CC.IsNotInteractable = true; // AI ���� ��ư ��Ȱ��ȭ
            consoleAIResetButtonOutline_CC.OutlineWidth = 0;
        }
    }
}
