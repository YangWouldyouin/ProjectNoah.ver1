using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainButtonController : MonoBehaviour
{
    public Canvas savePagePanel;
    GameData gameData;

    private void Start()
    {
        gameData = SaveSystem.Load("save_001");
    }

    IEnumerator GoToTutorial()
    {
        yield return null;
        SceneManager.LoadScene("Tutorial");
    }

    IEnumerator GoToNewCockpit()
    {
        yield return null;
        SceneManager.LoadScene("new cockpit");
    }



    public void OnOpenButtonClicked()
    {

        if(gameData.IsTutorialClear)
        {
            StartCoroutine(GoToNewCockpit());
        }
        else
        {
            StartCoroutine(GoToTutorial());
        }
    }

    public void OnProjectButtonClicked()
    {
        savePagePanel.gameObject.SetActive(true);
    }

    public void OnExitButtonClicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
