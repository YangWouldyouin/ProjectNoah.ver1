using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxzoneChecker : MonoBehaviour
{
    public bool GoodBoxPosition = false;
    public bool IMReady = false;
    public bool EnterCheck;

    public GameObject box;

    public ObjectData boxData1;
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
        if (boxData1.IsUpDown && GoodBoxPosition)
        {
            //Debug.Log("�ڽ��� �غ�ư� �ö� �����ϴ�~");
            IDConsoleForBox.IsCenterButtonChanged = true;
            //IDConsoleForBox.IsCenterButtonDisabled = true;
        }

      else  if (!boxData1.IsUpDown)
        {
            IDConsoleForBox.IsCenterButtonChanged = false;
            //IDConsoleForBox.IsCenterButtonDisabled = false;
        }
    }

    //�ڽ��� ���� �ε�����
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Box_Tuto")
        {
            //Debug.Log("�浹��");

            //���� �����̶�� ��縦 ����ϰ�, ��� �ߺ� ��� ����
            if (!EnterCheck)
            {
                dialogManager.StartCoroutine(dialogManager.PrintSubtitles(17));
                Debug.Log("�ڽ� �غ� ��");

                EnterCheck = true;
            }


            GoodBoxPosition = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Box_Tuto")
        {
            GoodBoxPosition = false;

            Debug.Log("�ε����� ����");
            IDConsoleForBox.IsCenterButtonChanged = false;
        }
    }
}
