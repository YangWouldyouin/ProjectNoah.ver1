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
            noahOutline.OutlineWidth = 10.0f;
            StartCoroutine(StartOutlineTimer(outlineTime.outlineTimer));
        }
    }

    public void StartOutlineTime(float outlineSeconds)
    {
        noahOutline.OutlineWidth = 10.0f;
        outlineTime.IsNoahOutlineTurnOn = true;
        outlineTime.outlineTimer = outlineSeconds;
        StartCoroutine(StartOutlineTimer(outlineTime.outlineTimer));
    }

    IEnumerator StartOutlineTimer(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Debug.Log("ÀÌÁ¦ ¸ø ¼ûÀ½");
        noahOutline.OutlineWidth = 0.0f;
        outlineTime.IsNoahOutlineTurnOn = false;

        GameManager.gameManager._gameData.IsHide = false;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        //Destroy(gameObject, 0.5f);

        dialog.StartCoroutine(dialogManager.PrintAIDialog(52));
    }
}
