using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablet_Sound : MonoBehaviour
{
    // public float TabletSoundRange = 30f; // �º� �Ҹ� ���� �ֱ� = 30��
    public float speed; // ��ư� ���ƺ��� �ӵ�

    public GameObject TabletSoundArea; // �Ҹ� ���� �� �ִ� ����
    ObjData TabletSoundArea_Data;

    public GameObject Player_Noah; // ��� �÷��̾�

    public GameObject Tablet; // �º�
    ObjData Tablet_Data;

    public bool IsTabletSoundListen = false; // �º� �Ҹ��� ����°�?

    void Start()
    {
        Tablet_Data = Tablet.GetComponent<ObjData>();
    }

    void Update()
    {
    }

    public void TabletSoundLoop() // �º����� �Ҹ� �鸮��
    {
        IsTabletSoundListen = true;
        Debug.Log("�̻��� �Ҹ�");
    }

    public void OnTriggerEnter(Collider other)
    {
        if(GameManager.gameManager._gameData.IsNoBoxes == false)
        {
            TabletSoundArea.SetActive(true);

            if (other.gameObject == Player_Noah)
            {
                Debug.Log("�º� �Ҹ� ���� ����");
                TabletSoundLoop();
                // TabletSoundArea.SetActive(true);
            }
        }
        else
        {
            TabletSoundArea.SetActive(false);
            Debug.Log("���ھ���");
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject == Player_Noah && IsTabletSoundListen == true)
        {
            Invoke("FollowTablet", 2f);
            Debug.Log("�º� �Ҹ� ����");
            // ����â�� "[�Ҹ�] �̻��� �����" ����
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player_Noah)
        {
            CancelInvoke("FollowTablet");

            // TabletSoundArea.SetActive(false);
            Debug.Log("�º� �Ҹ� ���� ����");
        }
    }

    public void FollowTablet() // ��ư� �º� ���� �ٶ�
    {
        // TabletSoundArea_Data.IsNotInteractable = true;

        Vector3 dir = Tablet.transform.position - Player_Noah.transform.position;
        Player_Noah.transform.rotation = Quaternion.Lerp(Player_Noah.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * speed);
    }
}
