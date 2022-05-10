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
        if (IDConsoleForBox.IsClicked && GoodBoxPosition)
        {
            IDConsoleForBox.IsCenterButtonChanged = true;

            if (IDConsoleForBox.IsObserve)
            {
                IDConsoleForBox.IsClicked = false;
            }
            
        }

        else
        {
            IDConsoleForBox.IsCenterButtonChanged = false;
        }

        /*if (GoodBoxPosition = true && boxData.IsUpDown && EnterCheck)
        {
            //GoodBoxPosition = false;
            //IMReady = true;

            //Debug.Log("�����ϱ� �غ� �Ϸ�");
            IDConsoleForBox.IsCenterButtonChanged = true;

            EnterCheck = false;
        }

        /*�����ϱ� �׻� ����*/
        /*if (IMReady == true)
        {
            Debug.Log("�����ϱ� �غ� �Ϸ�");
            IDConsoleForBox.IsCenterButtonChanged = true;
        }

        else
        {
            //Debug.Log("�����ư ��ȣ�ۿ� �Ұ����ؿ�");
            IDConsoleForBox.IsCenterButtonChanged = false;
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == box)
        {
            Debug.Log("�ڽ� �غ� ��");
            dialogManager.StartCoroutine(dialogManager.PrintSubtitles(17));

            //EnterCheck = true;

            GoodBoxPosition = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == box)
        {
            GoodBoxPosition = false;
        }
    }
}
