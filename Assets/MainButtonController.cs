using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainButtonController : MonoBehaviour
{
    public Canvas savePagePanel;

    IEnumerator GoToScene()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Tutorial");
    }

    public void OnOpenButtonClicked()
    {
        StartCoroutine(GoToScene());
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
