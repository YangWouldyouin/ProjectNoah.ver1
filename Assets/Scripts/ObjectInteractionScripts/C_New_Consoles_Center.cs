using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_New_Consoles_Center: MonoBehaviour
{
    /* ������ ����Ǿ ����� ���� ������ */
    public static bool IsAI_M_C1 = false;

    /* �� ������Ʈ�� ��ȣ�ۿ� �ϴ� ������ */
    public GameObject box_M_C1;
    public GameObject envirPipe_M_C1;
    public GameObject consoleAIResetButton_M_C1;
    public GameObject consoleUnLockButton_M_C1;
    public GameObject consoleCenter_M_C1;
    //public GameObject cockpitDoor_M_C1;

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
        if (consoleCenteData_M_C1.IsObserve) // <�ڽ�> "������" && <������> "�����ϱ�" true �̸�
        {
            if(boxData_M_C1.IsUpDown)
            {
                CameraController.cameraController.currentView = consoleCenteData_M_C1.ObservePlusView; //���� �� : < �ý��� �簡�� ��ư> �� ���̴� ��ġ
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

                //consoleCenteData_M_C1.IsExtraDescriptionActive = true; // ��ư �߰� ������ Ȱ��ȭ�Ѵ�. 


                if (consoleUnLockButtonData_M_C1.IsPushOrPress)
                {
                    CameraController.cameraController.CancelObserve();
                    //consoleDescription.SetActive(false); // ��Ʋ ���� ��Ȱ��ȭ
                    // �� ���ȴٰ� ������ �ִϸ��̼� 
                    consoleCenteData_M_C1.IsObserve = false; // ���Ƿ� �����ϱ� ����Ͽ����Ƿ� �������� �������� ����
                }

                if (envirPipeData_M_C1.IsBite) // <������> "����" true �̸�
                {
                    consoleAIResetButtonData_M_C1.IsNotInteractable = false; // AI ���� ��ư Ȱ��ȭ
                    consoleAIResetButtonOutline.OutlineWidth = 8;

                    if (consoleAIResetButtonData_M_C1.IsPushOrPress)
                    {
                        CameraController.cameraController.CancelObserve();
                        //consoleDescription.SetActive(false);

                        consoleUnLockButtonData_M_C1.IsNotInteractable = true;
                        consoleUnLockButtonOutline.OutlineWidth = 0;

                        consoleAIResetButtonData_M_C1.IsNotInteractable = true; // AI ���� ��ư ��Ȱ��ȭ (������ ���� �� ����)
                        consoleAIResetButtonOutline.OutlineWidth = 0;

                        DialogManager.dialogManager.ResetSystem(); // AI 1 ��° ��� ���� ���

                        //CameraController.cameraController.currentView = consoleCenteData_M_C1.ObserveView; // ������ �� �� �����Ƿ� �ʱ�ȭ
                        IsAI_M_C1 = true; // return true; // ���� ���� ������ ����, ���� ���̺� �б���
                        consoleCenteData_M_C1.IsObserve = false; // ���Ƿ� �����ϱ� ����Ͽ����Ƿ� �������� �������� ����

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
                //consoleDescription.SetActive(false);

                consoleUnLockButtonData_M_C1.IsNotInteractable = true;
                consoleUnLockButtonOutline.OutlineWidth = 0;

                consoleAIResetButtonData_M_C1.IsNotInteractable = true; // AI ���� ��ư ��Ȱ��ȭ
                consoleAIResetButtonOutline.OutlineWidth = 0;
            }
        }
        else
        {
            timer = 0;
            consoleDescription.SetActive(false);
            consoleUnLockButtonData_M_C1.IsNotInteractable = true;
            consoleUnLockButtonOutline.OutlineWidth = 0;

            consoleAIResetButtonData_M_C1.IsNotInteractable = true; // AI ���� ��ư ��Ȱ��ȭ
            consoleAIResetButtonOutline.OutlineWidth = 0;
        }
    }

    void TurnOnConsoleDescription()
    {
        consoleDescription.SetActive(true);
    }
}
