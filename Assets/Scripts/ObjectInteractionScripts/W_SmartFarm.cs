using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W_SmartFarm : MonoBehaviour
{
    private bool IsDisappearIron_SF = false;
    private bool IsRepairCompletion_SF = false;
    private bool IsLineGone_SF = false;

    public GameObject managementMachine_SF; //��ü
    public GameObject ironPlate_SF; // ����
    public GameObject brokenLine2_SF; //������ ��
    public GameObject fixedLine_SF; // ������ ��
    // �� ����� �� 1,3,4�� ���߿� ���� ������ �츮�� ������ �߰��� ��
    public GameObject inputLiner2_SF; // �� ����� �� 2

    ObjData ironPlateData_SF;
    ObjData managementMachineData_SF;
    ObjData brokenLine2Data_SF;
    ObjData fixedLineData_SF;
    ObjData inputLiner2Data_SF;

    public Animator smartFarmDoorAnim_HM;

    private Outline brokenLine2Outline_SF;
    private Outline inputLiner2Outline_SF;
    private Outline ironPlateOutline_SF;

    public GameObject dialogManager_SF;
    DialogManager dialogManager;

    private float dialogTimer_SF = 0f;
    private bool IsDialogPrinted_SF = true;

    void Start()
    {
        dialogManager = dialogManager_SF.GetComponent<DialogManager>();

        ironPlateData_SF = ironPlate_SF.GetComponent<ObjData>();
        managementMachineData_SF = managementMachine_SF.GetComponent<ObjData>();
        brokenLine2Data_SF = brokenLine2_SF.GetComponent<ObjData>();
        fixedLineData_SF = fixedLine_SF.GetComponent<ObjData>();
        inputLiner2Data_SF = inputLiner2_SF.GetComponent<ObjData>();


        brokenLine2Outline_SF = brokenLine2_SF.GetComponent<Outline>();
        inputLiner2Outline_SF = inputLiner2_SF.GetComponent<Outline>();
        ironPlateOutline_SF = ironPlate_SF.GetComponent<Outline>();
    }

    void Update()
    {
        if (!GameManager.gameManager._gameData.IsSmartFarmOpen_T_C2) // ������ �Ϸ��ϸ� ���� ���� ���¸� �����Ѵ�.
        {
            if (!IsDisappearIron_SF) // ���� �ı��Ǿ� ���� ���� �����̸� ���� �ı��ϴ� �ڵ带 �����ϰڴ�. 
            {
                MachinePlateDisapppear();
            }
            else
            {
                if (!IsRepairCompletion_SF) // ��谡 �����Ǿ� ���� ���� ���¶�� �����ϴ� CanListen �ڵ带 �����ϰڴ�.
                {
                    CanListen();
                }
                else
                {
                    WindowOpen();
                }
            }
        }
        else // @@@@@ ���߿� ����Ʈ�� ���� �̼� �߰� @@@@@@
        {
            // if ����Ʈ�� ����̼��ؾ��ϸ� ����̼��� �Ѵ�.
        }
    }

    //���� ������� �ϴ� �ڵ�
    public void MachinePlateDisapppear()
    {
        if (managementMachineData_SF.IsClicked)
        {
            dialogTimer_SF = 0;
            IsDialogPrinted_SF = false;
        }

        if (managementMachineData_SF.IsObserve) // ����Ʈ�� ���� ��� ��ü�� '�����ϱ�'�� ����ϸ�, �����ϱ� �並 �����Ѵ�.
        {
            managementMachineData_SF.IsNotInteractable = true;
            CameraController.cameraController.currentView = managementMachineData_SF.ObserveView;

            dialogTimer_SF += Time.deltaTime;
            float timer = Mathf.FloorToInt((dialogTimer_SF % 3600) % 60); ;
            if (timer >= 3f)
            {
                if (!IsDialogPrinted_SF)
                {
                    dialogManager.StartCoroutine(dialogManager.PrintAIDialog(8));
                    IsDialogPrinted_SF = true;
                }
            }
            if (ironPlateData_SF.IsBite) // ���ǿ� (�����ϱ� ���¿���) ���⸦ ����ϸ�
            {
                // �θ� �ڽ� ���踦 �����Ѵ�.
                ironPlate_SF.GetComponent<Rigidbody>().isKinematic = false;
                ironPlate_SF.transform.parent = null;

                // �ش� ��ġ, ����, ũ��� �ٲٰڴ�.
                ironPlate_SF.transform.position = new Vector3(-258.15f, 538.619f, 670.1605f); //��ġ ����
                ironPlate_SF.transform.rotation = Quaternion.Euler(7.034f, 90, 90); //���� ����
                ironPlate_SF.transform.localScale = new Vector3(-2.882732f, -115.34f, -93.69196f); // ũ�� ����
                ironPlateData_SF.IsNotInteractable = true; // ���� �� �̻� ��ȣ�ۿ� �Ұ�
                ironPlateOutline_SF.OutlineWidth = 0;
                Invoke("MakeIsDisappearIron_SF_True", 3f); //IsDisappearIron_T_C2�� Ʈ��� �ٲٴ°� 3�� ������Ű�ڴ�.
            }
        }

        if(ironPlateData_SF.IsBite) // �����ϱ� ���� ���¿��� ������ ����
        {
            Invoke("MakeIsDisappearIron_SF_True", 3f); //IsDisappearIron_T_C2�� Ʈ��� �ٲٴ°� 3�� ������Ű�ڴ�.
        }
    }


    void MakeIsDisappearIron_SF_True()
    {
        ironPlateData_SF.IsBite = false; // üũ �Ǿ� �ִ� ���⸦ ���ش�.
        IsDisappearIron_SF = true; // IsDisappearIron_T_C2�� Ʈ��� �ٲ�� �� ���¸� uptate���� �����ش�.
    }



    // ��� ��ġ�� �ڵ�
    public void CanListen()
    {
        if (managementMachineData_SF.IsObserve) //�����ϱ�
        {
            managementMachineData_SF.IsNotInteractable = true;
            CameraController.cameraController.currentView = managementMachineData_SF.ObserveView;
            brokenLine2Data_SF.IsNotInteractable = false; // ��ȣ�ۿ� �����ϰ�
            brokenLine2Outline_SF.OutlineWidth = 8; // �ƿ����ε� ���ݴϴ�.

            if (IsLineGone_SF) // ������ ���� ������� ����̶��,
            {
                inputLiner2Data_SF.IsNotInteractable = false; // �� ���� ���� �� �ְ� �˴ϴ�.
                inputLiner2Outline_SF.OutlineWidth = 8; // �ƿ������� ���ݴϴ�.
                if (fixedLineData_SF.IsBite)
                {
                    if (inputLiner2Data_SF.IsPushOrPress)// ������ ���� ���⸦ �ϰ� �� �ִ� ���� �ֱ⸦ �ϸ�,
                    {
                        //Debug.Log("������ ���� ���� ���� �ִ� ���� �ֱ� �߾��");

                        //�θ𿡼� ����
                        fixedLineData_SF.GetComponent<Rigidbody>().isKinematic = false; // ��迡�� ����� �Ѵ�.
                        fixedLineData_SF.transform.parent = null;

                        //������ ���� ��迡 �ڵ� ����
                        fixedLineData_SF.transform.position = new Vector3(-258.06f, 539.623f, 670.358f); //��ġ ��
                        fixedLineData_SF.transform.rotation = Quaternion.Euler(0, -90, 90); // ���� �� 

                        //Invoke("NoLine", 2f); //���� ������� �ڵ带 2�� �Ŀ� �����ϰڴ�.
                        //CameraController.cameraController.CancelObserve(); // �����ϱ� �� ����
                        // �� �ڸ����� �Ҹ� ���� �� ���� - ���� AI��� ġ�� ��ó�� ��迡 '¢��'�� ����ϼ��� ��� ������ �鸱 �����̴�.
                        fixedLineData_SF.IsBite = false; // ���� �ִ� ���¸� false�� �ٲ���� Ȯ���ϰ� ��迡�� ��� �� �ִ�.
                        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(9));
                        IsRepairCompletion_SF = true;
                    }
                }
                else // �ƹ����¿����� �� �ִ� ���� �����⸦ ���� ��� ī�޶� �並 �����ϰ� �ִϸ��̼Ǹ� �����ݴϴ�.
                {
                    if (inputLiner2Data_SF.IsPushOrPress)
                    {
                        managementMachineData_SF.IsObserve = false;
                        CameraController.cameraController.CancelObserve();
                    }
                }
            }
            else
            {
                // ������ �� ����
                if (brokenLine2Data_SF.IsBite)
                {
                    //Debug.Log("������ ���� �����");
                    CameraController.cameraController.CancelObserve();
                    //Debug.Log("������ ���� ���� �����ϱ⸦ �����߾��");

                    Invoke("BrokenLine2Disapppear", 4f);
                    //Debug.Log("������ ���� ���ֹ��Ⱦ��");
                    IsLineGone_SF = true; // ������ ���� �����ٴ� �� ������Ʈ�� �˸���.
                }
            }
        }
        else // �����ϱ⸦ �����ϸ�,
        {
            //Debug.Log("��ȣ�ۿ� �Ұ����ؿ�");
            brokenLine2Data_SF.IsNotInteractable = true; // ��ȣ�ۿ��� �Ұ��������ϴ�.
            brokenLine2Outline_SF.OutlineWidth = 0; // �ƿ����ε� ���ݴϴ�.

            //Debug.Log("�� ����� ���� ��Ȱ��ȭ �ƾ��");
            inputLiner2Data_SF.IsNotInteractable = true; // �����ϱ⸦ ������ ���¿��� ������ �ִ� ���� ���� ���� - �����ϱ� ���¸� �����ϸ� �ٽ� ��ȣ�ۿ��� �Ұ��������ϴ�.
            inputLiner2Outline_SF.OutlineWidth = 0; // �ƿ������� ���ݴϴ�.
        }
        //else if (BrokenLine2_T_C2Data.IsBite && InputLiner2Data.IsPushOrPress)
        //{
        //    Debug.Log("���峭 ���� ���� ���� �ִ� ���� �ֱ� �߾��");

        //    //���� �ִ� fitPart ���� ���� -> bool false


        //    BrokenLine2_T_C2Data.GetComponent<Rigidbody>().isKinematic = false; // ��迡�� ����� �Ѵ�.
        //    BrokenLine2_T_C2Data.transform.parent = null;

        //    //������ ���� ��迡 �ڵ� ����
        //    BrokenLine2_T_C2Data.transform.position = new Vector3(-258.06f, 539.623f, 670.358f); //��ġ ��
        //    BrokenLine2_T_C2Data.transform.rotation = Quaternion.Euler(0, -90, 90); // ���� �� 

        //    //CameraController.cameraController.CancelObserve(); // �����ϱ� �� ����

        //    BrokenLine2_T_C2Data.IsBite = false; // ���� �ִ� ���¸� false�� �ٲ���� Ȯ���ϰ� ��迡�� ��� �� �ִ�.
        //}

    }


    void BrokenLine2Disapppear()
    {
        brokenLine2_SF.SetActive(false);
    }


    public void WindowOpen() //����Ʈ �� �� ���� �ڵ�
    {
        if (managementMachineData_SF.IsBark) // ��迡 ¢�⸦ ����ߴٸ�,
        {
            Invoke("WindowAnimAndDialog", 2f); //2���� �� ������ & AI �Ϸ� ��縦 �����Ѵ�.
            GameManager.gameManager._gameData.IsSmartFarmOpen_T_C2 = true; // �׻� �� ���� �����ִ� ���� True�� �ȴ�.
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        }
    }
    void WindowAnimAndDialog() // ����Ʈ�� �Ա� ������ �ִϸ��̼� & ���
    {
        smartFarmDoorAnim_HM.SetBool("FarmDoorMoving", true);
        smartFarmDoorAnim_HM.SetBool("FarmDoorStop", true);
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(10));

    }
}
