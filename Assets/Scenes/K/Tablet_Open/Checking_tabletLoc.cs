using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checking_tabletLoc : MonoBehaviour
{

    public GameObject tablet;


    public void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.name == "Tablet")
        {
            GameManager.gameManager._gameData.IsTabletMoved = false;
            Debug.Log("Ÿ�� ���ƿ�");
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
        if (other.gameObject.name == "Tablet")
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
                Destroy(tablet);
            }
        }
    }

}
