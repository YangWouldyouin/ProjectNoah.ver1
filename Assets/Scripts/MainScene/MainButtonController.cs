using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainButtonController : MonoBehaviour
{

    string lastScene = "new cockpit";
    string SavePage = "SavePage";
    public void OnOpenButtonClicked()
    {
        StartCoroutine("GoToLastScene");
    }

    public void OnProjectListButtonClicked()
    {
        StartCoroutine("GoToProjectListScene");
    }

    IEnumerator GoToLastScene()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(lastScene);
    }

    IEnumerator GoToProjectListScene()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("SavePage");
    }
}
