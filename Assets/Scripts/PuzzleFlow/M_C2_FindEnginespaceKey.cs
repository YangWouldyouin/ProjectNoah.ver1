using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_C2_FindEnginespaceKey : MonoBehaviour
{
    private GameObject nowObject_M_C2_FindEnginespaceKey;

    private static bool IsDisappearPack = false; // 퍼즐을 완료하면 팩이 사라진 상태를 유지하게 한다.

    public GameObject cardPack;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        nowObject_M_C2_FindEnginespaceKey = PlayerScripts.playerscripts.currentObject;

        if (nowObject_M_C2_FindEnginespaceKey != null)
        {
            if (IsDisappearPack==false) // 팩이 찢어져 카드가 보인다.
            {
                CanSeeCard();

            }

        }


    }


    public void CanSeeCard()
    {
        ObjData cardPackData = cardPack.GetComponent<ObjData>();

        if (cardPackData.IsDestroy)//파괴하기
        {

            Invoke("Disapppear", 2f);
            //Destroy(cardPack);
            IsDisappearPack = true;
        }
    }
    void Disapppear()
    {
        cardPack.SetActive(false);
    }
}