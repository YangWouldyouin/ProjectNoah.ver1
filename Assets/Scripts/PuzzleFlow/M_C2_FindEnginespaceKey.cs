using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_C2_FindEnginespaceKey : MonoBehaviour
{
    /* 이번 플로우차트에서 저장되는 설정들 */
    // 이번 플로우차트를 깨야 설정들이 True로 바뀌면서 풀리는 것이므로, 초기에는 모두 false 값을 넣는다. 
    // 이름 짓기 규칙 : 앞에 Is, Has, Can, Should 중 하나를 붙이고 한 단어의 첫 글자는 대문자로, 마지막에 플로우차트 넘버링 붙이기
    private static bool IsDisappearPack_M_C2 = false; // 퍼즐을 완료하면 팩이 사라진 상태를 유지하게 한다.

//    노아가 땅바닥에서 책상을 눌러본다.책상의 “오르기” 비활성화(이 때 비활성화는 - 이걸로 대체하는게 아니라 “오르기” 버튼이 엄청 연한 색으로 들어갈거야! 현재는 이미지 소스가 없다ㅜ)


//상자를 책상 쪽에 가져와서->상자 클릭해서 “오르기”하면 책상의 “오르기” 활성화


//책상 클릭해서 “오르기” 누르면 책상 위로 올라가진다.
//책상 위로 올라간거 인지하면 책상의 특수 상호작용이 “오르기->관찰하기”로 변경된다.

    /* 이번 플로우차트에서 쓰이는 상호작용 오브젝트 목록 */
    // 움직일 수 있는 오브젝트와 못 움직이는 오브젝트 모두 넣는다.
    // 이름 짓기 규칙 : 오브젝트 이름 + 플로우차트 넘버링
    public GameObject cardPack_M_C2;
    public GameObject desk_M_C2;
    public GameObject box_M_C2;
    public GameObject engineRoomDoor_M_C2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 이 플로우차트는 크게 2 퍼즐로 나눌 수 있다. 

       // nowObject_M_C2_FindEnginespaceKey = PlayerScripts.playerscripts.currentObject;

       
        
            if (IsDisappearPack_M_C2==false) // 팩이 찢어져 카드가 보인다.
            {
                CanSeeCard();

            }

        


    }


    public void CanSeeCard()
    {
        /* 함수 첫 시작에서 앞에서 정했던 이번 플로우차트에서 쓰이는 오브젝트들의 각각의 데이터가 저장되어있는 ObjData 컴포넌트를 모두 불러온다. */
        // 이름 짓기 규칙 : 오브젝트 이름 + Data + 플로우차트 넘버링
        //ObjData consoleLeftData_M_C1 = consoleLeft_M_C1.GetComponent<ObjData>();

        ObjData cardPackData = cardPack_M_C2.GetComponent<ObjData>();

        if (cardPackData.IsDestroy)//파괴하기
        {

            Invoke("Disapppear", 2f);
            //Destroy(cardPack);
            IsDisappearPack_M_C2 = true;
        }
    }

    void Disapppear()
    {
        cardPack_M_C2.SetActive(false);
    }
}