using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPageExit : MonoBehaviour
{
    public Canvas settingPage;

    public Image open, load, projectList, settings, exit;

    public void TurnOffSavePage()
    {
        if (settings != null)
        {
            settings.rectTransform.localScale = new Vector3(1f, 1f, 1f);
            load.fillAmount = 1;
            open.fillAmount = 1;
            projectList.fillAmount = 1;
            exit.fillAmount = 1;
        }

        settingPage.gameObject.SetActive(false);
    }
}
