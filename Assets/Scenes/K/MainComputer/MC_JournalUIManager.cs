using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MC_JournalUIManager : MonoBehaviour
{
    public GameObject TW_MainUI;
    public GameObject TW_UploadSelectUI;
    public GameObject TW_UploadUI;
    public GameObject TW_alertUI;

    public Image TW_onoffBT;

    public bool TW_WirelessOn = false;
    public bool LieHealthData = false;
    public bool FakeCoordinateData = false;
    public bool FakeCoordinateDatafile = false;

    public Text OnOffText;
    public Text HealthReportText;
    public Text FakeCoordinateDataText;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
