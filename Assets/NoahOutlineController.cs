using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoahOutlineController : MonoBehaviour
{
    public DialogManager dialogManager;
    DialogManager dialog;
    public InGameTime outlineTime;
    Outline noahOutline;


    void Start()
    {
        dialog = dialogManager.GetComponent<DialogManager>();
        noahOutline = GetComponent<Outline>();

        if(outlineTime.IsNoahOutlineTurnOn)
        {
            if (!outlineTime.IsNoSeeFail1)
            {
                noahOutline.OutlineWidth = 10.0f;
                StartCoroutine(StartOutlineTimer(outlineTime.outlineTimer, outlineTime.IsNoSeeFail1));
            }

            if(!outlineTime.IsNoSeeFail2)
            {
                noahOutline.OutlineWidth = 10.0f;
                StartCoroutine(StartOutlineTimer(outlineTime.outlineTimer, outlineTime.IsNoSeeFail2));
            }

            if (!outlineTime.IsPretendDeadFail1)
            {
                noahOutline.OutlineWidth = 10.0f;
                StartCoroutine(StartOutlineTimer(outlineTime.outlineTimer, outlineTime.IsPretendDeadFail1));
            }
        }
    }

    public void StartOutlineTime(float outlineSeconds, bool IsFinished)
    {
        if(!IsFinished)
        {
            noahOutline.OutlineWidth = 10.0f;
            outlineTime.IsNoahOutlineTurnOn = true;
            outlineTime.outlineTimer = outlineSeconds;
            StartCoroutine(StartOutlineTimer(outlineTime.outlineTimer, IsFinished));
        }
    }

    IEnumerator StartOutlineTimer(float seconds, bool IsFinished)
    {
        while (outlineTime.outlineTimer >= 0 && outlineTime.IsNoahOutlineTurnOn)
        {
            yield return new WaitForSeconds(1f);
            outlineTime.outlineTimer -= 1f;
        }
        IsFinished = true;
        Debug.Log("ÀÌÁ¦ ¸ø ¼ûÀ½");
        noahOutline.OutlineWidth = 0.0f;
        outlineTime.IsNoahOutlineTurnOn = false;

        GameManager.gameManager._gameData.IsHide = false;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        dialog.StartCoroutine(dialogManager.PrintAIDialog(52));
    }


}
