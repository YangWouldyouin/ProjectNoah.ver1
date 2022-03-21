using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_C2_FindDrug : MonoBehaviour
{
    private GameObject nowObject_T_C2_FindDrug;

    //�ʿ� ������Ʈ ����, ���༺ �๰, Ư�� �๰, Ĩ, ������, ����, ������ǻ��
    public GameObject drugBag;
    public GameObject drug;
    public GameObject specificDrug;
    //public GameObject drugChip;
    //public GameObject drugBoard;
    public GameObject mainCom;

    //�̻��� ���� ����, �๰ �˻�, �๰ ����, �ص� ��� ã��, �ص�
    public static bool IsSmellDrug = false;
    private static bool IsCheckDrug = false;
    public static bool IsReportDrug = false;
    public static bool IsDetox = false;

    // Start is called before the first frame update
    void Start()
    {
        //5�п� �� ���� 60% Ȯ���� 10�� ���� '�̻��� ����' ���� �� ����
        //��, �������� å�� ���� 3ĭ �̳��� ��ġ�ؾ� ������ �� ����
    }

    // Update is called once per frame
    void Update()
    {
        nowObject_T_C2_FindDrug = PlayerScripts.playerscripts.currentObject;

        if (nowObject_T_C2_FindDrug != null)
        {
            if (IsDetox)
            {
                Invoke("noDrug", 2f);
            }

            else
            {
                researchDrug();
            }
        }

        //���� ���� ���� ������ ���� ã�� ���� ����


        //�๰ ȹ�� ��, '����' �ִϸ��̼�
        //�๰ ���� �Ŀ� �����ϸ� ���� �м� ����
        //�ʷϺ� �߸� ����� ���õ� �̾߱Ⱑ ȭ�鿡 ����

        //�������� ������ ���
        //���� ��ǻ�Ϳ��� Ĩ ��������

        //�������� �������� ���� ���
        //�������� ���� ��, �ش� �๰�� ȭ�н��� �ִ� �����尡 ����
        //Ư�� �๰�� ������ �ص��� > �ٸ� �����ϴ� �๰�� �־����� �ص��� ��� o
        //��, �� Ư�� �๰�� �������� ���� �Ұ�, �İ����� ���� > ������ ����
        //�̿ϼ� �๰ ��, �ش� Ư�� �๰ �İ����� ã�� = �� �๰ �տ� ���� �����ñ� ����� �����ϰ� ������ ���� ���� Ư�� �๰ ã��
        //Ư�� �๰�� ���༺ �๰�� �๰������迡 �ְ� �ص���Ŵ

        //Ŭ���� ����
        //���� ��� Ĩ�� ������ ���� ��ǻ�ͷ� ���� (�ӹ� ���ø�Ʈ ����)
        //�๰������迡 ���༺ �๰�� Ư�� �๰ �ְ� ������ �ص�
    }

    /* public void findDrug()
    {
        ObjData drugBagData = drugBag.GetComponent<ObjData>();
        ObjData drugData = drug.GetComponent<ObjData>();

        if (drugBagData.IsBite)
        {
            Invoke("NoBag" , 0f);
        }
    }
    */

    public void researchDrug()
    {
        ObjData drugBagData = drugBag.GetComponent<ObjData>();
        ObjData drugData = drug.GetComponent<ObjData>();
        ObjData specificDrugData = specificDrug.GetComponent<ObjData>();

        ObjData mainComData = mainCom.GetComponent<ObjData>();

        if (drugBagData.IsBite) //���� �߰� �� ����
        {
            Invoke("noBag", 2f);
        }

        /*if (mainComData.IsObserve)
        {
            CameraController.cameraController.currentView = mainComData.ObserveView;
        }
        */

        if (drugData.IsBite && mainComData.IsPushOrPress) //���� üũ
        {
            //�����̶�� ��ũ��Ʈ ���
            //��� ���� ������ �� �ִٴ� �ȳ� �ʿ�
            IsCheckDrug = true;
        }

        if (specificDrugData.IsBite && mainComData.IsPushOrPress) //���� �ص�
        {
            //�ص��Ǿ��ٴ� ��ũ��Ʈ ���
            //�ص� �ȳ� �ʿ�
            IsDetox = true;
        }    
    }

    void noBag() //������ ������� ������ ���̵��� �Ѵ�
    {
        drugBag.SetActive(false);
        drug.SetActive(true);
    }

    void noDrug() //����� Ư���๰ ������� �ϱ�
    {
        drug.SetActive(false);
        specificDrug.SetActive(false);
    }
}
