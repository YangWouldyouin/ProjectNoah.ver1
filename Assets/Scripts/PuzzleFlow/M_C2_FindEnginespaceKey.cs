using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_C2_FindEnginespaceKey : MonoBehaviour
{
    private GameObject nowObject_M_C2_FindEnginespaceKey;

    private static bool IsDisappearPack_M_C2 = false; // 퍼즐을 완료하면 팩이 사라진 상태를 유지하게 한다.

    public GameObject cardPack_M_C2;
    public GameObject EngineKey_M_C2;
    public GameObject UpTable1_M_C2;
    public GameObject UpBox_M_C2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        ObjData UpTable1Data = UpTable1_M_C2.GetComponent<ObjData>();



        //--------------------------------------------------------------------------------------- 

        //nowObject_M_C2_FindEnginespaceKey = PlayerScripts.playerscripts.currentObject;

        if (IsDisappearPack_M_C2 == false) // 팩이 찢어져 카드가 보인다.
        {
            CanSeeCard();

        }


        //--------------------------------------------------------------------------------------- 책상위로 올라가기

        //순서: 기본 - 책상 오르기 비활성화->노아의 높이, 거리값 맞으면 책상 오르기 활성화(UpUp코드 참고)-> 책상 위로 올라갔으면 오르기에서 관찰하기로 상호작용 교체 ->관찰하기 누르면 카메라 뷰 전환



        if (UpTable1Data.IsCollision == true) // IsCollision이 켜지면 책상과 노아가 충돌했다는 뜻이다.
        {
            UpTable1Data.IsCenterButtonDisabled = false; // 책상과 노아가 충돌하면 책상의 가운데 특수 상호작용 버튼을 비활성화->오르기로 바꿔주겠다는 것이다. (기본적으로 비활성화 상태라면 인스펙터의 IsCenterButtonDisabled에 체크를 해두자)

        }
        else // IsCenterButtonDisabled => 센터 버튼 비활성화가 트루이면 다시 비활성화 상태로 돌리겠다는 것이다. //책상에서 내려왔을 때 상자 위가 아님을 알면 다시 '오르기'를 비활성화로 바꾸기 위해 넣는 코드
        {
            UpTable1Data.IsCenterButtonDisabled = true;
        }

        //--------------------------

        if (UpTable1Data.IsUpDown) //가운데 버튼이 오르기 비활성화->활성화로 바뀐 상태라면 가운데버튼을 '관찰하기'로 바꾸는 걸 트루로 하겠다.
        {
            UpTable1Data.IsCenterButtonChanged = true;
        }
        else
        {
            UpTable1Data.IsCenterButtonChanged = false;
        }

        //--------------------------

        if (UpTable1Data.IsObserve) // 책상에서 '관찰하기'를 사용한게 트루이면 관찰하기 뷰를 실행하겠다.
        {
            CameraController.cameraController.currentView = UpTable1Data.ObserveView;
        }
    }


    //--------------------------------------------------------------------------------------- 보관팩  파괴하기
    public void CanSeeCard()
    {
        ObjData cardPackData = cardPack_M_C2.GetComponent<ObjData>();
        ObjData EngineKeyData = EngineKey_M_C2.GetComponent<ObjData>();


        if (cardPackData.IsSmash)//파괴하기
        {
            EngineKeyData.GetComponent<Rigidbody>().isKinematic = false; // 모계에서 벗어나게 한다.
            EngineKeyData.transform.parent = null;
            Invoke("Disapppear", 3f);
            //Destroy(cardPack);
            IsDisappearPack_M_C2 = true;
        }


    }


    void Disapppear()
    {
        cardPack_M_C2.SetActive(false);
        EngineKey_M_C2.SetActive(true);
    }



}