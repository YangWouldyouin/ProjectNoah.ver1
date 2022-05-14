using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CantBoxClick : MonoBehaviour
{
    //public GameObject CantClickBox;

    ObjData CantClickBoxData;
    public ObjectData IsCantClickBoxData;

    Outline CantClickBoxnOutline;
    public Outline IsCantClickBoxnOutline;

    /*Collider*/
    BoxCollider Box_Collider;

    // Start is called before the first frame update
    void Start()
    {
        /*Collider*/
        Box_Collider = GetComponent<BoxCollider>();

        CantClickBoxData = GetComponent<ObjData>();

        CantClickBoxnOutline = GetComponent<Outline>();
    }

    // Update is called once per frame
    void Update()
    {
        if(IsCantClickBoxData.IsUpDown)
        {
            IsCantClickBoxData.IsNotInteractable = true; // 상호작용 가능하게
            IsCantClickBoxnOutline.OutlineWidth = 0;
            Box_Collider.enabled = false;
        }

        else
        {
            IsCantClickBoxData.IsNotInteractable = false; // 상호작용 가능하게
            IsCantClickBoxnOutline.OutlineWidth = 8;
            Box_Collider.enabled = true;
        }
    
    }
}
