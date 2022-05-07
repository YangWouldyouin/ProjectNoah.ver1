using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checking_tabletLoc : MonoBehaviour
{
    public GameObject TabletHideZone_E;
    ObjData TabletHideZone_Data_E;

    public GameObject Tablet_E;
    ObjData TabletData_E;

    public GameObject noahPlayer;
    ObjData noahPlayerData_E;

    void Start()
    {
        // TabletHideZone_Data_E = TabletHideZone_E.GetComponent<ObjData>();
        TabletData_E = Tablet_E.GetComponent<ObjData>();
        noahPlayerData_E = noahPlayer.GetComponent<ObjData>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "noahPlayer" && TabletData_E.IsBite)
        {
            GameManager.gameManager._gameData.IsTabletMoved = false;
            Debug.Log("Ÿ�� �ȿ� ����");
        }

        /*if (other.tag == "chip")
         {
             if(GameManager.gameManager._gameData.IsHide)
             {
                 Debug.Log("������");
             }

             else
             {
                 Debug.Log("�� ���� ���Ͻô�????");
                 //AI�� ����ϴ� ��� ���

                 GameManager.gameManager._gameData.IsAlert = true;
                 SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
             }

         }*/
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "noahPlayer" && TabletData_E.IsBite) // && TabletData_E.IsBite
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
                // Destroy(Tablet_E);
                Tablet_E.SetActive(false);

                /* ���������������������������������������� P-1��� ���� ���������������������������������������� */
            }
        }


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

}
