using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevisionComplaintUIManager : MonoBehaviour
{
    public GameObject RC_GUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.gameManager._gameData.IsFinalBusinessReportFile_MC && GameManager.gameManager._gameData.IsReturnOfTheEarth)
        {
            Invoke("seconds3time", 3f);
        }
    }

    public void seconds3time()
    {
        RC_GUI.SetActive(true);
    }

    public void OnReportBT()
    {
        GameManager.gameManager._gameData.IsRevisioncomplaint = true;
        RC_GUI.SetActive(false);
    }

    public void OnCancleBT()
    {
        RC_GUI.SetActive(false);
    }
}
