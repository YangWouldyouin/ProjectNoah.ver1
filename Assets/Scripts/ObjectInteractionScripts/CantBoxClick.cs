using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CantBoxClick : MonoBehaviour
{
    public GameObject CantClickBox;

    ObjData CantClickBoxData;

    Outline CantClickBoxnOutline;

    // Start is called before the first frame update
    void Start()
    {
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
        }

        else
        {
            CantClickBoxData.IsNotInteractable = false; // 상호작용 가능하게
            CantClickBoxnOutline.OutlineWidth = 8;
        }
    
    }
}
