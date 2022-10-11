using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabletWirelessUIManager : MonoBehaviour
{
    public GameObject TW_MainUI;
    public GameObject TW_UploadSelectUI;
    public GameObject TW_UploadUI;
    public GameObject TW_alertUI;

    public Image TW_onoffBT;

    //public bool TW_WirelessOn = false;
    //public bool LieHealthData = false;
    //public bool FakeCoordinateData = false;
    //public bool FakeCoordinateDatafile = false;

    public Text OnOffText;
    public Text HealthReportText;
    public Text FakeCoordinateDataText;

    public Text TW_Alert_TitleText;
    public Text TW_Alert_BodyText;
    public Text TW_Alert_UploadText;

    public GameObject dialogManager_HM;
    DialogManager dialogManager;

    /* 소리 */
    AudioSource Download_Complete_Sound; // 업로드 완료
    public AudioClip Download_Complete; 

    AudioSource Connect_Complete_Sound;// 블루투스 연결 완료
    public AudioClip Connect_Complete;

    //public bool Is_Tablet_WirelessOn = false;
    //MC_BluetoothUIManager manager = new MC_BluetoothUIManager();

    // Start is called before the first frame update
    void Start()
    {
        Download_Complete_Sound = GetComponent<AudioSource>();
        Connect_Complete_Sound = GetComponent<AudioSource>();

        dialogManager = dialogManager_HM.GetComponent<DialogManager>();

        TW_MainUI.SetActive(true);
        TW_UploadSelectUI.SetActive(false);
        TW_UploadUI.SetActive(false);
        TW_alertUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameManager._gameData.Is_Tablet_WirelessOn)
        {
            OnOffText.GetComponent<Text>().text = "무선 연결        ON";
            Color onoffcolor = TW_onoffBT.color;
            onoffcolor.a = 1f;
            TW_onoffBT.color = onoffcolor;
            Connect_Complete_Sound.Play();
        }
        else
        {
            OnOffText.GetComponent<Text>().text = "무선 연결        OFF";
            Color onoffcolor = TW_onoffBT.color;
            onoffcolor.a = 0.3f;
            TW_onoffBT.color = onoffcolor;
        }

        /* 수정 필요 */
        if (GameManager.gameManager._gameData.IsFakeCoordinateData_Tablet )
        {
            if (GameManager.gameManager._gameData.IsDontFakeCoordinateDatafile_Tablet || GameManager.gameManager._gameData.IsFakeCoordinateDatafile_Tablet)
            {
                Color HRTcolor = FakeCoordinateDataText.color;
                HRTcolor.a = 0.3f;
                FakeCoordinateDataText.color = HRTcolor;
            }
            else
            {
                FakeCoordinateDataText.GetComponent<Text>().text = "귀환 좌표 데이터";

                Color FCDTcolor = FakeCoordinateDataText.color;
                FCDTcolor.a = 1f;
                FakeCoordinateDataText.color = FCDTcolor;
            }
        }
    }

    public void TW_WirelessCheck()
    {
        if (!GameManager.gameManager._gameData.Is_Tablet_WirelessOn)
        {
            GameManager.gameManager._gameData.Is_Tablet_WirelessOn = true;

            GameData tabletData = SaveSystem.Load("save_001");

            if (GameManager.gameManager._gameData.Is_Tablet_WirelessOn && GameManager.gameManager._gameData.Is_MainComputer_WirelessOn && !tabletData.IsWirelessMCTabletCheck )
            {
                GameManager.gameManager._gameData.IsWirelessMCTabletCheck = true;
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
                //메인 컴퓨터와 태블릿 신호 연결 끝 시점
                if(tabletData.ActiveMissionList[28])
                {
                    MissionGenerator.missionGenerator.DeleteNewMission(28);
                }
            }
        }
        else
        {
            GameManager.gameManager._gameData.Is_Tablet_WirelessOn = false;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        }
    }

    public void TW_SelectFile()
    {
        if (GameManager.gameManager._gameData.Is_Tablet_WirelessOn)
        {
            TW_MainUI.SetActive(false);
            TW_UploadSelectUI.SetActive(true);
        }
    }

    public void TW_ChangeUpload_HealthReport()
    {
        if(GameManager.gameManager._gameData.Is_Tablet_WirelessOn && GameManager.gameManager._gameData.Is_MainComputer_WirelessOn)
        {
            if (GameManager.gameManager._gameData.IsFakeHealthData_Tablet == false)
            {
                TW_UploadSelectUI.SetActive(false);
                TW_UploadUI.SetActive(true);

                Invoke("TW_Alert", 3f);
                TW_Alert_UploadText.GetComponent<Text>().text = "FileUploading " + 100 + " % ";
                TW_Alert_TitleText.GetComponent<Text>().text = "Complete!";
                TW_Alert_BodyText.GetComponent<Text>().text = "[메인컴퓨터]에 [체력 보고서]를 성공적으로 업로드했습니다.";
                Download_Complete_Sound.Play();

                GameManager.gameManager._gameData.IsFakeHealthData_Tablet = true;
                GameManager.gameManager._gameData.Is_Tablet_WirelessOn = false;
                GameManager.gameManager._gameData.Is_MainComputer_WirelessOn = false;
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

                Color HRTcolor = HealthReportText.color;
                HRTcolor.a = 0.3f;
                HealthReportText.color = HRTcolor;
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

                //더미데이터 보고(다운로드) 완료 시점
                MissionGenerator.missionGenerator.DeleteNewMission(29);
            }
        }
        else
        {
            TW_alertUI.SetActive(true);

            TW_Alert_TitleText.GetComponent<Text>().text = "Warning!";
            TW_Alert_BodyText.GetComponent<Text>().text = "연결된 기기가 없습니다." + "\n" + "연결 가능 기기: 메인 컴퓨터, 메인 시스템";

            Invoke("TW_Alert_onetime", 2f);
        }
    }

    public void TW_ChangeUpload_FakeCoordinateData()
    {
        GameData gameData = SaveSystem.Load("save_001");

        if (GameManager.gameManager._gameData.IsFakeCoordinateData_Tablet == true)
        {
            if (GameManager.gameManager._gameData.Is_Tablet_WirelessOn && GameManager.gameManager._gameData.Is_MainComputer_WirelessOn)
            {
                if (gameData.IsCanConnect_C_MS == false)
                {
                    if (GameManager.gameManager._gameData.IsFakeCoordinateDatafile_Tablet == false)
                    {
                        TW_UploadSelectUI.SetActive(false);
                        TW_UploadUI.SetActive(true);

                        Invoke("TW_Alert", 3f);
                        TW_Alert_UploadText.GetComponent<Text>().text = "FileUploading " + 100 + " % ";
                        TW_Alert_TitleText.GetComponent<Text>().text = "Complete!";
                        TW_Alert_BodyText.GetComponent<Text>().text = "[메인컴퓨터]에 [귀환 좌표 데이터]를 성공적으로 업로드했습니다.";
                        Download_Complete_Sound.Play();

                        GameManager.gameManager._gameData.Is_Tablet_WirelessOn = false;
                        GameManager.gameManager._gameData.Is_MainComputer_WirelessOn = false;
                        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

                        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(39));
                        GameManager.gameManager._gameData.IsDontFakeCoordinateDatafile_Tablet = true;
                        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

                        Color FCDTcolor = FakeCoordinateDataText.color;
                        FCDTcolor.a = 0.3f;
                        FakeCoordinateDataText.color = FCDTcolor;
                    }
                }
            }
            else if (GameManager.gameManager._gameData.Is_Tablet_WirelessOn && gameData.Is_MainSystem_WirelessOn)
            {
                if (gameData.IsCanConnect_C_MS)
                {
                    if (GameManager.gameManager._gameData.IsFakeCoordinateDatafile_Tablet == false && GameManager.gameManager._gameData.IsDontFakeCoordinateDatafile_Tablet == false)
                    {
                        TW_UploadSelectUI.SetActive(false);
                        TW_UploadUI.SetActive(true);

                        Invoke("TW_Alert", 3f);
                        TW_Alert_UploadText.GetComponent<Text>().text = "FileUploading " + 100 + " % ";
                        TW_Alert_TitleText.GetComponent<Text>().text = "Complete!";
                        TW_Alert_BodyText.GetComponent<Text>().text = "[메인시스템]에 [귀환 좌표 데이터]를 성공적으로 업로드했습니다.";
                        Download_Complete_Sound.Play();

                        GameManager.gameManager._gameData.Is_Tablet_WirelessOn = false;
                        GameManager.gameManager._gameData.Is_MainSystem_WirelessOn = false;
                        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

                        GameManager.gameManager._gameData.IsFakeCoordinateDatafile_Tablet = true;
                        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");


                        //if (GameManager.gameManager._gameData.IsRevisioncomplaint)
                        //{
                        //    GameManager.gameManager._gameData.IsReturnOfTheEarth = true;
                        //}

                        Color FCDTcolor = FakeCoordinateDataText.color;
                        FCDTcolor.a = 0.3f;
                        FakeCoordinateDataText.color = FCDTcolor;
                    }

                }
            }
            else
            {
                if (GameManager.gameManager._gameData.IsFakeCoordinateDatafile_Tablet == false)
                {
                    TW_alertUI.SetActive(true);

                    TW_Alert_TitleText.GetComponent<Text>().text = "Warning!";
                    TW_Alert_BodyText.GetComponent<Text>().text = "연결된 기기가 없습니다." + "\n" + "연결 가능 기기: 메인 컴퓨터, 메인 시스템";

                    Invoke("TW_Alert_onetime", 3f);
                }
                else if (GameManager.gameManager._gameData.Is_Tablet_WirelessOn && gameData.Is_MainSystem_WirelessOn && gameData.IsCanConnect_C_MS )
                {
                    TW_alertUI.SetActive(true);

                    TW_Alert_TitleText.GetComponent<Text>().text = "Warning!";
                    TW_Alert_BodyText.GetComponent<Text>().text = "연결된 기기가 없습니다." + "\n" + "연결 가능 기기: 메인 컴퓨터, 메인 시스템";

                    Invoke("TW_Alert_onetime", 3f);
                }
            }
        }
    }

    public void TW_Alert()
    {
        TW_alertUI.SetActive(true);

        Invoke("TW_Change_MainUI", 3f);
    }

    public void TW_Alert_onetime()
    {
        TW_alertUI.SetActive(false);
    }

    public void TW_Change_MainUI()
    {
        TW_alertUI.SetActive(false);
        TW_UploadUI.SetActive(false);
        TW_UploadSelectUI.SetActive(false);
        TW_MainUI.SetActive(true);
    }
}