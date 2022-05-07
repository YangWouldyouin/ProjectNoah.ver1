using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseGameManu : MonoBehaviour
{
    public GameObject pauseManu;
    public string projectList, mainScene;

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
    }
}
