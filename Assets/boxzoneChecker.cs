using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxzoneChecker : MonoBehaviour
{
    public bool GoodBoxPosition = false;
    public bool IMReady = false;
    public bool EnterCheck;

    public GameObject box;

    public ObjectData boxData;
    public ObjectData IDConsoleForBox;

    public GameObject dialog;
    DialogManager dialogManager;

    // Start is called before the first frame update
    void Start()
    {
        dialogManager = dialog.GetComponent<DialogManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!boxData.IsUpDown)
        {
            IDConsoleForBox.IsCenterButtonChanged = false;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Box_Tuto")
        {
            Debug.Log("충돌함");


            if (!EnterCheck)
            {
                dialogManager.StartCoroutine(dialogManager.PrintSubtitles(17));
                Debug.Log("박스 준비 완");

                EnterCheck = true;
            }


            GoodBoxPosition = true;


            if (boxData.IsUpDown)
            {
                IDConsoleForBox.IsCenterButtonChanged = true;
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Box_Tuto")
        {
            GoodBoxPosition = false;

            IDConsoleForBox.IsCenterButtonChanged = false;
        }
    }
}
