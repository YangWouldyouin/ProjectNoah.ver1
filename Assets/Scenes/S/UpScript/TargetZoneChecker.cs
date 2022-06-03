using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetZoneChecker : MonoBehaviour
{
    public bool GoodBoxPosition = false;
    //public bool IMReady = false;
    //public bool EnterCheck;

    public GameObject box;

    public ObjectData boxData1;
    public ObjectData TargetData;

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
            TargetData.IsCollision = true;
        }

      else  if (!boxData1.IsUpDown)
        {
            TargetData.IsCollision = false;
            //StorageButtonData.IsCenterButtonChanged = false;
            //IDConsoleForBox.IsCenterButtonDisabled = false;
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


            //Debug.Log("�ڽ� �غ� ��");
            GoodBoxPosition = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Box")
        {
            GoodBoxPosition = false;

            //Debug.Log("�ε����� ����");
            //StorageButtonData.IsCenterButtonChanged = false;
            TargetData.IsCollision = false;
        }
    }
}
