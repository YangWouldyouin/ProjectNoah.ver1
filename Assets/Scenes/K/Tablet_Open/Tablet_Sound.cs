using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablet_Sound : MonoBehaviour
{
    public float TabletSoundRange; // 태블릿 소리 나는 주기
    public float speed;

    /*    public GameObject TabletSoundArea; // 소리 나는 영역
        ObjData TabletSoundArea_Data;*/

    public GameObject Player_Noah; // 노아 플레이어

    AudioSource TabletSoundAudio; // 태블릿 기계 소리

    public GameObject Tablet; // 태블릿
    ObjData Tablet_Data;

    void Start()
    {
        Tablet_Data = Tablet.GetComponent<ObjData>();
        TabletSoundAudio = GetComponent<AudioSource>();

        Invoke("TabletSoundLoop", 30f); // 30초에 한번 호출
    }
    
    void Update()
    {

    }

    public void TabletSoundLoop() // 30초마다 한번 씩 태블릿에서 소리 들리기
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

    public void FollowTablet() // 바라봄
    {
        // smellAreaData.IsNotInteractable = true;

        Vector3 dir = Tablet.transform.position - Player_Noah.transform.position;
        Player_Noah.transform.rotation = Quaternion.Lerp(Player_Noah.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * speed);
    }
}
