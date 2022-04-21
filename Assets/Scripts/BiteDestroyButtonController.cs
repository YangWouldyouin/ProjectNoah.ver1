using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BiteDestroyButtonController : MonoBehaviour
{
    public static BiteDestroyButtonController biteDestroyButtonController { get; private set; }

    ////public Animator playerAnimation;

    ////public Sprite biteButtonImage, biteButtonMouseOver, biteButtonClicked, destroyButtonMouseOver;

    ////public GameObject myMouth;

    ////public TMPro.TextMeshProUGUI biteObjectText;

    void Awake()
    {
        biteDestroyButtonController = this;
    }
}
