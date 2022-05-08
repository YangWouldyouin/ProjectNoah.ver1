using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checking_tabletLoc : MonoBehaviour
{
    private float timer = 0f; // �º� ���� Ÿ�̸�
    public float DestroyTime = 10.0f; // �º��� AI�� �����ϱ���� �ɸ��� �ð�

    public GameObject TabletHideZone_E;
    ObjData TabletHideZone_Data_E;

    public GameObject Tablet_E;
    ObjData TabletData_E;
    public GameObject noahPlayer;
    ObjData noahPlayerData_E;

    public GameObject dialog;
    DialogManager dialogManager;

    void Start()
    {
        dialogManager = dialog.GetComponent<DialogManager>();

        // TabletHideZone_Data_E = TabletHideZone_E.GetComponent<ObjData>();
        TabletData_E = Tablet_E.GetComponent<ObjData>();
        noahPlayerData_E = noahPlayer.GetComponent<ObjData>();
    }

    private void Update()
    {
        GetOutAIZone(); // �º��� AI���İ������� ����°� �ȹ���°�
    }

    public void GetOutAIZone() // AI���İ������� �����
    {
        Vector3 TabletPos = Tablet_E.transform.position; // �º� �ǽð� ��ġ��

        if (TabletPos.x > 1 && TabletPos.x < 10 && TabletPos.z < -8 && TabletPos.z > -16) // Ÿ���� ���� ���� �ȿ� ������
        {
            Debug.Log("Ÿ�̸� ����");
            timer = 0f; // 5�� �ȿ� ���� �������� �ٽ� ���ƿ��� Ÿ�̸Ӹ� �ٽ� 0���� ����
        }
        else // Ÿ���� ���� ���� �ۿ� ������
        {
            timer += Time.deltaTime; // Ÿ�̸� ���� 
            float seconds = Mathf.FloorToInt((timer % 3600) % 60); // �� ���� üũ
            Debug.Log(seconds);
            if (seconds >= DestroyTime) // 5�ʰ� ������
            {
                Debug.Log("Ÿ�� �ı�");
                // AI: �̻� ���İ� �����Ǿ����ϴ�. �ش� ��⸦ ����մϴ�
                dialogManager.StartCoroutine(dialogManager.PrintAIDialog(39));

                Tablet_E.SetActive(false);
                //Destroy(Tablet_E); // Ÿ�� �ı�
                GameManager.gameManager._gameData.IsTabletDestory = true; // �ݺ������� ��������
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "noahPlayer")
        {
            if (!GameManager.gameManager._gameData.IsFirstExitTablet)
            {
                dialogManager.StartCoroutine(dialogManager.PrintAIDialog(40));
                GameManager.gameManager._gameData.IsFirstExitTablet = true;
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            }
            
            if (GameManager.gameManager._gameData.IsFirstExitTablet)
            {
                dialogManager.StartCoroutine(dialogManager.PrintAIDialog(41));
            }
        }
    }

    //public void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.name == "noahPlayer" && tabletData.IsBite)
    //    {
    //        GameManager.gameManager._gameData.IsTabletMoved = false;
    //        Debug.Log("Ÿ�� �ȿ� ����");
    //    }

    //    /*if (other.tag == "chip")
    //     {
    //         if(GameManager.gameManager._gameData.IsHide)
    //         {
    //             Debug.Log("������");
    //         }

    //         else
    //         {
    //             Debug.Log("�� ���� ���Ͻô�????");
    //             //AI�� ����ϴ� ��� ���

    //             GameManager.gameManager._gameData.IsAlert = true;
    //             SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    //         }

    //     }*/
    //}

    //public void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.name == "noahPlayer" && tabletData.IsBite) // && TabletData_E.IsBite
    //    {
    //        GameManager.gameManager._gameData.IsCanConnect_C_MS = true;
    //        Debug.Log("Ÿ�� ����");

    //        if (GameManager.gameManager._gameData.IsAIDown)
    //        {
    //            Debug.Log("Ÿ�� �ű�� �ٳ൵ ������");
    //        }

    //        else
    //        {
    //            Debug.Log("AI�� Ÿ�� �ı�"); // AI�� Ÿ�� �ı���
    //            // Destroy(Tablet_E);
    //            Tablet_E.SetActive(false);

    //            /* ���������������������������������������� P-1��� ���� ���������������������������������������� */
    //        }
    //    }


    /*if (other.gameObject.name == "Tablet_E")
    {
        GameManager.gameManager._gameData.IsCanConnect_C_MS = true;
        Debug.Log("Ÿ�� ����");

        if (GameManager.gameManager._gameData.IsAIDown)
        {
            Debug.Log("Ÿ�� �ű�� �ٳ൵ ������");
        }

        else
        {
            Debug.Log("AI�� Ÿ�� �ı�"); // AI�� Ÿ�� �ı���
            Destroy(Tablet_E);
        }
    }*/
}


