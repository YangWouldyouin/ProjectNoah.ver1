using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_C3_TabletOpen : MonoBehaviour
{
    // ������Ʈ
    public GameObject Tablet_TO; // �º�
    public GameObject FullEgPad_TO; // ���� �� �����е�
    //public GameObject ZeroEgPad_TO; // ���� �� �� �����е�
    public GameObject Boxes_TO; // ���ڵ�

    // ������Ʈ ������
    ObjData TabletData_TO; // �º�
    ObjData FullEgPadData_TO; // ���� �� �����е�
    //ObjData ZeroEgPadData_TO; // ���� �� �� �����е�
    ObjData BoxesData_TO; // ���ڵ�


    private float timer = 0f; // �º� ���� Ÿ�̸�
    public float DestroyTime = 5.0f; // �º��� AI�� �����ϱ���� �ɸ��� �ð�
    private float Charge;

    public static bool IsTabletDestroyed = false; // �º� AI���� ���� �������°�

    public static bool NoBoxes = false; // ���� ���ʶ߷� ���ֱ�
    public static bool UseTablet = false; // �º� ���� �ر�

    public Animator BoxDestroyAnimation; // �ڽ� �������� �ִϸ��̼�

    private bool OpenTablet = false; // �º� ���ȭ�� �ر� ����
    private bool FullEgTablet = false; //�º� ���� ����
    private bool NoAIZone = false; // AI ���� ���� ���� �ش� ����

    void Update()
    {
        GetOutAIZone(); // �º��� AI���İ������� ����°� �ȹ���°�

        if (!IsTabletDestroyed) // �º��� AI���İ������� ��� �ı����� �ʾ��� ��,
        {
            if (BoxesData_TO.IsPushOrPress) // �ڽ� ������Ʈ '������' ���� ��
            {
                Invoke("DestroyBoxAnim", 1f); // 1�� �� �ڽ� �������� �ִϸ��̼� ����
                Invoke("DestroyBox", 2f); // 2�� �� �ڽ� ������Ʈ ��Ȱ��ȭ
                NoBoxes = true;

                if (FullEgPadData_TO.IsBite) // ������ �����е带 ������ ��,
                {
                    Charge = Vector3.Distance(Tablet_TO.transform.position, FullEgPad_TO.transform.position);

                    if (Charge <= 1f) // �º��� ����O�е� ���̰� 1f ���� �� ��
                    {
                        FullEgTablet = true; // �º� ���� ��

                        if (TabletData_TO.IsObserve) // �º� �����ϱ�
                        {
                            //if UIȭ�� Ȯ��信�� �˸��� ��й�ȣ�� Ŭ������ ��
                            {
                                OpenTablet = true;
                            }
                        }

                    }
                }
                else // �º� ���� ������ ��
                {
                    FullEgTablet = false;
                    OpenTablet = false;
                }
            }
        }
    }



    void DestroyBoxAnim() // �ڽ� �������� �ִϸ��̼�
    {
        BoxDestroyAnimation.SetBool("Destroy", true);
    }
    void DestroyBox() // �ڽ� ������Ʈ ��Ȱ��ȭ
    {
        Boxes_TO.SetActive(false);
    }


    public void GetOutAIZone() // AI���İ������� �����
    {
        Vector3 TabletPos = Tablet_TO.transform.position; // �º� �ǽð� ��ġ��

        if (TabletPos.x > 3 && TabletPos.x < 8 && TabletPos.z < -10 && TabletPos.z > -14) // Ÿ���� ���� ���� �ȿ� ������
        {
            timer = 0f; // 5�� �ȿ� ���� �������� �ٽ� ���ƿ��� Ÿ�̸Ӹ� �ٽ� 0���� ����
        }
        else // Ÿ���� ���� ���� �ۿ� ������
        {
            timer += Time.deltaTime; // Ÿ�̸� ���� 
            float seconds = Mathf.FloorToInt((timer % 3600) % 60); // �� ���� üũ
            if (seconds >= DestroyTime) // 5�ʰ� ������
            {
                // AI: �̻� ���İ� �����Ǿ����ϴ�. �ش� ��⸦ ����մϴ�
                Destroy(Tablet_TO); // Ÿ�� �ı�
                IsTabletDestroyed = true; // �ݺ������� ��������
            }
        }
    }

}
