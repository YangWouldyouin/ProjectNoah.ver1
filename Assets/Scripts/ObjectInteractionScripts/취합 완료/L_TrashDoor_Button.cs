using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_TrashDoor_Button : MonoBehaviour
{

    public GameObject trashDoorButton_TB;
    public GameObject trashDoorButtonFixpart_TB;

    ObjData trashDoorButtonData_TB;
    ObjData trashDoorButtonFixpartData_TB;

    Interactable TrashBT_Interactable;
    Interactable TrashBT_fixPartInteractable;

    // Start is called before the first frame update
    void Start()
    {
        if (!GameManager.gameManager.IsTrashDoorFixed_L_L1)
        {
            // 플로우차트 처음 시작 때 넣고 싶은 연출들을 넣는다.  
        }

        /* (필수) 각 오브젝트로부터 Objdata 컴포넌트를 받아와서 변수에 넣는다.*/
        trashDoorButtonData_TB = trashDoorButton_TB.GetComponent<ObjData>();
        trashDoorButtonFixpartData_TB = trashDoorButtonFixpart_TB.GetComponent<ObjData>();

        TrashBT_Interactable = trashDoorButton_TB.GetComponent<Interactable>();
        TrashBT_fixPartInteractable = trashDoorButtonFixpart_TB.GetComponent<Interactable>();

    }

    // Update is called once per frame
    void Update()
    {
        if (trashDoorButtonData_TB.IsPushOrPress && trashDoorButtonFixpartData_TB.IsBite)
        {
            Invoke("TrashBTDone", 1.5f);
        }
    }

    public void TrashBTDone()
    {
        trashDoorButtonFixpartData_TB.GetComponent<Rigidbody>().isKinematic = false;
        trashDoorButtonFixpartData_TB.transform.parent = null;

        //fitPart 위치 HM에 자동 장착
        trashDoorButtonFixpartData_TB.transform.position = new Vector3(-27.253f, 1.844f, 35.729f);
        trashDoorButtonFixpartData_TB.transform.rotation = Quaternion.Euler(0, -90, 0);

        //한 번 물기 하면 더이상 fitPart 상호작용 불가 오브젝트로 변경 -> interaction 스크립트 끄기

        //TrashBT_fixPartData.IsNotInteractable = true; // 아예 Interactable 스크립트 자체를 제거할 것이므로 필요없어서 주석처리함 
        //TrashBTData.IsNotInteractable = true;

        //물고 있는 fitPart 물기 해제 -> bool false
        trashDoorButtonFixpartData_TB.IsBite = false;

        // 마우스 오버시 아웃라인이 생기게 하는 것과 상호작용 버튼이 생기게 하는것 둘다 Interactable  스크립트에서 하기 때문에
        // 이 퍼즐 이후로 더 이상 상호작용이 일어나지 않는 오브젝트일 경우 Interactable 스크립트 컴포넌트를 아예 제거하면
        // 더 이상 상호작용 버튼과 외곽선이 생기지 않는다.
        Destroy(TrashBT_Interactable);
        Destroy(TrashBT_fixPartInteractable);

        GameManager.gameManager.IsTrashDoorFixed_L_L1 = true;
    }
}
