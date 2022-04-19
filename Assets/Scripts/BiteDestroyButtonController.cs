using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BiteDestroyButtonController : MonoBehaviour
{ 
    public static BiteDestroyButtonController biteDestroyButtonController { get; private set; }

    public Animator playerAnimation;

    [SerializeField] float requiredHoldTime = 1f;
    [SerializeField] float requiredChangeTime = 0.5f;
    float pointerDownTimer = 0;

    //public Button biteDestroyButton; // PlayerScripts - MovePlayer ���� ��ư �̹��� BiteButtonImage �� �ٲ�
    public Sprite biteButtonImage, biteButtonMouseOver, biteButtonClicked, destroyButtonMouseOver;

    public GameObject myMouth;

    public TMPro.TextMeshProUGUI biteObjectText;

    void Awake()
    {
        biteDestroyButtonController = this;
    }
}
