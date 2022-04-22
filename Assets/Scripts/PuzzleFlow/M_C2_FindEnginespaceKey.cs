using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_C2_FindEnginespaceKey : MonoBehaviour
{
    private GameObject nowObject_M_C2_FindEnginespaceKey;

    private static bool IsDisappearPack_M_C2 = false; // ������ �Ϸ��ϸ� ���� ����� ���¸� �����ϰ� �Ѵ�.

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

        if (IsDisappearPack_M_C2 == false) // ���� ������ ī�尡 ���δ�.
        {
            CanSeeCard();

        }


        //--------------------------------------------------------------------------------------- å������ �ö󰡱�

        //����: �⺻ - å�� ������ ��Ȱ��ȭ->����� ����, �Ÿ��� ������ å�� ������ Ȱ��ȭ(UpUp�ڵ� ����)-> å�� ���� �ö����� �����⿡�� �����ϱ�� ��ȣ�ۿ� ��ü ->�����ϱ� ������ ī�޶� �� ��ȯ



        if (UpTable1Data.IsCollision == true) // IsCollision�� ������ å��� ��ư� �浹�ߴٴ� ���̴�.
        {
            UpTable1Data.IsCenterButtonDisabled = false; // å��� ��ư� �浹�ϸ� å���� ��� Ư�� ��ȣ�ۿ� ��ư�� ��Ȱ��ȭ->������� �ٲ��ְڴٴ� ���̴�. (�⺻������ ��Ȱ��ȭ ���¶�� �ν������� IsCenterButtonDisabled�� üũ�� �ص���)

        }
        else // IsCenterButtonDisabled => ���� ��ư ��Ȱ��ȭ�� Ʈ���̸� �ٽ� ��Ȱ��ȭ ���·� �����ڴٴ� ���̴�. //å�󿡼� �������� �� ���� ���� �ƴ��� �˸� �ٽ� '������'�� ��Ȱ��ȭ�� �ٲٱ� ���� �ִ� �ڵ�
        {
            UpTable1Data.IsCenterButtonDisabled = true;
        }

        //--------------------------

        if (UpTable1Data.IsUpDown) //��� ��ư�� ������ ��Ȱ��ȭ->Ȱ��ȭ�� �ٲ� ���¶�� �����ư�� '�����ϱ�'�� �ٲٴ� �� Ʈ��� �ϰڴ�.
        {
            UpTable1Data.IsCenterButtonChanged = true;
        }
        else
        {
            UpTable1Data.IsCenterButtonChanged = false;
        }

        //--------------------------

        if (UpTable1Data.IsObserve) // å�󿡼� '�����ϱ�'�� ����Ѱ� Ʈ���̸� �����ϱ� �並 �����ϰڴ�.
        {
            CameraController.cameraController.currentView = UpTable1Data.ObserveView;
        }
    }


    //--------------------------------------------------------------------------------------- ������  �ı��ϱ�
    public void CanSeeCard()
    {
        ObjData cardPackData = cardPack_M_C2.GetComponent<ObjData>();
        ObjData EngineKeyData = EngineKey_M_C2.GetComponent<ObjData>();


        if (cardPackData.IsSmash)//�ı��ϱ�
        {
            EngineKeyData.GetComponent<Rigidbody>().isKinematic = false; // ��迡�� ����� �Ѵ�.
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