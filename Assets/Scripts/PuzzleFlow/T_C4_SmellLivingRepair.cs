using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_C4_SmellLivingRepair : MonoBehaviour
{
    private GameObject nowObject_T_C4_SmellLivingRepair;

    public static bool IsTrashDoorDone = false;

    public GameObject TrashBT;
    public GameObject TrashBT_fixPart;

    // Start is called before the first frame update
    void Start()
    {
        //AI: 부품 수리 스크립트
    }

    // Update is called once per frame
    void Update()
    {
        nowObject_T_C4_SmellLivingRepair = PlayerScripts.playerscripts.currentObject;

        if (nowObject_T_C4_SmellLivingRepair != null)
        {
            if (IsTrashDoorDone)
            {
                Invoke("TrashBTDone", 1.5f);
            }
            else
            {
                TrashBT_fixPart_Putting();
            }
        }
    }

    public void TrashBT_fixPart_Putting()
    {
        ObjData TrashBTData = TrashBT.GetComponent<ObjData>();
        ObjData TrashBT_fixPartData = TrashBT_fixPart.GetComponent<ObjData>();
        if (TrashBTData.IsPushOrPress && TrashBT_fixPartData.IsBite)
        {
            IsTrashDoorDone = true;
        }
    }

    public void TrashBTDone()
    {
        ObjData TrashBTData = TrashBT.GetComponent<ObjData>();
        ObjData TrashBT_fixPartData = TrashBT_fixPart.GetComponent<ObjData>();


        //물고 있는 fitPart 물기 해제 -> bool false
        TrashBT_fixPartData.IsBite = false;

        TrashBT_fixPartData.GetComponent<Rigidbody>().isKinematic = false;
        TrashBT_fixPartData.transform.parent = null;

        //fitPart 위치 HM에 자동 장착
        TrashBT_fixPartData.transform.position = new Vector3(-27.279f, 1.182999f, 35.614f);
        TrashBT_fixPartData.transform.rotation = Quaternion.Euler(0, -90, 0);

        //한 번 물기 하면 더이상 fitPart 상호작용 불가 오브젝트로 변경 -> interaction 스크립트 끄기
        TrashBT_fixPartData.IsNotInteractable = true;
        TrashBTData.IsNotInteractable = true;
    }
}
