using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W_MeteorCollectMachine : MonoBehaviour
{
    private bool meteorCollectanimOpen_MCM = false;

    //� ����---------------------------------
    //public GameObject doorCollectMachine_MCM; // ���� ��� ��
    public GameObject meteorCollectMachine_MCM; // � ���� ���
    public GameObject meteorButton_MCM; // ���� ��� �� ���� ��ư
    public GameObject normalMeteor1_MCM; // �Ϲ� �
    public GameObject importantMeteor_MCM; // �߿��� �
    public GameObject analyticalMachine_MCM; // �м���
    public GameObject analyticalMachineButton_MCM; // �м����ư
    public GameObject analyticalMachinePlate_MCM; // �м��� ���� ����? �׸�?
    public GameObject rubber2_MCM; // ����


    //ObjData doorCollectMachineData_MCM;
    ObjData meteorCollectMachineData_MCM;
    ObjData meteorButtonData_MCM;
    ObjData normalMeteor1Data_MCM;
    ObjData importantMeteorData_MCM;
    ObjData analyticalMachineData_MCM;
    ObjData analyticalMachineButtonData_MCM;
    ObjData analyticalMachinePlateData_MCM;
    ObjData rubber2Data_MCM;


    Outline meteorButtonOutline_MCM;
    Outline meteorCollectMachineOutline_MCM;
    Outline normalMeteor1Outline_MCM;
    Outline importantMeteorOutline_MCM;
    Outline analyticalMachineOutline_MCM;
    Outline analyticalMachineButtonOutline_MCM;
    Outline analyticalMachinePlateOutline_MCM;

    public GameObject Report_GUI;
    private bool IsReported = false;


    public Animator meteorBoxAnim_WED;
    public Animator analyticalMachineAnim_WED;



    //



    //private int count = 0;
    //private int count1 = 0;

    // Start is called before the first frame update
    void Start()
    {
        // AI�� �˸��� ��� ������������ �̵��Ѵ�.
        // ���� ��� � ���� ��迡�� ���������� Ȯ��
        // ������ �ʾҴٸ� ���� ��� �������.
        // �ð� ���� ��� ������� ������.

        // 5�ʰ� ������ A��� ������ ��ȣ�ۿ� ����
        // 10�ʰ� ������ A��� ������(��ȣ�ۿ� �Ұ���) B��� ������.(��ȣ�ۿ� ����)
        // 15�ʰ� ������ B��� ������ C��� ������.


        //doorCollectMachineData_MCM = doorCollectMachine_MCM.GetComponent<ObjData>();
        meteorCollectMachineData_MCM = meteorCollectMachine_MCM.GetComponent<ObjData>();
        meteorButtonData_MCM = meteorButton_MCM.GetComponent<ObjData>();
        normalMeteor1Data_MCM = normalMeteor1_MCM.GetComponent<ObjData>();
        importantMeteorData_MCM = importantMeteor_MCM.GetComponent<ObjData>();
        analyticalMachineData_MCM = analyticalMachine_MCM.GetComponent<ObjData>();
        analyticalMachineButtonData_MCM = analyticalMachineButton_MCM.GetComponent<ObjData>();
        analyticalMachinePlateData_MCM = analyticalMachinePlate_MCM.GetComponent<ObjData>();
        rubber2Data_MCM = rubber2_MCM.GetComponent<ObjData>();

        meteorButtonOutline_MCM = meteorButton_MCM.GetComponent<Outline>();
        meteorCollectMachineOutline_MCM = meteorCollectMachine_MCM.GetComponent<Outline>();
        normalMeteor1Outline_MCM = normalMeteor1_MCM.GetComponent<Outline>();
        importantMeteorOutline_MCM = importantMeteor_MCM.GetComponent<Outline>();
        analyticalMachineOutline_MCM = analyticalMachine_MCM.GetComponent<Outline>();
        analyticalMachineButtonOutline_MCM = analyticalMachineButton_MCM.GetComponent<Outline>();
        analyticalMachinePlateOutline_MCM = analyticalMachinePlate_MCM.GetComponent<Outline>();
    }

    
    // Update is called once per frame
    void Update()
    {
        if(meteorButtonData_MCM.IsCollision)
        {
            meteorButtonData_MCM.IsNotInteractable = false; // ��ȣ�ۿ� �����ϰ�
            meteorButtonOutline_MCM.OutlineWidth = 16;
        }

        else
        {
            meteorButtonData_MCM.IsNotInteractable = true; // ��ȣ�ۿ� �����ϰ�
            meteorButtonOutline_MCM.OutlineWidth = 0;
        }

        //� ������ ���� ��ư�� ������
        if (meteorButtonData_MCM.IsPushOrPress)
        {
            StartCoroutine(meteorBoxOpen());
           // Invoke("meteorBoxOpen", 1f);
            meteorCollectMachineData_MCM.IsNotInteractable = false; // ��ȣ�ۿ� �����ϰ�
            meteorCollectMachineOutline_MCM.OutlineWidth = 8;
            meteorCollectanimOpen_MCM = true;

            //�κ�ũ ȣ�� Ƚ�� ���� �Լ�
            /*if (count >= 2)
            {
                CancelInvoke("meteorBoxOpen");
                Reset();
            }*/

            if (meteorCollectanimOpen_MCM == true)
            {
                if (!normalMeteor1Data_MCM.IsBite)
                {
                    //Invoke("meteorBoxClose", 10f);

                    StartCoroutine(meteorBoxClose(0f, 30f));
                }
            }
        }




        //���̰� �Ǹ�, ��� ��ȣ�ۿ� ��ư ������.
        if(meteorCollectMachineData_MCM.IsCollision)
        {
            meteorCollectMachineData_MCM.IsCenterButtonDisabled = false;
        }
        else
        {
            meteorCollectMachineData_MCM.IsCenterButtonDisabled = true;
        }

        

        if(meteorCollectMachineData_MCM.IsObserve)
        {
            CameraController.cameraController.currentView = meteorCollectMachineData_MCM.ObserveView;

            normalMeteor1Data_MCM.IsNotInteractable = false; // ��ȣ�ۿ� �����ϰ�
            normalMeteor1Outline_MCM.OutlineWidth = 8; // �ƿ����ε� ���ݴϴ�.

            importantMeteorData_MCM.IsNotInteractable = false; // ��ȣ�ۿ� �����ϰ�
            importantMeteorOutline_MCM.OutlineWidth = 8; // �ƿ����ε� ���ݴϴ�.

            meteorCollectMachineData_MCM.IsNotInteractable = true; // ��ȣ�ۿ� �Ұ����ϰ�
            meteorCollectMachineOutline_MCM.OutlineWidth = 0; // �ƿ����ε� ���ݴϴ�.

            meteorButtonData_MCM.IsNotInteractable = true; // ��ȣ�ۿ� �����ϰ�
            meteorButtonOutline_MCM.OutlineWidth = 0;
        }
/*
        else
        {
            //meteorCollectMachineData_MCM.IsCenterButtonDisabled = false;
            Invoke("meteorBoxClose", 2f);
        }*/


        if(meteorCollectMachineData_MCM.IsObserve && normalMeteor1Data_MCM.IsBite 
            || meteorCollectMachineData_MCM.IsObserve && importantMeteorData_MCM.IsBite)
        {
            meteorCollectMachineData_MCM.IsObserve = false;

            CameraController.cameraController.CancelObserve();

            GameManager.gameManager.IsCanMeteorGet = true;


            StartCoroutine(meteorBoxClose(0f, 30f));

          //  Invoke("meteorBoxClose", 2f);
/*            if (count >= 2)
            {
                CancelInvoke("meteorBoxClose");
            }*/

            meteorCollectMachineData_MCM.IsNotInteractable = true; // ��ȣ�ۿ� �� ����
            meteorCollectMachineOutline_MCM.OutlineWidth = 0;
        }



        //���� �ñ⸦ �ϸ� ������ ��迡 ��ȣ�ۿ� �����ϰ� �ȴ�.
        // �׳� �ѹ��� ������ ���� �м��⿡ ������ � ���� �� �ְ� �Ǵ� �Ű���? 
        // �ƴ� ����� ���� ������ �ݺ��ؾ� �Ǵ°ǰ�?
        if (normalMeteor1Data_MCM.IsSniff && analyticalMachineButtonData_MCM.IsCollision
            || importantMeteorData_MCM.IsSniff && analyticalMachineButtonData_MCM.IsCollision)
        {
            //Debug.Log("��ȣ�ۿ��� �����������");
            //��ȣ�ۿ��� ����������.
            analyticalMachineButtonData_MCM.IsNotInteractable = false; // ��ȣ�ۿ� �����ϰ�
            analyticalMachineButtonOutline_MCM.OutlineWidth = 16;

            GameManager.gameManager.IsSmellDone = true;
        }
        else if(analyticalMachineButtonData_MCM.IsCollision == false)
        {
            analyticalMachineButtonData_MCM.IsNotInteractable = true; // ��ȣ�ۿ� �� �����ϰ�
            analyticalMachineButtonOutline_MCM.OutlineWidth = 0;
        }



        //�м��� ��ư�� ������
        if (analyticalMachineButtonData_MCM.IsPushOrPress)
        {
            StartCoroutine(analyticalMachineClose(2f,0f));

            /*            if (count1 >= 3)
                        {
                            CancelInvoke("analyticalMachineOpen");
                        }*/

            analyticalMachineData_MCM.IsNotInteractable = false; // ��ȣ�ۿ� �����ϰ�
            analyticalMachineOutline_MCM.OutlineWidth = 8;
        }

        //���̰� �Ǹ� Ư�� ��ȣ�ۿ� ������ 
        if (analyticalMachineData_MCM.IsCollision)
        {
            analyticalMachineData_MCM.IsCenterButtonDisabled = false;
        }
        else
        {
            analyticalMachineData_MCM.IsCenterButtonDisabled = true;
        }


        if (analyticalMachineData_MCM.IsObserve)
        {
            CameraController.cameraController.currentView = analyticalMachineData_MCM.ObserveView;
            analyticalMachinePlateData_MCM.IsNotInteractable = false; // ��ȣ�ۿ� �����ϰ�
            analyticalMachinePlateOutline_MCM.OutlineWidth = 8;

            analyticalMachineData_MCM.IsNotInteractable = true; // ��ȣ�ۿ� �� �����ϰ�
            analyticalMachineOutline_MCM.OutlineWidth = 0;

            analyticalMachineButtonData_MCM.IsNotInteractable = true; // ��ȣ�ۿ� �� �����ϰ�
            analyticalMachineButtonOutline_MCM.OutlineWidth = 0;
        }

        else
        {
            analyticalMachinePlateData_MCM.IsNotInteractable = true; // ��ȣ�ۿ� �����ϰ�
            analyticalMachinePlateOutline_MCM.OutlineWidth = 0;
        }


        if(rubber2Data_MCM.IsBite)
        {
            if (GameManager.gameManager.IsSmellDone == true)
            {
                //������ ���� �Ϲ� ��� ���� ���� �����ϴ�. 
                if (rubber2Data_MCM.IsBite && normalMeteor1Data_MCM.IsBite)
                {
                    if (analyticalMachineData_MCM.IsObserve && rubber2Data_MCM.IsBite && analyticalMachinePlateData_MCM.IsPushOrPress)
                    {
                        normalMeteor1Data_MCM.GetComponent<Rigidbody>().isKinematic = false; // ��迡�� ����� �Ѵ�.
                        normalMeteor1Data_MCM.transform.parent = null;

                        normalMeteor1Data_MCM.transform.position = new Vector3(-254.667f, 540.622f, 690.674f); //��ġ ��

                        Invoke("analyticalMachineView", 1f);

                        StartCoroutine(analyticalMachineOpen());// ������ �ִϸ��̼�

                        /*                        if (count1 >= 3)
                                                {
                                                    CancelInvoke("analyticalMachineClose");
                                                }*/

                        GameManager.gameManager.InputNormalMeteor1 = true;

                        Invoke("Report_Popup", 4f);


                        // �����ϱ� �˾��� ���.  UI.SetActive(True);
                        // ����� �׳� 1,2,3,4,5 �ڵ� �����ϸ� ���� ��
                        // if(�м��⿡ ����� ������)
                        // � �������� ���� �ٽ� ������
                        // IsCanMeteorGet = false;�� �Ǿ� �ݺ� �����ϰ�
                        // ���� �ϱ⸦ �ϸ� InputNormalMeteor1 = true; �� �־��ش�.

                        //�����ϱ� â�� �˾�
                        //�ٸ� ������ �� ��� ���⿡ �����ϳ� �־��ְ� �������� Report�Լ��� if(�� ������ Ʈ���) -> ������ ���� �����.

                    }
                }


                //������ ���� Ư�� ��� ���� ������ ���� �����ϴ�.
                if (analyticalMachineData_MCM.IsObserve && rubber2Data_MCM.IsBite && importantMeteorData_MCM.IsBite)
                {
                    if (analyticalMachinePlateData_MCM.IsPushOrPress)
                    {
                        //�߿� ��� �־����� Ȯ���ϴ� Boolüũ
                        GameManager.gameManager.IsyesImportantMeteor = true;

                        importantMeteorData_MCM.GetComponent<Rigidbody>().isKinematic = false; // ��迡�� ����� �Ѵ�.
                        importantMeteorData_MCM.transform.parent = null;

                        importantMeteorData_MCM.transform.position = new Vector3(-254.667f, 540.622f, 690.674f); //��ġ ��

                        Invoke("analyticalMachineView", 1f);

                        // � ��� �ӹ��� ��������� Ȯ������ �ʾƼ� Ƚ�� ���¼��� �ְڴ�.
/*                        if (count1 >= 4)
                        {
                            CancelInvoke("analyticalMachineClose");
                        }*/

                        // ������ �ִϸ��̼�
                        Invoke("analyticalMachineClose", 2f);
                        Invoke("Report_Popup", 4f);

                    }
                }
                /*            else if (analyticalMachineButtonData_MCM.IsBite)
                            {
                                Debug.Log("��������");
                            }*/
            }
        }

           

        // ������ ���� ���� ���·δ� ���� ������ ����.
        else if (normalMeteor1Data_MCM.IsBite || importantMeteorData_MCM.IsBite)
        {
            Debug.Log("��������");
        }


    }

    public void Report_Popup()
    {
        if (IsReported)
        {
            Report_GUI.SetActive(false);
        }
        else
        {
            Report_GUI.SetActive(true);
        }
    }

    public void Report()
    {
        //if ���� ������ �ٿ� ������ �Ϸ���� �ʾҴٸ�
        //�����ϱ� ������ �̵�
        //else ���� ������ �̵�

        Debug.Log("�����ϱ�");
        IsReported = true;
        Report_GUI.SetActive(false);

        if(GameManager.gameManager.IsyesImportantMeteor == true)
        {
            Debug.Log("������ȯ����");
        }
    }

    public void Cancle()
    {
        //if ���� ������ �ٿ� ������ �Ϸ���� �ʾҴٸ�
        //cancleCount += 1;

        Debug.Log("����ϱ�");
        IsReported = true;
        Report_GUI.SetActive(false);
    }


    //�ִϸ��̼�
    IEnumerator meteorBoxOpen()
    {
        // �⺻������ �� �Լ��� ���� �� ���� 1�� ������ �Ŀ� �����ϰڴ�.
        yield return new WaitForSeconds(1f);

        
        meteorBoxAnim_WED.SetBool("isMeteorBoxClose", false);
        meteorBoxAnim_WED.SetBool("isMeteorBoxCloseEnd", false);
        meteorBoxAnim_WED.SetBool("isMeteorBoxOpen", true);
        meteorBoxAnim_WED.SetBool("isMeteorBoxOpenEnd", true);
        //count += 1;
    }

    // delay: �ִϸ��̼� �����ϱ� ������ �ð����� �󸶳� �Ұ���,
    // closeTimeCheck: �ð� ���� �󸶷� �ɾ��ٰ��� ��: 20�ʸ� ������ 20��Ȯ���Ŀ� �ִϸ��̼� �����ϰڴ�.
    IEnumerator meteorBoxClose(float delay, float closeTimeCheck)
    {
        
        yield return new WaitForSeconds(delay);


        bool isTimeOver = false;
        float closeTime = 0f;

        while (isTimeOver == false)
        {
            yield return null;

            closeTime += Time.deltaTime;

            //���� �ð���>=���� �ɾ�� �ð����� ũ�ų� ������
            //isTimeOver = true;�� �Ǿ� �� (isTimeOver == false)���� �����ڴ�.
            if (closeTime >= closeTimeCheck)
            {
                isTimeOver = true;
            }

            //Ȥ�� ��� �����ٸ� �� (isTimeOver == false)���� �����ڴ�
            if (normalMeteor1Data_MCM.IsBite)
            {
                isTimeOver = true;
            }
        }

        // isTimeOver = true�� �Ǿ��ٸ� �Ʒ��� �ִ� �ִϸ��̼��� �����ϰڴ�.
        meteorBoxAnim_WED.SetBool("isMeteorBoxOpen", false);
        meteorBoxAnim_WED.SetBool("isMeteorBoxOpenEnd", false);
        meteorBoxAnim_WED.SetBool("isMeteorBoxClose", true);
        meteorBoxAnim_WED.SetBool("isMeteorBoxCloseEnd", true);

    }

    IEnumerator analyticalMachineOpen()
    {
        yield return new WaitForSeconds(1f);

        analyticalMachineAnim_WED.SetBool("isAnalyticalMachineOpen", true);
        analyticalMachineAnim_WED.SetBool("isAnalyticalMachineOpenEnd", true);
        analyticalMachineAnim_WED.SetBool("isAnalyticalMachineClose", false);
        analyticalMachineAnim_WED.SetBool("isAnalyticalMachineCloseEnd", false);

        //count1 += 1;
    }

    IEnumerator analyticalMachineClose(float delay2, float CloseTimeCheck2)
    {
        yield return new WaitForSeconds(delay2);


        bool isAnalyticalTimeOver = false;
        float closeTime2 = 0f;

        while (isAnalyticalTimeOver == false)
        {
            yield return null;

            closeTime2 += Time.deltaTime;

            //���� �ð���>=���� �ɾ�� �ð����� ũ�ų� ������
            //isTimeOver = true;�� �Ǿ� �� (isTimeOver == false)���� �����ڴ�.
            if (closeTime2 >= CloseTimeCheck2)
            {
                isAnalyticalTimeOver = true;
            }

            //Ȥ�� ��� �����ٸ� �� (isTimeOver == false)���� �����ڴ�
            if (normalMeteor1Data_MCM.IsBite)
            {
                isAnalyticalTimeOver = true;
            }
        }

        analyticalMachineAnim_WED.SetBool("isAnalyticalMachineClose", true);
        analyticalMachineAnim_WED.SetBool("isAnalyticalMachineCloseEnd", true);
        analyticalMachineAnim_WED.SetBool("isAnalyticalMachineOpen", false);
        analyticalMachineAnim_WED.SetBool("isAnalyticalMachineOpenEnd", false);

        //count1 += 1;
    }

    void analyticalMachineView()
    {
        analyticalMachineData_MCM.IsObserve = false;

        CameraController.cameraController.CancelObserve();
    }

    private void Reset()
    {
        Debug.Log("count�� �����߾��!");
        //count = 1;
    }
}
