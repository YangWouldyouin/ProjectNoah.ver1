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

    //박스가 존에 부딪히고
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Box")
        {
            //Debug.Log("충돌함");

            //불이 거짓이라면 대사를 출력하고, 대사 중복 재생 방지
            /*            if (!EnterCheck)
                        {
                            Debug.Log("박스 준비 완");

                            EnterCheck = true;
                        }*/


            Debug.Log("박스 준비 완");
            GoodBoxPosition = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Box")
        {
            GoodBoxPosition = false;

            Debug.Log("부딪히기 해제");
            //StorageButtonData.IsCenterButtonChanged = false;
            Target1Data.IsCollision = false;
            Target2Data.IsCollision = false;
            Target3Data.IsCollision = false;
            Target4Data.IsCollision = false;
            Target5Data.IsCollision = false;
        }
    }
}
