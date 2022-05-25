using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageZoneChecker : MonoBehaviour
{
    public bool GoodBoxPosition = false;
    //public bool IMReady = false;
    //public bool EnterCheck;

    public GameObject box;

    public ObjectData boxData1;
    public ObjectData Target1Data;
    public ObjectData Target2Data;
    public ObjectData Target3Data;
    public ObjectData Target4Data;
    public ObjectData Target5Data;

    /*    public GameObject dialog;
        DialogManager dialogManager;*/

    // Start is called before the first frame update
    void Start()
    {
        //dialogManager = dialog.GetComponent<DialogManager>();
    }

    // Update is called once per frame
    void Update()
    {
       if (boxData1.IsUpDown && GoodBoxPosition)
        {
            Target1Data.IsCollision = true;
            Target2Data.IsCollision = true;
            Target3Data.IsCollision = true;
            Target4Data.IsCollision = true;
            Target5Data.IsCollision = true;
        }

      else  if (!boxData1.IsUpDown)
        {
            Target1Data.IsCollision = false;
            //StorageButtonData.IsCenterButtonChanged = false;
            //IDConsoleForBox.IsCenterButtonDisabled = false;
            Target2Data.IsCollision = false;
            Target3Data.IsCollision = false;
            Target4Data.IsCollision = false;
            Target5Data.IsCollision = false;
        }
    }

    //�ڽ��� ���� �ε�����
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Box")
        {
            //Debug.Log("�浹��");

            //���� �����̶�� ��縦 ����ϰ�, ��� �ߺ� ��� ����
            /*            if (!EnterCheck)
                        {
                            Debug.Log("�ڽ� �غ� ��");

                            EnterCheck = true;
                        }*/


            Debug.Log("�ڽ� �غ� ��");
            GoodBoxPosition = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Box")
        {
            GoodBoxPosition = false;

            Debug.Log("�ε����� ����");
            //StorageButtonData.IsCenterButtonChanged = false;
            Target1Data.IsCollision = false;
            Target2Data.IsCollision = false;
            Target3Data.IsCollision = false;
            Target4Data.IsCollision = false;
            Target5Data.IsCollision = false;
        }
    }
}
