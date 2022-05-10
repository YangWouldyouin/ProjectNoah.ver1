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

        /*�����ϱ� �׻� ����*/
        if (IMReady == true)
        {
            Debug.Log("�����ϱ� �غ� �Ϸ�");
            IDConsoleForBox.IsCenterButtonChanged = true;
        }

        else
        {
            Debug.Log("�����ư ��ȣ�ۿ� �Ұ����ؿ�");
            IDConsoleForBox.IsCenterButtonChanged = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == box)
        {
            Debug.Log("�ڽ� �غ� ��");
            dialogManager.StartCoroutine(dialogManager.PrintSubtitles(17));

            GoodBoxPosition = true;
        }
    }
}
