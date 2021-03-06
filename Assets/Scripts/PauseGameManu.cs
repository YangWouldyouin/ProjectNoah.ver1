using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseGameManu : MonoBehaviour
{
    public Canvas savePagePanel;
    public Canvas settingPanel;

    public CancelInteractions cancellnteractions;
    CancelInteractions cancellnteract;

    GameObject pauseManu, copyRightText;
    Image exitElert, mainElert;
    Button exitYesButton, exitNoButton, mainYesButton, mainNoButton;

    public InGameTime inGameTime;
    GameData gameData;

    private void Start()
    {
        cancellnteract = cancellnteractions.GetComponent<CancelInteractions>();
 
        pauseManu = GameObject.Find("Stop Game Canvas").transform.GetChild(0).gameObject;
        copyRightText = GameObject.Find("Stop Game Canvas").transform.GetChild(1).gameObject;
        exitElert = GameObject.Find("Stop Game Canvas").transform.GetChild(2).GetComponentInChildren<Image>();
        mainElert = GameObject.Find("Stop Game Canvas").transform.GetChild(3).GetComponentInChildren<Image>();

        mainYesButton = mainElert.transform.GetChild(2).GetComponentInChildren<Button>();
        mainNoButton = mainElert.transform.GetChild(3).GetComponentInChildren<Button>();
        mainYesButton.onClick.AddListener(OnMainYesButtonClicked);
        mainNoButton.onClick.AddListener(OnMainNoButtonClicked);

        exitYesButton = exitElert.transform.GetChild(2).GetComponentInChildren<Button>();
        exitNoButton = exitElert.transform.GetChild(3).GetComponentInChildren<Button>();

        exitYesButton.onClick.AddListener(OnExitYesButtonClicked);
        exitNoButton.onClick.AddListener(OnExitNoButtonClicked);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            pauseManu.SetActive(true);
            copyRightText.SetActive(true);
        }
    }
    public void GoToMain()
    {
        GameManager.gameManager._gameData.inGameTime = inGameTime.timer;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        mainElert.gameObject.SetActive(true);
    }

    void OnMainYesButtonClicked()
    {
        Time.timeScale = 1;
        cancellnteract.ResetPlayerEquipement();
        SceneManager.LoadScene("Main");
    }
    void OnMainNoButtonClicked()
    {
        mainElert.gameObject.SetActive(false);
    }

    public void GoToProjectList()
    {
        savePagePanel.gameObject.SetActive(true);
    }

    public void ExitGame()
    {
        exitElert.gameObject.SetActive(true);
    }

    public void OnExitYesButtonClicked()
    {
        GameManager.gameManager._gameData.inGameTime = inGameTime.timer;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        cancellnteract.ResetPlayerEquipement();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
    public void OnExitNoButtonClicked()
    {
        exitElert.gameObject.SetActive(false);
    }

    public void OnSettingButtonClicked()
    {
        settingPanel.gameObject.SetActive(true);
    }

    public void ResumeGame()
    {
        pauseManu.SetActive(false);
        copyRightText.SetActive(false);
        Time.timeScale = 1;
        //TimerManager.timerManager.TimerStart(3f);
        
        //dialogManager.StartCoroutine(dialogManager.PrintAIDialog(23));
        //dialogManager.StartCoroutine(dialogManager.PrintSubtitles(2));
    }
}
