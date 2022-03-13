using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_C2_FindEnginespaceKey : MonoBehaviour
{
    private GameObject nowObject_M_C2_FindEnginespaceKey;

    private static bool IsDisappearPack = false; // ������ �Ϸ��ϸ� ���� ����� ���¸� �����ϰ� �Ѵ�.

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
            if (IsDisappearPack==false) // ���� ������ ī�尡 ���δ�.
            {
                CanSeeCard();

            }

        }


    }


    public void CanSeeCard()
    {
        ObjData cardPackData = cardPack.GetComponent<ObjData>();

        if (cardPackData.IsDestroy)//�ı��ϱ�
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