using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_AnalyticalMachinePlate : MonoBehaviour, IInteraction
{
    public GameObject Report_GUI;
    private bool IsReported = false;

    /*�����ִ� ������Ʈ*/
    public GameObject T_RealNormalMeteor1;
    public GameObject T_RealImportantMeteor;
    public GameObject T_AreRubber;

    /*������Ʈ�� ��ȣ�ۿ� ��ư��*/
    private Button barkButton_T_AnalyticalMachineButton, sniffButton_T_AnalyticalMachineButton, biteButton_T_AnalyticalMachineButton,
        pressButton_T_AnalyticalMachineButton, noCenterButton_T_AnalyticalMachineButton;

    /*ObjData*/
    ObjData analyticalMachineButtonData_T;
    ObjData RealNormalMeteor1Data_T;
    ObjData RealimportantMeteorData_T;
    ObjData areRubberData_T;


    /*Outline*/
    Outline RealNormalMeteor1Outline_T;
    Outline RealimportantMeteorOutline_T;

    // Start is called before the first frame update
    void Start()
    {
        /*ObjData*/
        analyticalMachineButtonData_T = GetComponent<ObjData>();
        RealNormalMeteor1Data_T = T_RealNormalMeteor1.GetComponent<ObjData>();
        RealimportantMeteorData_T = T_RealImportantMeteor.GetComponent<ObjData>();
        areRubberData_T = T_AreRubber.GetComponent<ObjData>();


        /*Outline*/
        RealNormalMeteor1Outline_T = T_RealNormalMeteor1.GetComponent<Outline>();
        RealimportantMeteorOutline_T = T_RealImportantMeteor.GetComponent<Outline>();


        barkButton_T_AnalyticalMachineButton = analyticalMachineButtonData_T.BarkButton;
        barkButton_T_AnalyticalMachineButton.onClick.AddListener(OnBark);

        sniffButton_T_AnalyticalMachineButton = analyticalMachineButtonData_T.SniffButton;
        sniffButton_T_AnalyticalMachineButton.onClick.AddListener(OnSniff);

        biteButton_T_AnalyticalMachineButton = analyticalMachineButtonData_T.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_T_AnalyticalMachineButton = analyticalMachineButtonData_T.PushOrPressButton;
        pressButton_T_AnalyticalMachineButton.onClick.AddListener(OnPushOrPress);

        noCenterButton_T_AnalyticalMachineButton = analyticalMachineButtonData_T.CenterButton1;
    }

    void DisableButton()
    {
        barkButton_T_AnalyticalMachineButton.transform.gameObject.SetActive(false);
        sniffButton_T_AnalyticalMachineButton.transform.gameObject.SetActive(false);
        biteButton_T_AnalyticalMachineButton.transform.gameObject.SetActive(false);
        pressButton_T_AnalyticalMachineButton.transform.gameObject.SetActive(false);
        noCenterButton_T_AnalyticalMachineButton.transform.gameObject.SetActive(false);
    }
    public void OnBark()
    {
        analyticalMachineButtonData_T.IsBark = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }


    public void OnPushOrPress()
    {
        analyticalMachineButtonData_T.IsPushOrPress = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();

        StartCoroutine(ChangePressFalse());

        if(areRubberData_T.IsBite)
        {
            //������ ���� �Ϲ� ��� ����
            if (areRubberData_T.IsBite && RealNormalMeteor1Data_T.IsBite)
            {
                T_RealNormalMeteor1.GetComponent<Rigidbody>().isKinematic = false; // ��迡�� ����� �Ѵ�.
                T_RealNormalMeteor1.transform.parent = null;

                T_RealNormalMeteor1.transform.position = new Vector3(-254.667f, 540.622f, 690.674f);

                GameManager.gameManager._gameData.IsInputNormalMeteor1_T_C2 = true;
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

                Invoke("Report_Popup", 4f);

                //��ȣ�ۿ��� ���ش�.

                RealNormalMeteor1Data_T.IsNotInteractable = true; // ��ȣ�ۿ� �Ұ����ϰ�
                RealNormalMeteor1Outline_T.OutlineWidth = 0;
            }

            //������ ���� Ư���� ��� ����
            if(areRubberData_T.IsBite && RealimportantMeteorData_T)
            {
                /*�߿� ��� �־����� Ȯ��*/
                GameManager.gameManager._gameData.IsInputImportantMeteor1_T_C2 = true;
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

                //C-4 ��� ��� �١١١١١١١١١١١١١١١١١١١١�

                T_RealImportantMeteor.GetComponent<Rigidbody>().isKinematic = false; // ��迡�� ����� �Ѵ�.
                T_RealImportantMeteor.transform.parent = null;

                T_RealImportantMeteor.transform.position = new Vector3(-254.667f, 540.622f, 690.674f);

                Invoke("Report_Popup", 4f);

                //��ȣ�ۿ��� ���ش�.

                RealimportantMeteorData_T.IsNotInteractable = true; // ��ȣ�ۿ� �Ұ����ϰ�
                RealimportantMeteorOutline_T.OutlineWidth = 0;
            }
        }

        else if(RealNormalMeteor1Data_T.IsBite || RealimportantMeteorData_T.IsBite)
        {
            Debug.Log("��������");
        }
        
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        analyticalMachineButtonData_T.IsPushOrPress = false;
    }

    public void OnSniff()
    {
        analyticalMachineButtonData_T.IsSniff = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
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

        if (GameManager.gameManager._gameData.IsInputImportantMeteor1_T_C2 == true)
        {
            //GameManager.gameManager.IsyesImportantMeteor == true
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
    public void OnBite()
    {
       
    }

    public void OnEat()
    {
       
    }

    public void OnInsert()
    {
        
    }

    public void OnObserve()
    {
        
    }

    public void OnSmash()
    {

    }

    public void OnUp()
    {
      
    }
}
