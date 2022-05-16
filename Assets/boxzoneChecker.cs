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
            //Debug.Log("박스도 준비됐고 올라도 갔습니다~");
            IDConsoleForBox.IsCenterButtonChanged = true;
            //IDConsoleForBox.IsCenterButtonDisabled = true;
        }

      else  if (!boxData1.IsUpDown)
        {
            IDConsoleForBox.IsCenterButtonChanged = false;
            //IDConsoleForBox.IsCenterButtonDisabled = false;
        }
    }

    //박스가 존에 부딪히고
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Box_Tuto")
        {
            //Debug.Log("충돌함");

            //불이 거짓이라면 대사를 출력하고, 대사 중복 재생 방지
            if (!EnterCheck)
            {
                dialogManager.StartCoroutine(dialogManager.PrintSubtitles(17));
                Debug.Log("박스 준비 완");

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

            Debug.Log("부딪히기 해제");
            IDConsoleForBox.IsCenterButtonChanged = false;
        }
    }
}
