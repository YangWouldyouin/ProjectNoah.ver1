using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablet_Sound : MonoBehaviour
{
    public float TabletSoundRange; // �º� �Ҹ� ���� �ֱ�
    public float speed;

    /*    public GameObject TabletSoundArea; // �Ҹ� ���� ����
        ObjData TabletSoundArea_Data;*/

    public GameObject Player_Noah; // ��� �÷��̾�

    AudioSource TabletSoundAudio; // �º� ��� �Ҹ�

    public GameObject Tablet; // �º�
    ObjData Tablet_Data;

    void Start()
    {
        Tablet_Data = Tablet.GetComponent<ObjData>();
        TabletSoundAudio = GetComponent<AudioSource>();

        Invoke("TabletSoundLoop", 30f); // 30�ʿ� �ѹ� ȣ��
    }
    
    void Update()
    {

    }

    public void TabletSoundLoop() // 30�ʸ��� �ѹ� �� �º����� �Ҹ� �鸮��
    {
        print("TabletSoundLoop!");
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player_Noah)
        {
            if (smellRange <= 1)
            {
                smellArea.SetActive(true);
            }
        }
    }

    public void FollowTablet() // �ٶ�
    {
        // smellAreaData.IsNotInteractable = true;

        Vector3 dir = Tablet.transform.position - Player_Noah.transform.position;
        Player_Noah.transform.rotation = Quaternion.Lerp(Player_Noah.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * speed);
    }
}
