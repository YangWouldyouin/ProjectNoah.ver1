using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseGameManu : MonoBehaviour
{
    public GameObject pauseManu;
    public Canvas savePagePanel;

    public GameObject dialogManager_CC;
    DialogManager dialogManager;


    private void Start()
    {
        dialogManager = dialogManager_CC.GetComponent<DialogManager>();
        
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            pauseManu.SetActive(true);
        }
    }
    public void GoToMain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main");
    }

    public void GoToProjectList()
    {
        savePagePanel.gameObject.SetActive(true);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void ResumeGame()
    {
        pauseManu.SetActive(false);
        Time.timeScale = 1;
        TimerManager.timerManager.TimerStart(3f);
        
        //dialogManager.StartCoroutine(dialogManager.PrintAIDialog(23));
        dialogManager.StartCoroutine(dialogManager.PrintSubtitles(1));
    }
}
