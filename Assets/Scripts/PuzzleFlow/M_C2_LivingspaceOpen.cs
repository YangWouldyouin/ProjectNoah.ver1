using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_C2_LivingspaceOpen : MonoBehaviour
{
    private GameObject nowObject_M_C2_LivingspaceOpen;

    // public GameObject livingroomDoor; // 생활공간 문
    public GameObject doll_LSO;
    public GameObject HalfDoll_LSO; // 반쪽짜리 인형
    public GameObject AllDoll_LSO; // 완전한 인형

    ObjData dollData_LSO;
    ObjData HalfDollData_LSO;
    ObjData AllDollData_LSO;

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
        if(dollData_LSO.IsBite) // 인형을 물면
        {
            Invoke("SwitchDoll",1.2f); // 완전한 인형으로 바뀜
            // Invoke("HalfDoll",1.3f);
            GameManager.gameManager._gameData.IsWLDoorOpened_M_C2 = true; // 항상 업무공간에서 생활공간 이동 가능
        }
    }

    void SwitchDoll()
    {
        HalfDoll_LSO.SetActive(false);
        AllDoll_LSO.SetActive(true);
    }

}