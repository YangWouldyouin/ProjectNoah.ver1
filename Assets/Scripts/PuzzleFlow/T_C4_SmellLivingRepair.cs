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

        //TrashBT_fixPartData.IsNotInteractable = true; // 아예 Interactable 스크립트 자체를 제거할 것이므로 필요없어서 주석처리함 
        //TrashBTData.IsNotInteractable = true;

        // 마우스 오버시 아웃라인이 생기게 하는 것과 상호작용 버튼이 생기게 하는것 둘다 Interactable  스크립트에서 하기 때문에
        // 이 퍼즐 이후로 더 이상 상호작용이 일어나지 않는 오브젝트일 경우 Interactable 스크립트 컴포넌트를 아예 제거하면
        // 더 이상 상호작용 버튼과 외곽선이 생기지 않는다.
    }
}
