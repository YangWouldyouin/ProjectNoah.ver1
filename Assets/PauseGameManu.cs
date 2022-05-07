using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseGameManu : MonoBehaviour
{
    public GameObject pauseManu;
    public string projectList, mainScene;
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
            pauseManu.SetActive(true);
        }
    }
    public void GoToMain()
    {
        SceneManager.LoadScene(mainScene);
    }

    public void GoToProjectList()
    {
        SceneManager.LoadScene(projectList);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ResumeGame()
    {
        pauseManu.SetActive(false);
        //dialogManager.StartCoroutine(dialogManager.PrintAIDialog(23));
        dialogManager.StartCoroutine(dialogManager.PrintSubtitles(1));
    }
}
