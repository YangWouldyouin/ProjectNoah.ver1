using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CantBoxClick : MonoBehaviour
{
    public GameObject CantClickBox;

    ObjData CantClickBoxData;

    Outline CantClickBoxnOutline;

    /*Collider*/
    BoxCollider Box_Collider;

    // Start is called before the first frame update
    void Start()
    {
        /*Collider*/
        Box_Collider = GetComponent<BoxCollider>();

        CantClickBoxData = CantClickBox.GetComponent<ObjData>();

        CantClickBoxnOutline = CantClickBox.GetComponent<Outline>();
    }

    // Update is called once per frame
    void Update()
    {
        if(CantClickBoxData.IsUpDown)
        {
            CantClickBoxData.IsNotInteractable = true; // 상호작용 가능하게
            CantClickBoxnOutline.OutlineWidth = 0;
            Box_Collider.isTrigger = false;
        }

        else
        {
            CantClickBoxData.IsNotInteractable = false; // 상호작용 가능하게
            CantClickBoxnOutline.OutlineWidth = 8;
            Box_Collider.isTrigger = true;
        }
    
    }
}
