using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_AnalyticalMachinePlate : MonoBehaviour, IInteraction
{
    public GameObject Report_GUI;
    private bool IsReported = false;

    /*연관있는 오브젝트*/
    public GameObject T_RealNormalMeteor1;
    public GameObject T_RealImportantMeteor;
    public GameObject T_AreRubber;

    /*오브젝트의 상호작용 버튼들*/
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
            //고무판을 물고 일반 운석을 물면
            if (areRubberData_T.IsBite && RealNormalMeteor1Data_T.IsBite)
            {
                T_RealNormalMeteor1.GetComponent<Rigidbody>().isKinematic = false; // 모계에서 벗어나게 한다.
                T_RealNormalMeteor1.transform.parent = null;

                T_RealNormalMeteor1.transform.position = new Vector3(-254.667f, 540.622f, 690.674f);

                GameManager.gameManager._gameData.IsInputNormalMeteor1_T_C2 = true;
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

                Invoke("Report_Popup", 4f);

                //상호작용을 꺼준다.

                RealNormalMeteor1Data_T.IsNotInteractable = true; // 상호작용 불가능하게
                RealNormalMeteor1Outline_T.OutlineWidth = 0;
            }

            //고무판을 물고 특별한 운석을 물면
            if(areRubberData_T.IsBite && RealimportantMeteorData_T)
            {
                /*중요 운석을 넣었는지 확인*/
                GameManager.gameManager._gameData.IsInputImportantMeteor1_T_C2 = true;
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

                //C-4 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆

                T_RealImportantMeteor.GetComponent<Rigidbody>().isKinematic = false; // 모계에서 벗어나게 한다.
                T_RealImportantMeteor.transform.parent = null;

                T_RealImportantMeteor.transform.position = new Vector3(-254.667f, 540.622f, 690.674f);

                Invoke("Report_Popup", 4f);

                //상호작용을 꺼준다.

                RealimportantMeteorData_T.IsNotInteractable = true; // 상호작용 불가능하게
                RealimportantMeteorOutline_T.OutlineWidth = 0;
            }
        }

        else if(RealNormalMeteor1Data_T.IsBite || RealimportantMeteorData_T.IsBite)
        {
            Debug.Log("감염엔딩");
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
        //if 더미 데이터 다운 퍼즐이 완료되지 않았다면
        //보고하기 데이터 이동
        //else 더미 데이터 이동

        Debug.Log("보고하기");
        IsReported = true;
        Report_GUI.SetActive(false);

        if (GameManager.gameManager._gameData.IsInputImportantMeteor1_T_C2 == true)
        {
            //GameManager.gameManager.IsyesImportantMeteor == true
            Debug.Log("지구귀환엔딩");
        }
    }

    public void Cancle()
    {
        //if 더미 데이터 다운 퍼즐이 완료되지 않았다면
        //cancleCount += 1;

        Debug.Log("취소하기");
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
