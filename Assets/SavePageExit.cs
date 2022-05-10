using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavePageExit : MonoBehaviour
{
    public Canvas savePage;

    public void TurnOffSavePage()
    {
        savePage.gameObject.SetActive(false);
    }
}
