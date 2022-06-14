using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainButtonController : MonoBehaviour
{
    public Canvas savePagePanel;

    public Canvas settingPanel;
    public InGameTime inGameTime;

    Image open, load, projectList, settings, exit;
    AudioSource audios;
    GameData gameData;
    float i = 12;


    private void Start()
    {
        i = 12;
        gameData = SaveSystem.Load("save_001");
        open = transform.GetChild(1).GetComponentInChildren<Image>();
        load = transform.GetChild(2).GetComponentInChildren<Image>();
        projectList = transform.GetChild(3).GetComponentInChildren<Image>();
        settings = transform.GetChild(4).GetComponentInChildren<Image>();
        exit = transform.GetChild(5).GetComponentInChildren<Image>();
        audios = GetComponent<AudioSource>();
    }

    public void OnSettingButtonClicked()
    {
        StartCoroutine(GoToSetting());
    }

    IEnumerator GoToSetting()
    {
        while (i >= 0)
        {
            i -= 1;
            settings.rectTransform.localScale += new Vector3(0.02f, 0.02f, 0.02f);
            load.fillAmount = i / 12;
            exit.fillAmount = i / 12;
            projectList.fillAmount = i / 12;
            open.fillAmount = i / 12;
            yield return new WaitForSeconds(0.02f);
        }
        i = 12;
        yield return new WaitForSeconds(0.5f);
        settingPanel.gameObject.SetActive(true);
    }



    IEnumerator GoToTutorial()
    {
        while (i >= 0)
        {
            i -= 1;
            open.rectTransform.localScale += new Vector3(0.02f, 0.02f, 0.02f);
            load.fillAmount = i / 12;
            projectList.fillAmount = i / 12;
            settings.fillAmount = i / 12;
            exit.fillAmount = i / 12;
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(0.02f);

        SceneManager.LoadScene("Tutorial");
    }

    IEnumerator GoToNewCockpit()
    {
        while (i >= 0)
        {
            i -= 1;
            open.rectTransform.localScale += new Vector3(0.02f, 0.02f, 0.02f);
            load.fillAmount = i / 12;
            projectList.fillAmount = i / 12;
            settings.fillAmount = i / 12;
            exit.fillAmount = i / 12;
            yield return new WaitForSeconds(0.02f);
        }

        // 타이머에 이전 시간 넣음
        inGameTime.timer = gameData.inGameTime;

        yield return new WaitForSeconds(0.5f);
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

        StartCoroutine(ProjectList());
    }

    IEnumerator ProjectList()
    {
        while (i >= 0)
        {
            i -= 1;
            projectList.rectTransform.localScale += new Vector3(0.02f, 0.02f, 0.02f);
            load.fillAmount = i / 12;
            exit.fillAmount = i / 12;
            settings.fillAmount = i / 12;
            open.fillAmount = i / 12;
            yield return new WaitForSeconds(0.02f);
        }
        i = 12;
        yield return new WaitForSeconds(0.5f);
        savePagePanel.gameObject.SetActive(true);
    }
    public void OnExitButtonClicked()
    {
        StartCoroutine(GoExit());
    }

    IEnumerator GoExit()
    {
        while (i >= 0)
        {
            i -= 1;
            exit.rectTransform.localScale += new Vector3(0.02f, 0.02f, 0.02f);
            load.fillAmount = i / 12;
            projectList.fillAmount = i / 12;
            settings.fillAmount = i / 12;
            open.fillAmount = i / 12;
            yield return new WaitForSeconds(0.02f);
        }

        // 종료전 마지막 시간 넣음
        GameManager.gameManager._gameData.inGameTime = inGameTime.timer;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        yield return new WaitForSeconds(0.5f);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();

    }
}
