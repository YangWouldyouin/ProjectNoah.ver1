using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_C2_FindEnginespaceKey : MonoBehaviour
{
    /* �̹� �÷ο���Ʈ���� ����Ǵ� ������ */
    // �̹� �÷ο���Ʈ�� ���� �������� True�� �ٲ�鼭 Ǯ���� ���̹Ƿ�, �ʱ⿡�� ��� false ���� �ִ´�. 
    // �̸� ���� ��Ģ : �տ� Is, Has, Can, Should �� �ϳ��� ���̰� �� �ܾ��� ù ���ڴ� �빮�ڷ�, �������� �÷ο���Ʈ �ѹ��� ���̱�
    private static bool IsDisappearPack_M_C2 = false; // ������ �Ϸ��ϸ� ���� ����� ���¸� �����ϰ� �Ѵ�.

//    ��ư� ���ٴڿ��� å���� ��������.å���� �������⡱ ��Ȱ��ȭ(�� �� ��Ȱ��ȭ�� - �̰ɷ� ��ü�ϴ°� �ƴ϶� �������⡱ ��ư�� ��û ���� ������ ���ž�! ����� �̹��� �ҽ��� ���٤�)


//���ڸ� å�� �ʿ� �����ͼ�->���� Ŭ���ؼ� �������⡱�ϸ� å���� �������⡱ Ȱ��ȭ


//å�� Ŭ���ؼ� �������⡱ ������ å�� ���� �ö�����.
//å�� ���� �ö󰣰� �����ϸ� å���� Ư�� ��ȣ�ۿ��� ��������->�����ϱ⡱�� ����ȴ�.

    /* �̹� �÷ο���Ʈ���� ���̴� ��ȣ�ۿ� ������Ʈ ��� */
    // ������ �� �ִ� ������Ʈ�� �� �����̴� ������Ʈ ��� �ִ´�.
    // �̸� ���� ��Ģ : ������Ʈ �̸� + �÷ο���Ʈ �ѹ���
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
        // �� �÷ο���Ʈ�� ũ�� 2 ����� ���� �� �ִ�. 

       // nowObject_M_C2_FindEnginespaceKey = PlayerScripts.playerscripts.currentObject;

       
        
            if (IsDisappearPack_M_C2==false) // ���� ������ ī�尡 ���δ�.
            {
                CanSeeCard();

            }

        


    }


    public void CanSeeCard()
    {
        /* �Լ� ù ���ۿ��� �տ��� ���ߴ� �̹� �÷ο���Ʈ���� ���̴� ������Ʈ���� ������ �����Ͱ� ����Ǿ��ִ� ObjData ������Ʈ�� ��� �ҷ��´�. */
        // �̸� ���� ��Ģ : ������Ʈ �̸� + Data + �÷ο���Ʈ �ѹ���
        //ObjData consoleLeftData_M_C1 = consoleLeft_M_C1.GetComponent<ObjData>();

        ObjData cardPackData = cardPack_M_C2.GetComponent<ObjData>();

        if (cardPackData.IsDestroy)//�ı��ϱ�
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