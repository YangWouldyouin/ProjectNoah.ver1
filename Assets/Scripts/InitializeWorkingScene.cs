using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeWorkingScene : MonoBehaviour
{
    public Animator controlWorkDoorAnim;
    public GameObject ChangeScene;

    public GameObject DoIronPlateDoor; // 스마트팜 합판 


    // Start is called before the first frame update
    void Start()
    {
        GameData intialGameData = SaveSystem.Load("save_001");

        /*스마트팜 오픈 퍼즐을 완료 하면*/
        if(intialGameData.IsCompleteSmartFarmOpen)
        {
            //스마트팜 위치 고정
            DoIronPlateDoor.GetComponent<Rigidbody>().isKinematic = false;
            DoIronPlateDoor.transform.parent = null;

            DoIronPlateDoor.transform.position = new Vector3(-258.15f, 0.2092f, 670.1605f); //위치 고정
            DoIronPlateDoor.transform.rotation = Quaternion.Euler(7.034f, 90, 90); //각도 고정
            DoIronPlateDoor.transform.localScale = new Vector3(-2.882732f, -115.34f, -93.69196f); // 크기 고정


        }
    }

}
