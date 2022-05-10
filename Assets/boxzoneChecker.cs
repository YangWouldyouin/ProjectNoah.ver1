using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxzoneChecker : MonoBehaviour
{
    public bool GoodBoxPosition = false;
    public bool IMReady = false;

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
        if (GoodBoxPosition = true && boxData.IsUpDown)
        {
            GoodBoxPosition = false;
            IMReady = true;
        }

        /*관찰하기 항상 가능*/
        if (IMReady == true)
        {
            Debug.Log("관찰하기 준비 완료");
            IDConsoleForBox.IsCenterButtonChanged = true;
        }

        else
        {
            Debug.Log("가운데버튼 상호작용 불가능해요");
            IDConsoleForBox.IsCenterButtonChanged = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == box)
        {
            Debug.Log("박스 준비 완");
            dialogManager.StartCoroutine(dialogManager.PrintSubtitles(17));

            GoodBoxPosition = true;
        }
    }
}
