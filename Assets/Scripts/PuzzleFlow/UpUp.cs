using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpUp : MonoBehaviour
{
    //해당 스크립트는 M_C2_FindEnginespaceKey파일에서 업무공간 책상과 노아와의 충돌 오브젝트를 관리하는 코드이다.
    // 높은 곳에 올라갈 때 이용할 수 있는 코드이다.
    // 해당 코드를 올라가고 싶은 오브젝트에 별도로 넣고, 노아가 올라가고 싶은 높은 오브젝트에 부딪히면 -> 그곳 부딪힌 것을 인지한다.

    public GameObject Table; // 코드에서 올라가고 싶은 물체가 누구인지 인지시켜줘야 된다. 유니티 인스펙터에서 올라가고 싶은 오브젝트를 이 안에 넣으면 된다.

    private void OnTriggerEnter(Collider other) //노아와 콜라이더 Other(올라가고 싶은 오브젝트)과의 충돌감지 영역이다.
    {
        ObjData TableData = Table.GetComponent<ObjData>();  // 올라가고 싶은(책상)의 ObjData를 가져온다.

        

        if (other.gameObject.tag == "Player") // 노아가 누구인지는 태그로 인지하겠다는 코드이다.
        {
            TableData.IsCollision = true; //노아와 책상이 부딪힌걸 인지하면 책상의 ObjData의 IsCollision에 체크를 해주겠다는 코드이다.
            Debug.Log("나는 부딪혔어"); // 확인용 디버그
        }
            


    }

    private void OnTriggerExit(Collider other)
    {
        ObjData TableData = Table.GetComponent<ObjData>();  // 책상의 ObjData를 가져온다.

       

        if (other.gameObject.tag == "Player") // 노아가 누구인지는 태그로 인지하겠다는 코드이다.
        {
            TableData.IsCollision = false; //높이가 안되어 노아와 책상이 부딪힌걸 인지하지 못하게 되면 책상의 ObjData의 IsCollision에 체크를 해제해주겠다는 것이다. 
            Debug.Log("나는 안 부딪혀"); // 확인용 디버그
        }
            
    }
}
