using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CantBoxClick : MonoBehaviour
{
    public GameObject Noah_Collider3D;

    //public GameObject CantClickBox;

    ObjData CantClickBoxData;
    public ObjectData IsCantClickBoxData;

    Outline CantClickBoxnOutline;
    public Outline IsCantClickBoxnOutline;

    /*Collider*/
    BoxCollider Box_Collider;
    BoxCollider Noah_Collider;

    // Start is called before the first frame update
    void Start()
    {
        /*Collider*/
        Box_Collider = GetComponent<BoxCollider>();
        Noah_Collider = Noah_Collider3D.GetComponent<BoxCollider>();

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
            Noah_Collider.enabled = false;
        }

        else
        {
            IsCantClickBoxData.IsNotInteractable = false; // 상호작용 가능하게
            IsCantClickBoxnOutline.OutlineWidth = 8;
            Box_Collider.enabled = true;
            Noah_Collider.enabled = true;
        }
    
    }
}
