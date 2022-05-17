using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavePageExit : MonoBehaviour
{
    public Canvas savePage;

    public Image open, load, projectList, settings, exit;

    public void TurnOffSavePage()
    {
        if(projectList!=null)
        {
            projectList.rectTransform.localScale = new Vector3(1f, 1f, 1f);
            load.fillAmount = 1;
            open.fillAmount = 1;
            settings.fillAmount = 1;
            exit.fillAmount = 1;
        }

        savePage.gameObject.SetActive(false);
    }
}
