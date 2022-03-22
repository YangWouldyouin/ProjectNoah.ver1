using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_C3_SmellEngineRepair : MonoBehaviour
{
    private GameObject nowObject_T_C3_SmellEngineRepair;

    public static bool IsFuelabsorberDone = false;

    public GameObject Fuelabsorber_Body;
    public GameObject Fuelabsorber_fixPart;
    public GameObject Fuelabsorber;

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
            if (IsFuelabsorberDone)
            {
                Invoke("FuelabsorberDone", 1.5f);
            }
            else
            {
                Fuelabsorber_fixPart_Putting();
            }
        }
    }

    public void Fuelabsorber_fixPart_Putting()
    {
        ObjData Fuelabsorber_BodyData = Fuelabsorber_Body.GetComponent<ObjData>();
        ObjData Fuelabsorber_fixPartData = Fuelabsorber_fixPart.GetComponent<ObjData>();
        if (Fuelabsorber_BodyData.IsPushOrPress && Fuelabsorber_fixPartData.IsBite)
        {
            IsFuelabsorberDone = true;
        }
    }

    public void FuelabsorberDone()
    {
        ObjData Fuelabsorber_BodyData = Fuelabsorber_Body.GetComponent<ObjData>();
        ObjData Fuelabsorber_fixPartData = Fuelabsorber_fixPart.GetComponent<ObjData>();
        ObjData FuelabsorberData = Fuelabsorber.GetComponent<ObjData>();

        //물고 있는 fitPart 물기 해제 -> bool false
        Fuelabsorber_fixPartData.IsBite = false;

        Fuelabsorber_fixPartData.GetComponent<Rigidbody>().isKinematic = false;
        Fuelabsorber_fixPartData.transform.parent = null;

        //fitPart 위치 HM에 자동 장착
        Fuelabsorber_fixPartData.transform.position = new Vector3(-1.82f, 0.509f, 0.25f);
        Fuelabsorber_fixPartData.transform.rotation = Quaternion.Euler(0, 90, 90);

        //한 번 물기 하면 더이상 fitPart 상호작용 불가 오브젝트로 변경 -> interaction 스크립트 끄기
        Fuelabsorber_fixPartData.IsNotInteractable = true;
        Fuelabsorber_BodyData.IsNotInteractable = true;
        FuelabsorberData.IsNotInteractable = false;

        //오브젝트 끄기
        Fuelabsorber.SetActive(true);
        Fuelabsorber_fixPart.SetActive(false);
        Fuelabsorber_Body.SetActive(false);
    }
}
