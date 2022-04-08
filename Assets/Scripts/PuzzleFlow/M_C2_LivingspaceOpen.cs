using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_C2_LivingspaceOpen : MonoBehaviour
{
    private GameObject nowObject_M_C2_LivingspaceOpen;

    // public GameObject livingroomDoor; // 생활공간 문
    public GameObject doll;
    public GameObject HalfDoll; // 반쪽짜리 인형
    public GameObject AllDoll; // 완전한 인형

    public static bool OpenLivingroomDoor = false;


    void Start()
    {
    }
    void Update()
    {
        if(OpenLivingroomDoor==false) //문이 완전히 열리지 않는다면
        {
            PullADoll();
        }
        else
        {
            // 문이 열리는 애니메이션
        }


    }

    void PullADoll()
    {
        //오브젝트 데이터 불러오기
        ObjData dollData = doll.GetComponent<ObjData>();
        ObjData HalfDollData = HalfDoll.GetComponent<ObjData>();
        ObjData AllDollData = AllDoll.GetComponent<ObjData>();
        // ObjData livingroomDoorData = livingroomDoor.GetComponent<ObjData>();

        if(dollData.IsBite) // 인형을 물면
        {
            Invoke("SwitchDoll",1.2f);
            // Invoke("HalfDoll",1.3f);
        }
    }

    void SwitchDoll()
    {
        HalfDoll.SetActive(false);
        AllDoll.SetActive(true);
    }

}