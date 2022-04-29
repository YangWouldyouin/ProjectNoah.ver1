using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitializeObjects : MonoBehaviour
{
    public GameObject pipe, box, cardKey;

    //public static bool IsPipeInControlActive = false;
    //public static bool IsBoxInControlActive = false;
    //public static bool IsCardKeyInControlActive = false;

    //public static bool IsPipeInWorkActive;
    //public static bool IsBoxInWorkActive;
    //public static bool IsCardKeyInWorkActive;

    Scene currentScene;

    // Start is called before the first frame update
    void Start()
    {
        //if(currentScene.name == "new cockpit")
        //{
        //    if(IsPipeInControlActive)
        //    {
        //        pipe.SetActive(true);
        //    }
        //    else
        //    {
        //        pipe.SetActive(false);
        //    }

        //    if(IsBoxInControlActive)
        //    {
        //       box.SetActive(true);
        //    }
        //    else
        //    {
        //        box.SetActive(false);
        //    }

        //    if (IsCardKeyInControlActive)
        //    {
        //        cardKey.SetActive(true);
        //    }
        //    else
        //    {
        //        cardKey.SetActive(false);
        //    }
        //}
        //else if(currentScene.name == "new workroom")
        //{
        //    if (IsPipeInWorkActive)
        //    {
        //        pipe.SetActive(true);
        //    }
        //    else
        //    {
        //        pipe.SetActive(false);
        //    }

        //    if (IsBoxInWorkActive)
        //    {
        //        box.SetActive(true);
        //    }
        //    else
        //    {
        //        box.SetActive(false);
        //    }

        //    if (IsCardKeyInWorkActive)
        //    {
        //        cardKey.SetActive(true);
        //    }
        //    else
        //    {
        //        cardKey.SetActive(false);
        //    }
        //}
    }
}
