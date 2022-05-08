using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeWorkingScene : MonoBehaviour
{
    public Animator controlWorkDoorAnim;
    public GameObject ChangeScene;

    public GameObject DoIronPlateDoor; // ����Ʈ�� ���� 


    // Start is called before the first frame update
    void Start()
    {
        GameData intialGameData = SaveSystem.Load("save_001");

        /*����Ʈ�� ���� ������ �Ϸ� �ϸ�*/
        if(intialGameData.IsCompleteSmartFarmOpen)
        {
            //����Ʈ�� ��ġ ����
            DoIronPlateDoor.GetComponent<Rigidbody>().isKinematic = false;
            DoIronPlateDoor.transform.parent = null;

            DoIronPlateDoor.transform.position = new Vector3(-258.15f, 0.2092f, 670.1605f); //��ġ ����
            DoIronPlateDoor.transform.rotation = Quaternion.Euler(7.034f, 90, 90); //���� ����
            DoIronPlateDoor.transform.localScale = new Vector3(-2.882732f, -115.34f, -93.69196f); // ũ�� ����


        }
    }

}
