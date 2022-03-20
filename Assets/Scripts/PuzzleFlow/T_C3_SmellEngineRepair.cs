using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_C3_SmellEngineRepair : MonoBehaviour
{
    private GameObject nowObject_T_C3_SmellEngineRepair;

    public static bool IsFueltankDone = false;

    public GameObject Fueltank;
    public GameObject Fueltank_fixPart;

    // Start is called before the first frame update
    void Start()
    {
        //AI: 상태 체크 기계 연결이 되어 있지 않았다 스크립트
    }

    // Update is called once per frame
    void Update()
    {
        nowObject_T_C3_SmellEngineRepair = PlayerScripts.playerscripts.currentObject;

        if (nowObject_T_C3_SmellEngineRepair != null)
        {
            if (IsFueltankDone)
            {
                Invoke("FueltankDone", 1.5f);
            }
            else
            {
                Fueltank_fixPart_Putting();
            }
        }
    }

    public void Fueltank_fixPart_Putting()
    {
        ObjData FueltankData = Fueltank.GetComponent<ObjData>();
        ObjData Fueltank_fixPartData = Fueltank_fixPart.GetComponent<ObjData>();
        if (FueltankData.IsPushOrPress && Fueltank_fixPartData.IsBite)
        {
            IsFueltankDone = true;
        }
    }

    public void FueltankDone()
    {
        ObjData FueltankData = Fueltank.GetComponent<ObjData>();
        ObjData Fueltank_fixPartData = Fueltank_fixPart.GetComponent<ObjData>();


        //물고 있는 fitPart 물기 해제 -> bool false
        Fueltank_fixPartData.IsBite = false;

        Fueltank_fixPartData.GetComponent<Rigidbody>().isKinematic = false;
        Fueltank_fixPartData.transform.parent = null;

        //fitPart 위치 HM에 자동 장착
        Fueltank_fixPartData.transform.position = new Vector3(0f, 0f, 0f);
        Fueltank_fixPartData.transform.rotation = Quaternion.Euler(0, 0, 0);

        //한 번 물기 하면 더이상 fitPart 상호작용 불가 오브젝트로 변경 -> interaction 스크립트 끄기
        //gameObject.GetComponent<Interactable>().enabled = false;

        //HM 가운데 버튼 오르기 버튼으로 변경->업데이트
        FueltankData.IsCenterButtonDisabled = false;
        //HealthMachineData.IsCenterButtonChanged = true;
    }
}
